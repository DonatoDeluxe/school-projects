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

namespace Simulation_eines_Wärmerückgewinnungsgerätes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int currentLevel = 0;
        private int selectedLevel = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_Off_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
