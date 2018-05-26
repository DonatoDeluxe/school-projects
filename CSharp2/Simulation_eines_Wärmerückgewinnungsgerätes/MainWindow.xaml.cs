using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
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
        // COLORS --------------------------------------------------------------------------------------//
        private static GradientStop gs_Start_White = new GradientStop(Color.FromRgb(255, 255, 255), 0);
        private static GradientStop gs_End_White = new GradientStop(Color.FromRgb(255, 255, 255), 1);

        private static IEnumerable<GradientStop> gsc_Enum_White = new GradientStop[] {
            gs_Start_White, new GradientStop(Color.FromRgb(130, 130, 130), 0.55), gs_End_White
        };
        private static GradientStopCollection gsc_White = new GradientStopCollection(gsc_Enum_White);
        LinearGradientBrush lgb_White = new LinearGradientBrush(gsc_White, new Point(0, 0), new Point(0, 1));

        private static IEnumerable<GradientStop> gsc_Enum_Green = new GradientStop[] {
            gs_Start_White, new GradientStop(Color.FromRgb(0, 190, 0), 0.55), gs_End_White
        };
        private static GradientStopCollection gsc_Green = new GradientStopCollection(gsc_Enum_Green);
        LinearGradientBrush lgb_Green = new LinearGradientBrush(gsc_Green, new Point(0, 0), new Point(0, 1));

        private static IEnumerable<GradientStop> gsc_Enum_Red = new GradientStop[] {
            gs_Start_White, new GradientStop(Color.FromRgb(210, 0, 0), 0.55), gs_End_White
        };
        private static GradientStopCollection gsc_Red = new GradientStopCollection(gsc_Enum_Red);
        LinearGradientBrush lgb_Red = new LinearGradientBrush(gsc_Red, new Point(0, 0), new Point(0, 1));

        private static IEnumerable<GradientStop> gsc_Enum_Yellow = new GradientStop[] {
            gs_Start_White, new GradientStop(Color.FromRgb(255, 255, 0), 0.55), gs_End_White
        };
        private static GradientStopCollection gsc_Yellow = new GradientStopCollection(gsc_Enum_Yellow);
        LinearGradientBrush lgb_Yellow = new LinearGradientBrush(gsc_Yellow, new Point(0, 0), new Point(0, 1));
        
        // END OF COLORS---------------------------------------------------------------------------------------//

        private bool logFlag = false;
        private static Timer secTimer = new Timer(1000);
        private HeatRecoveryDevice hrDevice = new HeatRecoveryDevice();

        public MainWindow()
        {
            InitializeComponent();
            btn_Off.Click += OnLevelSelectionChanged;
            btn_Level1.Click += OnLevelSelectionChanged;
            btn_Level2.Click += OnLevelSelectionChanged;
            btn_Level3.Click += OnLevelSelectionChanged;
        }

        private static void SetTimer(int mSeconds)
        {
            secTimer = null;
            secTimer = new Timer(mSeconds);
            secTimer.Elapsed += OnTimedEvent;
            secTimer.AutoReset = true;
            secTimer.Enabled = true;
        }

        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Console.WriteLine("The Elapsed event was raised at {0:HH:mm:ss.fff}",
                              e.SignalTime);
        }

        public void OnLevelSelectionChanged(object source, EventArgs eArgs)
        {
            var btn = source as Button;
            foreach (Button level in stackp_Levels.Children)
            {
                if (level == btn)
                {
                    //level.IsEnabled = false;
                    level.Background = lgb_Yellow;
                }
                else
                {
                    //level.IsEnabled = true;
                    level.Background = lgb_White;
                }
            }
        }

        private void btn_Off_Click(object sender, RoutedEventArgs e)
        {
            hrDevice.SelectedLevel = 0;
        }

        private void btn_Level1_Click(object sender, RoutedEventArgs e)
        {
            hrDevice.SelectedLevel = 1;
        }

        private void btn_Level2_Click(object sender, RoutedEventArgs e)
        {
            hrDevice.SelectedLevel = 2;
        }

        private void btn_Level3_Click(object sender, RoutedEventArgs e)
        {
            hrDevice.SelectedLevel = 3;
        }

        private void btn_LogMeasurements_Click(object sender, RoutedEventArgs e)
        {
            if (logFlag)
            {
                if(secTimer.Enabled)
                {
                    secTimer.Stop();
                    secTimer.Dispose();
                }
                btn_LogMeasurements.Content = "Messungen aufnehmen";
                btn_LogMeasurements.Background = lgb_Red;
                logFlag = false;
            }
            else
            {
                SetTimer(1000);
                btn_LogMeasurements.Content = "Messungen stopen";
                btn_LogMeasurements.Background = lgb_Green;
                logFlag = true;
            }
        }
    }
}
