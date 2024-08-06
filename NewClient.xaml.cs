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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class NewClient : Window
    {
        public String Company { get; set; }
        public String Contact { get; set; }
        public String Address1 { get; set; }
        public String Address2 { get; set; }
        public String Phone { get; set; }
        public String MobilePhone { get; set; }
        public String Email { get; set; }
        public String Note { get; set; }
        public String Maand { get; set; }
        public DateTime months { get; set; }

        public NewClient()
        {
            InitializeComponent();
            DataContext = this;
            months = DateTime.Today;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var client = new Client();
            using (var db = new ServiceProgramContext())
            {
                DateTime months2;
                if (months != null)
                {
                    months2 = (DateTime)months;
                }
                else
                {
                    months2 = DateTime.Now;
                }
                client = new Client() { Company = Company, Contact = Contact, Address1 = Address1, Address2 = Address2, Phone = Phone, MobilePhone = MobilePhone, Email = Email, Note = Note, KalibratieMaand = months2};
                db.Clients.Add(client);
                db.SaveChanges();
                
            }
            ((MainWindow)this.Owner).UpdateClientsGrid();
            this.Close();
            this.Owner.Activate();
        }
    }
}
