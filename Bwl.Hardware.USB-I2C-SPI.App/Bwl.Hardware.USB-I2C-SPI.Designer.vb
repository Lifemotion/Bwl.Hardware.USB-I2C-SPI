<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1

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
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.incom_data = New System.Windows.Forms.TextBox()
        Me.dev_addr = New System.Windows.Forms.TextBox()
        Me.label1 = New System.Windows.Forms.Label()
        Me.bClear = New System.Windows.Forms.Button()
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        Me.write_reg = New System.Windows.Forms.Button()
        Me.wr_reg_addr = New System.Windows.Forms.TextBox()
        Me.reg_val = New System.Windows.Forms.TextBox()
        Me.label2 = New System.Windows.Forms.Label()
        Me.label3 = New System.Windows.Forms.Label()
        Me.groupBox2 = New System.Windows.Forms.GroupBox()
        Me.bRdSomeReg = New System.Windows.Forms.Button()
        Me.rd_some_reg_addr = New System.Windows.Forms.TextBox()
        Me.rd_cnt = New System.Windows.Forms.TextBox()
        Me.label4 = New System.Windows.Forms.Label()
        Me.label5 = New System.Windows.Forms.Label()
        Me.groupBox3 = New System.Windows.Forms.GroupBox()
        Me.bRdReg = New System.Windows.Forms.Button()
        Me.rd_reg_addr = New System.Windows.Forms.TextBox()
        Me.label6 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.bSPI_Read = New System.Windows.Forms.Button()
        Me.spi_incom_data = New System.Windows.Forms.TextBox()
        Me.SPI_data_to_write = New System.Windows.Forms.TextBox()
        Me.bScan = New System.Windows.Forms.Button()
        Me.bOpen = New System.Windows.Forms.Button()
        Me.port_list = New System.Windows.Forms.ComboBox()
        Me.GroupBox5.SuspendLayout()
        Me.groupBox1.SuspendLayout()
        Me.groupBox2.SuspendLayout()
        Me.groupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'logWriter
        '
        Me.logWriter.Location = New System.Drawing.Point(0, 363)
        Me.logWriter.Size = New System.Drawing.Size(778, 149)
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.incom_data)
        Me.GroupBox5.Controls.Add(Me.dev_addr)
        Me.GroupBox5.Controls.Add(Me.label1)
        Me.GroupBox5.Controls.Add(Me.bClear)
        Me.GroupBox5.Controls.Add(Me.groupBox1)
        Me.GroupBox5.Controls.Add(Me.groupBox2)
        Me.GroupBox5.Controls.Add(Me.groupBox3)
        Me.GroupBox5.Location = New System.Drawing.Point(12, 55)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(438, 297)
        Me.GroupBox5.TabIndex = 32
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "I2C"
        '
        'incom_data
        '
        Me.incom_data.Location = New System.Drawing.Point(6, 128)
        Me.incom_data.Multiline = True
        Me.incom_data.Name = "incom_data"
        Me.incom_data.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.incom_data.Size = New System.Drawing.Size(423, 126)
        Me.incom_data.TabIndex = 23
        '
        'dev_addr
        '
        Me.dev_addr.Location = New System.Drawing.Point(17, 27)
        Me.dev_addr.Name = "dev_addr"
        Me.dev_addr.Size = New System.Drawing.Size(36, 20)
        Me.dev_addr.TabIndex = 18
        Me.dev_addr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(59, 30)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(63, 13)
        Me.label1.TabIndex = 19
        Me.label1.Text = "DEV ADDR"
        '
        'bClear
        '
        Me.bClear.Font = New System.Drawing.Font("Consolas", 9.0!)
        Me.bClear.Location = New System.Drawing.Point(7, 261)
        Me.bClear.Name = "bClear"
        Me.bClear.Size = New System.Drawing.Size(420, 23)
        Me.bClear.TabIndex = 24
        Me.bClear.Text = "Clear"
        Me.bClear.UseVisualStyleBackColor = True
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.write_reg)
        Me.groupBox1.Controls.Add(Me.wr_reg_addr)
        Me.groupBox1.Controls.Add(Me.reg_val)
        Me.groupBox1.Controls.Add(Me.label2)
        Me.groupBox1.Controls.Add(Me.label3)
        Me.groupBox1.Location = New System.Drawing.Point(6, 53)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(153, 69)
        Me.groupBox1.TabIndex = 20
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Write to reg"
        '
        'write_reg
        '
        Me.write_reg.Font = New System.Drawing.Font("Consolas", 9.0!)
        Me.write_reg.Location = New System.Drawing.Point(98, 34)
        Me.write_reg.Name = "write_reg"
        Me.write_reg.Size = New System.Drawing.Size(40, 23)
        Me.write_reg.TabIndex = 10
        Me.write_reg.Text = "WR"
        Me.write_reg.UseVisualStyleBackColor = True
        '
        'wr_reg_addr
        '
        Me.wr_reg_addr.Location = New System.Drawing.Point(8, 36)
        Me.wr_reg_addr.Name = "wr_reg_addr"
        Me.wr_reg_addr.Size = New System.Drawing.Size(39, 20)
        Me.wr_reg_addr.TabIndex = 5
        Me.wr_reg_addr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'reg_val
        '
        Me.reg_val.Location = New System.Drawing.Point(53, 36)
        Me.reg_val.Name = "reg_val"
        Me.reg_val.Size = New System.Drawing.Size(39, 20)
        Me.reg_val.TabIndex = 9
        Me.reg_val.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(13, 20)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(30, 13)
        Me.label2.TabIndex = 7
        Me.label2.Text = "REG"
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(59, 20)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(27, 13)
        Me.label3.TabIndex = 8
        Me.label3.Text = "VAL"
        '
        'groupBox2
        '
        Me.groupBox2.Controls.Add(Me.bRdSomeReg)
        Me.groupBox2.Controls.Add(Me.rd_some_reg_addr)
        Me.groupBox2.Controls.Add(Me.rd_cnt)
        Me.groupBox2.Controls.Add(Me.label4)
        Me.groupBox2.Controls.Add(Me.label5)
        Me.groupBox2.Location = New System.Drawing.Point(276, 53)
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.Size = New System.Drawing.Size(153, 69)
        Me.groupBox2.TabIndex = 22
        Me.groupBox2.TabStop = False
        Me.groupBox2.Text = "Read some regs"
        '
        'bRdSomeReg
        '
        Me.bRdSomeReg.Font = New System.Drawing.Font("Consolas", 9.0!)
        Me.bRdSomeReg.Location = New System.Drawing.Point(98, 34)
        Me.bRdSomeReg.Name = "bRdSomeReg"
        Me.bRdSomeReg.Size = New System.Drawing.Size(40, 23)
        Me.bRdSomeReg.TabIndex = 10
        Me.bRdSomeReg.Text = "RD"
        Me.bRdSomeReg.UseVisualStyleBackColor = True
        '
        'rd_some_reg_addr
        '
        Me.rd_some_reg_addr.Location = New System.Drawing.Point(8, 36)
        Me.rd_some_reg_addr.Name = "rd_some_reg_addr"
        Me.rd_some_reg_addr.Size = New System.Drawing.Size(39, 20)
        Me.rd_some_reg_addr.TabIndex = 5
        Me.rd_some_reg_addr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'rd_cnt
        '
        Me.rd_cnt.Location = New System.Drawing.Point(53, 36)
        Me.rd_cnt.Name = "rd_cnt"
        Me.rd_cnt.Size = New System.Drawing.Size(39, 20)
        Me.rd_cnt.TabIndex = 9
        Me.rd_cnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(13, 20)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(30, 13)
        Me.label4.TabIndex = 7
        Me.label4.Text = "REG"
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Location = New System.Drawing.Point(59, 20)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(29, 13)
        Me.label5.TabIndex = 8
        Me.label5.Text = "CNT"
        '
        'groupBox3
        '
        Me.groupBox3.Controls.Add(Me.bRdReg)
        Me.groupBox3.Controls.Add(Me.rd_reg_addr)
        Me.groupBox3.Controls.Add(Me.label6)
        Me.groupBox3.Location = New System.Drawing.Point(165, 53)
        Me.groupBox3.Name = "groupBox3"
        Me.groupBox3.Size = New System.Drawing.Size(105, 69)
        Me.groupBox3.TabIndex = 21
        Me.groupBox3.TabStop = False
        Me.groupBox3.Text = "Read single reg"
        '
        'bRdReg
        '
        Me.bRdReg.Font = New System.Drawing.Font("Consolas", 9.0!)
        Me.bRdReg.Location = New System.Drawing.Point(53, 34)
        Me.bRdReg.Name = "bRdReg"
        Me.bRdReg.Size = New System.Drawing.Size(40, 23)
        Me.bRdReg.TabIndex = 10
        Me.bRdReg.Text = "RD"
        Me.bRdReg.UseVisualStyleBackColor = True
        '
        'rd_reg_addr
        '
        Me.rd_reg_addr.Location = New System.Drawing.Point(8, 36)
        Me.rd_reg_addr.Name = "rd_reg_addr"
        Me.rd_reg_addr.Size = New System.Drawing.Size(39, 20)
        Me.rd_reg_addr.TabIndex = 5
        Me.rd_reg_addr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label6
        '
        Me.label6.AutoSize = True
        Me.label6.Location = New System.Drawing.Point(13, 20)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(30, 13)
        Me.label6.TabIndex = 7
        Me.label6.Text = "REG"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Button1)
        Me.GroupBox4.Controls.Add(Me.bSPI_Read)
        Me.GroupBox4.Controls.Add(Me.spi_incom_data)
        Me.GroupBox4.Controls.Add(Me.SPI_data_to_write)
        Me.GroupBox4.Location = New System.Drawing.Point(456, 55)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(309, 297)
        Me.GroupBox4.TabIndex = 31
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "SPI"
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Consolas", 9.0!)
        Me.Button1.Location = New System.Drawing.Point(242, 259)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(61, 23)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Clear"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'bSPI_Read
        '
        Me.bSPI_Read.Cursor = System.Windows.Forms.Cursors.Default
        Me.bSPI_Read.FlatAppearance.BorderColor = System.Drawing.Color.Blue
        Me.bSPI_Read.Font = New System.Drawing.Font("Consolas", 9.0!)
        Me.bSPI_Read.Location = New System.Drawing.Point(15, 259)
        Me.bSPI_Read.Name = "bSPI_Read"
        Me.bSPI_Read.Size = New System.Drawing.Size(221, 23)
        Me.bSPI_Read.TabIndex = 3
        Me.bSPI_Read.Text = "READ/WRITE"
        Me.bSPI_Read.UseVisualStyleBackColor = True
        '
        'spi_incom_data
        '
        Me.spi_incom_data.Font = New System.Drawing.Font("Consolas", 8.25!)
        Me.spi_incom_data.Location = New System.Drawing.Point(15, 128)
        Me.spi_incom_data.Multiline = True
        Me.spi_incom_data.Name = "spi_incom_data"
        Me.spi_incom_data.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.spi_incom_data.Size = New System.Drawing.Size(288, 126)
        Me.spi_incom_data.TabIndex = 2
        '
        'SPI_data_to_write
        '
        Me.SPI_data_to_write.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.SPI_data_to_write.Location = New System.Drawing.Point(15, 19)
        Me.SPI_data_to_write.Multiline = True
        Me.SPI_data_to_write.Name = "SPI_data_to_write"
        Me.SPI_data_to_write.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SPI_data_to_write.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.SPI_data_to_write.Size = New System.Drawing.Size(288, 101)
        Me.SPI_data_to_write.TabIndex = 0
        '
        'bScan
        '
        Me.bScan.Font = New System.Drawing.Font("Consolas", 9.0!)
        Me.bScan.Location = New System.Drawing.Point(163, 25)
        Me.bScan.Name = "bScan"
        Me.bScan.Size = New System.Drawing.Size(73, 23)
        Me.bScan.TabIndex = 30
        Me.bScan.Text = "scan"
        Me.bScan.UseVisualStyleBackColor = True
        '
        'bOpen
        '
        Me.bOpen.Font = New System.Drawing.Font("Consolas", 9.0!)
        Me.bOpen.Location = New System.Drawing.Point(80, 25)
        Me.bOpen.Name = "bOpen"
        Me.bOpen.Size = New System.Drawing.Size(77, 23)
        Me.bOpen.TabIndex = 29
        Me.bOpen.Text = "open"
        Me.bOpen.UseVisualStyleBackColor = True
        '
        'port_list
        '
        Me.port_list.FormattingEnabled = True
        Me.port_list.Location = New System.Drawing.Point(12, 27)
        Me.port_list.Name = "port_list"
        Me.port_list.Size = New System.Drawing.Size(59, 21)
        Me.port_list.TabIndex = 28
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(778, 512)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.bScan)
        Me.Controls.Add(Me.bOpen)
        Me.Controls.Add(Me.port_list)
        Me.Name = "Form1"
        Me.Text = "TWI/SPI Adaper 1.0"
        Me.Controls.SetChildIndex(Me.logWriter, 0)
        Me.Controls.SetChildIndex(Me.port_list, 0)
        Me.Controls.SetChildIndex(Me.bOpen, 0)
        Me.Controls.SetChildIndex(Me.bScan, 0)
        Me.Controls.SetChildIndex(Me.GroupBox4, 0)
        Me.Controls.SetChildIndex(Me.GroupBox5, 0)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        Me.groupBox2.ResumeLayout(False)
        Me.groupBox2.PerformLayout()
        Me.groupBox3.ResumeLayout(False)
        Me.groupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox5 As GroupBox
    Private WithEvents incom_data As TextBox
    Private WithEvents dev_addr As TextBox
    Private WithEvents label1 As Label
    Private WithEvents bClear As Button
    Private WithEvents groupBox1 As GroupBox
    Private WithEvents write_reg As Button
    Private WithEvents wr_reg_addr As TextBox
    Private WithEvents reg_val As TextBox
    Private WithEvents label2 As Label
    Private WithEvents label3 As Label
    Private WithEvents groupBox2 As GroupBox
    Private WithEvents bRdSomeReg As Button
    Private WithEvents rd_some_reg_addr As TextBox
    Private WithEvents rd_cnt As TextBox
    Private WithEvents label4 As Label
    Private WithEvents label5 As Label
    Private WithEvents groupBox3 As GroupBox
    Private WithEvents bRdReg As Button
    Private WithEvents rd_reg_addr As TextBox
    Private WithEvents label6 As Label
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents Button1 As Button
    Friend WithEvents bSPI_Read As Button
    Friend WithEvents spi_incom_data As TextBox
    Friend WithEvents SPI_data_to_write As TextBox
    Private WithEvents bScan As Button
    Private WithEvents bOpen As Button
    Private WithEvents port_list As ComboBox
End Class
