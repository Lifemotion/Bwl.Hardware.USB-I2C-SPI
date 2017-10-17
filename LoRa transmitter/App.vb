Imports Bwl.Framework
Public Class App
    Inherits FormAppBase
    Private _rfm As Rfm95W
    Private Sub App_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Timer1.Start()
    End Sub

    Private Sub ModemInterruptHandler(msg As String)
        _logger.AddInformation(msg)
    End Sub

    Private Sub RfmModemHandler(msg As String)
        _logger.AddInformation(msg)
    End Sub

    Private Sub Send_Click(sender As Object, e As EventArgs) Handles Send.Click
        Dim msg = System.Text.Encoding.Unicode.GetBytes(textMessage.Text)
        _rfm.RfmSendData(msg)
    End Sub

    Private Sub OK_Click(sender As Object, e As EventArgs) Handles OK.Click
        _rfm = New Rfm95W(0, 0, _logger)
    End Sub

    Private Sub CloseEvent(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Application.Exit()
    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            Dim data = _rfm.RfmRead(&H19)
            _logger.AddInformation("IRQ flags: " + data.ToString)
            checkRxCodingRate2.CheckState = If(data And &H80, 1, 0)
            checkRxCodingRate1.CheckState = If(data And &H40, 1, 0)
            checkRxCodingRate0.CheckState = If(data And &H20, 1, 0)
            checkModemClear.CheckState = If(data And &H10, 1, 0)
            checkHeaderValid.CheckState = If(data And &H8, 1, 0)
            checkRXonGoing.CheckState = If(data And &H4, 1, 0)
            checkSynchronized.CheckState = If(data And &H2, 1, 0)
            checkSignalDetected.CheckState = If(data And &H1, 1, 0)
            data = _rfm.RfmRead(&H12)
            _logger.AddInformation("Modem flags: " + data.ToString)
            checkRxTimeout.CheckState = If(data And &H80, 1, 0)
            checkRxDone.CheckState = If(data And &H40, 1, 0)
            checkPayloadCrcError.CheckState = If(data And &H20, 1, 0)
            checkValidHeader.CheckState = If(data And &H10, 1, 0)
            checkTxDone.CheckState = If(data And &H8, 1, 0)
            checkCadDone.CheckState = If(data And &H4, 1, 0)
            checkFhssChangeChannel.CheckState = If(data And &H2, 1, 0)
            checkCadDetected.CheckState = If(data And &H1, 1, 0)
            Dim receivedCount = _rfm.RfmRead(&H13)
            Dim rxPtr = _rfm.RfmRead(&H25)
            If receivedCount > 0 Then
                textReceivedString.Text = System.Text.Encoding.Unicode.GetString(_rfm.RfmReadData())
            End If
            textFifoRxBytesNb.Text = receivedCount.ToString
            textValidHeaderCntMsb.Text = _rfm.RfmRead(&H14).ToString
            textValidHeaderCntLsb.Text = _rfm.RfmRead(&H15).ToString
            textValidPacketCntMsb.Text = _rfm.RfmRead(&H16).ToString
            textValidPacketCntLsb.Text = _rfm.RfmRead(&H17).ToString
            textRegFifoRxByteAddr.Text = rxPtr.ToString
            textRegPktRssiValue.Text = (_rfm.RfmRead(&H1A) - 137).ToString
            textRegRssiValue.Text = (_rfm.RfmRead(&H1B) - 137).ToString
        Catch ex As Exception

        End Try

    End Sub

    Private Sub checkRxTimeout_CheckedChanged(sender As Object, e As EventArgs) Handles checkRxDone.Click, checkRxTimeout.Click, checkPayloadCrcError.Click, checkValidHeader.Click, checkTxDone.Click, checkCadDone.Click, checkFhssChangeChannel.Click, checkCadDetected.Click
        Try
            If sender.Name = "checkRxTimeout" Then _rfm.RfmWrite(&H12, &H80)
            If sender.Name = "checkRxDone" Then _rfm.RfmWrite(&H12, &H40)
            If sender.Name = "checkPayloadCrcError" Then _rfm.RfmWrite(&H12, &H20)
            If sender.Name = "checkValidHeader" Then _rfm.RfmWrite(&H12, &H10)
            If sender.Name = "checkTxDone" Then _rfm.RfmWrite(&H12, &H8)
            If sender.Name = "checkCadDone" Then _rfm.RfmWrite(&H12, &H4)
            If sender.Name = "checkFhssChangeChannel" Then _rfm.RfmWrite(&H12, &H2)
            If sender.Name = "checkCadDetected" Then _rfm.RfmWrite(&H12, &H1)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub bWrite_Click(sender As Object, e As EventArgs) Handles bWrite.Click
        Dim Val = Convert.ToByte(value.Text, 16)
        Dim addr = Convert.ToByte(address.Text, 16)
        _rfm.RfmWrite(addr, Val)
    End Sub

    Private Sub bRead_Click(sender As Object, e As EventArgs) Handles bRead.Click
        Dim addr = Convert.ToByte(address.Text, 16)
        value.Text = Convert.ToString(_rfm.RfmRead(addr), 2)
    End Sub

    Private Sub bPull_Click(sender As Object, e As EventArgs) Handles bPull.Click
        Timer1.Start()
    End Sub
End Class
