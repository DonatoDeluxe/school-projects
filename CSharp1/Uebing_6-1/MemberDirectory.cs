using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uebing_6_1
{
    class MemberDirectory
    {
        Hashtable memberList = new Hashtable();

        public ArrayList searchMember(string searchString)
        {
            ArrayList retMemberList = new ArrayList();
            Array searchStrings = searchString.Split(' ', ',');
            foreach (Member member in memberList.Values)
            {
                foreach (string search in searchStrings)
                {
                    string tSearch = search.Trim();
                    if ( member.Name == tSearch ||
                        member.Firstname == tSearch ||
                        member.Phonenumber == tSearch ||
                        member.Personalnumber.ToString() == tSearch)
                    {
                        if(!retMemberList.Contains(member))
                            retMemberList.Add(member);
                    }
                }

            }
            return retMemberList;
        }

        public void addMember(Member member)
        {
            if (memberList.ContainsKey(member.Personalnumber))
                return; 
            memberList.Add(member.Personalnumber, member);
        }
    }
}
