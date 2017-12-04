using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pruefung1_GeraeteVerwaltung
{
    class Program
    {
        static void Main(string[] args)
        {
            var deviceList = DefaultDevices();
            int number;
            string errorText = "";
            while(true)
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("1) -Liste aller eingetragener Geräte");
                    Console.WriteLine("2) -Füge ein neues Gerät hinzu");
                    Console.WriteLine("3) -Gerät bearbeiten");
                    Console.WriteLine("9) -Programm beenden\n");

                    if (errorText.Length != 0)
                    {
                        Console.WriteLine(errorText);
                    }

                    Console.Write("Wähle eine Menuoption aus: ");

                    errorText = "";
                    if (Int32.TryParse(Console.ReadKey().KeyChar.ToString(), out number))
                    {
                        switch (number)
                        {
                            case 1: // output devie list
                                Console.Clear();
                                PrintDeviceList(deviceList);
                                break;
                            case 2: // add new device

                                break;
                            case 3: // enter edit device mode

                                break;
                            case 9: // close programm
                                Environment.Exit(0);
                                break;
                            default:
                                errorText = "ungültige Auswahl!";
                                break;
                        }
                    }
                    else
                    {
                        errorText = "Eingabe muss eine ganze Zahl sein!";
                    }
                } while (errorText.Length != 0);
                Console.ReadKey();
            }
        }

        static void PrintDeviceList(List<Device> list)
        {
            foreach (Device device in list)
            {
                Console.WriteLine(device.GetType().Name);
                if (device != null)
                    Console.WriteLine(device.ToString(1));
            }
        }









        // just for cleaner and more readable main code
        static List<Device> DefaultDevices()
        {
            var deviceList = new List<Device>();

            deviceList.Add(new Smartphone()
            {
                Marke = "IPhone",
                Model = "7S",
                OS = "IOS1.7",
                Arbeitsspeicher = 2,
                Speicherkapazität = 126,
                Bildschirmgrösse = 5,
                Akkulaufzeit = 8,
                Prozessortyp = "I42",
                AnzProzessoren = 2,
                Farbe = Farbe.weiss,
                Kaufpreis = 700.00,
                HatMicroSDSlot = false,
                MaxSpeichererweiterung = 0,
            });

            deviceList.Add(new Smartphone()
            {
                Marke = "Samsung",
                Model = "S7",
                OS = "Android Ice Cream Sandwich",
                Arbeitsspeicher = 2,
                Speicherkapazität = 126,
                Bildschirmgrösse = 5.5,
                Akkulaufzeit = 8,
                Prozessortyp = "I742",
                AnzProzessoren = 3,
                Farbe = Farbe.blau,
                Kaufpreis = 450.00,
                HatMicroSDSlot = true,
                MaxSpeichererweiterung = 126,
            });

            deviceList.Add(new Tablet()
            {
                Marke = "Tablet1",
                Model = "7S",
                OS = "IOS1.7",
                Arbeitsspeicher = 2,
                Speicherkapazität = 126,
                Bildschirmgrösse = 5,
                Akkulaufzeit = 8,
                Prozessortyp = "I42",
                AnzProzessoren = 2,
                Farbe = Farbe.blau,
                Kaufpreis = 700.00,
                HatMicroSDSlot = false,
                Hat4G = true,
            });

            deviceList.Add(new Tablet()
            {
                Marke = "Tablet2",
                Model = "7S",
                OS = "IOS1.7",
                Arbeitsspeicher = 2,
                Speicherkapazität = 126,
                Bildschirmgrösse = 5,
                Akkulaufzeit = 8,
                Prozessortyp = "I42",
                AnzProzessoren = 2,
                Farbe = Farbe.blau,
                Kaufpreis = 700.00,
                HatMicroSDSlot = false,
                Hat4G = false,
            });

            deviceList.Add(new Notebook()
            {
                Marke = "Notebook1",
                Model = "7S",
                OS = "IOS1.7",
                Arbeitsspeicher = 2,
                Speicherkapazität = 126,
                Bildschirmgrösse = 5,
                Akkulaufzeit = 8,
                Prozessortyp = "I42",
                AnzProzessoren = 2,
                Farbe = Farbe.blau,
                Kaufpreis = 700.00,
                SSDGroesse = 126,
                HatBelTastatur = true,
                HatHDMIAnschluss = true
            });

            deviceList.Add(new Notebook()
            {
                Marke = "Notebook2",
                Model = "7S",
                OS = "IOS1.7",
                Arbeitsspeicher = 2,
                Speicherkapazität = 126,
                Bildschirmgrösse = 5,
                Akkulaufzeit = 8,
                Prozessortyp = "I42",
                AnzProzessoren = 2,
                Farbe = Farbe.blau,
                Kaufpreis = 700.00,
                SSDGroesse = 126,
                HatBelTastatur = true,
                HatHDMIAnschluss = false
            });

            return deviceList;
        }
    }
}
