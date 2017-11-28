using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pruefung1_GeraeteVerwaltung
{
    class Tablet : Device
    {
        public bool HatMicroSDSlot { set; get; }
        public bool Hat4G { set; get; }

        public override void Print(string className = "")
        {
            base.Print();
            Console.WriteLine($"\tMicroSD Slot?:\t{HatMicroSDSlot}");
            Console.WriteLine($"\t4G?:\t\t{Hat4G}");
        }
    }
}
