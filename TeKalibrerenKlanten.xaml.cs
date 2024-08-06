using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
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
using Microsoft.Office.Interop.Outlook;

namespace Service_Program
{
    /// <summary>
    /// Interaction logic for TeKalibreren.xaml
    /// </summary>
    public partial class TeKalibrerenKlanten : Window
    {
        public DateTime? From { get; set; }
        public DateTime? Untill { get; set; }
        public String ClientName { get; set; }
        public Client SelectedClient { get; set; }
        public List<Client> clients { get; set; }


        public TeKalibrerenKlanten()
        {
            InitializeComponent();
            DataContext = this;
            From = DateTime.Now;
            DateTime month = DateTime.Now.AddMonths(1);
            Untill = month;
            UpdateClientsGrid();
        }

        public void UpdateClientsGrid()
        {
            using (var db = new ServiceProgramContext())
            {
                var fromdt = (DateTime)From;
                var from = fromdt.Date;
                var untilldt = (DateTime)Untill;
                var untill = untilldt.Date;

                clients = db.Clients.Where(d => d.KalibratieMaand > from).Where(d => d.KalibratieMaand <= untill).ToList();
                ClientGrid.Items.Clear();
                foreach (var client in clients)
                {
                    ClientGrid.Items.Add(client);
                }
            }
        }

        private void ClientGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Client device = (Client)ClientGrid.SelectedItem;
            if (device != null)
            {
                using (var db = new ServiceProgramContext())
                {
                    SelectedClient = db.Clients.Find(device.Id);
                }
            }
        }
        private void Button_ClickExcel(object sender, RoutedEventArgs e)
        {


            ExcelCreatorKalibratieKlanten kalibratieexcel = new ExcelCreatorKalibratieKlanten(clients);
            kalibratieexcel.OpenFile();


        }
        private void Button_ZoekKalibration(object sender, RoutedEventArgs e)
        {
            UpdateClientsGrid();
        }
    }
}
