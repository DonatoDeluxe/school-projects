using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MLZ_RentalBoatManager
{
	class Controller
	{
		private const string directoryPath = @".\Assets";
		private const string filePath = directoryPath + @"\Boats.xml";

		private static bool CreateDirectory()
		{
			try
			{
				Directory.CreateDirectory(directoryPath);
				return true;
			}
			catch (IOException ioe)
			{
				Console.WriteLine("Probleme beim Verzeichnis erstellen: " + ioe.Message);
				Console.WriteLine(ioe.StackTrace);
				return false;
			}
		}

		public static void XmlSerializeBoatsBindingList(BindingList<Boat> boatlist)
		{
			if (!CreateDirectory())
				return;

			Stream stm = new FileStream(filePath, FileMode.Create);
			XmlSerializer xs = new XmlSerializer(typeof(BindingList<Boat>));
			xs.Serialize(stm, boatlist);
			stm.Flush();
			stm.Close();
		}

		public static BindingList<Boat> XmlDeserializeBoatsBindingList()
		{
			try
			{
				FileStream fs = new FileStream(filePath, FileMode.Open);
				XmlSerializer xs = new XmlSerializer(typeof(BindingList<Boat>));
				BindingList<Boat> boatlist = xs.Deserialize(fs) as BindingList<Boat>;
				fs.Close();
				return boatlist;
			}
			catch (DirectoryNotFoundException e)
			{
				return new BindingList<Boat>();
			}
			catch (FileNotFoundException e)
			{
				return new BindingList<Boat>();
			}
		}
	}
}
