using ServiceClient_app.MVVM.Model;
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

namespace ServiceClient_app.MVVM.View
{
    /// <summary>
    /// Логика взаимодействия для ZapisWindow.xaml
    /// </summary>
    public partial class ZapisWindow : Window
    {
        private int serviceId;
        public ZapisWindow(Service service)
        {
            InitializeComponent();
            serviceId = service.id;
            date.Text = DateTime.Now.ToString();
            serviceTextBlock.DataContext = service;
            clients.ItemsSource = Client.GetClients();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var zapis = new Zapis();
            zapis.ClientID = (clients.SelectedItem as Client).id;
            zapis.ServiceID = serviceId;
            zapis.Date = DateTime.Parse(date.Text);
            if(!zapis.Add())
            {
                MessageBox.Show("Ошибка записи");
                return;
            }
            Close();
        }
    }
}
