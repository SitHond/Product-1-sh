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
        public int count = 0;
        public static string ALF = "1234567890QWERTYUIOPASDFGHJKLZXCVBNM";
        public static class CurrentUser
        {
            public static Users AuthUser { get; set; }
        }
        public class DbContext
        {
            private static DBshop _dbContext;
            public static DBshop Context { 
               get {
                    if (_dbContext == null)
                    {
                        _dbContext = new DBshop();
                    }
                    return _dbContext;
                } 
            }
        }

        public Auth()
        {
            InitializeComponent();
        }

        private void LoginButton(object sender, RoutedEventArgs e)
        {       
                var user = DbContext.Context.users.FirstOrDefault(u => u.Login == LoginTextBox.Text && u.Password == PasswordTextBox.Password);

                if (user != null)
                {
                    CurrentUser.AuthUser = user;
                    NavigationService.Navigate(new CatalogItems());
                }
                else if (count == 5)
                {
                    Random random = new Random();
                    BlockCapcha.Visibility = Visibility.Visible;
                    LableCapcha.Visibility = Visibility.Visible;
                    ConfirmCapcha.Visibility = Visibility.Visible;
                    ConfirmBtn.Visibility = Visibility.Visible;
                    LoginBtn.IsEnabled = false;
                    BlockCapcha.Text = Convert.ToString(random.Next(ALF.Length));

                }
                else
                {
                    count++;
                    ErrorBox.Visibility = Visibility;
                }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (BlockCapcha.Text == ConfirmCapcha.Text)
            {
                LoginBtn.IsEnabled = true;
                BlockCapcha.Visibility = Visibility.Hidden;
                LableCapcha.Visibility = Visibility.Hidden;
                ConfirmCapcha.Visibility = Visibility.Hidden;
                ConfirmBtn.Visibility = Visibility.Hidden; 
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var user = DbContext.Context.users.FirstOrDefault(u => u.Login == "guest"  && u.Password == "guest");
            if (user != null)
            {
                CurrentUser.AuthUser = user;
                NavigationService.Navigate(new CatalogItems());
            }
            else
            {
                MessageBox.Show("Администратор не создал учетную запись гостя", "Error");
            }
        }
    }
}
