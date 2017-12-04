using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pruefung1_GeraeteVerwaltung
{
    class Notebook : Device
    {
        public double SSDGroesse { set; get; }
        public bool HatBelTastatur { set; get; }
        public bool HatHDMIAnschluss { set; get; }
    }
}
