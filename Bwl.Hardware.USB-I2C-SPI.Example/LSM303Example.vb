Imports Bwl.Hardware.USB_I2C_SPI

Module LSM303Example
    Private _lsmAddress As Byte = &H3A

    Sub Main()
        Dim adp As UsbSpiTwiAdapter = New UsbSpiTwiAdapter()
        adp.Open()
        While Not adp.isConnected
            Console.WriteLine("Поиск адаптера")
            Threading.Thread.Sleep(1000)
        End While
        Console.WriteLine("Адаптер обнаружен: " + adp.GetAdapterName)
        Dim whoIAm = adp.TwiReadRegister(_lsmAddress, &HF)
        If whoIAm = &H49 Then
            Console.WriteLine("Обнаружен датчик LSM303")
            Console.WriteLine("Запись настроек LSM303")
            adp.TwiWriteRegister(_lsmAddress, &H1F, &H0)
            adp.TwiWriteRegister(_lsmAddress, &H20, &H4F)
            adp.TwiWriteRegister(_lsmAddress, &H21, &HC1)
            adp.TwiWriteRegister(_lsmAddress, &H24, &HF0)
            adp.TwiWriteRegister(_lsmAddress, &H26, &H20)

            Console.WriteLine("Проверка корректной записи:")
            Console.WriteLine("Регистр 0x1F: " + Conversion.Hex(adp.TwiReadRegister(_lsmAddress, &H1F)))
            Console.WriteLine("Регистр 0x20: " + Conversion.Hex(adp.TwiReadRegister(_lsmAddress, &H20)))
            Console.WriteLine("Регистр 0x21: " + Conversion.Hex(adp.TwiReadRegister(_lsmAddress, &H21)))
            Console.WriteLine("Регистр 0x24: " + Conversion.Hex(adp.TwiReadRegister(_lsmAddress, &H24)))
            Console.WriteLine("Регистр 0x26: " + Conversion.Hex(adp.TwiReadRegister(_lsmAddress, &H26)))
            Console.WriteLine("")
            Console.WriteLine("Чтение показаний магнетометра:")
            Console.WriteLine("")
            While True
                Threading.Thread.Sleep(1000)
                Dim data = adp.TwiReadRegistersArray(_lsmAddress, &H88, 6)
                Console.Write(Chr(13))
                Console.Write(New String(" ", Console.WindowWidth - 1))
                Console.Write(Chr(13) + Chr(13) + "X:{0} Y:{1} Z:{2}", BitConverter.ToInt16(data, 0) * 0.16, BitConverter.ToInt16(data, 2) * 0.16, BitConverter.ToInt16(data, 4) * 0.16)
            End While
        Else
            Console.WriteLine("LSM303 не подключен")
        End If

        Console.ReadKey()
    End Sub
End Module
