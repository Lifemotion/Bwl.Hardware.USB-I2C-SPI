Module LSM303Example

    Sub Main()
        Dim ports = IO.Ports.SerialPort.GetPortNames
        If ports.Length = 0 Then
            Console.WriteLine("No serial devices!")
        ElseIf ports.Length > 1 Then
            Console.WriteLine("Must be only one serial port!")
        Else
            Dim port = ports(0)
            Console.WriteLine("Trying to open port " + port)
            Dim adapter As New UsbSpiTwiAdapter(port)
            Try
                adapter.Open()
                Dim info = adapter.GetAdapterName
                Console.WriteLine("Adapter connected: " + info)
                'TODO: добавить чтение магнитного поля, ускорения, температуры
                Dim magInfo = "X: -120, Y: 450, Z:40"
                Console.WriteLine(magInfo)
            Catch ex As Exception
                Console.WriteLine("Error! " + ex.Message)
            End Try
            Try
                adapter.Close()
            Catch ex As Exception
            End Try
        End If
        Console.ReadLine()
    End Sub

End Module
