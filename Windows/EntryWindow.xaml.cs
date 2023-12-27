using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BookStore.Infrastructure;
using BookStore.Infrastructure.Consts;
using BookStore.Infrastructure.Database;
using System.Data.Entity;

namespace BookStore.Windows
{
    /// <summary>
    /// Логика взаимодействия для EntryWindow.xaml
    /// </summary>
    public partial class EntryWindow : Window
    {
        public EntryWindow()
        {
            InitializeComponent();
        }

        private void Undo_Btn(Object sender, RoutedEventArgs e) 
        {
            Close();
        }

        private void Auth_Btn(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            Close();
        }

        private void Guest_Btn(object sender, RoutedEventArgs e)
        {
            Application.Current.Resources[UserInfoConsts.RoleId] = 1;
            Application.Current.Resources[UserInfoConsts.RoleName] = "Клиент";
            Application.Current.Resources[UserInfoConsts.UserName] = "Клиент";

            ClientMainMenuWindow clientMainMenuWindow = new ClientMainMenuWindow();
            clientMainMenuWindow.Show();
            Close();
        }

        private void Entry_Btn(object sender, RoutedEventArgs e)
        {
            string login = TextBoxLogin.Text.Trim();
            string password = TextBoxPassword.Password.Trim();

            User user = new User();

            Employee emp = Context.GetContext().Employee.surname;
            if (emp != null)
            {
                UserInfoConsts.RoleName = emp.Post.name;
                UserInfoConsts.UserName = emp.name;

                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                Close();
            }
            else
            { MessageBox.Show("Нет такого пользоваткля в базе данных"); }

            using (Context db = new Context())
            {
                user = db.User.Where(b => b.login == login && b.password == password).FirstOrDefault();
            }
        }
    }
}
