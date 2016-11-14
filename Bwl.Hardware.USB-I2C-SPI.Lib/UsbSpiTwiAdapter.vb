Imports Bwl.Hardware.SimplSerial

''' <summary>
''' Класс, представляет подключенный USB-TWI-SPI адаптер.
''' </summary>
Public Class UsbSpiTwiAdapter
    Private _ss As New SimplSerialBus()

    ''' <summary>
    ''' Конструктор.
    ''' </summary>
    ''' <param name="port">Имя последовательного порта, например COM1</param>
    Public Sub New(port As String)
        _ss.SerialDevice.DeviceAddress = port
        _ss.SerialDevice.DeviceSpeed = 9600
    End Sub

    Public Sub Open()
        _ss.Connect()
    End Sub

    Public Sub Close()
        _ss.Disconnect()
    End Sub

    ''' <summary>
    ''' Записать регистр по интерфейсу I2C (TWI).
    ''' </summary>
    ''' <param name="deviсe_addr">Адрес устройства на шине I2C</param>
    ''' <param name="reg_addr">Адрес регистра устройства.</param>
    ''' <returns>Значение прочитанного регистра.</returns>
    Public Function TwiReadRegister(deviсe_addr As Byte, reg_addr As Byte) As Byte
        Dim args(1) As Byte
        args(0) = deviсe_addr
        args(1) = reg_addr
        Dim resp = _ss.Request(0, 1, args)
        Return resp.Data(0)
    End Function

    Public Sub TwiWriteRegister(device_addr As Byte, reg_addr As Byte, reg_value As Byte)
        Dim args(2) As Byte
        args(0) = device_addr
        args(1) = reg_addr
        args(2) = reg_value
        _ss.Request(0, 2, args)
    End Sub

    Public Function TwiReadRegistersArray(device_addr As Byte, read_from As Byte, count As Integer) As Byte()
        Dim args(2) As Byte
        args(0) = device_addr
        args(1) = read_from
        args(2) = count
        Dim resp = _ss.Request(0, 3, args)
        Return resp.Data
    End Function

    Public Function SpiWriteArray(data As Byte())
        Return _ss.Request(0, 4, data).Data
    End Function

    Public Function SpiReadArray(data As Byte())
        Return _ss.Request(0, 4, data).Data
    End Function

    Public Function GetAdapterName() As String
        Dim info = _ss.RequestDeviceInfo(0)
        If info.Response.ResponseState = ResponseState.ok Then
            Return info.DeviceName
        End If
        Throw New Exception("GetAdapterName: Adapter not responding!")
    End Function
End Class
