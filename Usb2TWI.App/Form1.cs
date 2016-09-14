using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace USBtoTWIconverter_GUI
{
    public partial class Form1 : Form
    {
        private SerialPort _port = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            String[] ports = SerialPort.GetPortNames();
            foreach(String port in ports)
            {
                port_list.Items.Add(port);
            }

        }

        private void bScan_Click(object sender, EventArgs e)
        {
            String[] ports = SerialPort.GetPortNames();
            port_list.Items.Clear();
            foreach (String port in ports)
            {
                port_list.Items.Add(port);
            }
        }

        private void bOpen_Click(object sender, EventArgs e)
        {
            if (_port != null && _port.IsOpen)
            {
                _port.Close();
                _port = null;
                bOpen.Text = "open";
            }
            else
            {
                if (port_list.SelectedItem == null) return;
                String port = port_list.SelectedItem.ToString();
                if (port.Length < 1) return;
                try
                {
                    _port = new SerialPort(port, 9600);
                    _port.Open();
                    bOpen.Text = "close";
                } catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void serial_process()
        {
            while (_port.IsOpen)
            {
                while (_port.BytesToRead < 1) ;
                byte[] data = new byte[_port.BytesToRead];
                _port.Read(data, 0, data.Length);
                string hex = BitConverter.ToString(data).Replace("-", " 0x") + " | ";
                this.Invoke((MethodInvoker)delegate {
                    incom_data.Text = incom_data.Text + hex;
                    status.Text = "received " +data.Length + " bytes";
                });
            }
        }

        private void bClear_Click(object sender, EventArgs e)
        {
            incom_data.Text = "";
        }

        private void write_reg_Click(object sender, EventArgs e)
        {
            if (_port == null || !_port.IsOpen) return;
            byte rg_addr  = Convert.ToByte(wr_reg_addr.Text, 16);
            byte rg_value = Convert.ToByte(reg_val.Text, 16);
            byte addr = Convert.ToByte(dev_addr.Text, 16);
            byte[] data = { 0x03, addr, rg_addr, rg_value };
            _port.Write(data, 0, data.Length);
            sync_device();
            status.Text = "register recorded";
        }

        private void sync_device()
        {
           
        }

        private void bWrReg_Click(object sender, EventArgs e)
        {
            if (_port == null || !_port.IsOpen) return;
            byte rg_addr = Convert.ToByte(rd_reg_addr.Text, 16);
            byte addr = Convert.ToByte(dev_addr.Text, 16);
            byte[] data = { 0x02, addr, rg_addr};
            _port.Write(data, 0, data.Length);
            while (_port.BytesToRead < 1) ;
            byte resp = (byte)_port.ReadByte();
            incom_data.Text = incom_data.Text + "val of 0x"+ BitConverter.ToString(new byte[] { rg_addr }) + ": 0x"+ BitConverter.ToString(new byte[] { resp }) + Environment.NewLine;
            sync_device();
            status.Text = "read successfully";
        }

        private void bRdSomeReg_Click(object sender, EventArgs e)
        {
            if (_port == null || !_port.IsOpen) return;
            byte rg_addr = Convert.ToByte(rd_some_reg_addr.Text, 16);
            byte count = Convert.ToByte(rd_cnt.Text, 16);
            byte addr = Convert.ToByte(dev_addr.Text, 16);
            byte[] data = { 0x04, addr, rg_addr, count };
            _port.Write(data, 0, data.Length);
            while (_port.BytesToRead < count) ;
            byte[] resp = new byte[count];
            _port.Read(resp, 0, count);
            incom_data.Text = incom_data.Text + "starting with 0x" + BitConverter.ToString(new byte[] { rg_addr }) + ": 0x" + BitConverter.ToString(resp).Replace("-", " 0x") + Environment.NewLine;
            sync_device();
            status.Text = "read registers successfully";
        }
    }
}
