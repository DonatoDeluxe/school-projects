using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometrischeFormen
{
    class Program
    {
        static void Main(string[] args)
        {
            Quadrat quadrat = new Quadrat() { Seitenlaenge = 15 };
            Kreis kreis = new Kreis() { Radius = 10 };
            
            Console.WriteLine("Quadratumfang: " + quadrat.Umfang.ToString());
            Console.WriteLine("Quadratfläche: " + quadrat.BerechneFlaeche().ToString());
            Console.WriteLine("Kreistumfang: " + kreis.Umfang.ToString());
            Console.WriteLine("Kreisfläche: " + kreis.BerechneFlaeche().ToString());

        }
    }
}
