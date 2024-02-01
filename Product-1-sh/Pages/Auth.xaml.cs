using DBShop;
using DBShop.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
                   NavigationService.Navigate(new CatalogItems());
                }
                else
                {
                    ErrorBox.Visibility = Visibility;
                }
            }
        }
    }
    public static class GetUsersDb
    {
        private static List<Users> user = new List<Users>();

        public static List<Users> GetUsers() 
        {
            return user;
        }


    }
}
