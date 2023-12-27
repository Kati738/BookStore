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
    /// Логика взаимодействия для ClientCard.xaml
    /// </summary>
    public partial class ClientCard : Window
    {
        private Client client = new Client();
        public ClientCard(Client selectedClient)
        {
            InitializeComponent();

            if (selectedClient != null)
                client = selectedClient;
            DataContext = client;
        }

        private void Undo_Btn(object sender, RoutedEventArgs e)
        {
            ClientsWindow clientsWindow = new ClientsWindow();
            clientsWindow.Show();
            Close();
        }

        private void Save_Btn(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            if (string.IsNullOrWhiteSpace(client.surname))
                sb.AppendLine("Введите фамилию!");
            if (string.IsNullOrWhiteSpace(client.name))
                sb.AppendLine("Введите имя!");
            if (string.IsNullOrWhiteSpace(client.patronymic))
                sb.AppendLine("Введите отчество!");
            if (client.birthday == null)
                sb.AppendLine("Введите дату!");
            if (client.phone_number == null)
                sb.AppendLine("Введите номер телефона!");

            if (sb.Length > 0)
            {
                MessageBox.Show(sb.ToString());
                return;
            }
            if (client.id == 0)
                Context.GetContext().Client.Add(client);
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
