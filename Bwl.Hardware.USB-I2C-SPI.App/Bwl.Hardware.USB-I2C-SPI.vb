Imports System.IO
Imports System.IO.Ports
Imports System.Threading
Imports Bwl.Framework

Public Class Form1
    Inherits FormAppBase

    Private adp = Nothing

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        File.Delete("spi_log.txt")
        Dim ports As String() = SerialPort.GetPortNames()
        textSpiCycleCount.Text = "10"
        textSpiCycleDelay.Text = "1000"
        textSpiDelayCmd.Text = "100"

        For Each p As String In ports
            port_list.Items.Add(p)
        Next
        _logger.AddMessage("Готов к работе")
    End Sub

    Private Sub bRdReg_Click(sender As Object, e As EventArgs) Handles bRdReg.Click
        If adp Is Nothing Then
            _logger.AddMessage("Установите подключение к адаптеру!")
            Return
        End If
        Dim addr As Byte = Convert.ToByte(dev_addr.Text, 16)
        Dim reg_addr As Byte = Convert.ToByte(rd_reg_addr.Text, 16)
        Dim resp As Byte = adp.ReadRegister(addr, reg_addr)
        incom_data.Text = incom_data.Text + "val of 0x" + BitConverter.ToString(New Byte() {reg_addr}) + ": 0x" + BitConverter.ToString(New Byte() {resp}) + Environment.NewLine
        incom_data.SelectionStart = incom_data.Text.Length
        incom_data.ScrollToCaret()

    End Sub

    Private Sub bOpen_Click(sender As Object, e As EventArgs) Handles bOpen.Click
        If bOpen.Text.Equals("open") Then
            adp = New Adapter(port_list.SelectedItem.ToString())
            bOpen.Text = "close"
            _logger.AddMessage(adp.GetDeviceInfo())
        ElseIf bOpen.Text.Equals("close") Then
            adp = Nothing
            bOpen.Text = "open"
            _logger.AddMessage("COM порт закрыт")
        End If
        bOpen.Refresh()
    End Sub

    Private Sub write_reg_Click(sender As Object, e As EventArgs) Handles write_reg.Click
        If adp Is Nothing Then
            _logger.AddMessage("Установите подключение к адаптеру!")
            Return
        End If
        Dim rg_addr As Byte = Convert.ToByte(wr_reg_addr.Text, 16)
        Dim rg_value As Byte = Convert.ToByte(reg_val.Text, 16)
        Dim addr As Byte = Convert.ToByte(dev_addr.Text, 16)
        adp.WriteRegister(addr, rg_addr, rg_value)
        _logger.AddMessage("В регистр " + wr_reg_addr.Text + " записано " + reg_val.Text)
    End Sub

    Private Sub bRdSomeReg_Click(sender As Object, e As EventArgs) Handles bRdSomeReg.Click
        If adp Is Nothing Then
            _logger.AddMessage("Установите подключение к адаптеру!")
            Return
        End If
        Dim rg_addr As Byte = Convert.ToByte(rd_some_reg_addr.Text, 16)
        Dim count As Byte = Convert.ToByte(rd_cnt.Text, 16)
        Dim addr As Byte = Convert.ToByte(dev_addr.Text, 16)
        Dim resp = adp.ReadRegistersArray(addr, rg_addr, count)
        incom_data.Text = incom_data.Text + "starting with 0x" + BitConverter.ToString(New Byte() {rg_addr}) + ": 0x" + BitConverter.ToString(resp).Replace("-", " 0x") + Environment.NewLine
        incom_data.SelectionStart = incom_data.Text.Length
        incom_data.ScrollToCaret()
        _logger.AddMessage("Прочитано регистров: " + count)
    End Sub

    Private Sub bClear_Click(sender As Object, e As EventArgs) Handles bClear.Click
        incom_data.Text = ""
        _logger.AddMessage("Очистка поля данных")
    End Sub

    Private Sub bScan_Click(sender As Object, e As EventArgs) Handles bScan.Click
        port_list.Items.Clear()
        _logger.AddMessage("Сканирование доступных портов")
        Dim ports As String() = SerialPort.GetPortNames()
        For Each p As String In ports
            port_list.Items.Add(p)
        Next
    End Sub

    Private Sub SpiCmdProcess(str As String)
        If str.Length < 2 Then Return
        Dim str_bytes = str.Split(" ")
        Dim bytes(str_bytes.Length - 1) As Byte
        For index As Integer = 0 To str_bytes.Length - 1
            If str_bytes(index).Length > 1 Then
                If str_bytes(index).Contains("|") Then
                    bytes(index) = Convert.ToByte(str_bytes(index).Split("|")(0), 16) Or Convert.ToByte(str_bytes(index).Split("|")(1), 16)
                ElseIf str_bytes(index).Contains("&") Then
                    bytes(index) = Convert.ToByte(str_bytes(index).Split("&")(0), 16) And Convert.ToByte(str_bytes(index).Split("&")(1), 16)
                Else
                    bytes(index) = Convert.ToByte(str_bytes(index), 16)
                End If
            End If
        Next
        Dim data = adp.SpiReadArray(bytes)
        File.AppendAllText("spi_log.txt", "REQ: " + BitConverter.ToString(bytes).Replace("-", " ") + Environment.NewLine)
        File.AppendAllText("spi_log.txt", "RES: " + BitConverter.ToString(data).Replace("-", " ") + Environment.NewLine + Environment.NewLine)
        Invoke(Sub() spi_incom_data.Text = spi_incom_data.Text + BitConverter.ToString(data).Replace("-", " ") + Environment.NewLine)
        Invoke(Sub() _logger.AddMessage("SPI передача выполнена"))
        Invoke(Sub()
                   spi_incom_data.SelectionStart = spi_incom_data.Text.Length
                   spi_incom_data.ScrollToCaret()
               End Sub)
    End Sub

    Public Sub SpiCycleProcess()
        Dim cycleCount As Integer = CInt(textSpiCycleCount.Text)
        For i As Integer = cycleCount To 0 Step -1
            SpiCmd()
            Invoke(Sub() textSpiCycleCount.Text = i)
            Invoke(Sub()
                       spi_incom_data.SelectionStart = spi_incom_data.Text.Length
                       spi_incom_data.ScrollToCaret()
                   End Sub)
            Invoke(Sub() spi_incom_data.Text = spi_incom_data.Text + "-----------------" + Environment.NewLine)
            Invoke(Sub()
                       spi_incom_data.SelectionStart = spi_incom_data.Text.Length
                       spi_incom_data.ScrollToCaret()
                   End Sub)
            Thread.Sleep(textSpiCycleDelay.Text)
        Next
        Invoke(Sub() bSpiCycleStart.Text = "GO!")
    End Sub

    Private Sub SpiCmd()
        Dim Str As String = ""
        For i As Integer = 0 To SPI_data_to_write.Lines.Length - 1
            Str += SPI_data_to_write.Lines(i)
        Next
        Dim cmds = Str.Split(";")
        For index As Integer = 0 To cmds.Length - 1
            SpiCmdProcess(cmds(index))
            Thread.Sleep(textSpiDelayCmd.Text)
        Next
    End Sub

    Private Sub bSPI_Read_Click(sender As Object, e As EventArgs) Handles bSPI_Read.Click
        If adp Is Nothing Then
            _logger.AddMessage("Установите подключение к адаптеру!")
            Return
        End If
        If SPI_data_to_write.Text.Length < 2 Then Return
        Dim th As New Thread(AddressOf SpiCmd)
        th.Start()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        spi_incom_data.Text = ""
    End Sub

    Private Sub SPI_data_to_write_TextChanged(sender As Object, e As EventArgs) Handles SPI_data_to_write.TextChanged
        Dim currentPosition = SPI_data_to_write.SelectionStart
        SPI_data_to_write.Text = SPI_data_to_write.Text.ToUpper()
        SPI_data_to_write.SelectionStart = currentPosition
    End Sub

    Private Sub logWriter_Load(sender As Object, e As EventArgs) Handles logWriter.Load

    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click

    End Sub

    Dim spi_thread As Thread

    Private Sub bSpiCycleStart_Click(sender As Object, e As EventArgs) Handles bSpiCycleStart.Click
        If adp Is Nothing Then
            _logger.AddMessage("Установите подключение к адаптеру!")
            Return
        End If
        If bSpiCycleStart.Text = "GO!" Then
            spi_thread = New Thread(AddressOf SpiCycleProcess)
            spi_thread.Start()
            bSpiCycleStart.Text = "STOP"
        Else
            spi_thread.Abort()
            bSpiCycleStart.Text = "GO!"
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If File.Exists("spi_log.txt") Then
            Process.Start("spi_log.txt")
        Else
            _logger.AddMessage("Логи SPI отсутствуют")
        End If
    End Sub

End Class
