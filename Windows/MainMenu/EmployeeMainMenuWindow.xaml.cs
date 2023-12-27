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
    /// Логика взаимодействия для EmployeeMainMenuWindow.xaml
    /// </summary>
    public partial class EmployeeMainMenuWindow : Window
    {
        public EmployeeMainMenuWindow()
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

        private void Product_Btn(object sender, RoutedEventArgs e)
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

        private void Discoints_Btn(object sender, RoutedEventArgs e)
        { 
            DiscountsWindow discountsWindow = new DiscountsWindow();
            discountsWindow.Show();
            Close();
        }

        private void Genres_Btn(object senser, RoutedEventArgs e)
        { 
            GenresWindow genresWindow = new GenresWindow();
            genresWindow.Show();
            Close();
        }
    }
}
