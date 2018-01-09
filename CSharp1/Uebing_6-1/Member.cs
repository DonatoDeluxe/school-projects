using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uebung_6_1
{
    class Member
    {
        public int Personalnumber { set; get; }
        public string Name { set; get; }
        public string Firstname { set; get; }
        public string Phonenumber { set; get; }

        public void print()
        {
            Console.WriteLine("Member:");

            //if(Personalnumber)
            Console.WriteLine($"    ID: {Personalnumber}");
            //if(Personalnumber)
                Console.WriteLine($"    Name: {Firstname} {Name}");
            //if(Personalnumber)
                Console.WriteLine($"    Phone: {Phonenumber}");

            Console.WriteLine("");
        }
    }
}
