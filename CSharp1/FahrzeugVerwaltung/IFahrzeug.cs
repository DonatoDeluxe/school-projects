using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FahrzeugVerwaltung
{
    interface IFahrzeug
    {
        int FahrzeugID { get; set; }
        string Marke { get; set; }
        string Typ { get; set; }
        string Farbe { get; set; }
        double Hubraum { get; set; }
        double Preis { get; set; }
        int Jahrgang { get; set; }
        double Treibstoff { get; set; }

        void PrintFahrzeug();
    }
}
