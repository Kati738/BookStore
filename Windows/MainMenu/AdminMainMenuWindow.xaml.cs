using BookStore.Windows.Chapters;
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
using System.Windows.Shapes;

namespace BookStore.Windows
{
    /// <summary>
    /// Логика взаимодействия для MainMenuWindow.xaml
    /// Главное меню для Админа
    /// </summary>
    public partial class AdminMainMenuWindow : Window
    {
        public AdminMainMenuWindow()
        {
            InitializeComponent();
        }

        private void Quit_Btn(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите выйти из аккаунта?", "",
                MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                EntryWindow entryWindow = new EntryWindow();
                Close();
                entryWindow.Show();
            }
        }
        private void Clients_Btn(object sender, RoutedEventArgs e)
        {
            ClientsWindow clientsWindow = new ClientsWindow();
            clientsWindow.Show();
            Close();
        }

        private void Employees_Btn(object sender, RoutedEventArgs e)
        {
            EmployeesWindow employeesWindow = new EmployeesWindow();
            employeesWindow.Show();
            Close();
        }

        private void Products_Btn(object sender, RoutedEventArgs e)
        {
            ProductsWindow productsWindow = new ProductsWindow();
            productsWindow.Show();
            Close();
        }

        private void Categories_Btn(object sender, RoutedEventArgs e)
        {
            CategoriesWindow categoriesWindow = new CategoriesWindow();
            categoriesWindow.Show();
            Close();
        }

        private void Discounts_Btn(object sender, RoutedEventArgs e)
        {
            DiscountsWindow discountsWindow = new DiscountsWindow();
            discountsWindow.Show();
            Close();
        }

        private void Genres_Btn(object sender, RoutedEventArgs e)
        {
            GenresWindow genresWindow = new GenresWindow();
            genresWindow.Show();
            Close();
        }
    }
}
