Imports System.IO
Imports System.IO.Ports
Imports System.Management
Imports System.Threading
Imports Bwl.Framework

Public Class Form1
    Inherits FormAppBase

    Private _adp As UsbSpiTwiAdapter = Nothing


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        File.Delete("spi_log.txt")
        File.Delete("i2c_log.txt")
        Dim ports As String() = SerialPort.GetPortNames()
        textSpiCycleCount.Text = "10"
        textSpiCycleDelay.Text = "1000"
        textSpiDelayCmd.Text = "100"
        textI2CPeriod.Text = "500"
        Dim DeviceSearchProcess = New Thread(AddressOf FindAdapter)
        DeviceSearchProcess.Start()
        _logger.AddMessage("Поиск адаптера...")
    End Sub

    Private Sub bRdReg_Click(sender As Object, e As EventArgs) Handles bRdReg.Click
        If _adp Is Nothing Then
            _logger.AddMessage("Установите подключение к адаптеру!")
            Return
        End If
        If Not _adp.isConnected Then
            _logger.AddWarning("Соединение не установлено")
            Return
        End If
        If dev_addr.Text.Length = 0 Or rd_reg_addr.Text.Length = 0 Then
            _logger.AddMessage("Заполните поля!")
            Return
        End If
        Dim addr As Byte = 0
        Dim reg_addr As Byte = 0
        Try
            addr = Convert.ToByte(dev_addr.Text, 16)
            reg_addr = Convert.ToByte(rd_reg_addr.Text, 16)
        Catch ex As Exception
            _logger.AddWarning("Значения полей должны быть в формате FF")
            Return
        End Try
        Dim resp As Byte = _adp.TwiReadRegister(addr, reg_addr)
        singleValueBox.Text = BitConverter.ToString(New Byte() {resp})
        _logger.AddMessage("REG 0x" + rd_reg_addr.Text + ": 0x" + singleValueBox.Text)
    End Sub


    Private Sub write_reg_Click(sender As Object, e As EventArgs) Handles write_reg.Click
        If _adp Is Nothing Then
            _logger.AddMessage("Установите подключение к адаптеру!")
            Return
        End If
        If Not _adp.isConnected Then
            _logger.AddWarning("Адаптер не отвечает")
            Return
        End If
        If wr_reg_addr.Text.Length = 0 Or reg_val.Text.Length = 0 Or dev_addr.Text.Length = 0 Then
            _logger.AddMessage("Заполните поля!")
            Return
        End If
        Dim rg_addr As Byte = 0
        Dim rg_value As Byte = 0
        Dim addr As Byte = 0
        Try
            rg_value = Convert.ToByte(reg_val.Text, 16)
            addr = Convert.ToByte(dev_addr.Text, 16)
            rg_addr = Convert.ToByte(wr_reg_addr.Text, 16)
        Catch ex As Exception
            _logger.AddWarning("Значения полей должны быть в формате FF")
            Return
        End Try
        rd_reg_addr.Text = wr_reg_addr.Text
        _adp.TwiWriteRegister(addr, rg_addr, rg_value)
        _logger.AddMessage("В регистр 0x" + wr_reg_addr.Text + " записано 0x" + reg_val.Text)
    End Sub

    Private Sub bRdSomeReg_Click(sender As Object, e As EventArgs) Handles bRdSomeReg.Click
        If _adp Is Nothing Then
            _logger.AddMessage("Установите подключение к адаптеру!")
            Return
        End If
        If Not _adp.isConnected Then
            _logger.AddWarning("Адаптер не отвечает")
            Return
        End If

        If rd_some_reg_addr.Text.Length = 0 Or rd_cnt.Text.Length = 0 Or dev_addr.Text.Length = 0 Then
            _logger.AddMessage("Заполните поля!")
            Return
        End If

        Dim rg_addr As Byte = 0
        Dim count As Byte = 0
        Dim addr As Byte = 0
        Try
            rg_addr = Convert.ToByte(rd_some_reg_addr.Text, 16)
            count = Convert.ToByte(rd_cnt.Text, 16)
            addr = Convert.ToByte(dev_addr.Text, 16)
        Catch ex As Exception
            _logger.AddWarning("Значения полей должны быть в формате FF")
            Return
        End Try
        Dim resp = _adp.TwiReadRegistersArray(addr, rg_addr, count)
        incom_data.Text = incom_data.Text + "0x" + BitConverter.ToString(New Byte() {rg_addr}) + ": 0x" + BitConverter.ToString(resp).Replace("-", " 0x") + Environment.NewLine
        incom_data.SelectionStart = incom_data.Text.Length
        incom_data.ScrollToCaret()
        _logger.AddMessage("Прочитано регистров: " + rd_cnt.Text)
    End Sub

    Private Sub bClear_Click(sender As Object, e As EventArgs) Handles bClear.Click
        incom_data.Text = ""
        _logger.AddMessage("Очистка поля данных")
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
        Dim data = _adp.SpiReadArray(bytes)
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
        For k As Integer = cycleCount To 0 Step -1
            Dim i = k
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
        If _adp Is Nothing Then
            _logger.AddMessage("Установите подключение к адаптеру!")
            Return
        End If
        If Not _adp.isConnected Then
            _logger.AddWarning("Адаптер не отвечает")
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
        If _adp Is Nothing Then
            _logger.AddMessage("Установите подключение к адаптеру!")
            Return
        End If
        If Not _adp.isConnected Then
            _logger.AddWarning("Адаптер не отвечает")
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

    Private Sub Label13_Click(sender As Object, e As EventArgs) Handles Label13.Click

    End Sub

    Private Sub TWIPeriodRequest()

        Dim rg_addr As Byte = 0
        Dim count As Byte = 0
        Dim addr As Byte = 0
        Dim reg_addr As Byte = 0

        While bI2Cycles.Text.Contains("STOP")
            If rd_some_reg_addr.Text.Length = 0 Or rd_cnt.Text.Length = 0 Or dev_addr.Text.Length = 0 Then
                _logger.AddMessage("Заполните поля!")
                Return
            End If
            rg_addr = Convert.ToByte(rd_some_reg_addr.Text, 16)
            count = Convert.ToByte(rd_cnt.Text, 16)
            addr = Convert.ToByte(dev_addr.Text, 16)
            If RadioSomeRegs.Checked Then
                Dim resp = _adp.TwiReadRegistersArray(addr, rg_addr, count)
                Invoke(Sub()
                           rd_reg_addr.Enabled = True
                           rd_some_reg_addr.Enabled = False
                           rd_cnt.Enabled = False
                           incom_data.Text = incom_data.Text + "REG 0x" + BitConverter.ToString(New Byte() {rg_addr}) + ": 0x" + BitConverter.ToString(resp).Replace("-", " 0x") + Environment.NewLine
                           incom_data.SelectionStart = incom_data.Text.Length
                           incom_data.ScrollToCaret()
                           _logger.AddMessage("Прочитано регистров: " + rd_cnt.Text)
                           File.AppendAllText("i2c_log.txt", "REG 0x" + BitConverter.ToString(New Byte() {rg_addr}) + ": 0x" + BitConverter.ToString(resp).Replace("-", " 0x") + Environment.NewLine)
                       End Sub)
            End If
            If RadioSingle.Checked Then
                Dim resp As Byte = _adp.TwiReadRegister(addr, reg_addr)
                Invoke(Sub()
                           rd_some_reg_addr.Enabled = True
                           rd_cnt.Enabled = True
                           rd_reg_addr.Enabled = False
                           singleValueBox.Text = BitConverter.ToString(New Byte() {resp})
                           incom_data.Text = incom_data.Text + "REG 0x" + rd_reg_addr.Text + ": 0x" + singleValueBox.Text + Environment.NewLine
                           incom_data.SelectionStart = incom_data.Text.Length
                           incom_data.ScrollToCaret()
                           _logger.AddMessage("REG 0x" + rd_reg_addr.Text + ": 0x" + singleValueBox.Text)
                           File.AppendAllText("i2c_log.txt", "REG 0x" + rd_reg_addr.Text + ": 0x" + singleValueBox.Text + Environment.NewLine)
                       End Sub)
            End If
            Thread.Sleep(Convert.ToInt32(textI2CPeriod.Text))
        End While
        Invoke(Sub()
                   rd_some_reg_addr.Enabled = True
                   rd_cnt.Enabled = True
                   rd_reg_addr.Enabled = True

               End Sub)
    End Sub

    Private Sub bI2Cycles_Click(sender As Object, e As EventArgs) Handles bI2Cycles.Click
        If _adp Is Nothing Then
            _logger.AddMessage("Установите подключение к адаптеру!")
            Return
        End If
        If Not _adp.isConnected Then
            _logger.AddWarning("Адаптер не отвечает")
            Return
        End If
        If bI2Cycles.Text.Contains("STOP") Then
            bI2Cycles.Text = "GO!"
        ElseIf bI2Cycles.Text.Contains("GO") Then
            bI2Cycles.Text = "STOP"
            Dim twiThread = New Thread(AddressOf TWIPeriodRequest)
            twiThread.Start()
        End If
    End Sub

    Private Sub bTWIopenLog_Click(sender As Object, e As EventArgs) Handles bTWIopenLog.Click
        If File.Exists("i2c_log.txt") Then
            Process.Start("i2c_log.txt")
        Else
            _logger.AddMessage("Лог файл I2C отсутсвует")
        End If
    End Sub

    Private Sub FindAdapter()
        _adp = New UsbSpiTwiAdapter()
        _adp.Open()
        While Not _adp.isConnected()
            Thread.Sleep(300)
        End While
        _logger.AddMessage(_adp.GetAdapterName)
    End Sub

    Private Sub UploadFrimware(com As String)
        Dim oProcess As New Process()

        Dim oStartInfo As New ProcessStartInfo("avrdude.exe", "-V -F -C avrdude.conf -p atmega32u4 -cavr109 -P " + com + " -b57600 -U flash:w:firmware.hex -vvvv")
        oStartInfo.UseShellExecute = False
        oStartInfo.RedirectStandardOutput = False
        oStartInfo.CreateNoWindow = False
        oProcess.StartInfo = oStartInfo
        oProcess.Start()
        Thread.Sleep(1000)
        Dim timer = New Stopwatch()
        timer.Start()
        oProcess.WaitForExit(10000)
        textUpgrade.Text = "Done."
        timer.Stop()
        If (timer.ElapsedMilliseconds / 1000 > 3) Then
            _adp.Close()
            Dim DeviceSearchProcess = New Thread(AddressOf FindAdapter)
            DeviceSearchProcess.Start()
            Tabs.SelectedIndex = 0
        End If
    End Sub

    Private Sub bUpdate_Click(sender As Object, e As EventArgs) Handles bUpdate.Click

        Dim fileDialog As New OpenFileDialog()
        fileDialog.Filter = "hex files | *.hex"
        fileDialog.FilterIndex = 2
        fileDialog.RestoreDirectory = True
        If fileDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Dim fileName = fileDialog.FileName
            MessageBox.Show("Please, reset your board and press OK")
            Try
                Dim searcher As New ManagementObjectSearcher("root\CIMV2", "SELECT * FROM Win32_PnPEntity")
                For Each queryObj As ManagementObject In searcher.Get()
                    If InStr(queryObj("Caption"), "(COM") > 0 Then
                        Dim deviceName = queryObj("Caption").ToString
                        If deviceName.ToLower.Contains("bootloader") Then
                            textUpgrade.Text = "Uprading: " + deviceName
                            deviceName = deviceName.Split("(")(1).Split(")")(0)
                            If File.Exists("firmware.hex") Then
                                File.Delete("firmware.hex")
                            End If
                            File.Copy(fileName, "firmware.hex")
                            UploadFrimware(deviceName)
                        End If
                    End If
                Next
            Catch err As ManagementException
                _logger.AddError(err.Message)
            End Try
        End If


    End Sub
End Class
