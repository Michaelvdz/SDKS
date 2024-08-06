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
    /// Interaction logic for UpdateSensor.xaml
    /// </summary>
    public partial class UpdateSensor : Window
    {
        public String SensorName { get; set; }
        public String Range { get; set; }
        public String Resolution { get; set; }
        public String Laag { get; set; }
        public String Hoog { get; set; }
        public String Stel { get; set; }
        public String Twa { get; set; }
        public String Conc { get; set; }
        Sensor sensor;

        public UpdateSensor()
        {
            InitializeComponent();
        }

        public UpdateSensor(Sensor selectedSensor)
        {
            InitializeComponent();
            DataContext = this;
            sensor = selectedSensor;
            SensorName = selectedSensor.Name;
            Range = selectedSensor.Range;
            Resolution = selectedSensor.Resolution;
            Laag = selectedSensor.Laag;
            Hoog = selectedSensor.Hoog;
            Stel = selectedSensor.Stel;
            Twa = selectedSensor.Twa;
            Conc = selectedSensor.Conc;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Bent u zeker dat u deze sensor wilt aanpassen?", "", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                using (var db = new ServiceProgramContext())
                {
                    var _sensor = db.Sensors.Find(sensor.Id);
                    _sensor.Name = SensorName;
                    _sensor.Range = Range;
                    _sensor.Resolution = Resolution;
                    _sensor.Laag = Laag;
                    _sensor.Hoog = Hoog;
                    _sensor.Twa = Twa;
                    _sensor.Stel = Stel;
                    _sensor.Conc = Conc;
                    db.SaveChanges();

                }
                ((Sensoren)this.Owner).UpdateSensorGrid();
                this.Close();
                this.Owner.Activate();
            }
            else { }
        }
    }
}
