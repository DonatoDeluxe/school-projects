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
        public void PrintData(ArrayList dataList)
        {
            foreach (string data in dataList)
            {
                Console.WriteLine($"{nameof(data)}:\t{data}");
            }
        }

        static void Main(string[] args)
        {
            Device[] deviceList = new Device[50];

            deviceList[0] = new Smartphone()
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
            };

            deviceList[1] = new Smartphone()
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
            };

            deviceList[2] = new Tablet()
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
            };

            deviceList[3] = new Tablet()
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
            };

            deviceList[4] = new Notebook()
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
            };

            deviceList[5] = new Notebook()
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
            };

            PrintList(deviceList);
        }

        static void PrintList(Device[] list)
        {
            foreach (Device device in list)
            {
                if (device != null)
                    device.Print();
            }
        }
    }
}
