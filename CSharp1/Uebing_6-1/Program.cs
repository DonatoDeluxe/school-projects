using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uebung_6_1
{
    class Program
    {
        static void Main(string[] args)
        {
            MemberDirectory memberDirectory = new MemberDirectory();
            Member member1 = new Member() { Firstname = "Serafino", Name = "Fornito", Personalnumber = 7, Phonenumber = "0796192099" };
            Member member2 = new Member() { Firstname = "Valentino", Name = "Fornito", Personalnumber = 3, Phonenumber = "0797777777" };
            Member member3 = new Member() { Firstname = "Carmelo", Name = "Fornito", Personalnumber = 15, Phonenumber = "0795555555" };
            Member member4 = new Member() { Firstname = "Rebecca", Name = "Hasler", Personalnumber = 1, Phonenumber = "0794444444" };
            Member member5 = new Member() { Firstname = "Donato", Name = "Fornito", Personalnumber = 42, Phonenumber = "0796192099" };
            memberDirectory.addMember(member1);
            memberDirectory.addMember(member2);
            memberDirectory.addMember(member3);
            memberDirectory.addMember(member4);
            memberDirectory.addMember(member5);

            foreach(Member member in memberDirectory.searchMember("Rebecca 0796192099"))
            {
                member.print();
            }
        }
    }
}
