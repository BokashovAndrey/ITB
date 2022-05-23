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
    /// Логика взаимодействия для Catalog.xaml
    /// </summary>
    public partial class Catalog : Page
    {
        ITBEntities dataEntities = new ITBEntities();
        public Catalog()
        {
            InitializeComponent();
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            var deleteOrderDetails =
            from details in dataEntities.Product
            where details.Name == DeleteBoxName.Text
            select details;

            foreach (var detail in deleteOrderDetails)
            {
                dataEntities.Product.Remove(detail);
                MessageBox.Show(
                    "Продукт удален",
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

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Product product = new Product()
                {
                    Name = AddBoxName.Text,
                    Price = Convert.ToDouble(AddBoxPrice.Text),
                };
                Connect.entObj.Product.Add(product);
                Connect.entObj.SaveChanges();
                MessageBox.Show(
                    "Продукт добавлен",
                    "Уведомление",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void Find_Click(object sender, RoutedEventArgs e)
        {
            if (FindValue.Text != "")
            {
                var query =
                from product in dataEntities.Product
                where product.Name == FindValue.Text
                select new { product.Id, product.Name, product.Price};

                ProductGrid.ItemsSource = query.ToList();
            }
            else
            {
                var query =
                from product in dataEntities.Product
                select new { product.Id, product.Name, product.Price };

                ProductGrid.ItemsSource = query.ToList();
            }
        }
    }
}
