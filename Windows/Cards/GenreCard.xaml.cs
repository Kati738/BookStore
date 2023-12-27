using BookStore.Infrastructure;
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

namespace BookStore.Windows.Cards
{
    /// <summary>
    /// Логика взаимодействия для GenreCard.xaml
    /// </summary>
    public partial class GenreCard : Window
    {
        private Genre genre = new Genre();
        public GenreCard(Genre selectedGenre)
        {
            InitializeComponent();

            if (selectedGenre != null)
                genre = selectedGenre;
            DataContext = genre;
        }

        private void Undo_Btn(object sender, RoutedEventArgs e)
        {
            GenresWindow genresWindow = new GenresWindow();
            genresWindow.Show();
            Close();
        }

        private void Save_Btn(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            if (string.IsNullOrWhiteSpace(genre.name))
                sb.AppendLine("Введите название!");

            if (sb.Length > 0)
            {
                MessageBox.Show(sb.ToString());
                return;
            }
            if (genre.id == 0)
                Context.GetContext().Genre.Add(genre);
            try
            {
                Context.GetContext().SaveChanges();
                MessageBox.Show("Данные были успешно добавлены");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
