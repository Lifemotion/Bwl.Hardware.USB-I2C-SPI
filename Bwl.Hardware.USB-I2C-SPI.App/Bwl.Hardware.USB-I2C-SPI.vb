Imports System.IO.Ports
Imports Bwl.Framework

Public Class Form1
    Inherits FormAppBase

    Private adp As Adapter

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ports As String() = SerialPort.GetPortNames()
        For Each p As String In ports
            port_list.Items.Add(p)
        Next
        _logger.AddMessage("Готов к работе")
    End Sub

    Private Sub bRdReg_Click(sender As Object, e As EventArgs) Handles bRdReg.Click
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
        Dim rg_addr As Byte = Convert.ToByte(wr_reg_addr.Text, 16)
        Dim rg_value As Byte = Convert.ToByte(reg_val.Text, 16)
        Dim addr As Byte = Convert.ToByte(dev_addr.Text, 16)
        adp.WriteRegister(addr, rg_addr, rg_value)
        _logger.AddMessage("В регистр " + wr_reg_addr.Text + " записано " + reg_val.Text)
    End Sub

    Private Sub bRdSomeReg_Click(sender As Object, e As EventArgs) Handles bRdSomeReg.Click
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

    Private Sub bSPI_Read_Click(sender As Object, e As EventArgs) Handles bSPI_Read.Click
        If SPI_data_to_write.Text.Length < 2 Then Return
        Dim str_bytes = SPI_data_to_write.Text.Split(" ")
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
        ' SPI_data_to_write.Text = ""
        Dim data = adp.SpiReadArray(bytes)
        spi_incom_data.Text = spi_incom_data.Text + BitConverter.ToString(data).Replace("-", " ") + Environment.NewLine + "------------" + Environment.NewLine
        spi_incom_data.SelectionStart = spi_incom_data.TextLength
        spi_incom_data.ScrollToCaret()
        _logger.AddMessage("Обмен данными SPI...")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        spi_incom_data.Text = ""
    End Sub

    Private Sub SPI_data_to_write_TextChanged(sender As Object, e As EventArgs) Handles SPI_data_to_write.TextChanged
        SPI_data_to_write.Text = SPI_data_to_write.Text.ToUpper()
        SPI_data_to_write.SelectionStart = SPI_data_to_write.TextLength
    End Sub

    Private Sub logWriter_Load(sender As Object, e As EventArgs) Handles logWriter.Load

    End Sub
End Class
