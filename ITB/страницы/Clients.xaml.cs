using ITB.DataFilesApp;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ITB.страницы
{
    /// <summary>
    /// Логика взаимодействия для Clients.xaml
    /// </summary>
    public partial class Clients : Page
    {
        ITBEntities dataEntities = new ITBEntities();
        private Client currentClient = new Client();


        public Clients()
        {
            InitializeComponent();
            DataContext = currentClient;
        }

        private void Find_Click(object sender, RoutedEventArgs e)
        {
            
            if (FindValue.Text != "")
            {
                int idF = Convert.ToInt32(FindValue.Text);
                var query =
                from product in dataEntities.Client
                where product.Id == idF
                select new { product.Id, product.Name, product.Surname, product.Phone, product.Mail };

                ClientGrid.ItemsSource = query.ToList();
            }
            else
            {

                var query =
                from product in dataEntities.Client
                select new { product.Id, product.Name, product.Surname ,product.Phone,product.Mail};

                ClientGrid.ItemsSource = query.ToList();
            }


        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Client client = new Client()
                {
                    Name = AddBoxName.Text,
                    Surname = AddBoxSurname.Text,
                    Phone = AddBoxPhone.Text,
                    Mail = AddBoxMail.Text
                };
                Connect.entObj.Client.Add(client);
                Connect.entObj.SaveChanges();
                MessageBox.Show(
                    "Клиент добавлен",
                    "Уведомление",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            int id = Convert.ToInt32(DeleteBoxSurname.Text);
            var deleteOrderDetails =
            from details in dataEntities.Client
            where details.Id == id
            select details;

            foreach (var detail in deleteOrderDetails)
            {
                dataEntities.Client.Remove(detail);
                MessageBox.Show(
                    "Клиент удален",
                    "Уведомление",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }

            try
            {
                dataEntities.SaveChanges(); 
            }
            catch (Exception)
            {
                throw;
            }
            
        }
    }
}
