using CorporatePortal.WPF.Models;
using CorporatePortal.WPF.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
using CorporatePortal.WPF.Views;
using WPF.Models;

namespace WPF.Views.Cards
{
    /// <summary>
    /// Логика взаимодействия для NewsCard.xaml
    /// </summary>
    public partial class NewsCard : Window
    {
        private readonly ApiClient _apiClient;
        private User _currentUser;
        public NewsCard(ApiClient apiClient, User user)
        {
            InitializeComponent();
            _currentUser = user;
            _apiClient = apiClient;
            LoadNewsTypes();
        }

        private async void LoadNewsTypes()
        {
            var newsTypes = await _apiClient.GetNewsTypesAsync();
            TypeComboBox.ItemsSource = newsTypes;
        }

        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TitleTextBox.Text))
            {
                MessageBox.Show("Title cannot be empty.");
                return;
            }

            if (string.IsNullOrWhiteSpace(DescriptionTextBox.Text))
            {
                MessageBox.Show("Description cannot be empty.");
                return;
            }

            if (TypeComboBox.SelectedValue == null)
            {
                MessageBox.Show("Please select a type.");
                return;
            }
            var news = new NewsItem
            {
                Title = TitleTextBox.Text,
                Description = DescriptionTextBox.Text,
                CreateDate = DateTime.Now,
                IdTypeNew = Convert.ToInt32(TypeComboBox.SelectedValue),
                IdCreator = _currentUser?.IdUser
            };

            try
            {
                var createdNews = await _apiClient.CreateNewsAsync(news);
                MessageBox.Show($"News created with ID: {createdNews.IdNew}");
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
            this.DialogResult = true;
            this.Close();
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

    }
}
