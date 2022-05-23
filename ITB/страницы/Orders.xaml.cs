using ITB.DataFilesApp;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для Orders.xaml
    /// </summary>
    public partial class Orders : Page
    {
        ITBEntities dataEntities = new ITBEntities();
        public Orders()
        {
            InitializeComponent();
        }

        private void Find_Click(object sender, RoutedEventArgs e)
        {
            if (FindValue.Text != "")
            {
                int value = Convert.ToInt32(FindValue.Text);
                var query =
                from product in dataEntities.Order
                where product.Id == value
                select new { product.Id, ProductId = product.Product.Name, ClientId = product.Client.Surname, StatusId = product.Status.StatusName };

                OrderGrid.ItemsSource = query.ToList();
            }
            else
            {
                var query =
                from product in dataEntities.Order
                select new { product.Id, ProductId = product.Product.Name,ClientId = product.Client.Surname, StatusId = product.Status.StatusName,TotalPrice = product.Product.Price};

                OrderGrid.ItemsSource = query.ToList();
            }
        }

        private void SumBut_Click(object sender, RoutedEventArgs e)
        {
            int count = 0;
            int count2 = 0;
            int count3 = 0;
            string v1 = "Разработка ПО на заказ";
            string v2 = "Установка офисных программ";
            string v3 = "Установка программ для повседневного использования";
            double sum = 0d;
            for (int i = 0; i < OrderGrid.Items.Count; i++)
            {
                sum += double.Parse((OrderGrid.Columns[4].GetCellContent(OrderGrid.Items[i]) as TextBlock).Text);
                if ((OrderGrid.Columns[1].GetCellContent(OrderGrid.Items[i]) as TextBlock).Text == v1)
                    count++;
                else if ((OrderGrid.Columns[1].GetCellContent(OrderGrid.Items[i]) as TextBlock).Text == v2)
                    count2++;
                else if ((OrderGrid.Columns[1].GetCellContent(OrderGrid.Items[i]) as TextBlock).Text == v3)
                    count3++;
          
            }
            MessageBox.Show(
                    $"Общая сумма заказов - {sum}," +
                    $"\nВсего заказов на 'Разработка ПО на заказ' - {count}" +
                    $"\nВсего заказов на 'Установка офисных программ' - {count2}" +
                    $"\nВсего заказов на 'Установка программ для повседневного использования' - {count3}",
                    "Уведомление",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
        }
    }
}
