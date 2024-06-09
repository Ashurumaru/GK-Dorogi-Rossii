using CorporatePortal.WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WPF.Data;
using CorporatePortal.WPF.Models;

namespace CorporatePortal.WPF.Views
{
    /// <summary>
    /// Логика взаимодействия для LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        private List<User> Users;
        private User currentUser;
        public LoginView()
        {
            InitializeComponent();
            LoadUsers();
            
        }


        private void LoadUsers()
        {
            //using (var context = new CorporatePortalEntities())
            //{
            //    Users = context.Пользователи.Select(u => new User
            //    {
            //        ПользовательID = u.ПользовательID,
            //        Логин = u.Логин,
            //        Пароль = u.Пароль,
            //        Имя = u.Имя,
            //        Фамилия = u.Фамилия,
            //        Отчество = u.Отчество,
            //        ЭлПочта = u.ЭлПочта,
            //        РольID = u.РольID,
            //        ПодразделениеID = u.ПодразделениеID,
            //        Должность = u.Должность,
            //        РабочийТелефон = u.РабочийТелефон,
            //        ДомашнийТелефон = u.ДомашнийТелефон,
            //        ДатаРождения = u.ДатаРождения,
            //        ЗаменяющийID = u.ЗаменяющийID,
            //        ПутьКФото = u.ПутьКФото
            //    }).ToList();
            //    UsersDataGrid.ItemsSource = Users;
            //}
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                var user = button.CommandParameter as User;
                if (user != null)
                {
                    currentUser = user;
                    MessageBox.Show($"Вход для пользователя: {user.Имя} {user.Фамилия}");
                    DashboardView window = new DashboardView(user);
                    window.Show();
                    this.Close();
                }
            }
        }
    }
}
