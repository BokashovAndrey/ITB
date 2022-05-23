using ITB.DataFilesApp;
using ITB.страницы;
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

namespace ITB
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static bool IsAdmin = true;
        public static string FIO;
        public static string Role;
        public MainWindow()
        {
            InitializeComponent();

            Connect.entObj = new ITBEntities();
        }

        private void loginBut_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var userObj = Connect.entObj.Employer.FirstOrDefault(
                    x => x.Login == login.Text && x.Password == Password.Password);

                if (userObj == null)
                {
                    MessageBox.Show("пользователь не найден",
                        "Уведомление",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning);
                }
                else
                {
                    Main main = new Main();
                    switch (userObj.Role)
                    {
                        case 1:
                            MessageBox.Show($"Здравствуйте {userObj.Name} {userObj.Surname}", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                            FIO = $"{userObj.Name} {userObj.Surname}";
                            Role = "Администратор";
                            IsAdmin = true;
                            main.Show();
                            Close();
                            break;
                        case 2:
                            MessageBox.Show($"Здравствуйте {userObj.Name} {userObj.Surname}", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                            FIO = $"{userObj.Name} {userObj.Surname}";
                            Role = "Менеджер";
                            IsAdmin= false;
                            main.Show();
                            Close();
                            break;

                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
