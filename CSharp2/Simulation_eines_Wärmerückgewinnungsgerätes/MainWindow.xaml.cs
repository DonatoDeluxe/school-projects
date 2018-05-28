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
        private Timer logTimer = new Timer(1000);
        private Timer fanTimer = new Timer(1000);
        private DateTime prevSystemTime;
        private HeatRecoveryDevice hrDevice = new HeatRecoveryDevice();

        public MainWindow()
        {
            InitializeComponent();
            hrDevice.SelectedLevelChanged += OnSelectedLevelChanged;
            hrDevice.CurrentLevelChanged += OnCurrentLevelChanged;
            SetFanTimer(1000 / 60); //run with 60fps (60-times per second)
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (logTimer != null)
            {
                logTimer.Stop();
                logTimer.Dispose();
            }
            if (fanTimer != null)
            {
                fanTimer.Stop();
                fanTimer.Dispose();
            }
        }

        private void SetLogTimer(int mSeconds)
        {
            if (logTimer != null)
                logTimer.Stop();
            logTimer = new Timer(mSeconds);
            logTimer.Elapsed += OnLogTimerEvent;
            logTimer.AutoReset = true;
            logTimer.Start();
        }

        private void SetFanTimer(int mSeconds)
        {
            if(fanTimer != null)
                fanTimer.Stop();
            fanTimer = new Timer(mSeconds);
            fanTimer.Elapsed += OnFanTimerEvent;
            fanTimer.AutoReset = true;
            fanTimer.Start();
        }

        private void OnLogTimerEvent(Object source, ElapsedEventArgs e)
        {

            Console.WriteLine("The Elapsed event was raised at {0:HH:mm:ss.fff}",
                              e.SignalTime);
        }

        private void OnFanTimerEvent(Object source, ElapsedEventArgs e)
        {
            this.Dispatcher.Invoke(
                new Action(
                    () => RotateFanImage(e.SignalTime)
                )
            );
        }

        public void RotateFanImage(DateTime currentSystemTime)
        {
            double rotationInDegrees = 0;
            RotateTransform rotation = img_fan.RenderTransform as RotateTransform;
            if (rotation != null)
                rotationInDegrees = rotation.Angle;

            if (prevSystemTime != null)
            {
                var mSecDiff = (currentSystemTime - prevSystemTime).Milliseconds;
                var degrees = hrDevice.EngineSpeed * mSecDiff  * (360f / 60000f);
                img_fan.RenderTransform = new RotateTransform(rotationInDegrees + degrees, 0.5, 0.5);
            }

            prevSystemTime = currentSystemTime;
        }

        public void OnCurrentLevelChanged(object source, EventArgs eArgs)
        {
            this.Dispatcher.Invoke(
                new Action(
                    () => SetLevelButtonsBackground()
                )
            );
        }

        public void OnSelectedLevelChanged(object source, EventArgs eArgs)
        {
            this.Dispatcher.Invoke(
                new Action(
                    () => SetLevelButtonsBackground()
                )
            );
        }

        private void SetLevelButtonsBackground()
        {
            for (int lvl = 0; lvl < stackp_Levels.Children.Count; lvl++)
            {
                var lvl_btn = stackp_Levels.Children[lvl] as Button;

                if (lvl == hrDevice.CurrentLevel)
                {
                    if (lvl == 0)
                        lvl_btn.Background = lgb_Red;
                    else
                        lvl_btn.Background = lgb_Green;
                }
                else if (lvl == hrDevice.SelectedLevel)
                    lvl_btn.Background = lgb_Yellow;
                else
                    lvl_btn.Background = lgb_White;
            }
        }

        private void btn_Off_Click(object sender, RoutedEventArgs e) => hrDevice.SelectedLevel = 0;

        private void btn_Level1_Click(object sender, RoutedEventArgs e) => hrDevice.SelectedLevel = 1;

        private void btn_Level2_Click(object sender, RoutedEventArgs e) => hrDevice.SelectedLevel = 2;

        private void btn_Level3_Click(object sender, RoutedEventArgs e) => hrDevice.SelectedLevel = 3;

        private void btn_LogMeasurements_Click(object sender, RoutedEventArgs e)
        {
            if (logFlag)
            {
                if(logTimer.Enabled)
                {
                    logTimer.Stop();
                    logTimer.Dispose();
                }
                btn_LogMeasurements.Content = "Messungen aufnehmen";
                btn_LogMeasurements.Background = lgb_Red;
                logFlag = false;
            }
            else
            {
                SetLogTimer(1000);
                btn_LogMeasurements.Content = "Messungen stopen";
                btn_LogMeasurements.Background = lgb_Green;
                logFlag = true;
            }
        }
    }
}
