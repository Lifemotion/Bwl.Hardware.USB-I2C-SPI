Imports System.IO
Imports System.Management
Imports System.Windows.Forms
Imports Bwl.Hardware.SimplSerial

''' <summary>
''' Класс, представляет подключенный USB-TWI-SPI адаптер.
''' </summary>
Public Class UsbSpiTwiAdapter
    Private _ss As New SimplSerialBus()
    Private _connectionState As Boolean = False
    Private _searchThread As Threading.Thread = Nothing
    ''' <summary>
    ''' Конструктор класса
    ''' </summary>
    ''' <param name="port">Имя последовательного порта, например COM1</param>
    Public Sub New(port As String)
        _ss.SerialDevice.DeviceAddress = port
        _ss.SerialDevice.DeviceSpeed = 9600
    End Sub

    ''' <summary>
    ''' Конструктор класса
    ''' </summary>
    Public Sub New()
        _ss.SerialDevice.DeviceSpeed = 9600
    End Sub
    ''' <summary>
    ''' Открывает соединение с USB адаптером
    ''' </summary>
    Public Sub Open()
        If _ss.SerialDevice.DeviceAddress.Length > 0 Then
            _ss.Connect()
        Else
            _searchThread = New Threading.Thread(AddressOf FindProcess)
            _searchThread.Start()
        End If

    End Sub

    ''' <summary>
    ''' Функция проверяет состояние текущего подключения
    ''' <returns>True, если соединение установлено. False, если подключения нет</returns> 
    ''' </summary>
    Public Function isConnected() As Boolean
        If Not _ss.IsConnected() Then
            Return False
        End If
        Try
            Dim info = _ss.RequestDeviceInfo(0)
            If info.Response.ResponseState = ResponseState.ok Then
                If info.DeviceName.Contains("Adapter") Then
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Возвращает имя подключенного устройства
    ''' </summary>
    Public Function GetAdapterName() As String
        Dim info = _ss.RequestDeviceInfo(0)
        If info.Response.ResponseState = ResponseState.ok Then
            Return info.DeviceName
        End If
        Throw New Exception("GetAdapterName: Adapter not responding!")
    End Function

    Private Sub FindProcess()
        While True
            If Not isConnected() Then
                Dim ports() = IO.Ports.SerialPort.GetPortNames()
                For Each port As String In ports
                    Try
                        _ss.SerialDevice.DeviceAddress = port
                        _ss.Connect()
                        Dim info = _ss.RequestDeviceInfo(0)
                        If info.Response.ResponseState = ResponseState.ok Then
                            If Not info.DeviceName.Contains("Adapter") Then
                                _ss.SerialDevice.DeviceAddress = ""
                                _ss.Disconnect()
                            Else
                                _connectionState = True
                            End If
                        Else
                            _ss.SerialDevice.DeviceAddress = ""
                            _ss.Disconnect()
                        End If
                    Catch ex As Exception

                    End Try
                Next
            End If
            Threading.Thread.Sleep(2000)
        End While
    End Sub

    ''' <summary>
    ''' Закрыть текущее соединение
    ''' </summary>
    Public Sub Close()
        _ss.Disconnect()
    End Sub

    ''' <summary>
    ''' Прочитать регистр по интерфейсу I2C (TWI).
    ''' </summary>
    ''' <param name="deviсe_addr">Адрес устройства на шине I2C</param>
    ''' <param name="reg_addr">Адрес регистра устройства.</param>
    ''' <returns>Значение прочитанного регистра.</returns>
    Public Function TwiReadRegister(deviсe_addr As Byte, reg_addr As Byte) As Byte
        Dim args(1) As Byte
        args(0) = deviсe_addr
        args(1) = reg_addr
        Dim resp = _ss.Request(0, 1, args)
        If resp.ResponseState = ResponseState.ok Then
            If resp.Data(0) = 0 Then
                Throw New Exception("No ACK")
            End If
            Return resp.Data(1)
        Else
            _ss.Disconnect()
            _ss = New SimplSerialBus()
        End If

        Return 0
    End Function

    ''' <summary>
    ''' Записать регистр по интерфейсу I2C (TWI).
    ''' </summary>
    ''' <param name="device_addr">Адрес устройства на шине I2C</param>
    ''' <param name="reg_addr">Адрес регистра устройства.</param>
    ''' <param name="reg_value">Значение регистра.</param>
    Public Sub TwiWriteRegister(device_addr As Byte, reg_addr As Byte, reg_value As Byte)
        Dim args(2) As Byte
        args(0) = device_addr
        args(1) = reg_addr
        args(2) = reg_value
        Dim resp = _ss.Request(0, 2, args)
        If resp.ResponseState <> ResponseState.ok Then
            _ss.Disconnect()
            _ss = New SimplSerialBus()
        Else
            If resp.Data(0) = 0 Then
                Throw New Exception("No ACK")
            End If
        End If
    End Sub

    ''' <summary>
    ''' Записать регистр по интерфейсу I2C (TWI).
    ''' </summary>
    ''' <param name="device_addr">Адрес устройства на шине I2C</param>
    ''' <param name="read_from">Адрес первого регистра</param>
    ''' <param name="count">Количество регистров, которые нужно прочитать.</param>
    ''' <returns>Массив значений регистров</returns>
    Public Function TwiReadRegistersArray(device_addr As Byte, read_from As Byte, count As Integer) As Byte()
        Dim args(2) As Byte
        args(0) = device_addr
        args(1) = read_from
        args(2) = count
        Dim resp = _ss.Request(0, 3, args)
        If resp.ResponseState <> ResponseState.ok Then
            _ss.Disconnect()
            _ss = New SimplSerialBus()
        Else
            If resp.Data(0) = 0 Then
                Throw New Exception("No ACK")
            End If
            Dim data() As Byte
            Array.Copy(resp.Data, 1, data, 0, resp.Data.Length - 1)
            Return data
        End If
        Return resp.Data
    End Function




    ''' <summary>
    ''' Запись данных по интерфейсу SPI.
    ''' </summary>
    ''' <param name="data">Данны для записи</param>
    ''' <returns>Ответ ведомого устройства в байтах.</returns>
    Public Function SpiWriteArray(data As Byte())
        Dim resp = _ss.Request(0, 4, data)
        If resp.ResponseState <> ResponseState.ok Then
            _ss.Disconnect()
            _ss = New SimplSerialBus()
        Else
            Return resp.Data
        End If
    End Function

    ''' <summary>
    ''' Чтение данных по интерфейсу SPI.
    ''' </summary>
    ''' <param name="data">Данные, которые будут переданы ведомому во время чтения.</param>
    ''' <returns>Ответ ведомого устройства в байтах.</returns>
    Public Function SpiReadArray(data As Byte())
        Dim resp = _ss.Request(0, 4, data)
        If resp.ResponseState <> ResponseState.ok Then
            _ss.Disconnect()
            _ss = New SimplSerialBus()
        Else
            Return resp.Data
        End If
    End Function

    Private Sub AvrdudeExec(deviceDescriptor As String)
        If Not File.Exists("avrdude.exe") Then
            Throw New Exception("avrdude.exe not finded")
        End If
        Dim oProcess As New Process()
        Dim port = deviceDescriptor.Split("(")(1).Split(")")(0)
        Dim cmd = ""
        If (deviceDescriptor.ToLower.Contains("uno")) Then
            cmd = "-V -F -C avrdude.conf -p atmega328p -carduino -P" + port + " -b115200 -D -Uflash:w:firmware.hex -vvvv"
        ElseIf deviceDescriptor.ToLower.Contains("bootloader") Then
            cmd = "-V -F -C avrdude.conf -p atmega32u4 -cavr109 -P " + port + " -b57600 -U flash:w:firmware.hex -vvvv"
            MessageBox.Show("Please, reset your board and press OK")
        Else
            Throw New Exception("Arduino not finded or not supported")
        End If
        Dim oStartInfo As New ProcessStartInfo("avrdude.exe", cmd)
        oStartInfo.UseShellExecute = False
        oStartInfo.RedirectStandardOutput = False
        oStartInfo.CreateNoWindow = False
        oProcess.StartInfo = oStartInfo
        oProcess.Start()
        Dim timer = New Stopwatch()
        timer.Start()
        oProcess.WaitForExit(10000)
        timer.Stop()
    End Sub

    ''' <summary>
    ''' Загрузка прошивки адаптера через штатный загрузчик Arduino
    ''' </summary>
    ''' <param name="hexPath">Абсолютный путь файла прошивки</param>
    ''' <returns></returns>
    Public Function UploadFirmware(hexPath As String)
        Try
            Dim searcher As New ManagementObjectSearcher("root\CIMV2", "SELECT * FROM Win32_PnPEntity")
            For Each queryObj As ManagementObject In searcher.Get()
                If InStr(queryObj("Caption"), "(COM") > 0 Then
                    Dim deviceName = queryObj("Caption").ToString
                    If deviceName.ToLower.Contains("arduino") Or deviceName.ToLower.Contains("genuino") Then
                        If File.Exists("firmware.hex") Then
                            File.Delete("firmware.hex")
                        End If
                        File.Copy(hexPath, "firmware.hex")
                        _searchThread.Abort()
                        If _ss IsNot Nothing Then
                            _ss.Disconnect()
                        End If
                        AvrdudeExec(deviceName)
                        _searchThread = New Threading.Thread(AddressOf FindProcess)
                        _searchThread.Start()
                    End If
                End If
            Next
        Catch err As ManagementException
        End Try
    End Function

End Class
