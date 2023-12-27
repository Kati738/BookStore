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
using BookStore.Infrastructure;
using BookStore.Infrastructure.Database;
using BookStore.Windows.Cards;

namespace BookStore.Windows.Chapters
{
    /// <summary>
    /// Логика взаимодействия для GenresWindow.xaml
    /// </summary>
    public partial class GenresWindow : Window
    {
        private GenreRepository genreRepository;
        public GenresWindow()
        {
            InitializeComponent();
            genreRepository = new GenreRepository();
            Genres_table.ItemsSource = genreRepository.GetListGenre();
        }

        private void MainMenu_Btn(object sender, RoutedEventArgs e)
        {
            ClientMainMenuWindow clientMainMenuWindow = new ClientMainMenuWindow();
            clientMainMenuWindow.Show();
            Close();
        }

        private void Add_Btn(object sender, RoutedEventArgs e)
        {
            GenreCard genreCard = new GenreCard(null);
            genreCard.Show();
            Close();
        }
        private void Delete_Btn(object sender, RoutedEventArgs e)
        {
            var list = Genres_table.SelectedItems.Cast<Genre>().ToList();
            if (MessageBox.Show($"Вы уверены, что хотите удалить{list.Count()} элемент/ы?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Context.GetContext().Genre.RemoveRange(list);
                    Context.GetContext().SaveChanges();
                    MessageBox.Show("Данные успешно удалены!");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void Update_Btn(object sender, RoutedEventArgs e)
        {
            Genres_table.ItemsSource = Context.GetContext().Genre.ToList();
        }

        /*private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = Context.GetContext().Client.ToList();
            textBox = textBox.Where(p => p.LastNameClient.ToLower().Contains(TextBox_Search.Text.ToLower())).ToList();
            Clients_table.ItemsSource = textBox.OrderBy(p => p.LastNameClient).ToList();
        }

        private void Button_Click_Upload(object sender, RoutedEventArgs e)
        {
            Excel.Application excel = new Excel.Application();
            excel.Visible = true;
            Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
            Worksheet sheet1 = (Worksheet)workbook.Sheets[1];

            for (int j = 0; j < Clients_table.Columns.Count; j++)
            {
                Range myRange = (Range)sheet1.Cells[1, j + 1];
                sheet1.Cells[1, j + 1].Font.Bold = true;
                sheet1.Columns[j + 1].ColumnWidth = 15;
                myRange.Value2 = Clients_table.Columns[j].Header;
            }
            for (int i = 0; i < Clients_table.Columns.Count; i++)
            {
                for (int j = 0; j < Clients_table.Items.Count; j++)
                {
                    TextBlock b = Clients_table.Columns[i].GetCellContent(Clients_table.Items[j]) as TextBlock;

                    if (b == null)
                        continue;

                    Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[j + 2, i + 1];
                    myRange.Value2 = b.Text;
                }
            }
        }*/
    }
}
