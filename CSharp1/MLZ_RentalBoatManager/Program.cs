using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MLZ_RentalBoatManager
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 mainForm = new Form1();

            var boatsCollection = new BoatsCollection();
            boatsCollection.BoatsList = DefaultBoats();

            mainForm.BoatsList = boatsCollection.BoatsList;

            Application.Run(mainForm);
        }












        // just for cleaner and more readable main code
        public static BindingList<Boat> DefaultBoats()
        {
            var boatsList = new BindingList<Boat>();

            boatsList.Add(new Boat()
            {
                Brand = "Brand1",
                Model = "Model1",
                Category = Category.catamaran,
                Color = Color.red,
                Power = 120,
                LicensePlate = "XML123",
                Length = 7.2f,
                Width = 4.3f,
                Height = 6.0f,
                RentPerDay = 10.50f,
                NumberOfPerson = 5,
                MaxMotorSpeed = 50,
                MaxSailSpeed = 80
            });

            boatsList.Add(new Boat()
            {
                Brand = "Brand2",
                Model = "Model2",
                Category = Category.kayak,
                Color = Color.blue,
                Power = 120,
                LicensePlate = "24735X",
                Length = 7.2f,
                Width = 4.3f,
                Height = 6.0f,
                RentPerDay = 10.50f,
                NumberOfPerson = 5,
                MaxMotorSpeed = 50,
                MaxSailSpeed = 80
            });

            boatsList.Add(new Boat()
            {
                Brand = "Brand3",
                Model = "Model3",
                Category = Category.motorboat,
                Color = Color.black,
                Power = 120,
                LicensePlate = "ABCXYZ",
                Length = 7.2f,
                Width = 4.3f,
                Height = 6.0f,
                RentPerDay = 10.50f,
                NumberOfPerson = 5,
                MaxMotorSpeed = 50,
                MaxSailSpeed = 0
            });

            return boatsList;
        }
    }
}
