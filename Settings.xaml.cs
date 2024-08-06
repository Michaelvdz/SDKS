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
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        public int Number { get; set; }
        public List<ComboData> List { get; set; }
        public Settings()
        {
            InitializeComponent();
            DataContext = this;
            using (var db = new ServiceProgramContext())
            {
                var query = from s in db.Settings
                            where s.Key == "KalibratieNummer"
                            select s.Value;
                var currentNumber = query.First();
                Number = Convert.ToInt32(currentNumber);

                String id = "0";
                id = db.Settings.Where(s => s.Key == "Verhuur").First().Value;
                List<Client> clients = db.Clients.ToList();
                List = new List<ComboData>();
                foreach (var client in clients)
                {
                    List.Add(new ComboData { Id = client.Id, Value = client.Company });
                }

                companies.ItemsSource = List;
                companies.DisplayMemberPath = "Value";
                companies.SelectedValuePath = "Id";
                companies.SelectedValue = id;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new ServiceProgramContext())
            {
                Setting setting = db.Settings.Where(s => s.Key == "KalibratieNummer").First();
                setting.Value = (Number).ToString();
                Setting setting2 = db.Settings.Where(s => s.Key == "Verhuur").First();
                setting2.Value = companies.SelectedValue.ToString();
                db.SaveChanges();
            }
            this.Close();
            this.Owner.Activate();
        }

        public class ComboData
        {
            public int Id { get; set; }
            public string Value { get; set; }
        }
    }
}
