using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pruefung1_GeraeteVerwaltung
{
    class Smartphone : Device
    {
        public bool HatMicroSDSlot { set; get; }
        public double MaxSpeichererweiterung { set; get; }

        public override void Print(string className = "")
        {
            base.Print();
            Console.WriteLine($"\tMicroSD Slot?:\t\t{HatMicroSDSlot}");
            Console.WriteLine($"\tMax. Speichererweiterung: {MaxSpeichererweiterung}");
        }
    }
}
