using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometrischeFormen
{
    class Quadrat: IForm
    {
        public double Seitenlaenge { get; set; }

        public double Umfang
        {
            get
            {
                return 4 * Seitenlaenge;
            }
        }

        public double BerechneFlaeche()
        {
            return Math.Pow(Seitenlaenge, 2);
        }
    }
}
