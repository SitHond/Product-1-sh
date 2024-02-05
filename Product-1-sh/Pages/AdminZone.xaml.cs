using DBShop;
using DBShop.Models;
using Microsoft.Identity.Client;
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
using static Product_1_sh.Pages.Auth;

namespace Product_1_sh.Pages
{
    /// <summary>
    /// Логика взаимодействия для AdminZone.xaml
    /// </summary>
    public partial class AdminZone : Page
    {
        public AdminZone()
        {
            InitializeComponent();
            var context = DbContext.Context;
            List<ItemList> prods = context.itemLists.ToList();
            dataGrid.ItemsSource = prods;

            TxTAd.Content = "Редактирование раздела с товарами";

        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            ItemList SelItem = (ItemList)dataGrid.SelectedItem;
            var itemDel = DbContext.Context.itemLists.FirstOrDefault(i => i.Id == SelItem.Id);
            DbContext.Context.Remove(SelItem);
            DbContext.Context.SaveChanges();
            var context = DbContext.Context;
            List<ItemList> prods = context.itemLists.ToList();
            dataGrid.ItemsSource = prods;
        }

        private void Vis_Click(object sender, RoutedEventArgs e)
        {
            if (AddForm.Visibility == Visibility.Visible)
            {
                AddForm.Visibility = Visibility.Collapsed;
            }
            else
            {
                AddForm.Visibility = Visibility.Visible;
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            ItemList itemList = new ItemList
            {
                Name = Tname.Text,
                Description = Tdesc.Text,
            };
            DbContext.Context.itemLists.Add(itemList);
            DbContext.Context.SaveChanges();

            var context = DbContext.Context;
            List<ItemList> prods = context.itemLists.ToList();
            dataGrid.ItemsSource = prods;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CatalogItems());
        }
    }
}
