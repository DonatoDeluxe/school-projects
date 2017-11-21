using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FahrzeugVerwaltung
{
    abstract class Fahrzeug
    {
        private int     FahrzeugID { get; set; }
        private string  Marke { get; set; }
        private string  Typ { get; set; }
        private string  Farbe { get; set; }
        private double  Hubraum { get; set; }
        private double  Preis { get; set; }
        private int     Jahrgang { get; set; }
        private double  Treibstoff { get; set; }

        public void PrintFahrzeug()
        {
            Console.WriteLine("Fahrzeug ID: " + FahrzeugID);
            Console.WriteLine("Marke: " + Marke);
            Console.WriteLine("Typ: " + Typ);
            Console.WriteLine("Farbe: " + Farbe);
            Console.WriteLine("Hubraum: " + Hubraum);
            Console.WriteLine("Preis: " + Preis);
            Console.WriteLine("Jahrgang: " + Jahrgang);
            Console.WriteLine("Treibstoff: " + Treibstoff);
        }

        public void CreateFahrzeug(Fahrzeug fahrzeug)
        {
            fahrzeug.FahrzeugID = Console.ReadLine();
            fahrzeug.Marke = Console.ReadLine();
            fahrzeug.Typ = Console.ReadLine();
            fahrzeug.Farbe = Console.ReadLine();
            fahrzeug.Hubraum = Console.ReadLine();
            fahrzeug.Preis = Console.ReadLine();
            fahrzeug.Jahrgang = Console.ReadLine();
            fahrzeug.Treibstoff = Console.ReadLine();
        }
    }
}
