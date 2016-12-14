﻿Imports Bwl.Hardware.SimplSerial

''' <summary>
''' Класс, представляет подключенный USB-TWI-SPI адаптер.
''' </summary>
Public Class UsbSpiTwiAdapter
    Private _ss As New SimplSerialBus()
    Private _connectionState As Boolean = False

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
            Dim th = New System.Threading.Thread(AddressOf FindProcess)
            th.Start()
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
            Return True
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

    Private Function FindProcess()
        While Not isConnected()
            Dim ports() = IO.Ports.SerialPort.GetPortNames()
            For Each port As String In ports
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
            Next
        End While

    End Function

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
        Return resp.Data(0)
    End Function

    ''' <summary>
    ''' Записать регистр по интерфейсу I2C (TWI).
    ''' </summary>
    ''' <param name="deviсe_addr">Адрес устройства на шине I2C</param>
    ''' <param name="reg_addr">Адрес регистра устройства.</param>
    ''' <param name="reg_value">Значение регистра.</param>
    ''' <returns>Значение прочитанного регистра.</returns>
    Public Sub TwiWriteRegister(device_addr As Byte, reg_addr As Byte, reg_value As Byte)
        Dim args(2) As Byte
        args(0) = device_addr
        args(1) = reg_addr
        args(2) = reg_value
        _ss.Request(0, 2, args)
    End Sub

    ''' <summary>
    ''' Записать регистр по интерфейсу I2C (TWI).
    ''' </summary>
    ''' <param name="deviсe_addr">Адрес устройства на шине I2C</param>
    ''' <param name="read_from">Адрес первого регистра</param>
    ''' <param name="count">Количество регистров, которые нужно прочитать.</param>
    ''' <returns>Массив значений регистров</returns>
    Public Function TwiReadRegistersArray(device_addr As Byte, read_from As Byte, count As Integer) As Byte()
        Dim args(2) As Byte
        args(0) = device_addr
        args(1) = read_from
        args(2) = count
        Dim resp = _ss.Request(0, 3, args)
        Return resp.Data
    End Function

    ''' <summary>
    ''' Запись данных по интерфейсу SPI.
    ''' </summary>
    ''' <param name="data">Данны для записи</param>
    ''' <returns>Ответ ведомого устройства в байтах.</returns>
    Public Function SpiWriteArray(data As Byte())
        Return _ss.Request(0, 4, data).Data
    End Function

    ''' <summary>
    ''' Чтение данных по интерфейсу SPI.
    ''' </summary>
    ''' <param name="data">Данные, которые будут переданы ведомому во время чтения.</param>
    ''' <returns>Ответ ведомого устройства в байтах.</returns>
    Public Function SpiReadArray(data As Byte())
        
        Return _ss.Request(0, 4, data).Data
    End Function


End Class
