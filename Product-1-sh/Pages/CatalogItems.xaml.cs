﻿
using DBShop.Models;
using System.Windows;
using System.Windows.Controls;
using static Product_1_sh.Pages.Auth;

namespace Product_1_sh.Pages
{
    /// <summary>
    /// Логика взаимодействия для CatalogItems.xaml
    /// </summary>
    /// 
    public partial class CatalogItems : Page
    {
        public CatalogItems()
        {
            InitializeComponent();
            var context = DbContext.Context;
            List<ItemList> prods = context.itemLists.ToList();
            listView.ItemsSource = prods;


            if (CurrentUser.AuthUser.IsAdmin == true)
            {
                TextProver.Content = "Админ";
                TextProver.Visibility = Visibility.Visible;
            }
            else if (CurrentUser.AuthUser.IsManager == true)
            {
                TextProver.Content = "Менеджер";
                TextProver.Visibility = Visibility.Visible;
            }
            else if (CurrentUser.AuthUser.IsGuest == true)
            {
                TextProver.Content = "Гость";
                TextProver.Visibility = Visibility.Visible;
            }
        }
    }
}
