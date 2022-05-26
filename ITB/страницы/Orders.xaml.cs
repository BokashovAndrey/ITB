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
        string findName;
        ITBEntities dataEntities = new ITBEntities();
        public Orders()
        {
            InitializeComponent();
            FindValue.SelectedValuePath = "Id";
            FindValue.DisplayMemberPath = "MonthName";
            FindValue.ItemsSource = Connect.entObj.Month.ToList();
        }

        private void Find_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt32(FindValue.SelectedValue) != 13)
            {
                findName = FindValue.Text;
                int value = Convert.ToInt32(FindValue.SelectedValue);
                var query =
                from product in dataEntities.Order
                where product.IdMonth == value
                select new { product.Id, ProductId = product.Product.Name, ClientId = product.Client.Surname, StatusId = product.Status.StatusName,Month = product.Month.MonthName, TotalPrice = product.Product.Price };

                OrderGrid.ItemsSource = query.ToList();
            }
            else
            {          
                var query =
                from product in dataEntities.Order
                select new { product.Id, ProductId = product.Product.Name,ClientId = product.Client.Surname, StatusId = product.Status.StatusName, Month = product.Month.MonthName, TotalPrice = product.Product.Price};

                OrderGrid.ItemsSource = query.ToList();
            }
        }

        private void SumBut_Click(object sender, RoutedEventArgs e)
        {
            findName = FindValue.Text;
            int count = 0;
            int count2 = 0;
            int count3 = 0;
            string v1 = "Разработка ПО на заказ";
            string v2 = "Установка офисных программ";
            string v3 = "Установка программ для повседневного использования";
            double sum = 0d;
            for (int i = 0; i < OrderGrid.Items.Count; i++)
            {
                sum += double.Parse((OrderGrid.Columns[5].GetCellContent(OrderGrid.Items[i]) as TextBlock).Text);
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
                    $"\nВсего заказов на 'Установка программ для повседневного использования' - {count3}" +
                    $"\nВсего заказов за {findName} - {OrderGrid.Items.Count}",
                    "Уведомление",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
        }

        private void Test_Click(object sender, RoutedEventArgs e)
        {
            TTest.Text = FindValue.Text;
        }
    }
}
