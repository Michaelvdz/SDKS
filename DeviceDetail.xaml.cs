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
using System.Windows.Shapes;

namespace Service_Program
{
    /// <summary>
    /// Interaction logic for DeviceDetail.xaml
    /// </summary>
    public partial class DeviceDetail : Window
    {
        public int DeviceId { get; set; }
        public String DeviceName { get; set; }
        public String SerialNumber { get; set; }
        public DateTime? Bought { get; set; }
        public DateTime? LastCheck { get; set; }
        public DateTime? NextCheck { get; set; }
        public CheckUp SelectedCheck { get; set; }
        public String Note { get; set; }
        public String Price { get; set; }
        public String Sensor1 { get; set; }
        public String Sensor2 { get; set; }
        public String Sensor3 { get; set; }
        public String Sensor4 { get; set; }
        public String Sensor5 { get; set; }
        public String Sensor6 { get; set; }
        public String Sensor7 { get; set; }
        public String Sensor8 { get; set; }
        public String Opmerking { get; set; }
        public Boolean Broken { get; set; }
        public Boolean Lost { get; set; }
        public Boolean GeenOp { get; set; }
        public String Reference { get; set; }
        public String Alarm1 { get; set; }
        public String Alarm1L { get; set; }
        public String Alarm1H { get; set; }
        public String Alarm1S { get; set; }
        public String Alarm1T { get; set; }
        public String Alarm2 { get; set; }
        public String Alarm2L { get; set; }
        public String Alarm2H { get; set; }
        public String Alarm2S { get; set; }
        public String Alarm2T { get; set; }
        public String Alarm3 { get; set; }
        public String Alarm3L { get; set; }
        public String Alarm3H { get; set; }
        public String Alarm3S { get; set; }
        public String Alarm3T { get; set; }
        public String Alarm4 { get; set; }
        public String Alarm4L { get; set; }
        public String Alarm4H { get; set; }
        public String Alarm4S { get; set; }
        public String Alarm4T { get; set; }
        public String Alarm5 { get; set; }
        public String Alarm5L { get; set; }
        public String Alarm5H { get; set; }
        public String Alarm5S { get; set; }
        public String Alarm5T { get; set; }
        public String Alarm6 { get; set; }
        public String Alarm6L { get; set; }
        public String Alarm6H { get; set; }
        public String Alarm6S { get; set; }
        public String Alarm6T { get; set; }
        public String Alarm7 { get; set; }
        public String Alarm7L { get; set; }
        public String Alarm7H { get; set; }
        public String Alarm7S { get; set; }
        public String Alarm7T { get; set; }
        public String Alarm8 { get; set; }
        public String Alarm8L { get; set; }
        public String Alarm8H { get; set; }
        public String Alarm8S { get; set; }
        public String Alarm8T { get; set; }
        public String Alarm1Name { get; set; }
        public String Alarm2Name { get; set; }
        public String Alarm3Name { get; set; }
        public String Alarm4Name { get; set; }
        public String Alarm5Name { get; set; }
        public String Alarm6Name { get; set; }
        public String Alarm7Name { get; set; }
        public String Alarm8Name { get; set; }

