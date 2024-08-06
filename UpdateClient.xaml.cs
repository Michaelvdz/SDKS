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
    /// Interaction logic for UpdateClient.xaml
    /// </summary>
    public partial class UpdateClient : Window
    {
        public String Company { get; set; }
        public String Contact { get; set; }
        public String Address1 { get; set; }
        public String Address2 { get; set; }
        public String Phone { get; set; }
        public String MobilePhone { get; set; }
        public String Email { get; set; }
        public String Note { get; set; }
        public Boolean geenOp { get; set; }
        public DateTime? months { get; set; }
        Client client;

        public UpdateClient()
        {
            InitializeComponent();
            DataContext = this;
        }

        public UpdateClient(Client selectedClient)
        {
            InitializeComponent();
            DataContext = this;
            client = selectedClient;
            Company = selectedClient.Company;
            Contact = selectedClient.Contact;
            Address1 = selectedClient.Address1;
            Address2 = selectedClient.Address2;
            Phone = selectedClient.Phone;
            MobilePhone = selectedClient.MobilePhone;
            Email = selectedClient.Email;
            bool go = selectedClient.GeenOproep;
            geenOp = go;
            months = selectedClient.KalibratieMaand;
            Note = selectedClient.Note;
        }

        private void CheckBoxChangedOn(object sender, RoutedEventArgs e)
        {
            maand.Visibility = Visibility.Collapsed;
        }

        private void CheckBoxChangedOff(object sender, RoutedEventArgs e)
        {
            maand.Visibility = Visibility.Visible;
            months = DateTime.Now;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!geenOp)
            {
                DateTime temp = DateTime.MinValue;
                if (temp == (DateTime)months)
                {
                    MessageBoxResult result2 = MessageBox.Show("De kalibratiemaand dient nog aangevuld te worden!", "", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                }
                else
                {
                    MessageBoxResult result = MessageBox.Show("Bent u zeker dat u deze klant wilt aanpassen?", "", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    if (result == MessageBoxResult.Yes)
                    {
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
                            if (geenOp)
                            {
                                months2 = DateTime.MinValue;
                            }

                            var _client = db.Clients.Find(client.Id);
                            _client.Company = Company;
                            _client.Contact = Contact;
                            _client.Address1 = Address1;
                            _client.Address2 = Address2;
                            _client.Phone = Phone;
                            _client.MobilePhone = MobilePhone;
                            _client.Email = Email;
                            _client.Note = Note;
                            _client.GeenOproep = geenOp;
                            _client.KalibratieMaand = months2;
                            db.SaveChanges();

                        }
                        ((MainWindow)this.Owner).UpdateClientsGrid();
                        this.Close();
                        this.Owner.Activate();
                    }
                    else { }
                }
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Bent u zeker dat u deze klant wilt aanpassen?", "", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
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
                        if (geenOp)
                        {
                            months2 = DateTime.MinValue;
                        }

                        var _client = db.Clients.Find(client.Id);
                        _client.Company = Company;
                        _client.Contact = Contact;
                        _client.Address1 = Address1;
                        _client.Address2 = Address2;
                        _client.Phone = Phone;
                        _client.MobilePhone = MobilePhone;
                        _client.Email = Email;
                        _client.Note = Note;
                        _client.GeenOproep = geenOp;
                        _client.KalibratieMaand = months2;
                        db.SaveChanges();

                    }
                    ((MainWindow)this.Owner).UpdateClientsGrid();
                    this.Close();
                    this.Owner.Activate();
                }
                else { }
            }
        }
    }
}
