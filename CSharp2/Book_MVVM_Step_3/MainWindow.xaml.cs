using Book_MVVM_Step_3.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Book_MVVM_Step_3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            PropertyChanged(this, new PropertyChangedEventArgs(""));
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {

            // Make the cursor the Hand cursor when the mouse moves 
            // over the button.
            Cursor = Cursors.Hand;
            //MainGrid
            // Call MyBase.OnMouseMove to activate the delegate.
            base.OnMouseMove(e);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void btn_SetTitle_Click(object sender, RoutedEventArgs e)
        {
            BookViewModel viewModel = this.DataContext as BookViewModel;
            viewModel.Title = "xxxxx";
        }
    }
}
