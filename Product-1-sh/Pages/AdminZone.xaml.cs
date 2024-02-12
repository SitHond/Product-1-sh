
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
                if (SelItem != null)
                {
                    var itemDel = DbContext.Context.itemLists.FirstOrDefault(i => i.Id == SelItem.Id);
                    DbContext.Context.Remove(SelItem);
                    DbContext.Context.SaveChanges();
                    GetDataGrid();
                }
                else
                {
                    MessageBox.Show("Нвозможное действие");
                }
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
                    Articul = Tdesc.Text,
                    Name = Tname.Text,
                    Izm = Tdesc1.Text,
                    Price = Convert.ToDouble(Tdesc2.Text),
                    Skid = Convert.ToInt32(Tdesc3.Text),
                    Manufacturer = Tdesc4.Text,
                    Provider = Tdesc5.Text,
                    Categoru = Tdesc6.Text,
                    SkidOn = Convert.ToInt32(Tdes7c.Text),
                    count = Convert.ToInt32(Tdesc8.Text),
                    Description = Tdesc9.Text,
                    Img = "C:\\Users\\Администратор\\Desktop\\экзамен\\Большая пачка.png",
                };
                DbContext.Context.itemLists.Add(itemList);
                DbContext.Context.SaveChanges();
                Tname.Text = null; Tdesc.Text = null;
                GetDataGrid();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Программа завершае работу, просба не волноваться т.к оно запланированно" + ex);
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CatalogItems());
        }
    }
}
