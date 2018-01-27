using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLZ_RentalBoatManager
{
    public enum Category { none, sailboat, catamaran, motorboat, kayak }
    public enum Color { none, black, grey, white, blue, red, green }

    public class Boat
    {
		public string ImagePath { get; set; }
		public string Brand { set; get; }
        public string Model { set; get; }
        public Category Category { set; get; }
        public Color Color { set; get; }
        public float Power { set; get; }
        public string LicensePlate { set; get; }
        public float Length { set; get; }
        public float Width { set; get; }
        public float Height { set; get; }
        public float RentPerDay { set; get; }
        public int NumberOfPerson { set; get; }
        public int MaxMotorSpeed { set; get; }
        public int MaxSailSpeed { set; get; }

        public override string ToString()
        {
            return String.Format($"Marke: {Brand}, Modell: {Model}, Kategorie: {Category}");
        }
    }
}
