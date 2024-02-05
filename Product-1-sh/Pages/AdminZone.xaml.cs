
using DBShop.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using static Product_1_sh.Pages.Auth;

namespace Product_1_sh.Pages
{
    /// <summary>
    /// Логика взаимодействия для AdminZone.xaml
    /// </summary>
    public partial class AdminZone : Page
    {
        public void GetDataGrid()
        {
            var context = DbContext.Context;
            List<ItemList> prods = context.itemLists.ToList();
            dataGrid.ItemsSource = prods;
        }
        public AdminZone()
        {
            InitializeComponent();
            GetDataGrid();
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ItemList SelItem = (ItemList)dataGrid.SelectedItem;
                var itemDel = DbContext.Context.itemLists.FirstOrDefault(i => i.Id == SelItem.Id);
                DbContext.Context.Remove(SelItem);
                DbContext.Context.SaveChanges();
                GetDataGrid();
            }
            catch
            {
                MessageBox.Show("Программа завершае работу, просба не волноваться т.к оно запланированно");
            }
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
            try
            {
                ItemList itemList = new ItemList
                {
                    Name = Tname.Text,
                    Description = Tdesc.Text,
                };
                DbContext.Context.itemLists.Add(itemList);
                DbContext.Context.SaveChanges();

                GetDataGrid();
            }
            catch
            {
                MessageBox.Show("Программа завершае работу, просба не волноваться т.к оно запланированно");
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CatalogItems());
        }
    }
}
