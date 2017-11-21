using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FahrzeugVerwaltung
{
    class Auto : Fahrzeug
    {
        public int AnzAirbags { get; set; }
        public string Innenfarbe { get; set; }
        public bool KlimaAnlage { get; set; }

        public new void PrintFahrzeug()
        {
            base.PrintFahrzeug();
            Console.WriteLine("Anzahl Airbags: " + AnzAirbags);
            Console.WriteLine("Innenfarbe: " + Innenfarbe);
            Console.WriteLine("Besitzt eine Klima Anlage? " + KlimaAnlage);
        }
    }
}
