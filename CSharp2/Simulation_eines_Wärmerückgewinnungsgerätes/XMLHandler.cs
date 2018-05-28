using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace Simulation_eines_Wärmerückgewinnungsgerätes
{
    public static class XMLHandler
    {
        private static readonly string defaultPath = @"D:\HeatRecoveryDevice\";
        private static readonly string defaultFilename = @"log";
        private static readonly XmlWriterSettings defaultWriterSettings = new XmlWriterSettings() {
            Indent = true,
            OmitXmlDeclaration = true,
            NewLineOnAttributes = true
        };

        public static string CreateDirectory(string path = null)
        {
            try
            {
                if (path == null)
                    path = defaultPath;

                //create directory if it doesn't exist yet
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                
            }
            catch (IOException e)
            {
                Console.WriteLine("couldn't create directory. - " + e.Message);
                Console.WriteLine(e.StackTrace);
            }

            return path;
        }

        public static string CreateXmlFile(string filename = null, string path = null, XmlWriterSettings xmlWriterSettings = null)
        {
            string absPath = null;

            try
            {
                absPath = CreateDirectory(path) + (filename != null ? filename : defaultFilename) + @".xml";

                if (xmlWriterSettings == null)
                    xmlWriterSettings = defaultWriterSettings;

                //create file if it doesn't exist yet
                if (!File.Exists(absPath))
                {
                    XmlWriter writer = XmlWriter.Create(absPath, xmlWriterSettings);
                    writer.WriteStartElement("Root");
                    writer.WriteEndElement();
                    writer.Flush();
                    writer.Close();
                }
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("couldn't create file. - " + e.Message);
                Console.WriteLine(e.StackTrace);
            }

            return absPath;
        }

        public static void WriteHRDeviceStatsInXml(HeatRecoveryDevice hrDevice, string filename = null, string path = null, XmlWriterSettings xmlWriterSettings = null)
        {
            string tableName = "Logtable";
            string absPath = CreateXmlFile(filename, path, xmlWriterSettings);

            var entryElem = new XElement("Entry");
            entryElem.Add(new XAttribute("Time", DateTime.Now.ToString()));
            entryElem.Add(new XAttribute("Voltage", hrDevice.Voltage.ToString()));
            entryElem.Add(new XAttribute("Current", hrDevice.Current.ToString()));
            entryElem.Add(new XAttribute("Power", hrDevice.Power.ToString()));
            entryElem.Add(new XAttribute("EngineSpeed", hrDevice.EngineSpeed.ToString()));
            
            var doc = XDocument.Load(absPath);
            var root = doc.Element("Root");
            var tableElem = root.Element(tableName);
            if (tableElem == null)
            {
                tableElem = new XElement(tableName);
                root.Add(tableElem);
            }

            tableElem.Add(entryElem);
            //doc.Element(tableName).Add(entryElem);
            doc.Save(absPath);
        }
    }
}
