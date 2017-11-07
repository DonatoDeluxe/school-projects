using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometrischeFormen
{
    class Kreis: IForm
    {
        public double Radius { get; set; }

        public double Umfang
        {
            get
            {
                return 2 * Radius * Math.PI;
            }
        }

        public double BerechneFlaeche()
        {
            return Math.Pow(Radius, 2) * Math.PI;
        }
    }
}
