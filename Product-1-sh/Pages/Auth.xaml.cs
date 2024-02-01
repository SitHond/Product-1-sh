using DBShop;
using DBShop.Models;
using System.Windows;
using System.Windows.Controls;

namespace Product_1_sh.Pages
{
    /// <summary>
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Auth : Page
    {
        public Auth()
        {
            InitializeComponent();


        }

        private void LoginButton(object sender, RoutedEventArgs e)
        {
            using (var context = new DBshop())
            {
                var user = context.users.FirstOrDefault(u => u.Username == LoginTextBox.Text && u.Password == PasswordTextBox.Password);

                if (user != null)
                {
                    CurrentUser.AuthUser = user;
                    NavigationService.Navigate(new CatalogItems());
                }
                else
                {
                    ErrorBox.Visibility = Visibility;
                }
            }
        }
    }
    public static class CurrentUser
    {
        public static Users AuthUser { get; set; }
    }
}
