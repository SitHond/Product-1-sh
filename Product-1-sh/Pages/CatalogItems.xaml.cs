
using DBShop.Models;
using System.Collections.ObjectModel;
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
        public void GetListViev()
        {
            var context = DbContext.Context;
            List<ItemList> prods = context.itemLists.ToList();
            listView.ItemsSource = prods;
        }
        private void DisplaySearchResults(List<ItemList> items)
        {
            if (items.Count > 0)
            {
                ObservableCollection<ItemList> foundItems = new ObservableCollection<ItemList>(items);
                listView.ItemsSource = foundItems;
            }
            else
            {
                MessageBox.Show("Товары не найдены.");
                listView.ItemsSource = null;
            }
        }
        public CatalogItems()
        {
            InitializeComponent();

            GetListViev();
            var providers = DbContext.Context.itemLists.Select(i => i.Provider).Distinct().ToList();
            ComboBoxItem.ItemsSource = providers;

            if (CurrentUser.AuthUser.IsAdmin == true)
            {
                TextProver.Content = "Админ";
                TextProver.Visibility = Visibility.Visible;
                AdminButton.Visibility = Visibility.Visible;  
            }
            else if (CurrentUser.AuthUser.IsManager == true)
            {
                TextProver.Content = "Менеджер";
                TextProver.Visibility = Visibility.Visible;
                AdminButton.Visibility = Visibility.Visible;
            }
            else if (CurrentUser.AuthUser.IsGuest == true)
            {
                TextProver.Content = "Гость";
                TextProver.Visibility = Visibility.Visible;
                AdminButton.Visibility = Visibility.Collapsed;
            }
        }

        private void AdminButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdminZone());
        }

        private void ExitAcc_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Auth());
        }

        private void AddBuket_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            ItemList prod = (ItemList)button.Tag;

            if (prod != null)
            {
                var currentUser = CurrentUser.AuthUser;

                if (currentUser != null)
                {
                    // Получаем доступное количество товара из таблицы ItemList
                    int availableQuantity = prod.Count;

                    // Проверяем, достаточно ли товара для добавления в корзину
                    if (availableQuantity > 0)
                    {
                        // Создаем запись UserToItem для добавления в корзину
                        UserToItem userToItem = new UserToItem
                        {
                            Users = currentUser,
                            Item = prod
                        };

                        // Добавляем запись в корзину
                        DbContext.Context.userToItems.Add(userToItem);
                        DbContext.Context.SaveChanges();

                        // Уменьшаем количество товара в базе данных на 1
                        prod.Count--;

                        // Обновляем список товаров в корзине
                        GetListViev();
                    }
                    else
                    {
                        MessageBox.Show("Извините, этот товар временно недоступен.");
                    }
                }
                else
                {
                    MessageBox.Show("Пользователь не авторизован.");
                }
            }
            else
            {
                MessageBox.Show("Выберите элемент для добавления.");
            }
        }


        private void OpenBuket_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new basket());
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            // Получаем выбранного поставщика из ComboBox
            string selectedProvider = ComboBoxItem.SelectedItem as string;

            // Получаем текст из TextBox
            string searchQuery = SearchBox.Text.Trim();

            // Проверяем, заполнены ли оба поля
            if (!string.IsNullOrEmpty(selectedProvider) || !string.IsNullOrEmpty(searchQuery))
            {
                // Если заполнены оба поля, производим поиск по обоим полям
                if (!string.IsNullOrEmpty(selectedProvider) && !string.IsNullOrEmpty(searchQuery))
                {
                    var items = DbContext.Context.itemLists.Where(i => i.Provider == selectedProvider && i.Name.Contains(searchQuery)).ToList();
                    DisplaySearchResults(items);
                }
                // Если заполнено только поле ComboBox, производим поиск только по поставщику
                else if (!string.IsNullOrEmpty(selectedProvider))
                {
                    var items = DbContext.Context.itemLists.Where(i => i.Provider == selectedProvider).ToList();
                    DisplaySearchResults(items);
                }
                // Если заполнено только поле TextBox, производим поиск только по имени товара
                else
                {
                    var items = DbContext.Context.itemLists.Where(i => i.Name.Contains(searchQuery)).ToList();
                    DisplaySearchResults(items);
                }
            }
            else
            {
                MessageBox.Show("Выберите поставщика из списка или введите текст для поиска.");
            }
        }

        private void Clean_Click(object sender, RoutedEventArgs e)
        {
            // Получаем все элементы из таблицы ItemList
            var allItems = DbContext.Context.itemLists.ToList();

            // Проверяем, есть ли элементы в таблице
            if (allItems.Count > 0)
            {
                // Создаем ObservableCollection для хранения всех элементов
                ObservableCollection<ItemList> allItemsCollection = new ObservableCollection<ItemList>(allItems);

                // Устанавливаем все элементы как источник данных для ListView
                listView.ItemsSource = allItemsCollection;
            }
            else
            {
                MessageBox.Show("Нет доступных товаров.");
            }
        }
    }
}
