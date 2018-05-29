using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace HeatRecoveryApplication
{
    public static class XMLHandler
    {
        private static readonly string defaultPath = @"C:\HeatRecoveryDevice\";
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
                    path = defaultPath; //take default path if none is given

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
                //create abs path string and take default filename if none is given
                absPath = CreateDirectory(path) + (filename != null ? filename : defaultFilename) + @".xml";

                if (xmlWriterSettings == null)
                    xmlWriterSettings = defaultWriterSettings; //take default writer settings if none are given

                //create file if it doesn't exist yet
                if (!File.Exists(absPath))
                {
                    XmlWriter writer = XmlWriter.Create(absPath, xmlWriterSettings);
                    writer.WriteStartElement("Root"); //creating root element for valid xml-file
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
            if (tableElem == null) //if node with given tablename doesn't exist yet...
            {
                tableElem = new XElement(tableName); //...create one and...
                root.Add(tableElem); //...add it to root node
            }

            tableElem.Add(entryElem); //add the new entry element to the table node
            doc.Save(absPath);
        }
    }
}
