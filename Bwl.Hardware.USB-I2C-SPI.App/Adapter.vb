Imports Bwl.Hardware.SimplSerial
Public Class Adapter
    Private _port As New SimplSerialBus()


    Public Sub New(port As String)
        _port.SerialDevice.DeviceAddress = port
        _port.SerialDevice.DeviceSpeed = 9600
        _port.Connect()
    End Sub

    Public Function ReadRegister(deviсe_addr As Byte, addr As Byte) As Byte
        Dim args(1) As Byte
        args(0) = deviсe_addr
        args(1) = addr
        Dim resp = _port.Request(0, 1, args)
        Return resp.Data(0)
    End Function

    Public Function WriteRegister(device_addr As Byte, reg_addr As Byte, reg_value As Byte)
        Dim args(2) As Byte
        args(0) = device_addr
        args(1) = reg_addr
        args(2) = reg_value
        _port.Request(0, 2, args)
    End Function

    Public Function ReadRegistersArray(device_addr As Byte, read_from As Byte, count As Integer) As Byte()
        Dim args(2) As Byte
        args(0) = device_addr
        args(1) = read_from
        args(2) = count
        Dim resp = _port.Request(0, 3, args)
        Return resp.Data
    End Function

    Public Function SpiWriteArray(data As Byte())
        Return _port.Request(0, 4, data).Data
    End Function

    Public Function SpiReadArray(data As Byte())
        Return _port.Request(0, 4, data).Data
    End Function

    Public Function GetDeviceInfo() As String
        Return _port.RequestDeviceInfo(0).DeviceName
    End Function
End Class
