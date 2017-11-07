using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometrischeFormen
{
    interface IForm
    {
        double Umfang { get; }
        double BerechneFlaeche();
    }
}
