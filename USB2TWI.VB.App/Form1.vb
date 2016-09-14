Imports System.IO.Ports
Public Class Form1
    Private adp As Adapter

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ports As String() = SerialPort.GetPortNames()
        For Each p As String In ports
            port_list.Items.Add(p)
        Next
    End Sub

    Private Sub bRdReg_Click(sender As Object, e As EventArgs) Handles bRdReg.Click
        Dim addr As Byte = Convert.ToByte(dev_addr.Text, 16)
        Dim reg_addr As Byte = Convert.ToByte(rd_reg_addr.Text, 16)
        Dim resp As Byte = adp.ReadRegister(addr, reg_addr)
        incom_data.Text = incom_data.Text + "val of 0x" + BitConverter.ToString(New Byte() {reg_addr}) + ": 0x" + BitConverter.ToString(New Byte() {resp}) + Environment.NewLine
        incom_data.SelectionStart = incom_data.Text.Length
        incom_data.ScrollToCaret()
        status.Text = "read successfully"
    End Sub

    Private Sub bOpen_Click(sender As Object, e As EventArgs) Handles bOpen.Click
        If bOpen.Text.Equals("open") Then
            adp = New Adapter(port_list.SelectedItem.ToString())
            bOpen.Text = "close"
        ElseIf bOpen.Text.Equals("close") Then
            adp = Nothing
            bOpen.Text = "open"
        End If
        bOpen.Refresh()
    End Sub

    Private Sub write_reg_Click(sender As Object, e As EventArgs) Handles write_reg.Click
        Dim rg_addr As Byte = Convert.ToByte(wr_reg_addr.Text, 16)
        Dim rg_value As Byte = Convert.ToByte(reg_val.Text, 16)
        Dim addr As Byte = Convert.ToByte(dev_addr.Text, 16)
        adp.WriteRegister(addr, rg_addr, rg_value)
        status.Text = "read registers successfully"
    End Sub

    Private Sub bRdSomeReg_Click(sender As Object, e As EventArgs) Handles bRdSomeReg.Click
        Dim rg_addr As Byte = Convert.ToByte(rd_some_reg_addr.Text, 16)
        Dim count As Byte = Convert.ToByte(rd_cnt.Text, 16)
        Dim addr As Byte = Convert.ToByte(dev_addr.Text, 16)
        Dim resp = adp.ReadRegistersArray(addr, rg_addr, count)
        incom_data.Text = incom_data.Text + "starting with 0x" + BitConverter.ToString(New Byte() {rg_addr}) + ": 0x" + BitConverter.ToString(resp).Replace("-", " 0x") + Environment.NewLine
        incom_data.SelectionStart = incom_data.Text.Length
        incom_data.ScrollToCaret()
    End Sub

    Private Sub bClear_Click(sender As Object, e As EventArgs) Handles bClear.Click
        incom_data.Text = ""
    End Sub

    Private Sub bScan_Click(sender As Object, e As EventArgs) Handles bScan.Click
        port_list.Items.Clear()
        Dim ports As String() = SerialPort.GetPortNames()
        For Each p As String In ports
            port_list.Items.Add(p)
        Next
    End Sub

    Private Sub pSPI_Write_Click(sender As Object, e As EventArgs) Handles pSPI_Write.Click
        Dim str_bytes = SPI_data_to_write.Text.Split(" ")
        Dim bytes(str_bytes.Length) As Byte
        For index As Integer = 0 To str_bytes.Length
            bytes(index) = Convert.ToByte(str_bytes(index), 16)
        Next
        SPI_data_to_write.Text = ""
    End Sub

    Private Sub bSPI_Read_Click(sender As Object, e As EventArgs) Handles bSPI_Read.Click
        Dim d_len = Convert.ToByte(spi_read_len.Text, 16)
        Dim data = adp.SpiReadArray(d_len)
        spi_incom_data.Text = spi_incom_data.Text + "0x" + BitConverter.ToString(data).Replace("-", " 0x") + Environment.NewLine
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        spi_incom_data.Text = ""
    End Sub
End Class
