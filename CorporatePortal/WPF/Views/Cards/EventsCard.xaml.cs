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
using WPF.Models;

namespace WPF.Views.Cards
{
    /// <summary>
    /// Логика взаимодействия для EventsCard.xaml
    /// </summary>
    public partial class EventsCard : Window
    {
        private readonly ApiClient _apiClient;

        public EventsCard(ApiClient apiClient)
        {
            InitializeComponent();
            _apiClient = apiClient;
            LoadEventTypes();
            LoadEventStatuses();
        }

        private async void LoadEventTypes()
        {
            var eventTypes = await _apiClient.GetEventTypesAsync();
            TypeComboBox.ItemsSource = eventTypes;
        }

        private async void LoadEventStatuses()
        {
            var eventStatuses = await _apiClient.GetEventStatusesAsync();
            StatusComboBox.ItemsSource = eventStatuses;
        }

        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameTextBox.Text))
            {
                MessageBox.Show("Event name cannot be empty.");
                return;
            }

            if (TypeComboBox.SelectedValue == null)
            {
                MessageBox.Show("Please select an event type.");
                return;
            }

            if (StatusComboBox.SelectedValue == null)
            {
                MessageBox.Show("Please select an event status.");
                return;
            }

            if (!StartDatePicker.SelectedDate.HasValue)
            {
                MessageBox.Show("Please select a start date.");
                return;
            }

            if (!EndDatePicker.SelectedDate.HasValue)
            {
                MessageBox.Show("Please select an end date.");
                return;
            }

            if (EndDatePicker.SelectedDate.Value < StartDatePicker.SelectedDate.Value)
            {
                MessageBox.Show("End date cannot be earlier than start date.");
                return;
            }

            if (string.IsNullOrWhiteSpace(DescriptionTextBox.Text))
            {
                MessageBox.Show("Event description cannot be empty.");
                return;
            }

            var eventDto = new EventsItem
            {
                NameEvent = NameTextBox.Text,
                IdTypeEvent = (int)TypeComboBox.SelectedValue,
                IdStatusEvent = (int)StatusComboBox.SelectedValue,
                StartDate = StartDatePicker.SelectedDate.Value,
                EndDate = EndDatePicker.SelectedDate.Value,
                DescriptionEvent = DescriptionTextBox.Text
            };

            try
            {
                var createdEvent = await _apiClient.CreateEventAsync(eventDto);
                MessageBox.Show($"Event created.");
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
