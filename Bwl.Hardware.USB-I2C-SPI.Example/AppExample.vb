Imports Bwl.Hardware.USB_I2C_SPI
Module AppExample
    Private LsmAddress As Byte = &H3A
    Sub Main()

        Dim adp As UsbSpiTwiAdapter = New UsbSpiTwiAdapter()
        adp.Open()
        While Not adp.isConnected
            Console.WriteLine("Поиск адаптера")
            Threading.Thread.Sleep(1000)
        End While
        Console.WriteLine("Адаптер обнаружен: " + adp.GetAdapterName)
        Console.WriteLine("Укажите интерфейс:")
        Console.WriteLine("1 - TWI, 2 - SPI")
        Dim mode = Console.ReadLine()
        Console.Clear()
        If mode = "1" Then
            If adp.TwiReadRegister(LsmAddress, &HF) = &H49 Then
                Console.WriteLine("Обнаружен датчик LSM303")
                Console.WriteLine("Запись настроек LSM303")
                adp.TwiWriteRegister(LsmAddress, &H1F, &H0)
                adp.TwiWriteRegister(LsmAddress, &H20, &H4F)
                adp.TwiWriteRegister(LsmAddress, &H21, &HC1)
                adp.TwiWriteRegister(LsmAddress, &H24, &HF0)
                adp.TwiWriteRegister(LsmAddress, &H26, &H20)

                Console.WriteLine("Проверка корректной записи:")
                Console.WriteLine("Регистр 0x1F: " + Conversion.Hex(adp.TwiReadRegister(LsmAddress, &H1F)))
                Console.WriteLine("Регистр 0x20: " + Conversion.Hex(adp.TwiReadRegister(LsmAddress, &H20)))
                Console.WriteLine("Регистр 0x21: " + Conversion.Hex(adp.TwiReadRegister(LsmAddress, &H21)))
                Console.WriteLine("Регистр 0x24: " + Conversion.Hex(adp.TwiReadRegister(LsmAddress, &H24)))
                Console.WriteLine("Регистр 0x26: " + Conversion.Hex(adp.TwiReadRegister(LsmAddress, &H26)))
                Console.WriteLine("")
                Console.WriteLine("Чтение показаний магнетометра:")
                Console.WriteLine("")
                While True
                    Threading.Thread.Sleep(1000)
                    Dim data = adp.TwiReadRegistersArray(LsmAddress, &H88, 6)
                    Console.Write(Chr(13))
                    Console.Write(New String(" ", Console.WindowWidth - 1))
                    Console.Write(Chr(13) + Chr(13) + "X:{0} Y:{1} Z:{2}", BitConverter.ToInt16(data, 0) * 0.16, BitConverter.ToInt16(data, 2) * 0.16, BitConverter.ToInt16(data, 4) * 0.16)
                End While
            Else
                Console.WriteLine("LSM303 не подключен")
            End If

        End If

        If mode = "2" Then
            If adp.SpiReadArray({&H8F, 0})(1) = &H49 Then
                Console.WriteLine("Обнаружен датчик LSM303")
                Console.WriteLine("Активация датчика температуры")
                adp.SpiWriteArray({&H24, &HF0})
                While True
                    Dim data = adp.SpiWriteArray({&HC5, 0, 0})
                    Console.Write(Chr(13) + Chr(13) + "Температура: {0}   ", Math.Round(((data(2) * 256 + data(1)) / 8) + 18, 2))
                    Threading.Thread.Sleep(1000)
                End While
            Else
                Console.WriteLine("LSM303 не подключен")
            End If

        End If
        Console.ReadKey()
    End Sub
End Module
