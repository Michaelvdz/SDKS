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
    /// Interaction logic for NewSensor.xaml
    /// </summary>
    public partial class NewSensor : Window
    {

        public String SensorName { get; set; }
        public String Range { get; set; }
        public String Resolution { get; set; }
        public String Laag { get; set; }
        public String Hoog { get; set; }
        public String Stel { get; set; }
        public String Twa { get; set; }
        public String Conc { get; set; }

        public NewSensor()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new ServiceProgramContext())
            {
                var sensor = new Sensor() { Name = SensorName, Range = Range, Resolution = Resolution, Hoog = Hoog, Laag = Laag, Stel = Stel, Twa = Twa, Conc = Conc};
                db.Sensors.Add(sensor);
                db.SaveChanges();

            }
            ((Sensoren)this.Owner).UpdateSensorGrid();
            this.Close();
            this.Owner.Activate();
        }
    }
}
