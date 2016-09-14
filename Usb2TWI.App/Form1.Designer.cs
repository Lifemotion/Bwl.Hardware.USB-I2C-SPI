namespace USBtoTWIconverter_GUI
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.port_list = new System.Windows.Forms.ComboBox();
            this.bOpen = new System.Windows.Forms.Button();
            this.bScan = new System.Windows.Forms.Button();
            this.dev_addr = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.wr_reg_addr = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.reg_val = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.write_reg = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.bRdSomeReg = new System.Windows.Forms.Button();
            this.rd_some_reg_addr = new System.Windows.Forms.TextBox();
            this.rd_cnt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.bRdReg = new System.Windows.Forms.Button();
            this.rd_reg_addr = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.incom_data = new System.Windows.Forms.TextBox();
            this.bClear = new System.Windows.Forms.Button();
            this.status = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // port_list
            // 
            this.port_list.FormattingEnabled = true;
            this.port_list.Location = new System.Drawing.Point(12, 12);
            this.port_list.Name = "port_list";
            this.port_list.Size = new System.Drawing.Size(59, 21);
            this.port_list.TabIndex = 0;
            // 
            // bOpen
            // 
            this.bOpen.Location = new System.Drawing.Point(78, 11);
            this.bOpen.Name = "bOpen";
            this.bOpen.Size = new System.Drawing.Size(47, 23);
            this.bOpen.TabIndex = 1;
            this.bOpen.Text = "open";
            this.bOpen.UseVisualStyleBackColor = true;
            this.bOpen.Click += new System.EventHandler(this.bOpen_Click);
            // 
            // bScan
            // 
            this.bScan.Location = new System.Drawing.Point(131, 11);
            this.bScan.Name = "bScan";
            this.bScan.Size = new System.Drawing.Size(39, 23);
            this.bScan.TabIndex = 2;
            this.bScan.Text = "scan";
            this.bScan.UseVisualStyleBackColor = true;
            this.bScan.Click += new System.EventHandler(this.bScan_Click);
            // 
            // dev_addr
            // 
            this.dev_addr.Location = new System.Drawing.Point(290, 13);
            this.dev_addr.Name = "dev_addr";
            this.dev_addr.Size = new System.Drawing.Size(36, 20);
            this.dev_addr.TabIndex = 3;
            this.dev_addr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(332, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "DEV ADDR";
            // 
            // wr_reg_addr
            // 
            this.wr_reg_addr.Location = new System.Drawing.Point(8, 36);
            this.wr_reg_addr.Name = "wr_reg_addr";
            this.wr_reg_addr.Size = new System.Drawing.Size(39, 20);
            this.wr_reg_addr.TabIndex = 5;
            this.wr_reg_addr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "REG";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(59, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "VAL";
            // 
            // reg_val
            // 
            this.reg_val.Location = new System.Drawing.Point(53, 36);
            this.reg_val.Name = "reg_val";
            this.reg_val.Size = new System.Drawing.Size(39, 20);
            this.reg_val.TabIndex = 9;
            this.reg_val.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.write_reg);
            this.groupBox1.Controls.Add(this.wr_reg_addr);
            this.groupBox1.Controls.Add(this.reg_val);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 53);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(153, 69);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Write to reg";
            // 
            // write_reg
            // 
            this.write_reg.Location = new System.Drawing.Point(98, 34);
            this.write_reg.Name = "write_reg";
            this.write_reg.Size = new System.Drawing.Size(40, 23);
            this.write_reg.TabIndex = 10;
            this.write_reg.Text = "WR";
            this.write_reg.UseVisualStyleBackColor = true;
            this.write_reg.Click += new System.EventHandler(this.write_reg_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.bRdSomeReg);
            this.groupBox2.Controls.Add(this.rd_some_reg_addr);
            this.groupBox2.Controls.Add(this.rd_cnt);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(282, 53);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(153, 69);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Read some regs";
            // 
            // bRdSomeReg
            // 
            this.bRdSomeReg.Location = new System.Drawing.Point(98, 34);
            this.bRdSomeReg.Name = "bRdSomeReg";
            this.bRdSomeReg.Size = new System.Drawing.Size(40, 23);
            this.bRdSomeReg.TabIndex = 10;
            this.bRdSomeReg.Text = "RD";
            this.bRdSomeReg.UseVisualStyleBackColor = true;
            this.bRdSomeReg.Click += new System.EventHandler(this.bRdSomeReg_Click);
            // 
            // rd_some_reg_addr
            // 
            this.rd_some_reg_addr.Location = new System.Drawing.Point(8, 36);
            this.rd_some_reg_addr.Name = "rd_some_reg_addr";
            this.rd_some_reg_addr.Size = new System.Drawing.Size(39, 20);
            this.rd_some_reg_addr.TabIndex = 5;
            this.rd_some_reg_addr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // rd_cnt
            // 
            this.rd_cnt.Location = new System.Drawing.Point(53, 36);
            this.rd_cnt.Name = "rd_cnt";
            this.rd_cnt.Size = new System.Drawing.Size(39, 20);
            this.rd_cnt.TabIndex = 9;
            this.rd_cnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "REG";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(59, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "CNT";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.bRdReg);
            this.groupBox3.Controls.Add(this.rd_reg_addr);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(171, 53);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(105, 69);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Read single reg";
            // 
            // bRdReg
            // 
            this.bRdReg.Location = new System.Drawing.Point(53, 34);
            this.bRdReg.Name = "bRdReg";
            this.bRdReg.Size = new System.Drawing.Size(40, 23);
            this.bRdReg.TabIndex = 10;
            this.bRdReg.Text = "RD";
            this.bRdReg.UseVisualStyleBackColor = true;
            this.bRdReg.Click += new System.EventHandler(this.bWrReg_Click);
            // 
            // rd_reg_addr
            // 
            this.rd_reg_addr.Location = new System.Drawing.Point(8, 36);
            this.rd_reg_addr.Name = "rd_reg_addr";
            this.rd_reg_addr.Size = new System.Drawing.Size(39, 20);
            this.rd_reg_addr.TabIndex = 5;
            this.rd_reg_addr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "REG";
            // 
            // incom_data
            // 
            this.incom_data.Location = new System.Drawing.Point(12, 128);
            this.incom_data.Multiline = true;
            this.incom_data.Name = "incom_data";
            this.incom_data.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.incom_data.Size = new System.Drawing.Size(423, 126);
            this.incom_data.TabIndex = 12;
            // 
            // bClear
            // 
            this.bClear.Location = new System.Drawing.Point(13, 261);
            this.bClear.Name = "bClear";
            this.bClear.Size = new System.Drawing.Size(420, 23);
            this.bClear.TabIndex = 13;
            this.bClear.Text = "clear";
            this.bClear.UseVisualStyleBackColor = true;
            this.bClear.Click += new System.EventHandler(this.bClear_Click);
            // 
            // status
            // 
            this.status.AutoSize = true;
            this.status.Location = new System.Drawing.Point(12, 290);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(47, 13);
            this.status.TabIndex = 14;
            this.status.Text = "Ready...";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 312);
            this.Controls.Add(this.status);
            this.Controls.Add(this.bClear);
            this.Controls.Add(this.incom_data);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dev_addr);
            this.Controls.Add(this.bScan);
            this.Controls.Add(this.bOpen);
            this.Controls.Add(this.port_list);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "TWI development GUI 1.0";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox port_list;
        private System.Windows.Forms.Button bOpen;
        private System.Windows.Forms.Button bScan;
        private System.Windows.Forms.TextBox dev_addr;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox wr_reg_addr;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox reg_val;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button write_reg;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button bRdSomeReg;
        private System.Windows.Forms.TextBox rd_some_reg_addr;
        private System.Windows.Forms.TextBox rd_cnt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button bRdReg;
        private System.Windows.Forms.TextBox rd_reg_addr;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox incom_data;
        private System.Windows.Forms.Button bClear;
        private System.Windows.Forms.Label status;
    }
}

