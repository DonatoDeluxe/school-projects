using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MLZ_RentalBoatManager
{
    class BoatsCollection
    {
        [XmlArray("Boats")]
        [XmlArrayItem("Boat", typeof(Boat))]
        public BindingList<Boat> BoatsList { get; set; }

        public BoatsCollection()
        {
            BoatsList = new BindingList<Boat>();
        }
    }
}
