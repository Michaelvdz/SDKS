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
    /// Interaction logic for Sensoren.xaml
    /// </summary>
    public partial class Sensoren : Window
    {
        Sensor selectedSensor = null;

        public Sensoren()
        {
            InitializeComponent();
            DataContext = this;

            UpdateSensorGrid();
        }

        private void SensorGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Sensor sensor = (Sensor)SensorGrid.SelectedItem;
            if (sensor != null)
            {
                using (var db = new ServiceProgramContext())
                {
                    selectedSensor = db.Sensors.Find(sensor.Id);
                }
            }
        }

        private void SensorGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex()).ToString();
        }

        public void UpdateSensorGrid()
        {
            using (var db = new ServiceProgramContext())
            {
                List<Sensor> sensors = db.Sensors.ToList();
                sensors.Sort((x, y) => String.Compare(x.Name, y.Name));
                SensorGrid.Items.Clear();
                foreach (var sensor in sensors)
                {
                    SensorGrid.Items.Add(sensor);
                }
            }
        }

        private void Button_ClickNewSensor(object sender, RoutedEventArgs e)
        {
            NewSensor newsensor = new NewSensor()
            {
                Owner = this
            };
            newsensor.Show();
        }

        private void Button_ClickEditSensor(object sender, RoutedEventArgs e)
        {
            if (selectedSensor == null)
            {
                MessageBoxResult result = MessageBox.Show("Selecteer een sensor om te bewerken.", "", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                UpdateSensor updatesensor = new UpdateSensor(selectedSensor)
                {
                    Owner = this
                };
                updatesensor.Show();
            }
        }
        private void Button_ClickDeleteSensor(object sender, RoutedEventArgs e)
        {
            if (selectedSensor == null)
            {
                MessageBoxResult result = MessageBox.Show("Selecteer een sensor om te verwijderen.", "", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                using (var db = new ServiceProgramContext())
                {
                    Sensor sensor = db.Sensors.Find(selectedSensor.Id);
                    db.Sensors.Remove(sensor);
                    db.SaveChanges();
                }
                UpdateSensorGrid();
            }
        }
    }
}
