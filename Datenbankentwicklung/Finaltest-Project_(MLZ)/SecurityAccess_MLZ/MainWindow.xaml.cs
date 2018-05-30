using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SecurityAccess_MLZ
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string connectionString = @"Data Source=LAPTOP-QP6R7PTH\SQLEXPRESS;Initial Catalog=SecurityAccess;Integrated Security=True";

        private static GradientStop gs_Start_White = new GradientStop(Color.FromRgb(255, 255, 255), 0);
        private static GradientStop gs_End_White = new GradientStop(Color.FromRgb(255, 255, 255), 1);

        private static IEnumerable<GradientStop> gsc_Enum_White = new GradientStop[] { gs_Start_White, new GradientStop(Color.FromRgb(130, 130, 130), 0.55), gs_End_White };
        private static GradientStopCollection gsc_White = new GradientStopCollection(gsc_Enum_White);
        LinearGradientBrush lgb_White = new LinearGradientBrush(gsc_White, new Point(0, 0), new Point(0, 1));

        private static IEnumerable<GradientStop> gsc_Enum_Green = new GradientStop[] { gs_Start_White, new GradientStop(Color.FromRgb(0, 190, 0), 0.55), gs_End_White };
        private static GradientStopCollection gsc_Green = new GradientStopCollection(gsc_Enum_Green);
        LinearGradientBrush lgb_Green = new LinearGradientBrush(gsc_Green, new Point(0, 0), new Point(0, 1));

        private static IEnumerable<GradientStop> gsc_Enum_Red = new GradientStop[] { gs_Start_White, new GradientStop(Color.FromRgb(210, 0, 0), 0.55), gs_End_White };
        private static GradientStopCollection gsc_Red = new GradientStopCollection(gsc_Enum_Red);
        LinearGradientBrush lgb_Red = new LinearGradientBrush(gsc_Red, new Point(0, 0), new Point(0, 1));

        private BindingList<Badge> BadgesList { get; set; }
        private BindingList<Doorlocksystem> DoorsList { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            BadgesList = new BindingList<Badge>();
            DoorsList = new BindingList<Doorlocksystem>();

            BadgesList.ListChanged += OnBadgesListChanged;
            cmbBox_Badge.SelectionChanged += OnBadgesListChanged;
            cmbBox_Badge.SelectionChanged += OnBadgeOrDoorSelectionChange;
            cmbBox_Door.SelectionChanged += OnBadgeOrDoorSelectionChange;

            getBadgesFromDB();
            cmbBox_Badge.ItemsSource = BadgesList;
            getDoorsFromDB();
            cmbBox_Door.ItemsSource = DoorsList;
        }

        public void OnBadgeOrDoorSelectionChange(object source, EventArgs eArgs)
        {
            //if(txtBox_PIN.Background != lgb_white)
                txtBox_PIN.Background = lgb_White;

            if (!btn_CloseDoor.IsEnabled && cmbBox_Door.SelectedIndex > -1 && cmbBox_Badge.SelectedIndex > -1)
                btn_CheckPIN.IsEnabled = true;
            else
                btn_CheckPIN.IsEnabled = false;
        }

        private void getBadgesFromDB()
        {
            //cmbBox_Badge.SelectionChanged -= OnBadgeOrDoorSelectionChange;

            int selectedIndex = cmbBox_Badge.SelectedIndex;
            BadgesList.Clear();
            foreach (var Badge in Badge.SelectBadgesFromDB())
                BadgesList.Add(Badge);
            if (BadgesList.Count > selectedIndex)
                cmbBox_Badge.SelectedIndex = selectedIndex;

            //cmbBox_Badge.SelectionChanged += OnBadgeOrDoorSelectionChange;
        }

        private void getDoorsFromDB()
        {
            //cmbBox_Door.SelectionChanged -= OnBadgeOrDoorSelectionChange;

            int selectedIndex = cmbBox_Door.SelectedIndex;
            DoorsList.Clear();
            foreach (var Door in Doorlocksystem.SelectDoorsFromDB())
                DoorsList.Add(Door);
            if (DoorsList.Count > selectedIndex)
                cmbBox_Door.SelectedIndex = selectedIndex;

            //cmbBox_Door.SelectionChanged += OnBadgeOrDoorSelectionChange;
        }

        private void cmbBox_Door_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbBox_Door.SelectedIndex >= 0 && (cmbBox_Door.SelectedItem as Doorlocksystem).Statustyp == "frei")
                btn_CloseDoor.IsEnabled = true;
            else
                btn_CloseDoor.IsEnabled = false;
        }

        private void btn_NewBadge_Click(object sender, RoutedEventArgs e)
        {
            NewBadgeWindow newBadgeWindow = new NewBadgeWindow();
            newBadgeWindow.ShowDialog();
            getBadgesFromDB();
        }

        private void btn_CheckPIN_Click(object sender, RoutedEventArgs re)
        {
            Badge badge = cmbBox_Badge.SelectedItem as Badge;
            Doorlocksystem doorlocksystem = cmbBox_Door.SelectedItem as Doorlocksystem;

            if(badge != null && doorlocksystem != null)
            {
                ValidationResponse response = Doorlocksystem.checkBadgeAccess(badge.BadgeId, doorlocksystem.ObjektId, txtBox_PIN.Text);
                txtBlock_PINErrorMessage.Text = response.Message;
                getBadgesFromDB();
                if (response.Successful)
                {
                    Doorlocksystem.openDoor(doorlocksystem.ObjektId);
                    getDoorsFromDB();
                    txtBox_PIN.Background = lgb_Green;
                }
                else
                {
                    txtBox_PIN.Background = lgb_Red;
                }
                    
            }
        }

        private void btn_CloseDoor_Click(object sender, RoutedEventArgs re)
        {
            Doorlocksystem doorlocksystem = cmbBox_Door.SelectedItem as Doorlocksystem;

            if (doorlocksystem != null)
            {
                Doorlocksystem.closeDoor(doorlocksystem.ObjektId);
                getDoorsFromDB();
            }
        }

        public void OnBadgesListChanged(object source, EventArgs eArgs)
        {
            if (cmbBox_Badge.SelectedItem != null)
                lbl_PINErrorCount.Content = "Anz.fehlerhafte PIN - Eingaben: " + (cmbBox_Badge.SelectedItem as Badge).ErrorCounter;
        }

        private void txtBox_PIN_GotFocus(object sender, RoutedEventArgs e)
        {
            txtBox_PIN.Clear();
        }
    }
}