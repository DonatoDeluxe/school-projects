using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uebung_5_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Kalkulation kalkulation = new Kalkulation();
            Console.WriteLine(kalkulation.Add(5, 5));
            Console.WriteLine(kalkulation.Add(5.0f, 5));
            Console.WriteLine(kalkulation.Add(5.0f, 5.0f));
        }
    }
}
