using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace MLZ_RentalBoatManager
{
    public partial class Form1 : Form
    {
        public BindingList<Boat> BoatsList { get; set; }

        public Form1()
        {
			InitializeComponent();

			BoatsList = new BindingList<Boat>();
            categoryDropdown.DataSource = Enum.GetValues(typeof(Category));
            colorDropdown.DataSource = Enum.GetValues(typeof(Color));
        }

		private void UpdateList()
        {
            boatsFormList.DataSource = null;
            boatsFormList.DataSource = BoatsList;
		}

		private void Form1_Load(object sender, EventArgs e)
        {
			foreach (TextBox control in Controls.OfType<TextBox>())
			{
				Console.WriteLine(control.GetType());
				//control.TextChanged += new System.EventHandler(OnContentChanged);
			}
			foreach (ComboBox control in Controls.OfType<ComboBox>())
			{
				control.SelectedIndexChanged += new System.EventHandler(OnContentChanged);
			}

			UpdateList();
		}

		void BoatsList_ListChanged(object sender, ListChangedEventArgs e)
		{
			MessageBox.Show("e.ListChangedType.ToString()");
			if (BoatsList.Count() > 0)
			{
				deleteEntryBtn.Enabled = true;
				saveEntryBtn.Enabled = true;
			}
			else
			{
				deleteEntryBtn.Enabled = false;
				saveEntryBtn.Enabled = false;
			}
		}

		private void boatsFormList_SelectedIndexChanged(object sender, EventArgs e)
		{
			int index = boatsFormList.SelectedIndex;
			if (index >= 0)
			{
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
		}

		private void saveEntryBtn_Click(object sender, EventArgs e)
		{
			var confirmResult = MessageBox.Show("Wollen Sie diesen Eintrag wirklich überschreiben?", "Überschreibbestätigung", MessageBoxButtons.YesNo);
			if (confirmResult == DialogResult.Yes)
			{
				int index = boatsFormList.SelectedIndex;
				if (index >= 0)
				{
					if (BoatsList[index].ImagePath == imageBox.ImageLocation)
						BoatsList[index].ImagePath = imageBox.ImageLocation;

					if (BoatsList[index].Brand == brandInput.Text)
						BoatsList[index].Brand = brandInput.Text;

					if (BoatsList[index].Model == modelInput.Text)
						BoatsList[index].Model = modelInput.Text;

					if (BoatsList[index].Category == (Category)categoryDropdown.SelectedIndex)
						BoatsList[index].Category = (Category)categoryDropdown.SelectedIndex;

					if (BoatsList[index].Color == (Color)colorDropdown.SelectedIndex)
						BoatsList[index].Color = (Color)colorDropdown.SelectedIndex;

					if (BoatsList[index].Power == float.Parse(powerInput.Text))
						BoatsList[index].Power = float.Parse(powerInput.Text);

					if (BoatsList[index].LicensePlate == licensePlateInput.Text)
						BoatsList[index].LicensePlate = licensePlateInput.Text;

					if (BoatsList[index].Length == float.Parse(lengthInput.Text))
						BoatsList[index].Length = float.Parse(lengthInput.Text);

					if (BoatsList[index].Width == float.Parse(widthInput.Text))
						BoatsList[index].Width = float.Parse(widthInput.Text);

					if (BoatsList[index].Height == float.Parse(heightInput.Text))
						BoatsList[index].Height = float.Parse(heightInput.Text);

					if (BoatsList[index].RentPerDay == float.Parse(rentPerDayInput.Text))
						BoatsList[index].RentPerDay = float.Parse(rentPerDayInput.Text);

					if (BoatsList[index].NumberOfPerson == int.Parse(numberOfPersonInput.Text))
						BoatsList[index].NumberOfPerson = int.Parse(numberOfPersonInput.Text);

					if (BoatsList[index].MaxMotorSpeed == int.Parse(maxMotorSpeedInput.Text))
						BoatsList[index].MaxMotorSpeed = int.Parse(maxMotorSpeedInput.Text);

					if (BoatsList[index].MaxSailSpeed == int.Parse(maxSailSpeedInput.Text))
						BoatsList[index].MaxSailSpeed = int.Parse(maxSailSpeedInput.Text);

					UpdateList();
				}
			}
		}

		private void newEntryBtn_Click(object sender, EventArgs e)
		{
			BoatsList.Add(new Boat()
			{
				ImagePath = imageBox.ImageLocation,
				Brand = brandInput.Text,
				Model = modelInput.Text,
				Category = (Category)categoryDropdown.SelectedIndex,
				Color = (Color)colorDropdown.SelectedIndex,
				Power = float.Parse(powerInput.Text),
				LicensePlate = licensePlateInput.Text,
				Length = float.Parse(lengthInput.Text),
				Width = float.Parse(widthInput.Text),
				Height = float.Parse(heightInput.Text),
				RentPerDay = float.Parse(rentPerDayInput.Text),
				NumberOfPerson = int.Parse(numberOfPersonInput.Text),
				MaxMotorSpeed = int.Parse(maxMotorSpeedInput.Text),
				MaxSailSpeed = int.Parse(maxSailSpeedInput.Text)
			});
			boatsFormList.SelectedIndex = BoatsList.Count() - 1;
		}

		private void deleteEntryBtn_Click(object sender, EventArgs e)
		{
			if (BoatsList.Count() > 0)
			{
				var confirmResult = MessageBox.Show("Wollen Sie diesen Eintrag wirklich löschen?", "Löschbestätigung", MessageBoxButtons.YesNo);
				if (confirmResult == DialogResult.Yes)
				{
					BoatsList.Remove((Boat)boatsFormList.SelectedItem);
				}
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
			}
			dialog.Dispose();
		}

		private void OnContentChanged(object sender, EventArgs e)
		{
			MessageBox.Show("OnContentChanged triggered");
		}
	}
}
