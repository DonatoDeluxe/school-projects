using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pruefung1_GeraeteVerwaltung
{
    public enum Farbe { schwarz, grau, weiss, blau, rot, grün }

    abstract class Device
    {
        public string Marke { set; get; }
        public string Model { set; get; }
        public string OS { set; get; }
        public double Arbeitsspeicher { set; get; }
        public double Speicherkapazität { set; get; }
        public double Bildschirmgrösse { set; get; }
        public double Akkulaufzeit { set; get; }
        public string Prozessortyp { set; get; }
        public int AnzProzessoren { set; get; }
        public Farbe Farbe { set; get; }
        public double Kaufpreis { set; get; }

        public virtual void Print(string className = "")
        {
            //var props = Device.GetProperties();
            //foreach (object obj in data)
            //{
            //    foreach (var prop in props)
            //    {
            //        object value = prop.GetValue(obj, null); // against prop.Name
            //    }
            //}
            
            Console.WriteLine($"{this.GetType().Name}");
            Console.WriteLine($"\tMarke:\t\t\t{Marke}");
            Console.WriteLine($"\tModel:\t\t\t{Model}");
            Console.WriteLine($"\tOperating System:\t{OS}");
            Console.WriteLine($"\tArbeitsspeicher:\t{Arbeitsspeicher}");
            Console.WriteLine($"\tSpeicherkapazität:\t{Speicherkapazität}");
            Console.WriteLine($"\tBildschirmgrösse:\t{Bildschirmgrösse}");
            Console.WriteLine($"\tAkkulaufzeit:\t\t{Akkulaufzeit}");
            Console.WriteLine($"\tProzessortyp:\t\t{Prozessortyp}");
            Console.WriteLine($"\tAnzProzessoren:\t\t{AnzProzessoren}");
            Console.WriteLine($"\tFarbe:\t\t\t{Farbe}");
            Console.WriteLine($"\tKaufpreis:\t\t{Kaufpreis}");
        }
    }
}
