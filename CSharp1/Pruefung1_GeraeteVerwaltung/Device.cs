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

        public override string ToString()
        {
            return this.ToString(0);
        }

        public string ToString(int tabs)
        {
            string indent = "";
            while (tabs-- != 0)
                indent += "  ";
            
            string returnString = "";
            var props = this.GetType().GetProperties().OrderBy(p => p.DeclaringType == typeof(Device) ? 0 : 1);
            foreach (var prop in props)
                returnString += String.Format(indent + "{0,-23}{1}\n", prop.Name + ":", prop.GetValue(this));

            return returnString;
        }
    }
}
