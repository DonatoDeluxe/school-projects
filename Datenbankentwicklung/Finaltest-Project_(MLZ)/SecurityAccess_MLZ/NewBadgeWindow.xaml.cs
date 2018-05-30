using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SecurityAccess_MLZ
{
    /// <summary>
    /// Interaction logic for NewBadgeWindow.xaml
    /// </summary>
    public partial class NewBadgeWindow : Window
    {
        private static Regex pinRgx = new Regex(@"^[0-9]{6}$");
        private static Regex nameRgx = new Regex(@"^[ A-Za-zäöü]+$");

        private BindingList<BadgeType> BadgeTypeList { get; set; }
        private BindingList<Doorlocksystem> DoorsList { get; set; }
        private BindingList<Doorlocksystem> DoorBadgeRelationList { get; set; }

        public NewBadgeWindow()
        {
            InitializeComponent();

            cmbBox_BadgeType.SelectionChanged += OnBadgeDetailsFocusLost;
            dp_terminationdate.SelectedDateChanged += OnBadgeDetailsFocusLost;
            txt_Firstname.TextChanged += OnBadgeDetailsFocusLost;
            txt_Lastname.TextChanged += OnBadgeDetailsFocusLost;
            txt_PINCode.TextChanged += OnBadgeDetailsFocusLost;

            BadgeTypeList = new BindingList<BadgeType>();
            DoorsList = new BindingList<Doorlocksystem>();
            DoorBadgeRelationList = new BindingList<Doorlocksystem>();

            getBadgeTypesFromDB();
            getDoorsFromDB();
            cmbBox_BadgeType.ItemsSource = BadgeTypeList;
            cmbBox_Door.ItemsSource = DoorsList;
            lstBox_DoorBadgeRelationList.ItemsSource = DoorBadgeRelationList;
        }

        public void OnBadgeDetailsFocusLost(object source, EventArgs eArgs)
        {
            if (cmbBox_BadgeType.SelectedIndex >= 0 &&
                dp_terminationdate.SelectedDate != null &&
                nameRgx.IsMatch(txt_Firstname.Text) &&
                nameRgx.IsMatch(txt_Lastname.Text) &&
                pinRgx.IsMatch(txt_PINCode.Text))
                btn_Save.IsEnabled = true;
            else
                btn_Save.IsEnabled = false;

        }

        private void getBadgeTypesFromDB()
        {
            BadgeTypeList = BadgeType.SelectBadgeTypesFromDB();
        }

        private void getDoorsFromDB()
        {
            DoorsList = Doorlocksystem.SelectDoorsFromDB();
        }

        private void NewBadgeWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("Vorgang abbrechen?", "Frage", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }

        private void cmbBox_Door_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbBox_Door.SelectedIndex > -1)
                btn_AddDoor.IsEnabled = true;
            else
                btn_AddDoor.IsEnabled = false;
        }

        private void btn_AddDoor_Click(object sender, RoutedEventArgs e)
        {
            Doorlocksystem doorlocksystem = cmbBox_Door.SelectedItem as Doorlocksystem;
            if (!DoorBadgeRelationList.Contains(doorlocksystem))
                DoorBadgeRelationList.Add(doorlocksystem);
        }

        private void lstBox_DoorBadgeRelationList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstBox_DoorBadgeRelationList.SelectedIndex > -1)
                btn_RemoveDoor.IsEnabled = true;
            else
                btn_RemoveDoor.IsEnabled = false;
        }

        private void btn_RemoveDoor_Click(object sender, RoutedEventArgs e)
        {
            DoorBadgeRelationList.Remove(lstBox_DoorBadgeRelationList.SelectedItem as Doorlocksystem);
        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            int badgetypeId = (cmbBox_BadgeType.SelectedItem as BadgeType).BadgetypeId;
            string firstname = txt_Firstname.Text;
            string lastname = txt_Lastname.Text;
            DateTime validUntil = dp_terminationdate.SelectedDate.Value.Date;
            string pinCode = txt_PINCode.Text;

            int newBadgeId = Badge.CreateBadgeInDB(badgetypeId, firstname, lastname, validUntil, pinCode);
            if(newBadgeId != 0)
            {
                string doorIDs = "";
                List<int> doorsIDs = new List<int>();
                foreach (Doorlocksystem dls in lstBox_DoorBadgeRelationList.Items)
                    doorsIDs.Add(dls.ObjektId);
                doorIDs = string.Join(",", doorsIDs.Distinct().ToList().Select(doorID => doorID.ToString()).ToArray());
                Badge.CreateBadgeDoorRelationsInDB(newBadgeId, doorIDs);
            }
        }
    }
}
