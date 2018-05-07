using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfBindingExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Car DisplayCar { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            DisplayCar = new Car()
            {
                Brand = "Audi",
                Model = "RS6",
                Color = "Green"
            };

            // Sample 1:
            //this.DataContext = DisplayCar;

            // Sample 2:
            //tbxBrand.DataContext = DisplayCar;
            //tbxModel.DataContext = DisplayCar;
            //lblColor.DataContext = DisplayCar;
        }

        private void btnChangeModel_Click(object sender, RoutedEventArgs e)
        {
            DisplayCar.Brand = "Nissan";
            DisplayCar.Model = "Skyline";
            DisplayCar.Color = "Blue";
        }
    }
}
