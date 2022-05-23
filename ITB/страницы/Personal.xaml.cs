using ITB.DataFilesApp;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ITB.страницы
{
    /// <summary>
    /// Логика взаимодействия для Personal.xaml
    /// </summary>
    public partial class Personal : Page
    {
        ITBEntities dataEntities = new ITBEntities();
        public Personal()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var query =
            from product in dataEntities.Employer
            select new { product.Id, product.Name, product.Surname, product.Login, product.Password, product.Role };

            PerGrid.ItemsSource = query.ToList();
        }

        private void Reload_Click(object sender, RoutedEventArgs e)
        {
            var query =
            from product in dataEntities.Employer
            select new { product.Id, product.Name, product.Surname, product.Login, product.Password, product.Role};

            PerGrid.ItemsSource = query.ToList();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int roleId = Convert.ToInt32(Role.Text);
                Employer emp = new Employer()
                {
                    Name = Name.Text,
                    Surname = Surname.Text,
                    Login = Login.Text,
                    Password = Password.Text,
                    Role = roleId
                    
                };
                Connect.entObj.Employer.Add(emp);
                Connect.entObj.SaveChanges();
                MessageBox.Show(
                    "Работник добавлен",
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
            int id = Convert.ToInt32(IdToDel.Text);
            var deleteOrderDetails =
            from details in dataEntities.Employer
            where details.Id == id
            select details;

            foreach (var detail in deleteOrderDetails)
            {
                dataEntities.Employer.Remove(detail);
                MessageBox.Show(
                    "Работник удален",
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
