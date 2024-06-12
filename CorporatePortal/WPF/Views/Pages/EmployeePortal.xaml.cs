using CorporatePortal.WPF.Models;
using CorporatePortal.WPF.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WPF.Views.Cards;

namespace WPF.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для EmployeePortal.xaml
    /// </summary>
    public partial class EmployeePortal : Page
    {
        private readonly ApiClient _apiClient;
        private User _currentUser;
        private ObservableCollection<NewDto> _newDto;
        private ObservableCollection<EventDto> _eventDto;
        private ObservableCollection<UserDto> _userDto;
        /// <summary>
        /// 
        /// </summary>
        public EmployeePortal(ApiClient apiClient, User currentUser)
        {
            InitializeComponent();
            _apiClient = apiClient;
            _currentUser = currentUser;
            LoadData();
        }

        private void LoadData()
        {
            LoadEvents();
            LoadEmployees();
            LoadNews();
        }

        private async void LoadEvents()
        {
            var events = await _apiClient.GetEventsAsync();
            _eventDto = new ObservableCollection<EventDto>(events.Select(ev => new EventDto
            {
                Id = ev.IdEvent,
                Name = ev.NameEvent,
                Type = ev.IdTypeEventNavigation?.NameType,
                Status = ev.IdStatusEventNavigation?.NameStatus,
                StartDate = ev.StartDate,
                EndDate = ev.EndDate,
                Description = ev.DescriptionEvent,
                Initiator = $"{ev.IdInitiatorNavigation?.FirstName} {ev.IdInitiatorNavigation?.SecondName} {ev.IdInitiatorNavigation?.Patronymic}",
            }));
            EventItemsControl.ItemsSource = _eventDto;
        }

        private async void LoadEmployees()
        {
            var employees = await _apiClient.GetUsersAsync();
            _userDto = new ObservableCollection<UserDto>(employees.Select(u => new UserDto
            {
                Email = u.Email,
                BirthDay = u.BirthDay,
                DepartmentName = u.IdDepartmentNavigation.NameDepartment,
                FirstName = u.FirstName,
                SecondName = u.SecondName,
                HomeNumber = u.HomeNumber,
                Patronymic = u.Patronymic,
                PositionName = u.IdPositionNavigation.NamePosition,
                WorkNumber = u.WorkNumber,
                IdPosition = u.IdPosition,
                IdDepartment = u.IdDepartment,
                IdSwapper = u.IdSwapper,
                IdUser = u.IdUser,
                PhotoPath = u.PhotoPath,
            }));
            EmployeeItems.ItemsSource = _userDto;
        }

        private async void LoadNews()
        {
            var news = await _apiClient.GetNewsAsync();
            _newDto = new ObservableCollection<NewDto>(news.Select(n => new NewDto
            {
                CreateDate = n.CreateDate,
                Creator = $"{n.IdCreatorNavigation?.FirstName} {n.IdCreatorNavigation?.SecondName} {n.IdCreatorNavigation?.Patronymic}",
                Description = n.Description,
                IdCreator = n.IdCreator,
                IdNew = n.IdNew,
                IdTypeNew = n.IdTypeNew,
                NameTypeNew = n.IdTypeNewNavigation.NameType,
                Title = n.Title,
            }));
            NewsItemsControl.ItemsSource = _newDto;
        }

        public void SearchItems(string searchText)
        {
            if (string.IsNullOrEmpty(searchText))
            {
                EventItemsControl.ItemsSource = _eventDto;
                EmployeeItems.ItemsSource = _userDto;
                NewsItemsControl.ItemsSource = _newDto;
            }
            else
            {
                var filteredEvents = new ObservableCollection<EventDto>(_eventDto.Where(ev => ev.Name.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                                                                             ev.Type.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                                                                             ev.Description.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                                                                             ev.Initiator.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0));

                var filteredEmployees = new ObservableCollection<UserDto>(_userDto.Where(e => e.FirstName.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                                                                              e.SecondName.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                                                                              e.Patronymic.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                                                                              e.WorkNumber.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                                                                              e.DepartmentName.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                                                                              e.PositionName.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                                                                              e.Email.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0));

                var filteredNews = new ObservableCollection<NewDto>(_newDto.Where(n => n.Title.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                                                                       n.Description.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                                                                       n.NameTypeNew.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                                                                       n.Creator.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0));

                EventItemsControl.ItemsSource = filteredEvents;
                EmployeeItems.ItemsSource = filteredEmployees;
                NewsItemsControl.ItemsSource = filteredNews;
            }
        }


        private void AddEventButton_Click(object sender, RoutedEventArgs e)
        {
            var addEventWindow = new EventsCard(_apiClient);
            if (addEventWindow.ShowDialog() == true)
            {
                LoadEvents();
            }
        }

        private void AddNewsButton_Click(object sender, RoutedEventArgs e)
        {
            var addNewsWindow = new NewsCard(_apiClient, _currentUser);
            if (addNewsWindow.ShowDialog() == true)
            {
                LoadNews();
            }
        }

        private void EventCalendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedDate = EventCalendar.SelectedDate;
            NewsItemsControl.ItemsSource = _newDto.Where(n => n.CreateDate == selectedDate.Value    );

            EmployeeItems.ItemsSource = _userDto.Where(n => n.BirthDay.Value.Month == selectedDate.Value.Month && n.BirthDay.Value.Day == selectedDate.Value.Day);

            EventItemsControl.ItemsSource = _eventDto.Where(ev => ev.EndDate.Value <= selectedDate.Value && ev.StartDate.Value >= selectedDate.Value);
        }

        private void Page_SizeChanged(object sender, System.Windows.SizeChangedEventArgs e)
        {
            double newWidth = MainGrid.ActualWidth;
            double newHeight = MainGrid.ActualHeight;

            NewsScrollViewer.Width = newWidth * 0.65;
            NewsScrollViewer.Height = newHeight * 0.75;
            
            EmployeeScrollViewer.Width = newWidth * 0.9;
            EmployeeScrollViewer.Height = 120;

            EventScrollViewer.Width = newWidth * 0.3;
            EventScrollViewer.Height = newHeight * 0.3;


        }

        private void ClearSearch_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            LoadData();
        }
    }
}
