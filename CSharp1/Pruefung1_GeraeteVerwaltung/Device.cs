using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pruefung1_GeraeteVerwaltung
{
    public enum Farbe { schwarz, grau, weiss, blau, rot, grün }

    abstract class Device
    {
        public string Marke { set; get; }
        public string Model { set; get; }
        public string OS { set; get; }
        public double Arbeitsspeicher { set; get; }
        public double Speicherkapazität { set; get; }
        public double Bildschirmgrösse { set; get; }
        public double Akkulaufzeit { set; get; }
        public string Prozessortyp { set; get; }
        public int AnzProzessoren { set; get; }
        public Farbe Farbe { set; get; }
        public double Kaufpreis { set; get; }

        public override string ToString()
        {
            return this.ToString(0);
        }

        public string ToString(int tabs)
        {
            string indent = "";
            while (tabs-- != 0)
                indent += "  ";
            
            string returnString = "";
            var props = this.GetType().GetProperties().OrderBy(p => p.DeclaringType == typeof(Device) ? 0 : 1);
            foreach (var prop in props)
                returnString += String.Format(indent + "{0,-23}{1}\n", prop.Name + ":", prop.GetValue(this));

            return returnString;
        }

        //public List<Device> GetSortedList()
        //{
        //    return this.GetType().GetProperties().OrderBy(p => p.DeclaringType == typeof(Device) ? 0 : 1);
        //}

        public static DeviceType CreateNew<DeviceType>() where DeviceType : Device, new()
        {
            DeviceType device = new DeviceType();
            bool success = true;
            int intNumber = 0;
            double doubleNumber = 0;

            var props = device.GetType().GetProperties().OrderBy(p => p.DeclaringType == typeof(Device) ? 0 : 1);
            foreach (var prop in props)
            {
                do
                {
                    Console.Clear();
                    Console.Write($"{prop.Name}: ");
                    if (!success)
                        Console.WriteLine("\nungültige Eingabe!");
                    success = true;

                    if (prop.PropertyType == typeof(int))
                    {
                        success = Int32.TryParse(Console.ReadLine(), out intNumber);
                        prop.SetValue(device, intNumber);
                    }
                    else if (prop.PropertyType == typeof(double))
                    {
                        success = Double.TryParse(Console.ReadLine(), out doubleNumber);
                        prop.SetValue(device, doubleNumber);
                    }
                    else if (prop.PropertyType == typeof(bool))
                    {
                        Console.WriteLine("drücken Sie 'Y' für wahr/trifft zu und 'N' für falsch/trifft nicht zu");
                        var input = Console.ReadKey().KeyChar;
                        if (input == 'y')
                            prop.SetValue(device, true);
                        else if (input == 'n')
                            prop.SetValue(device, false);
                        else
                            success = false;
                    }
                    else if (prop.PropertyType == typeof(string))
                    {
                        prop.SetValue(device, Console.ReadLine());
                    }
                    else if (prop.PropertyType == typeof(Farbe))
                    {
                        Console.WriteLine();
                        int length = Enum.GetNames(typeof(Farbe)).Length;
                        for (int x = 1; x <= length; x++)
                        {
                            Console.WriteLine($"{x}) -{Enum.GetName(typeof(Farbe), x-1)}");
                        }
                        if (Int32.TryParse(Console.ReadLine(), out intNumber))
                            prop.SetValue(device, intNumber-1);
                        else
                            success = false;
                    }
                    else
                    {
                        success = false;
                    }

                } while (!success);
            }

            return device;
        }
    }
}
