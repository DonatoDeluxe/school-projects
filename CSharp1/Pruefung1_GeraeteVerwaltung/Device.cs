using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pruefung1_GeraeteVerwaltung
{
    abstract class Device
    {
        public string Marke { set; get; }
        public string Model { set; get; }
        public string OS { set; get; }
        public float Arbeitsspeicher { set; get; }
        public float Speicherkapazität { set; get; }
        public int Bildschirmgrösse { set; get; }
        public float Akkulaufzeit { set; get; }
        public string Prozessortyp { set; get; }
        public int AnzProzessoren { set; get; }
        public enum Farbe { schwarz, grau, weiss, blau, rot, grün }
        public float Kaufpreis { set; get; }
        
    }
}
