using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace MLZ_RentalBoatManager
{
    public partial class Form1 : Form
    {
        [XmlArray("Boats")]
        [XmlArrayItem("Boat", typeof(Boat))]
        public BindingList<Boat> BoatsList { get; set; }
        public Boolean CancelOnChangeEvent { get; set; }

        public Form1()
        {
			InitializeComponent();

            BoatsList = new BindingList<Boat>();
            categoryDropdown.DataSource = Enum.GetValues(typeof(Category));
            colorDropdown.DataSource = Enum.GetValues(typeof(Color));
        }

		private void Form1_Load(object sender, EventArgs e)
        {
			BoatsList.ListChanged += new ListChangedEventHandler(OnListChanged);
			foreach (GroupBox groupBox in detailGroupBox.Controls.OfType<GroupBox>())
            {
                foreach (TextBox control in groupBox.Controls.OfType<TextBox>())
                    control.TextChanged += new EventHandler(OnContentChanged);

                foreach (ComboBox control in groupBox.Controls.OfType<ComboBox>())
                    control.TextChanged += new EventHandler(OnContentChanged);
			}
			saveEntryBtn.Enabled = false;
			deleteEntryBtn.Enabled = false;
			UpdateList();
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			Controller.XmlSerializeBoatsBindingList(BoatsList);
		}

		private void boatsFormList_SelectedIndexChanged(object sender, EventArgs e)
		{
			int index = boatsFormList.SelectedIndex;
			if (index >= 0)
			{
                CancelOnChangeEvent = true;
                imageBox.ImageLocation = BoatsList[index].ImagePath;
				brandInput.Text = BoatsList[index].Brand;
				brandInput.Text = BoatsList[index].Brand;
				modelInput.Text = BoatsList[index].Model;
				categoryDropdown.SelectedItem = BoatsList[index].Category;
				colorDropdown.SelectedItem = BoatsList[index].Color;
				powerInput.Text = BoatsList[index].Power.ToString();
				licensePlateInput.Text = BoatsList[index].LicensePlate;
				lengthInput.Text = BoatsList[index].Length.ToString();
				widthInput.Text = BoatsList[index].Width.ToString();
				heightInput.Text = BoatsList[index].Height.ToString();
				rentPerDayInput.Text = BoatsList[index].RentPerDay.ToString();
				numberOfPersonInput.Text = BoatsList[index].NumberOfPerson.ToString();
				maxMotorSpeedInput.Text = BoatsList[index].MaxMotorSpeed.ToString();
				maxSailSpeedInput.Text = BoatsList[index].MaxSailSpeed.ToString();
			}

			if (imageBox.ImageLocation != "")
				deleteImageBtn.Enabled = true;
			else
				deleteImageBtn.Enabled = false;

			saveEntryBtn.Enabled = false;
            CancelOnChangeEvent = false;
        }

		private void saveEntryBtn_Click(object sender, EventArgs e)
		{
			var confirmResult = MessageBox.Show("Wollen Sie diesen Eintrag wirklich überschreiben?", "Überschreibbestätigung", MessageBoxButtons.YesNo);
			if (confirmResult == DialogResult.Yes)
			{
				int index = boatsFormList.SelectedIndex;
				if (index >= 0)
				{
					WriteDetailsInBoat(BoatsList[index]);
					UpdateList();
				}
			}
		}

		private void newEntryBtn_Click(object sender, EventArgs e)
		{
			Boat boat = new Boat();
			WriteDetailsInBoat(boat);
			BoatsList.Add(boat);
			boatsFormList.SelectedIndex = BoatsList.Count() - 1;
		}

		private void deleteEntryBtn_Click(object sender, EventArgs e)
		{
			if (BoatsList.Count() > 0)
			{
				var confirmResult = MessageBox.Show("Wollen Sie diesen Eintrag wirklich löschen?", "Löschbestätigung", MessageBoxButtons.YesNo);
				if (confirmResult == DialogResult.Yes)
					BoatsList.Remove((Boat)boatsFormList.SelectedItem);
			}
		}

		private void selectImageBtn_Click(object sender, EventArgs e)
		{
			OpenFileDialog dialog = new OpenFileDialog();
			dialog.Title = "Wähle Boots-Bild";
			dialog.Filter = "Image Files (*.jpg;*.png)|*.jpg;*.png|All files (*.*)|*.*";
			if (dialog.ShowDialog() == DialogResult.OK)
			{
				dialog.OpenFile();
				imageBox.ImageLocation = dialog.FileName;
				OnContentChanged(this, null);
			}
			dialog.Dispose();
		}

		private void deleteImageBtn_Click(object sender, EventArgs e)
		{
			imageBox.ImageLocation = "";
			OnContentChanged(this, null);
			deleteImageBtn.Enabled = false;
		}








		private void UpdateList()
		{
			boatsFormList.DataSource = null;
			boatsFormList.DataSource = BoatsList;
		}

		private void OnListChanged(object sender, ListChangedEventArgs e)
		{
			if (BoatsList.Count() > 0)
				deleteEntryBtn.Enabled = true;
			else
				deleteEntryBtn.Enabled = false;
		}

		private void OnContentChanged(object sender, EventArgs e)
		{
			if (CancelOnChangeEvent)
				return;

			if(BoatsList.Count > 0)
				saveEntryBtn.Enabled = true;

			if (imageBox.ImageLocation != "")
				deleteImageBtn.Enabled = true;
			else
				deleteImageBtn.Enabled = false;
		}

		public void WriteDetailsInBoat(Boat boat)
		{
			float resFloat = 0;
			int resInt = 0;

			if (boat.ImagePath != imageBox.ImageLocation)
				boat.ImagePath = imageBox.ImageLocation;

			if (boat.Brand != brandInput.Text)
				boat.Brand = brandInput.Text;

			if (boat.Model != modelInput.Text)
				boat.Model = modelInput.Text;

			if (boat.Category != (Category)categoryDropdown.SelectedIndex)
				boat.Category = (Category)categoryDropdown.SelectedIndex;

			if (boat.Color != (Color)colorDropdown.SelectedIndex)
				boat.Color = (Color)colorDropdown.SelectedIndex;

			if (float.TryParse(powerInput.Text, out resFloat) && boat.Power != resFloat)
				boat.Power = resFloat;

			if (boat.LicensePlate != licensePlateInput.Text)
				boat.LicensePlate = licensePlateInput.Text;

			if (float.TryParse(lengthInput.Text, out resFloat) && boat.Length != resFloat)
				boat.Length = resFloat;

			if (float.TryParse(widthInput.Text, out resFloat) && boat.Width != resFloat)
				boat.Width = resFloat;

			if (float.TryParse(heightInput.Text, out resFloat) && boat.Height != resFloat)
				boat.Height = resFloat;

			if (float.TryParse(rentPerDayInput.Text, out resFloat) && boat.RentPerDay != resFloat)
				boat.RentPerDay = resFloat;

			if (int.TryParse(numberOfPersonInput.Text, out resInt) && boat.NumberOfPerson != resInt)
				boat.NumberOfPerson = resInt;

			if (int.TryParse(maxMotorSpeedInput.Text, out resInt) && boat.MaxMotorSpeed != resInt)
				boat.MaxMotorSpeed = resInt;

			if (int.TryParse(maxSailSpeedInput.Text, out resInt) && boat.MaxSailSpeed != resInt)
				boat.MaxSailSpeed = resInt;
		}
	}
}
