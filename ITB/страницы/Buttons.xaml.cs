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
    /// Логика взаимодействия для Buttons.xaml
    /// </summary>
    public partial class Buttons : Page
    {
        
        public Buttons()
        {
            InitializeComponent();
            

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Main.main.Navigate(new MainPage());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Main.main.Navigate(new Clients());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Main.main.Navigate(new Catalog());
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Main.main.Navigate(new Orders());
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Main.main.Navigate(new Personal());
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (MainWindow.IsAdmin == false)
            {
                AdminBut.Visibility = Visibility.Hidden;
            }
        }
    }
}
