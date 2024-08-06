using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Interaction logic for NewDevice.xaml
    /// </summary>
    public partial class NewDefaultDevice : Window
    {

        public String DeviceName { get; set; }
        public String Note { get; set; }
        public String Opmerking { get; set; }
        public int SensorCount { get; set; }
        public List<Sensor> Sensors { get; set; }
        Sensor SelectedSensor;

        public NewDefaultDevice()
        {
            InitializeComponent();
            DataContext = this;
            Sensors = new List<Sensor>();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new ServiceProgramContext())
            {
                var device = new PresetDevs() { Name = DeviceName, Note = Note, Opmerking = Opmerking};
                if (Sensors.Count() >= 1 && Sensors.ElementAt(0) != null)
                {
                    device.Sensor1 = db.Sensors.Find(Sensors.ElementAt(0).Id);
                }
                if (Sensors.Count() >= 2 && Sensors.ElementAt(1) != null)
                {
                    device.Sensor2 = db.Sensors.Find(Sensors.ElementAt(1).Id);
                }
                if (Sensors.Count() >= 3 && Sensors.ElementAt(2) != null)
                {
                    device.Sensor3 = db.Sensors.Find(Sensors.ElementAt(2).Id);
                }
                if (Sensors.Count() >= 4 && Sensors.ElementAt(3) != null)
                {
                    device.Sensor4 = db.Sensors.Find(Sensors.ElementAt(3).Id);
                }
                if (Sensors.Count() >= 5 && Sensors.ElementAt(4) != null)
                {
                    device.Sensor5 = db.Sensors.Find(Sensors.ElementAt(4).Id);
                }
                if (Sensors.Count() >= 6 && Sensors.ElementAt(5) != null)
                {
                    device.Sensor6 = db.Sensors.Find(Sensors.ElementAt(5).Id);
                }
                if (Sensors.Count() >= 7 && Sensors.ElementAt(6) != null)
                {
                    device.Sensor7 = db.Sensors.Find(Sensors.ElementAt(6).Id);
                }
                if (Sensors.Count() >= 8 && Sensors.ElementAt(7) != null)
                {
                    device.Sensor8 = db.Sensors.Find(Sensors.ElementAt(7).Id);
                }
                if (Sensors.Count() >= 9 && Sensors.ElementAt(8) != null)
                {
                    device.Sensor9 = db.Sensors.Find(Sensors.ElementAt(8).Id);
                }
                if (Sensors.Count() >= 10 && Sensors.ElementAt(9) != null)
                {
                    device.Sensor10 = db.Sensors.Find(Sensors.ElementAt(9).Id);
                }
                if (Sensors.Count() >= 11 && Sensors.ElementAt(10) != null)
                {
                    device.Sensor11 = db.Sensors.Find(Sensors.ElementAt(10).Id);
                }
                if (Sensors.Count() >= 12 && Sensors.ElementAt(11) != null)
                {
                    device.Sensor12 = db.Sensors.Find(Sensors.ElementAt(11).Id);
                }
                if (Sensors.Count() >= 13 && Sensors.ElementAt(12) != null)
                {
                    device.Sensor13 = db.Sensors.Find(Sensors.ElementAt(12).Id);
                }
                if (Sensors.Count() >= 14 && Sensors.ElementAt(13) != null)
                {
                    device.Sensor14 = db.Sensors.Find(Sensors.ElementAt(13).Id);
                }
                if (Sensors.Count() >= 15 && Sensors.ElementAt(14) != null)
                {
                    device.Sensor15 = db.Sensors.Find(Sensors.ElementAt(14).Id);
                }
                if (Sensors.Count() >= 16 && Sensors.ElementAt(15) != null)
                {
                    device.Sensor16 = db.Sensors.Find(Sensors.ElementAt(15).Id);
                }
                if (Sensors.Count() >= 17 && Sensors.ElementAt(16) != null)
                {
                    device.Sensor17 = db.Sensors.Find(Sensors.ElementAt(16).Id);
                }
                if (Sensors.Count() >= 18 && Sensors.ElementAt(17) != null)
                {
                    device.Sensor18 = db.Sensors.Find(Sensors.ElementAt(17).Id);
                }
                if (Sensors.Count() >= 19 && Sensors.ElementAt(18) != null)
                {
                    device.Sensor19 = db.Sensors.Find(Sensors.ElementAt(18).Id);
                }
                if (Sensors.Count() >= 20 && Sensors.ElementAt(19) != null)
                {
                    device.Sensor20 = db.Sensors.Find(Sensors.ElementAt(19).Id);
                }
                if (Sensors.Count() >= 21 && Sensors.ElementAt(20) != null)
                {
                    device.Sensor21 = db.Sensors.Find(Sensors.ElementAt(20).Id);
                }
                if (Sensors.Count() >= 22 && Sensors.ElementAt(21) != null)
                {
                    device.Sensor22 = db.Sensors.Find(Sensors.ElementAt(21).Id);
                }
                if (Sensors.Count() >= 23 && Sensors.ElementAt(22) != null)
                {
                    device.Sensor23 = db.Sensors.Find(Sensors.ElementAt(22).Id);
                }
                if (Sensors.Count() >= 24 && Sensors.ElementAt(23) != null)
                {
                    device.Sensor24 = db.Sensors.Find(Sensors.ElementAt(23).Id);
                }
                if (Sensors.Count() >= 25 && Sensors.ElementAt(24) != null)
                {
                    device.Sensor25 = db.Sensors.Find(Sensors.ElementAt(24).Id);
                }
                if (Sensors.Count() >= 26 && Sensors.ElementAt(25) != null)
                {
                    device.Sensor26 = db.Sensors.Find(Sensors.ElementAt(25).Id);
                }
                if (Sensors.Count() >= 27 && Sensors.ElementAt(26) != null)
                {
                    device.Sensor27 = db.Sensors.Find(Sensors.ElementAt(26).Id);
                }
                if (Sensors.Count() >= 28 && Sensors.ElementAt(27) != null)
                {
                    device.Sensor28 = db.Sensors.Find(Sensors.ElementAt(27).Id);
                }
                if (Sensors.Count() >= 29 && Sensors.ElementAt(28) != null)
                {
                    device.Sensor29 = db.Sensors.Find(Sensors.ElementAt(28).Id);
                }
                if (Sensors.Count() >= 30 && Sensors.ElementAt(29) != null)
                {
                    device.Sensor30 = db.Sensors.Find(Sensors.ElementAt(29).Id);
                }
                if (Sensors.Count() >= 31 && Sensors.ElementAt(30) != null)
                {
                    device.Sensor31 = db.Sensors.Find(Sensors.ElementAt(30).Id);
                }
                if (Sensors.Count() >= 32 && Sensors.ElementAt(31) != null)
                {
                    device.Sensor32 = db.Sensors.Find(Sensors.ElementAt(31).Id);
                }
                if (Sensors.Count() >= 33 && Sensors.ElementAt(32) != null)
                {
                    device.Sensor33 = db.Sensors.Find(Sensors.ElementAt(32).Id);
                }
                if (Sensors.Count() >= 34 && Sensors.ElementAt(33) != null)
                {
                    device.Sensor34 = db.Sensors.Find(Sensors.ElementAt(33).Id);
                }
                if (Sensors.Count() >= 35 && Sensors.ElementAt(34) != null)
                {
                    device.Sensor35 = db.Sensors.Find(Sensors.ElementAt(34).Id);
                }
                if (Sensors.Count() >= 36 && Sensors.ElementAt(35) != null)
                {
                    device.Sensor36 = db.Sensors.Find(Sensors.ElementAt(35).Id);
                }
                if (Sensors.Count() >= 37 && Sensors.ElementAt(36) != null)
                {
                    device.Sensor37 = db.Sensors.Find(Sensors.ElementAt(36).Id);
                }
                if (Sensors.Count() >= 38 && Sensors.ElementAt(37) != null)
                {
                    device.Sensor38 = db.Sensors.Find(Sensors.ElementAt(37).Id);
                }
                if (Sensors.Count() >= 39 && Sensors.ElementAt(38) != null)
                {
                    device.Sensor39 = db.Sensors.Find(Sensors.ElementAt(38).Id);
                }
                if (Sensors.Count() >= 40 && Sensors.ElementAt(39) != null)
                {
                    device.Sensor40 = db.Sensors.Find(Sensors.ElementAt(39).Id);
                }

                db.DefaultDevices.Add(device);
                db.SaveChanges();
                ((DefaultDevices)this.Owner).UpdateDevicesGrid();
            }
            this.Close();
            this.Owner.Activate();
        }

        public void UpdateSensorGrid()
        {
            using (var db = new ServiceProgramContext())
            {
                SensorCount = 0;
                SensorGrid.Items.Clear();
                foreach (var sensor in Sensors)
                {
                    SensorGrid.Items.Add(sensor);
                    SensorCount++;
                }
            }
        }

        private void SensorGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Sensor sensor = (Sensor)SensorGrid.SelectedItem;
            if (sensor != null)
            {
                using (var db = new ServiceProgramContext())
                {
                    SelectedSensor = db.Sensors.Find(sensor.Id);
                }
            }
        }

        private void SensorGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex()).ToString();
        }

        private void Button_ClickAddSensors(object sender, RoutedEventArgs e)
        {
            AddSensors addSensors = new AddSensors(Sensors)
            {
                Owner = this
            };
            addSensors.Show();
        }
    }
}
