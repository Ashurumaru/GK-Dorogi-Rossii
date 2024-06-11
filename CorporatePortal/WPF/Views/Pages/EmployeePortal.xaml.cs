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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для EmployeePortal.xaml
    /// </summary>
    public partial class EmployeePortal : Page
    {
        private readonly ApiClient _apiClient;

        public EmployeePortal()
        {
            InitializeComponent();
            _apiClient = new ApiClient("https://localhost:7201/");
            LoadEvents();
            LoadEmployees();
        }

        private async void LoadEvents()
        {

                var events = await _apiClient.GetEventsAsync();
                EventItemsControl.ItemsSource = events;

        }
        private async void LoadEmployees()
        {
            var employees = await _apiClient.GetUsersAsync();
            EmployeeItems.ItemsSource = employees;
        }
        private void EventCalendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
