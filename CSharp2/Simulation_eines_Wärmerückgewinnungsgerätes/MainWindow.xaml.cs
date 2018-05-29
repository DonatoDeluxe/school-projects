using System;
using System.Collections.Generic;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace HeatRecoveryApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Brushes
        // COLORS --------------------------------------------------------------------------------------//
        private static readonly GradientStop gs_Start_White = new GradientStop(Color.FromRgb(255, 255, 255), 0);
        private static readonly GradientStop gs_End_White = new GradientStop(Color.FromRgb(255, 255, 255), 1);

        private static readonly IEnumerable<GradientStop> gsc_Enum_White = new GradientStop[] {
            gs_Start_White, new GradientStop(Color.FromRgb(130, 130, 130), 0.55), gs_End_White
        };
        private static readonly GradientStopCollection gsc_White = new GradientStopCollection(gsc_Enum_White);
        private static readonly LinearGradientBrush lgb_White = new LinearGradientBrush(gsc_White, new Point(0, 0), new Point(0, 1));

        private static readonly IEnumerable<GradientStop> gsc_Enum_Green = new GradientStop[] {
            gs_Start_White, new GradientStop(Color.FromRgb(0, 190, 0), 0.55), gs_End_White
        };
        private static readonly GradientStopCollection gsc_Green = new GradientStopCollection(gsc_Enum_Green);
        private static readonly LinearGradientBrush lgb_Green = new LinearGradientBrush(gsc_Green, new Point(0, 0), new Point(0, 1));

        private static readonly IEnumerable<GradientStop> gsc_Enum_Red = new GradientStop[] {
            gs_Start_White, new GradientStop(Color.FromRgb(210, 0, 0), 0.55), gs_End_White
        };
        private static readonly GradientStopCollection gsc_Red = new GradientStopCollection(gsc_Enum_Red);
        private static readonly LinearGradientBrush lgb_Red = new LinearGradientBrush(gsc_Red, new Point(0, 0), new Point(0, 1));

        private static readonly IEnumerable<GradientStop> gsc_Enum_Yellow = new GradientStop[] {
            gs_Start_White, new GradientStop(Color.FromRgb(255, 255, 0), 0.55), gs_End_White
        };
        private static readonly GradientStopCollection gsc_Yellow = new GradientStopCollection(gsc_Enum_Yellow);
        private static readonly LinearGradientBrush lgb_Yellow = new LinearGradientBrush(gsc_Yellow, new Point(0, 0), new Point(0, 1));

        // END OF COLORS---------------------------------------------------------------------------------------//
        #endregion
        
        private Timer logTimer = new Timer(1000); //fan timer runs with 1fps (1-time per second)
        private Timer fanTimer = new Timer(1000 / 60); //fan timer runs with 60fps (60-times per second)
        private DateTime prevSystemTime; //used for calculating fan rotation

        public HeatRecoveryDevice HrDevice { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            HrDevice = this.DataContext as HeatRecoveryDevice;
            HrDevice.SelectedLevelChanged += OnSelectedLevelChanged;
            HrDevice.CurrentLevelChanged += OnCurrentLevelChanged;
            SetFanTimer(1000 / 60); //run with 60fps (60-times per second)
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //stop and dispose timers before closing application
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

        #region Timer logic
        #region Timer settings
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
        #endregion

        private void OnLogTimerEvent(Object source, ElapsedEventArgs e)
        {
            XMLHandler.WriteHRDeviceStatsInXml(HrDevice); //log HeatRecoveryDevice current stats in a xml-file
        }

        private void OnFanTimerEvent(Object source, ElapsedEventArgs e)
        {
            //dispatcher invoke because of different thread
            Dispatcher.Invoke(
                new Action(
                    () => RotateFanImage(e.SignalTime) //rotate the fan image by in method calculated degrees
                )
            );
        }
        #endregion

        public void RotateFanImage(DateTime currentSystemTime)
        {
            double rotationInDegrees = 0;
            RotateTransform rotation = img_fan.RenderTransform as RotateTransform; //get the current rotation of the fan-image
            if (rotation != null) //if there is no rotation yet, continue
                rotationInDegrees = rotation.Angle; //...else save the current rotation angle

            if (prevSystemTime != null)
            {
                var mSecDiff = (currentSystemTime - prevSystemTime).Milliseconds; //calculate the time between now and last time the rotation occured
                var degrees = HrDevice.EngineSpeed * mSecDiff  * (360f / 60000f); //calcutate the degrees it has to rotate so the visible rotation is realistic and accurate
                img_fan.RenderTransform = new RotateTransform(rotationInDegrees + degrees, 0.5, 0.5); //rotate the fan-image in it's center
            }

            prevSystemTime = currentSystemTime;
        }

        private void OnCurrentLevelChanged(object source, EventArgs eArgs)
        {
            //dispatcher invoke because of different thread
            Dispatcher.Invoke(
                new Action(
                    () => UpdateLevelButtonsBackground() //update the buttons background in the view
                )
            );
        }

        private void OnSelectedLevelChanged(object source, EventArgs eArgs)
        {
            //dispatcher invoke because of different thread
            Dispatcher.Invoke(
                new Action(
                    () => UpdateLevelButtonsBackground() //update the buttons background in the view
                )
            );
        }

        private void UpdateLevelButtonsBackground()
        {
            for (int lvl = 0; lvl < stackp_Levels.Children.Count; lvl++)
            {
                var lvl_btn = stackp_Levels.Children[lvl] as Button; //save current button to work with it as a button-object

                if (lvl == HrDevice.CurrentLevel)
                {
                    if (lvl == 0)
                        lvl_btn.Background = lgb_Red;
                    else
                        lvl_btn.Background = lgb_Green;
                }
                else if (lvl == HrDevice.SelectedLevel)
                    lvl_btn.Background = lgb_Yellow;
                else
                    lvl_btn.Background = lgb_White;
            }
        }

        #region GUI-Button clicks
        private void btn_Off_Click(object sender, RoutedEventArgs e) => HrDevice.SelectedLevel = 0;
        private void btn_Level1_Click(object sender, RoutedEventArgs e) => HrDevice.SelectedLevel = 1;
        private void btn_Level2_Click(object sender, RoutedEventArgs e) => HrDevice.SelectedLevel = 2;
        private void btn_Level3_Click(object sender, RoutedEventArgs e) => HrDevice.SelectedLevel = 3;

        private void btn_LogMeasurements_Click(object sender, RoutedEventArgs e)
        {
            if (logTimer.Enabled)
            {
                logTimer.Stop();
                logTimer.Dispose();
                btn_LogMeasurements.Content = "Messungen aufnehmen";
                btn_LogMeasurements.Background = lgb_Red;
            }
            else
            {
                SetLogTimer(1000);
                btn_LogMeasurements.Content = "Messungen stoppen";
                btn_LogMeasurements.Background = lgb_Green;
            }
        }
        #endregion
    }
}
