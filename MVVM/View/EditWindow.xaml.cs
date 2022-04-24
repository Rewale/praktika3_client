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
    /// Логика взаимодействия для EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        private Service service { get; set; }
        private bool isNew = false;
        public EditWindow(Service service)
        {
            InitializeComponent();
            this.service = service;
            button_add.Content = "Обновить";
            DataContext = service;
        }
        public EditWindow()
        {
            InitializeComponent();
            this.service = new Service();
            DataContext = service;
            isNew = true;
        }

        private void button_add_Click(object sender, RoutedEventArgs e)
        {
            if(service.Validate() != string.Empty)
            {
                MessageBox.Show(service.Validate());
                return;
            }
            if(isNew)
            {
                if(service.Add())
                {
                    MessageBox.Show("Добавление прошло успешно!");
                    Close();
                }
            }
            else
            {
                if(service.Save())
                {
                    MessageBox.Show("Обновление данных прошло успешно!");
                    Close();
                }
            }
        }

        private void zapis_click(object sender, RoutedEventArgs e)
        {
            new ZapisWindow(service).ShowDialog();

        }
    }
}
