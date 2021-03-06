﻿using System;
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
            int selectedOption;
            bool success = true;
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
                    if (Int32.TryParse(Console.ReadKey().KeyChar.ToString(), out selectedOption))
                    {
                        switch (selectedOption)
                        {
                            case 1: // output device list
                                Console.Clear();
                                PrintDeviceList(deviceList);
                                Console.ReadKey();
                                break;
                            case 2: // add new device
                                do
                                {
                                    Console.Clear();
                                    Console.WriteLine("1) -Tablet");
                                    Console.WriteLine("2) -Smartphone");
                                    Console.WriteLine("3) -Notebook");
                                    if(!success)
                                        Console.WriteLine("ungültige Eingabe!");
                                    success = true;

                                    if (Int32.TryParse(Console.ReadKey().KeyChar.ToString(), out selectedOption))
                                    {
                                        switch (selectedOption)
                                        {
                                            case 1:
                                                deviceList.Add(Device.CreateNew<Tablet>());
                                                break;
                                            case 2:
                                                deviceList.Add(Device.CreateNew<Smartphone>());
                                                break;
                                            case 3:
                                                deviceList.Add(Device.CreateNew<Notebook>());
                                                break;
                                            default:
                                                success = false;
                                                break;
                                        }
                                    }
                                } while (!success);
                                
                                break;
                            case 3: // enter edit device mode
                                //List<Device> filteredList = new List<Device>();
                                do
                                {
                                    Console.Clear();
                                    PrintDeviceList(deviceList, true);
                                    //Console.WriteLine("1) -Tablet");
                                    //Console.WriteLine("2) -Smartphone");
                                    //Console.WriteLine("3) -Notebook");
                                    //if (!success)
                                    //    Console.WriteLine("ungültige Eingabe!");
                                    success = true;

                                    if (Int32.TryParse(Console.ReadLine(), out selectedOption))
                                    {
                                        do
                                        {
                                            success = true;
                                            int index = 0;
                                            Device device = deviceList[selectedOption-1];
                                            List<string> propStringList = deviceList[selectedOption-1].ToString().Split('\n').ToList();

                                            Console.Clear();
                                            Console.WriteLine($"  {index++}) -delete Device");
                                            var props = device.GetType().GetProperties().OrderBy(p => p.DeclaringType == typeof(Device) ? 0 : 1);
                                            foreach (var prop in props)
                                            {
                                                Console.WriteLine("{0,3}) -{1,-23}{2}", index++, prop.Name + ":", prop.GetValue(device));
                                            }

                                            int editOption = 0;
                                            if (Int32.TryParse(Console.ReadKey().KeyChar.ToString(), out editOption))
                                            {
                                                switch (editOption)
                                                {
                                                    case 0:
                                                        Console.WriteLine("Sind Sie sich sicher? (Y = Ja)");
                                                        var input = Console.ReadKey().KeyChar;
                                                        if (input == 'y')
                                                            deviceList.RemoveAt(selectedOption-1);
                                                        break;
                                                    //case 2:
                                                    //    Console.Clear();
                                                    //    PrintDeviceList(deviceList);
                                                    //    Console.ReadKey();
                                                    //    break;
                                                    default:
                                                        success = false;
                                                        break;
                                                }
                                            }
                                            else
                                            {
                                                success = false;
                                            }
                                        } while (!success);
                                        //foreach (var value in propStringList)
                                        //{
                                        //    Console.WriteLine($"{index++}) -{value});
                                        //}

                                        //    switch (--selectedOption)
                                        //    {
                                        //        case 1:
                                        //            filteredList = deviceList.Where(device => device.GetType().Name == "Tablet").ToList();
                                        //            break;
                                        //        case 2:
                                        //            filteredList = deviceList.Where(device => device.GetType().Name == "Smartphone").ToList();
                                        //            break;
                                        //        case 3:
                                        //            filteredList = deviceList.Where(device => device.GetType().Name == "Notebook").ToList();
                                        //            break;
                                        //        default:
                                        //            success = false;
                                        //            break;
                                        //    }
                                        //    if(success)
                                        //    {
                                        //        PrintDeviceList(filteredList, true);
                                        //        Console.ReadKey();
                                        //    }
                                    }
                                    else
                                    {
                                        success = false;
                                    }
                                } while (!success);
                                Console.ReadKey();
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
            }
        }

        static void PrintDeviceList(List<Device> list, bool withIndex = false)
        {
            int index = 1;
            foreach (Device device in list)
            {
                Console.WriteLine($"{index++}) {device.GetType().Name}");
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