        public DeviceDetail(Device device)
        {
            InitializeComponent();
            DataContext = this;
            using (var db = new ServiceProgramContext())
            {
                Device dev = db.Devices.Find(device.Id);
                DeviceId = dev.Id;
                DeviceName = dev.Name;
                SerialNumber = dev.SerialNumber;
                Bought = dev.Bought;
                LastCheck = dev.LastCheck;
                NextCheck = dev.NextCheck;
                bool service = dev.BoughtByUs;
                Opmerking = dev.Opmerking;
                bool kapot = dev.Broken;
                Broken = kapot;
                bool weg = dev.Lost;
                Lost = weg;
                bool gnop = dev.NoS;
                GeenOp = gnop;
                Reference = dev.Reference;
                if (dev.Sensor1 != null)
                {
                    Sensor1 = dev.Sensor1.Name;
                    Alarm1Name = Sensor1;
                    Alarm1Group.Visibility = Visibility.Visible;
                    AlarmTitle.Visibility = Visibility.Visible;
                }
                if (dev.Sensor2 != null)
                {
                    Sensor2 = dev.Sensor2.Name;
                    Alarm2Name = Sensor2;
                    Alarm2Group.Visibility = Visibility.Visible;
                }
                if (dev.Sensor3 != null)
                {
                    Sensor3 = dev.Sensor3.Name;
                    Alarm3Name = Sensor3;
                    Alarm3Group.Visibility = Visibility.Visible;
                }
                if (dev.Sensor4 != null)
                {
                    Sensor4 = dev.Sensor4.Name;
                    Alarm4Name = Sensor4;
                    Alarm4Group.Visibility = Visibility.Visible;
                }
                if (dev.Sensor5 != null)
                {
                    Sensor5 = dev.Sensor5.Name;
                    Alarm5Name = Sensor5;
                    Alarm5Group.Visibility = Visibility.Visible;
                }
                if (dev.Sensor6 != null)
                {
                    Sensor6 = dev.Sensor6.Name;
                    Alarm6Name = Sensor6;
                    Alarm6Group.Visibility = Visibility.Visible;
                }
                if (dev.Sensor7 != null)
                {
                    Sensor7 = dev.Sensor7.Name;
                    Alarm7Name = Sensor7;
                    Alarm7Group.Visibility = Visibility.Visible;
                }
                if (dev.Sensor8 != null)
                {
                    Sensor8 = dev.Sensor8.Name;
                    Alarm8Name = Sensor8;
                    Alarm8Group.Visibility = Visibility.Visible;
                }
                if (!kapot)
                {
                    stuk.Visibility = Visibility.Collapsed;
                }
                if (!service)
                {
                    gekocht.Visibility = Visibility.Collapsed;
                }
                if (!weg)
                {
                    lost.Visibility = Visibility.Collapsed;
                }
                if (!gnop)
                {
                    geenOp.Visibility = Visibility.Collapsed;
                }
                Note = dev.Note;
                Price = dev.Price;
                Alarm1L = dev.Alarm1L;
                Alarm1H = dev.Alarm1H;
                Alarm1S = dev.Alarm1S;
                Alarm1T = dev.Alarm1T;
                Alarm2L = dev.Alarm2L;
                Alarm2H = dev.Alarm2H;
                Alarm2S = dev.Alarm2S;
                Alarm2T = dev.Alarm2T;
                Alarm3L = dev.Alarm3L;
                Alarm3H = dev.Alarm3H;
                Alarm3S = dev.Alarm3S;
                Alarm3T = dev.Alarm3T;
                Alarm4L = dev.Alarm4L;
                Alarm4H = dev.Alarm4H;
                Alarm4S = dev.Alarm4S;
                Alarm4T = dev.Alarm4T;
                Alarm5L = dev.Alarm5L;
                Alarm5H = dev.Alarm5H;
                Alarm5S = dev.Alarm5S;
                Alarm5T = dev.Alarm5T;
                Alarm6L = dev.Alarm6L;
                Alarm6H = dev.Alarm6H;
                Alarm6S = dev.Alarm6S;
                Alarm6T = dev.Alarm6T;
                Alarm7L = dev.Alarm7L;
                Alarm7H = dev.Alarm7H;
                Alarm7S = dev.Alarm7S;
                Alarm7T = dev.Alarm7T;
                Alarm8L = dev.Alarm8L;
                Alarm8H = dev.Alarm8H;
                Alarm8S = dev.Alarm8S;
                Alarm8T = dev.Alarm8T;
            }
            UpdateChecksGrid();
        }
        public void UpdateChecksGrid()
        {
            using (var db = new ServiceProgramContext())
            {
                List<CheckUp> checks = db.CheckUps.Where(c => c.Device.Id == DeviceId).ToList();
                checks.Sort((x, y) => DateTime.Compare(x.Date, y.Date));
                ChecksGrid.Items.Clear();
                foreach (var check in checks)
                {
                   ChecksGrid.Items.Add(check);
                }
            }
            SelectedCheck = null;
        }

