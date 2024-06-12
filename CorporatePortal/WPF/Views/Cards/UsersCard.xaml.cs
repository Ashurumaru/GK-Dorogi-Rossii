using CorporatePortal.WPF.Models;
using CorporatePortal.WPF.Utils;
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

namespace WPF.Views.Cards
{
    /// <summary>
    /// Логика взаимодействия для UsersCard.xaml
    /// </summary>
    public partial class UsersCard : Window
    {
        private readonly ApiClient _apiClient;
        private User _user;
        private bool _isNewUser;

        public UsersCard(int userId, ApiClient apiClient)
        {
            InitializeComponent();
            _apiClient = apiClient;
            LoadUserData(userId);
        }

        public UsersCard(User user, ApiClient apiClient, bool isNewUser = false)
        {
            InitializeComponent();
            _apiClient = apiClient;
            _user = user;
            _isNewUser = isNewUser;
            DataContext = _user;
            LoadComboBoxData();
        }

        private async void LoadUserData(int userId)
        {
            _user = await _apiClient.GetUserByIdAsync(userId);
            DataContext = _user;
            LoadComboBoxData();
        }

        private async void LoadComboBoxData()
        {
            DepartmentComboBox.ItemsSource = await _apiClient.GetDepartmentAsync();
            var position = await _apiClient.GetPositionsAsync();
            PositionComboBox.ItemsSource = position;
        }

        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (_isNewUser)
            {
                await _apiClient.CreateUserAsync(_user);
            }
            else
            {
                await _apiClient.UpdateUserAsync(_user.IdUser, _user);
            }
            DialogResult = true;
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
