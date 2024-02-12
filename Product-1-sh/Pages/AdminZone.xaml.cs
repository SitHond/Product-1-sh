
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
                    Articul = Tarticul.Text,
                    Name = Tname.Text,
                    Izm = Tizm.Text,
                    Price = Convert.ToDouble(Tprice.Text),
                    Skid = Convert.ToInt32(Tskid.Text),
                    Manufacturer = Tmanufacturer.Text,
                    Provider = Tprovider.Text,
                    Categoru = Tcategoru.Text,
                    SkidOn = Convert.ToInt32(TskidOn.Text),
                    count = Convert.ToInt32(Tcount.Text),
                    Description = Tdesc.Text,
                    Img = "C:\\Users\\Администратор\\Desktop\\экзамен\\Большая пачка.png",
                };
                DbContext.Context.itemLists.Add(itemList);
                DbContext.Context.SaveChanges();
                Tname.Text = null; Tdesc.Text = null; Tarticul.Text = null; Tizm.Text = null; Tprice.Text = null; Tskid.Text = null; Tmanufacturer.Text = null; Tprovider.Text = null; Tcategoru.Text = null; TskidOn.Text = null; Tcount.Text = null;
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