        private void ChecksGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CheckUp client = (CheckUp)ChecksGrid.SelectedItem;
            if (client != null)
            {
                using (var db = new ServiceProgramContext())
                {
                    SelectedCheck = db.CheckUps.Find(client.Id);
                }
            }
        }

        private void Button_Certificate(object sender, RoutedEventArgs e)
        {
            if (SelectedCheck == null)
            {
                MessageBoxResult result = MessageBox.Show("Selecteer een kalibratie om het certificaat op te vragen.", "", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                using (var db = new ServiceProgramContext())
                {
                    var checkUp = db.CheckUps.Find(SelectedCheck.Id);
                    if (checkUp.Alarm1L == null)
                    {
                        checkUp.Alarm1L = Alarm1L;
                        checkUp.Alarm1H = Alarm1H;
                        checkUp.Alarm1S = Alarm1S;
                        checkUp.Alarm1T = Alarm1T;
                        checkUp.Alarm2L = Alarm2L;
                        checkUp.Alarm2H = Alarm2H;
                        checkUp.Alarm2S = Alarm2S;
                        checkUp.Alarm2T = Alarm2T;
                        checkUp.Alarm3L = Alarm3L;
                        checkUp.Alarm3H = Alarm3H;
                        checkUp.Alarm3S = Alarm3S;
                        checkUp.Alarm3T = Alarm3T;
                        checkUp.Alarm4L = Alarm4L;
                        checkUp.Alarm4H = Alarm4H;
                        checkUp.Alarm4S = Alarm4S;
                        checkUp.Alarm4T = Alarm4T;
                        checkUp.Alarm5L = Alarm5L;
                        checkUp.Alarm5H = Alarm5H;
                        checkUp.Alarm5S = Alarm5S;
                        checkUp.Alarm5T = Alarm5T;
                        checkUp.Alarm6L = Alarm6L;
                        checkUp.Alarm6H = Alarm6H;
                        checkUp.Alarm6S = Alarm6S;
                        checkUp.Alarm6T = Alarm6T;
                        checkUp.Alarm7L = Alarm7L;
                        checkUp.Alarm7H = Alarm7H;
                        checkUp.Alarm7S = Alarm7S;
                        checkUp.Alarm7T = Alarm7T;
                        checkUp.Alarm8L = Alarm8L;
                        checkUp.Alarm8H = Alarm8H;
                        checkUp.Alarm8S = Alarm8S;
                        checkUp.Alarm8T = Alarm8T;
                    }
                    db.SaveChanges();
                }
                Certificate cert = new Certificate(SelectedCheck);
            }
        }

        private void Button_EditKali(object sender, RoutedEventArgs e)
        {
            if (SelectedCheck == null)
            {
                MessageBoxResult result = MessageBox.Show("Selecteer een kalibratie om het te bewerken.", "", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                EditCheck editCheck = new EditCheck(SelectedCheck)
                {
                    Owner = this
                };
                editCheck.Show();
             }
        }
        private void Button_DeleteCert(object sender, RoutedEventArgs e)
        {
            if (SelectedCheck == null)
            {
                MessageBoxResult result = MessageBox.Show("Selecteer een kalibratie om het certificaat op te vragen.", "", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                using (var db = new ServiceProgramContext())
                {
                    CheckUp check = db.CheckUps.Find(SelectedCheck.Id);
                    db.CheckUps.Remove(check);
                    db.SaveChanges();
                }
                UpdateChecksGrid();
            }
        }
        private void ChecksGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }
    }
}
