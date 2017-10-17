Imports Bwl.Framework
Imports Bwl.Hardware.USB_I2C_SPI

Public Class Rfm95W
    Const RegFifo As Byte = &H0
    Const RegOpMode As Byte = &H1
    Const RegFrfMsb As Byte = &H6
    Const RegFrfMid As Byte = &H7
    Const RegFrfLsb As Byte = &H8
    Const RegPaConfig As Byte = &H9
    Const RegPaRamp As Byte = &HA
    Const RegOcp As Byte = &HB

    Const RegLna As Byte = &HC
    Const RegFifoAddrPtr As Byte = &HD
    Const RegFifoTxBaseAddr As Byte = &HE
    Const RegFifoRxBaseAddr As Byte = &HF
    Const RegFifoRxCurrentAddr As Byte = &H10
    Const RegIrqFlagsMask As Byte = &H11
    Const RegIrqFlags As Byte = &H12
    Const RegRxNbBytes As Byte = &H13
    Const RegRxHeaderCntValueMsb As Byte = &H14
    Const RegRxHeaderCntValueLsb As Byte = &H15
    Const RegRxPacketCntValueMsb As Byte = &H16
    Const RegRxPacketCntValueLsb As Byte = &H17
    Const RegModemStat As Byte = &H18
    Const RegPktSnrValue As Byte = &H19

    Const RegPktRssiValue As Byte = &H1A
    Const RegRssiValue As Byte = &H1B
    Const RegHopChannel As Byte = &H1C
    Const RegModemConfig As Byte = &H1D
    Const RegModemConfig2 As Byte = &H1E
    Const RegModemConfig3 As Byte = &H26
    Const RegSymbTimeoutLsb As Byte = &H1F
    Const RegPreambleMsb As Byte = &H20
    Const RegPreambleLsb As Byte = &H21
    Const RegPayloadLength As Byte = &H22
    Const RegMaxPayloadLength As Byte = &H23
    Const RegHopPeriod As Byte = &H24
    Const RegFifoRxByteAddr As Byte = &H25


    Public Event RfmInterrupt(ByVal message As String)
    Public Event RfmModemInterrupt(ByVal message As String)
    Private _myAddress As Byte = 0
    Private _targetAddress As Byte = 0
    Private _obj As New Object
    Private _adp As UsbSpiTwiAdapter = Nothing
    Private _logger As Logger

    Sub New(my As Byte, target As Byte, logger As Logger)
        _logger = logger
        _myAddress = my
        _targetAddress = target
        _adp = New UsbSpiTwiAdapter()
        _adp.Open()
        Dim th = New Threading.Thread(AddressOf WorkProcess)
        th.Start()
    End Sub

    Public Sub RfmWrite(addr As Byte, value As Byte)
        SyncLock _obj
            _adp.SpiWriteArray({&H80 Or addr, value})
            Threading.Thread.Sleep(200)
        End SyncLock
    End Sub

    Public Function RfmRead(addr As Byte) As Byte
        SyncLock _obj
            Return _adp.SpiReadArray({addr, &H0})(1)
        End SyncLock
    End Function

    Private Sub RfmCheckInterrupts()
        SyncLock _obj

        End SyncLock
    End Sub

    Private Sub RfmCheckModem()

    End Sub

    Private Function PackageRssi() As UInt16
        Return RfmRead(RegPktRssiValue) - 137
    End Function

    Private Function CurrentRssi() As UInt16
        Return RfmRead(RegRssiValue) - 137
    End Function

    Private Function RfmReceivedBytesCount() As Byte
        Return RfmRead(RegRxNbBytes)
    End Function

    Public Function RfmReadData() As Byte()
        SyncLock _obj
            Dim list As List(Of Byte) = New List(Of Byte)
            Dim fifoLocation = RfmRead(&H10)
            Dim packageLenght = RfmRead(&H13)
            RfmWrite(&HD, fifoLocation)
            For i = 0 To packageLenght - 1
                list.Add(RfmRead(RegFifo))
            Next
            Return list.ToArray()
        End SyncLock
    End Function

    Public Sub RfmSendData(bytes As Byte())
        SyncLock _obj
            _logger.AddMessage("Sending: " + Text.ASCIIEncoding.ASCII.GetString(bytes))
            RfmWrite(&H40, &H40)
            RfmWrite(&H22, bytes.Length)
            Dim RFM_Tx_Location = RfmRead(&HE)
            RfmWrite(&HD, RFM_Tx_Location)
            For Each b In bytes
                RfmWrite(&H0, b)
            Next
            RfmWrite(&H1, &H83)
            'RfmWrite(&H1, &H81)
        End SyncLock
    End Sub


    Private Sub WorkProcess()
        While Not _adp.isConnected
            Threading.Thread.Sleep(1000)
        End While
        RfmWrite(&H1, &H0)
        While RfmRead(&H1) <> 0
            Threading.Thread.Sleep(1000)
            _logger.AddWarning("Wait sleep mode")
        End While

        RfmWrite(&H1, &H80)
        RfmWrite(&H1, &H81)
        RfmWrite(&H6, &HD9)
        RfmWrite(&H7, &H6)
        RfmWrite(&H8, &H8B)
        RfmWrite(&H9, &HFF)
        RfmWrite(&H1D, &H72)
        RfmWrite(&H1E, &H74)
        RfmWrite(&H20, &H0)
        RfmWrite(&H21, &H8)
        RfmWrite(&H39, &H34)
        RfmWrite(&H33, &H27)
        RfmWrite(&H3B, &H1D)
        RfmWrite(&HE, &H80)
        RfmWrite(&HF, &H0)
        _logger.AddMessage("Инициализация завершена")
    End Sub
End Class
