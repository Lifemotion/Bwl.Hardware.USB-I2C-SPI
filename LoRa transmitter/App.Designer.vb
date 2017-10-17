<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class App
    Inherits Bwl.Framework.FormAppBase

    'Форма переопределяет dispose для очистки списка компонентов.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Является обязательной для конструктора форм Windows Forms
    Private components As System.ComponentModel.IContainer

    'Примечание: следующая процедура является обязательной для конструктора форм Windows Forms
    'Для ее изменения используйте конструктор форм Windows Form.  
    'Не изменяйте ее в редакторе исходного кода.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(App))
        Me.Send = New System.Windows.Forms.Button()
        Me.textMessage = New System.Windows.Forms.TextBox()
        Me.receiveMessages = New System.Windows.Forms.TextBox()
        Me.textMyAddress = New System.Windows.Forms.TextBox()
        Me.textTargetAddress = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.OK = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.checkRxTimeout = New System.Windows.Forms.CheckBox()
        Me.checkRxDone = New System.Windows.Forms.CheckBox()
        Me.checkPayloadCrcError = New System.Windows.Forms.CheckBox()
        Me.checkValidHeader = New System.Windows.Forms.CheckBox()
        Me.checkTxDone = New System.Windows.Forms.CheckBox()
        Me.checkCadDone = New System.Windows.Forms.CheckBox()
        Me.checkFhssChangeChannel = New System.Windows.Forms.CheckBox()
        Me.checkCadDetected = New System.Windows.Forms.CheckBox()
        Me.checkRxCodingRate2 = New System.Windows.Forms.CheckBox()
        Me.checkRxCodingRate1 = New System.Windows.Forms.CheckBox()
        Me.checkRxCodingRate0 = New System.Windows.Forms.CheckBox()
        Me.checkModemClear = New System.Windows.Forms.CheckBox()
        Me.checkHeaderValid = New System.Windows.Forms.CheckBox()
        Me.checkRXonGoing = New System.Windows.Forms.CheckBox()
        Me.checkSynchronized = New System.Windows.Forms.CheckBox()
        Me.checkSignalDetected = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.textFifoRxBytesNb = New System.Windows.Forms.TextBox()
        Me.textValidHeaderCntMsb = New System.Windows.Forms.TextBox()
        Me.textValidHeaderCntLsb = New System.Windows.Forms.TextBox()
        Me.textValidPacketCntMsb = New System.Windows.Forms.TextBox()
        Me.textValidPacketCntLsb = New System.Windows.Forms.TextBox()
        Me.textRegFifoRxByteAddr = New System.Windows.Forms.TextBox()
        Me.textRegPktRssiValue = New System.Windows.Forms.TextBox()
        Me.textRegRssiValue = New System.Windows.Forms.TextBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.address = New System.Windows.Forms.TextBox()
        Me.value = New System.Windows.Forms.TextBox()
        Me.bRead = New System.Windows.Forms.Button()
        Me.bWrite = New System.Windows.Forms.Button()
        Me.bPull = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.textReceivedString = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'logWriter
        '
        Me.logWriter.Location = New System.Drawing.Point(0, 279)
        Me.logWriter.Size = New System.Drawing.Size(801, 156)
        '
        'Send
        '
        Me.Send.Location = New System.Drawing.Point(149, 28)
        Me.Send.Name = "Send"
        Me.Send.Size = New System.Drawing.Size(85, 23)
        Me.Send.TabIndex = 2
        Me.Send.Text = "bSend"
        Me.Send.UseVisualStyleBackColor = True
        '
        'textMessage
        '
        Me.textMessage.Location = New System.Drawing.Point(12, 30)
        Me.textMessage.Name = "textMessage"
        Me.textMessage.Size = New System.Drawing.Size(131, 20)
        Me.textMessage.TabIndex = 3
        '
        'receiveMessages
        '
        Me.receiveMessages.Location = New System.Drawing.Point(13, 66)
        Me.receiveMessages.Multiline = True
        Me.receiveMessages.Name = "receiveMessages"
        Me.receiveMessages.Size = New System.Drawing.Size(221, 100)
        Me.receiveMessages.TabIndex = 4
        '
        'textMyAddress
        '
        Me.textMyAddress.Location = New System.Drawing.Point(545, 31)
        Me.textMyAddress.Name = "textMyAddress"
        Me.textMyAddress.Size = New System.Drawing.Size(63, 20)
        Me.textMyAddress.TabIndex = 5
        '
        'textTargetAddress
        '
        Me.textTargetAddress.Location = New System.Drawing.Point(658, 30)
        Me.textTargetAddress.Name = "textTargetAddress"
        Me.textTargetAddress.Size = New System.Drawing.Size(63, 20)
        Me.textTargetAddress.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(498, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Device"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(614, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Target"
        '
        'OK
        '
        Me.OK.Location = New System.Drawing.Point(727, 28)
        Me.OK.Name = "OK"
        Me.OK.Size = New System.Drawing.Size(42, 23)
        Me.OK.TabIndex = 9
        Me.OK.Text = "bStart"
        Me.OK.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(240, 66)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "RegIrqFlags"
        '
        'checkRxTimeout
        '
        Me.checkRxTimeout.AutoSize = True
        Me.checkRxTimeout.Location = New System.Drawing.Point(243, 82)
        Me.checkRxTimeout.Name = "checkRxTimeout"
        Me.checkRxTimeout.Size = New System.Drawing.Size(77, 17)
        Me.checkRxTimeout.TabIndex = 11
        Me.checkRxTimeout.Text = "RxTimeout"
        Me.checkRxTimeout.UseVisualStyleBackColor = True
        '
        'checkRxDone
        '
        Me.checkRxDone.AutoSize = True
        Me.checkRxDone.Location = New System.Drawing.Point(243, 105)
        Me.checkRxDone.Name = "checkRxDone"
        Me.checkRxDone.Size = New System.Drawing.Size(65, 17)
        Me.checkRxDone.TabIndex = 12
        Me.checkRxDone.Text = "RxDone"
        Me.checkRxDone.UseVisualStyleBackColor = True
        '
        'checkPayloadCrcError
        '
        Me.checkPayloadCrcError.AutoSize = True
        Me.checkPayloadCrcError.Location = New System.Drawing.Point(243, 129)
        Me.checkPayloadCrcError.Name = "checkPayloadCrcError"
        Me.checkPayloadCrcError.Size = New System.Drawing.Size(102, 17)
        Me.checkPayloadCrcError.TabIndex = 13
        Me.checkPayloadCrcError.Text = "PayloadCrcError"
        Me.checkPayloadCrcError.UseVisualStyleBackColor = True
        '
        'checkValidHeader
        '
        Me.checkValidHeader.AutoSize = True
        Me.checkValidHeader.Location = New System.Drawing.Point(243, 153)
        Me.checkValidHeader.Name = "checkValidHeader"
        Me.checkValidHeader.Size = New System.Drawing.Size(84, 17)
        Me.checkValidHeader.TabIndex = 14
        Me.checkValidHeader.Text = "ValidHeader"
        Me.checkValidHeader.UseVisualStyleBackColor = True
        '
        'checkTxDone
        '
        Me.checkTxDone.AutoSize = True
        Me.checkTxDone.Location = New System.Drawing.Point(243, 177)
        Me.checkTxDone.Name = "checkTxDone"
        Me.checkTxDone.Size = New System.Drawing.Size(64, 17)
        Me.checkTxDone.TabIndex = 15
        Me.checkTxDone.Text = "TxDone"
        Me.checkTxDone.UseVisualStyleBackColor = True
        '
        'checkCadDone
        '
        Me.checkCadDone.AutoSize = True
        Me.checkCadDone.Location = New System.Drawing.Point(243, 201)
        Me.checkCadDone.Name = "checkCadDone"
        Me.checkCadDone.Size = New System.Drawing.Size(71, 17)
        Me.checkCadDone.TabIndex = 16
        Me.checkCadDone.Text = "CadDone"
        Me.checkCadDone.UseVisualStyleBackColor = True
        '
        'checkFhssChangeChannel
        '
        Me.checkFhssChangeChannel.AutoSize = True
        Me.checkFhssChangeChannel.Location = New System.Drawing.Point(243, 225)
        Me.checkFhssChangeChannel.Name = "checkFhssChangeChannel"
        Me.checkFhssChangeChannel.Size = New System.Drawing.Size(124, 17)
        Me.checkFhssChangeChannel.TabIndex = 17
        Me.checkFhssChangeChannel.Text = "FhssChangeChannel"
        Me.checkFhssChangeChannel.UseVisualStyleBackColor = True
        '
        'checkCadDetected
        '
        Me.checkCadDetected.AutoSize = True
        Me.checkCadDetected.Location = New System.Drawing.Point(243, 249)
        Me.checkCadDetected.Name = "checkCadDetected"
        Me.checkCadDetected.Size = New System.Drawing.Size(89, 17)
        Me.checkCadDetected.TabIndex = 18
        Me.checkCadDetected.Text = "CadDetected"
        Me.checkCadDetected.UseVisualStyleBackColor = True
        '
        'checkRxCodingRate2
        '
        Me.checkRxCodingRate2.AutoSize = True
        Me.checkRxCodingRate2.Location = New System.Drawing.Point(381, 82)
        Me.checkRxCodingRate2.Name = "checkRxCodingRate2"
        Me.checkRxCodingRate2.Size = New System.Drawing.Size(101, 17)
        Me.checkRxCodingRate2.TabIndex = 19
        Me.checkRxCodingRate2.Text = "RxCodingRate2"
        Me.checkRxCodingRate2.UseVisualStyleBackColor = True
        '
        'checkRxCodingRate1
        '
        Me.checkRxCodingRate1.AutoSize = True
        Me.checkRxCodingRate1.Location = New System.Drawing.Point(381, 105)
        Me.checkRxCodingRate1.Name = "checkRxCodingRate1"
        Me.checkRxCodingRate1.Size = New System.Drawing.Size(101, 17)
        Me.checkRxCodingRate1.TabIndex = 20
        Me.checkRxCodingRate1.Text = "RxCodingRate1"
        Me.checkRxCodingRate1.UseVisualStyleBackColor = True
        '
        'checkRxCodingRate0
        '
        Me.checkRxCodingRate0.AutoSize = True
        Me.checkRxCodingRate0.Location = New System.Drawing.Point(381, 129)
        Me.checkRxCodingRate0.Name = "checkRxCodingRate0"
        Me.checkRxCodingRate0.Size = New System.Drawing.Size(101, 17)
        Me.checkRxCodingRate0.TabIndex = 21
        Me.checkRxCodingRate0.Text = "RxCodingRate0"
        Me.checkRxCodingRate0.UseVisualStyleBackColor = True
        '
        'checkModemClear
        '
        Me.checkModemClear.AutoSize = True
        Me.checkModemClear.Location = New System.Drawing.Point(381, 153)
        Me.checkModemClear.Name = "checkModemClear"
        Me.checkModemClear.Size = New System.Drawing.Size(87, 17)
        Me.checkModemClear.TabIndex = 22
        Me.checkModemClear.Text = "Modem clear"
        Me.checkModemClear.UseVisualStyleBackColor = True
        '
        'checkHeaderValid
        '
        Me.checkHeaderValid.AutoSize = True
        Me.checkHeaderValid.Location = New System.Drawing.Point(381, 177)
        Me.checkHeaderValid.Name = "checkHeaderValid"
        Me.checkHeaderValid.Size = New System.Drawing.Size(106, 17)
        Me.checkHeaderValid.TabIndex = 23
        Me.checkHeaderValid.Text = "Header info valid"
        Me.checkHeaderValid.UseVisualStyleBackColor = True
        '
        'checkRXonGoing
        '
        Me.checkRXonGoing.AutoSize = True
        Me.checkRXonGoing.Location = New System.Drawing.Point(381, 201)
        Me.checkRXonGoing.Name = "checkRXonGoing"
        Me.checkRXonGoing.Size = New System.Drawing.Size(85, 17)
        Me.checkRXonGoing.TabIndex = 24
        Me.checkRXonGoing.Text = "RX on-going"
        Me.checkRXonGoing.UseVisualStyleBackColor = True
        '
        'checkSynchronized
        '
        Me.checkSynchronized.AutoSize = True
        Me.checkSynchronized.Location = New System.Drawing.Point(381, 225)
        Me.checkSynchronized.Name = "checkSynchronized"
        Me.checkSynchronized.Size = New System.Drawing.Size(120, 17)
        Me.checkSynchronized.TabIndex = 25
        Me.checkSynchronized.Text = "Signal synchronized"
        Me.checkSynchronized.UseVisualStyleBackColor = True
        '
        'checkSignalDetected
        '
        Me.checkSignalDetected.AutoSize = True
        Me.checkSignalDetected.Location = New System.Drawing.Point(381, 249)
        Me.checkSignalDetected.Name = "checkSignalDetected"
        Me.checkSignalDetected.Size = New System.Drawing.Size(100, 17)
        Me.checkSignalDetected.TabIndex = 26
        Me.checkSignalDetected.Text = "Signal detected"
        Me.checkSignalDetected.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(378, 66)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(81, 13)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "RegModemStat"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(528, 130)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(98, 13)
        Me.Label5.TabIndex = 28
        Me.Label5.Text = "ValidHeaderCntLsb"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(528, 106)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(101, 13)
        Me.Label6.TabIndex = 29
        Me.Label6.Text = "ValidHeaderCntMsb"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(528, 83)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(77, 13)
        Me.Label7.TabIndex = 30
        Me.Label7.Text = "FifoRxBytesNb"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(528, 154)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(100, 13)
        Me.Label8.TabIndex = 31
        Me.Label8.Text = "ValidPacketCntMsb"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(528, 178)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(97, 13)
        Me.Label9.TabIndex = 32
        Me.Label9.Text = "ValidPacketCntLsb"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(528, 202)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(100, 13)
        Me.Label10.TabIndex = 33
        Me.Label10.Text = "RegFifoRxByteAddr"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(528, 226)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(90, 13)
        Me.Label11.TabIndex = 34
        Me.Label11.Text = "RegPktRssiValue"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(528, 250)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(74, 13)
        Me.Label12.TabIndex = 35
        Me.Label12.Text = "RegRssiValue"
        '
        'textFifoRxBytesNb
        '
        Me.textFifoRxBytesNb.Location = New System.Drawing.Point(669, 80)
        Me.textFifoRxBytesNb.Name = "textFifoRxBytesNb"
        Me.textFifoRxBytesNb.Size = New System.Drawing.Size(100, 20)
        Me.textFifoRxBytesNb.TabIndex = 36
        '
        'textValidHeaderCntMsb
        '
        Me.textValidHeaderCntMsb.Location = New System.Drawing.Point(669, 103)
        Me.textValidHeaderCntMsb.Name = "textValidHeaderCntMsb"
        Me.textValidHeaderCntMsb.Size = New System.Drawing.Size(100, 20)
        Me.textValidHeaderCntMsb.TabIndex = 37
        '
        'textValidHeaderCntLsb
        '
        Me.textValidHeaderCntLsb.Location = New System.Drawing.Point(669, 127)
        Me.textValidHeaderCntLsb.Name = "textValidHeaderCntLsb"
        Me.textValidHeaderCntLsb.Size = New System.Drawing.Size(100, 20)
        Me.textValidHeaderCntLsb.TabIndex = 38
        '
        'textValidPacketCntMsb
        '
        Me.textValidPacketCntMsb.Location = New System.Drawing.Point(669, 151)
        Me.textValidPacketCntMsb.Name = "textValidPacketCntMsb"
        Me.textValidPacketCntMsb.Size = New System.Drawing.Size(100, 20)
        Me.textValidPacketCntMsb.TabIndex = 39
        '
        'textValidPacketCntLsb
        '
        Me.textValidPacketCntLsb.Location = New System.Drawing.Point(669, 175)
        Me.textValidPacketCntLsb.Name = "textValidPacketCntLsb"
        Me.textValidPacketCntLsb.Size = New System.Drawing.Size(100, 20)
        Me.textValidPacketCntLsb.TabIndex = 40
        '
        'textRegFifoRxByteAddr
        '
        Me.textRegFifoRxByteAddr.Location = New System.Drawing.Point(669, 199)
        Me.textRegFifoRxByteAddr.Name = "textRegFifoRxByteAddr"
        Me.textRegFifoRxByteAddr.Size = New System.Drawing.Size(100, 20)
        Me.textRegFifoRxByteAddr.TabIndex = 41
        '
        'textRegPktRssiValue
        '
        Me.textRegPktRssiValue.Location = New System.Drawing.Point(669, 223)
        Me.textRegPktRssiValue.Name = "textRegPktRssiValue"
        Me.textRegPktRssiValue.Size = New System.Drawing.Size(100, 20)
        Me.textRegPktRssiValue.TabIndex = 42
        '
        'textRegRssiValue
        '
        Me.textRegRssiValue.Location = New System.Drawing.Point(669, 247)
        Me.textRegRssiValue.Name = "textRegRssiValue"
        Me.textRegRssiValue.Size = New System.Drawing.Size(100, 20)
        Me.textRegRssiValue.TabIndex = 43
        '
        'Timer1
        '
        Me.Timer1.Interval = 2000
        '
        'address
        '
        Me.address.Location = New System.Drawing.Point(13, 178)
        Me.address.Name = "address"
        Me.address.Size = New System.Drawing.Size(86, 20)
        Me.address.TabIndex = 44
        '
        'value
        '
        Me.value.Location = New System.Drawing.Point(149, 178)
        Me.value.Name = "value"
        Me.value.Size = New System.Drawing.Size(85, 20)
        Me.value.TabIndex = 45
        '
        'bRead
        '
        Me.bRead.Location = New System.Drawing.Point(13, 205)
        Me.bRead.Name = "bRead"
        Me.bRead.Size = New System.Drawing.Size(86, 23)
        Me.bRead.TabIndex = 46
        Me.bRead.Text = "Read"
        Me.bRead.UseVisualStyleBackColor = True
        '
        'bWrite
        '
        Me.bWrite.Location = New System.Drawing.Point(148, 205)
        Me.bWrite.Name = "bWrite"
        Me.bWrite.Size = New System.Drawing.Size(86, 23)
        Me.bWrite.TabIndex = 47
        Me.bWrite.Text = "Write"
        Me.bWrite.UseVisualStyleBackColor = True
        '
        'bPull
        '
        Me.bPull.Location = New System.Drawing.Point(247, 29)
        Me.bPull.Name = "bPull"
        Me.bPull.Size = New System.Drawing.Size(221, 23)
        Me.bPull.TabIndex = 48
        Me.bPull.Text = "Pulling Start"
        Me.bPull.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(12, 247)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(56, 13)
        Me.Label13.TabIndex = 49
        Me.Label13.Text = "Received:"
        '
        'textReceivedString
        '
        Me.textReceivedString.Location = New System.Drawing.Point(74, 244)
        Me.textReceivedString.Name = "textReceivedString"
        Me.textReceivedString.Size = New System.Drawing.Size(160, 20)
        Me.textReceivedString.TabIndex = 50
        '
        'App
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(810, 444)
        Me.Controls.Add(Me.textReceivedString)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.bPull)
        Me.Controls.Add(Me.bWrite)
        Me.Controls.Add(Me.bRead)
        Me.Controls.Add(Me.value)
        Me.Controls.Add(Me.address)
        Me.Controls.Add(Me.textRegRssiValue)
        Me.Controls.Add(Me.textRegPktRssiValue)
        Me.Controls.Add(Me.textRegFifoRxByteAddr)
        Me.Controls.Add(Me.textValidPacketCntLsb)
        Me.Controls.Add(Me.textValidPacketCntMsb)
        Me.Controls.Add(Me.textValidHeaderCntLsb)
        Me.Controls.Add(Me.textValidHeaderCntMsb)
        Me.Controls.Add(Me.textFifoRxBytesNb)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.checkSignalDetected)
        Me.Controls.Add(Me.checkSynchronized)
        Me.Controls.Add(Me.checkRXonGoing)
        Me.Controls.Add(Me.checkHeaderValid)
        Me.Controls.Add(Me.checkModemClear)
        Me.Controls.Add(Me.checkRxCodingRate0)
        Me.Controls.Add(Me.checkRxCodingRate1)
        Me.Controls.Add(Me.checkRxCodingRate2)
        Me.Controls.Add(Me.checkCadDetected)
        Me.Controls.Add(Me.checkFhssChangeChannel)
        Me.Controls.Add(Me.checkCadDone)
        Me.Controls.Add(Me.checkTxDone)
        Me.Controls.Add(Me.checkValidHeader)
        Me.Controls.Add(Me.checkPayloadCrcError)
        Me.Controls.Add(Me.checkRxDone)
        Me.Controls.Add(Me.checkRxTimeout)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.OK)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.textTargetAddress)
        Me.Controls.Add(Me.textMyAddress)
        Me.Controls.Add(Me.receiveMessages)
        Me.Controls.Add(Me.textMessage)
        Me.Controls.Add(Me.Send)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "App"
        Me.Text = "LoRa App"
        Me.Controls.SetChildIndex(Me.logWriter, 0)
        Me.Controls.SetChildIndex(Me.Send, 0)
        Me.Controls.SetChildIndex(Me.textMessage, 0)
        Me.Controls.SetChildIndex(Me.receiveMessages, 0)
        Me.Controls.SetChildIndex(Me.textMyAddress, 0)
        Me.Controls.SetChildIndex(Me.textTargetAddress, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.OK, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.checkRxTimeout, 0)
        Me.Controls.SetChildIndex(Me.checkRxDone, 0)
        Me.Controls.SetChildIndex(Me.checkPayloadCrcError, 0)
        Me.Controls.SetChildIndex(Me.checkValidHeader, 0)
        Me.Controls.SetChildIndex(Me.checkTxDone, 0)
        Me.Controls.SetChildIndex(Me.checkCadDone, 0)
        Me.Controls.SetChildIndex(Me.checkFhssChangeChannel, 0)
        Me.Controls.SetChildIndex(Me.checkCadDetected, 0)
        Me.Controls.SetChildIndex(Me.checkRxCodingRate2, 0)
        Me.Controls.SetChildIndex(Me.checkRxCodingRate1, 0)
        Me.Controls.SetChildIndex(Me.checkRxCodingRate0, 0)
        Me.Controls.SetChildIndex(Me.checkModemClear, 0)
        Me.Controls.SetChildIndex(Me.checkHeaderValid, 0)
        Me.Controls.SetChildIndex(Me.checkRXonGoing, 0)
        Me.Controls.SetChildIndex(Me.checkSynchronized, 0)
        Me.Controls.SetChildIndex(Me.checkSignalDetected, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.Label10, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.Controls.SetChildIndex(Me.Label12, 0)
        Me.Controls.SetChildIndex(Me.textFifoRxBytesNb, 0)
        Me.Controls.SetChildIndex(Me.textValidHeaderCntMsb, 0)
        Me.Controls.SetChildIndex(Me.textValidHeaderCntLsb, 0)
        Me.Controls.SetChildIndex(Me.textValidPacketCntMsb, 0)
        Me.Controls.SetChildIndex(Me.textValidPacketCntLsb, 0)
        Me.Controls.SetChildIndex(Me.textRegFifoRxByteAddr, 0)
        Me.Controls.SetChildIndex(Me.textRegPktRssiValue, 0)
        Me.Controls.SetChildIndex(Me.textRegRssiValue, 0)
        Me.Controls.SetChildIndex(Me.address, 0)
        Me.Controls.SetChildIndex(Me.value, 0)
        Me.Controls.SetChildIndex(Me.bRead, 0)
        Me.Controls.SetChildIndex(Me.bWrite, 0)
        Me.Controls.SetChildIndex(Me.bPull, 0)
        Me.Controls.SetChildIndex(Me.Label13, 0)
        Me.Controls.SetChildIndex(Me.textReceivedString, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Send As Button
    Friend WithEvents textMessage As TextBox
    Friend WithEvents receiveMessages As TextBox
    Friend WithEvents textMyAddress As TextBox
    Friend WithEvents textTargetAddress As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents OK As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents checkRxTimeout As CheckBox
    Friend WithEvents checkRxDone As CheckBox
    Friend WithEvents checkPayloadCrcError As CheckBox
    Friend WithEvents checkValidHeader As CheckBox
    Friend WithEvents checkTxDone As CheckBox
    Friend WithEvents checkCadDone As CheckBox
    Friend WithEvents checkFhssChangeChannel As CheckBox
    Friend WithEvents checkCadDetected As CheckBox
    Friend WithEvents checkRxCodingRate2 As CheckBox
    Friend WithEvents checkRxCodingRate1 As CheckBox
    Friend WithEvents checkRxCodingRate0 As CheckBox
    Friend WithEvents checkModemClear As CheckBox
    Friend WithEvents checkHeaderValid As CheckBox
    Friend WithEvents checkRXonGoing As CheckBox
    Friend WithEvents checkSynchronized As CheckBox
    Friend WithEvents checkSignalDetected As CheckBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents textFifoRxBytesNb As TextBox
    Friend WithEvents textValidHeaderCntMsb As TextBox
    Friend WithEvents textValidHeaderCntLsb As TextBox
    Friend WithEvents textValidPacketCntMsb As TextBox
    Friend WithEvents textValidPacketCntLsb As TextBox
    Friend WithEvents textRegFifoRxByteAddr As TextBox
    Friend WithEvents textRegPktRssiValue As TextBox
    Friend WithEvents textRegRssiValue As TextBox
    Friend WithEvents Timer1 As Timer
    Friend WithEvents address As TextBox
    Friend WithEvents value As TextBox
    Friend WithEvents bRead As Button
    Friend WithEvents bWrite As Button
    Friend WithEvents bPull As Button
    Friend WithEvents Label13 As Label
    Friend WithEvents textReceivedString As TextBox
End Class
