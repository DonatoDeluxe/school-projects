using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MLZ_RentalBoatManager
{
    public partial class Form1 : Form
    {
        public List<Boat> BoatsList { get; set; }

        public Form1()
        {
            InitializeComponent();
            BoatsList = new List<Boat>();
        }

        private void UpdateList()
        {
            boatsFormList.DataSource = BoatsList;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateList();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = boatsFormList.SelectedIndex;
            brandInput.Text         = BoatsList[index].Brand;
            modelInput.Text         = BoatsList[index].Model;
            categoryDropdown.DataSource = Enum.GetValues(typeof(Category)); // BoatsList[index].Category.ToString();
            colorDropdown.DataSource    = Enum.GetValues(typeof(Color)); // BoatsList[index].Color.ToString();
            powerInput.Text         = BoatsList[index].Power.ToString();
            licensePlateInput.Text  = BoatsList[index].LicensePlate;
            lengthInput.Text        = BoatsList[index].Length.ToString();
            widthInput.Text         = BoatsList[index].Width.ToString();
            heightInput.Text        = BoatsList[index].Height.ToString();
            rentPerDayInput.Text    = BoatsList[index].RentPerDay.ToString();
            numberOfPersonInput.Text= BoatsList[index].NumberOfPerson.ToString();
            maxMotorSpeedInput.Text = BoatsList[index].MaxMotorSpeed.ToString();
            maxSailSpeedInput.Text  = BoatsList[index].MaxSailSpeed.ToString();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox9_Enter(object sender, EventArgs e)
        {

        }

        private void newEntryBtn_Click(object sender, EventArgs e)
        {
            int index = boatsFormList.SelectedIndex;
            BoatsList.Add(new Boat()
            {
                Brand = brandInput.Text,
                Model = modelInput.Text,
                //Category = Category.motorboat,
                //Color = Color.black,
                //Power = powerInput.Text,
                //LicensePlate = licensePlateInput.Text,
                //Length = lengthInput.Text,
                //Width = widthInput.Text,
                //Height = heightInput.Text,
                //RentPerDay = rentPerDayInput.Text,
                //NumberOfPerson = numberOfPersonInput.Text,
                //MaxMotorSpeed = maxMotorSpeedInput.Text,
                //MaxSailSpeed = maxSailSpeedInput.Text
            });
        }
    }
}
