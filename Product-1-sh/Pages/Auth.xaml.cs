﻿using DBShop;
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
        Random random = new Random();
        static int count = 0;
        static string ALF = "1234567890QWERTYUIOPASDFGHJKLZXCVBNM";
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
            try
            {
                var user = DbContext.Context.users.FirstOrDefault(u => u.Login == LoginTextBox.Text && u.Password == PasswordTextBox.Password);
                if (user != null)
                {
                    CurrentUser.AuthUser = user;
                    NavigationService.Navigate(new CatalogItems());
                }
                else if (count == 5)
                {
                    BlockCapcha.Visibility = Visibility.Visible;
                    LableCapcha.Visibility = Visibility.Visible;
                    ConfirmCapcha.Visibility = Visibility.Visible;
                    BlockCapcha.Text = Convert.ToString(random.Next(ALF.Length));
                    if (BlockCapcha.Text == ConfirmCapcha.Text)
                    {
                        BlockCapcha.Visibility = Visibility.Hidden;
                        LableCapcha.Visibility = Visibility.Hidden;
                        ConfirmCapcha.Visibility = Visibility.Hidden;
                        NavigationService.Navigate(new CatalogItems());
                    }
                }
                else
                {
                    count++;
                    ErrorBox.Visibility = Visibility;
                }
            }
            catch
            {
                MessageBox.Show("Программа завершае работу, просба не волноваться т.к оно запланированно");
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                var user = DbContext.Context.users.FirstOrDefault(u => u.Login == "guest" && u.Password == "guest");
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
            catch 
            {
                MessageBox.Show("Программа завершае работу, просба не волноваться т.к оно запланированно");
            }
        }
    }
}
