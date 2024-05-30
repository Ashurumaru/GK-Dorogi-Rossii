using CorporatePortal.WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Windows;
using System.Windows.Controls;
using WPF.Data;
using WPF.Models;

namespace WPF.Views.Pages
{
    public partial class IventCalendar : Page
    {
        private List<Event> _allEvents;
        private List<Department> _departments;
        private List<Event> _selectedEvents;
        private List<Event> _selectedDepartmentEvents;
        private List<User> _participants;

        public IventCalendar()
        {
            InitializeComponent();
            LoadEvents();
        }

        private void LoadEvents()
        {
            using (var context = new CorporatePortalEntities())
            {
                _departments = context.Подразделения.Select(p => new Department
                {
                    НазваниеПодразделения = p.НазваниеПодразделения,
                    ПодразделениеID = p.ПодразделениеID
                }).ToList();

                _allEvents = context.Мероприятия.Select(e => new Event
                {
                    ТипМероприятия = e.ТипыМероприятий.НазваниеТипа,
                    ДатаНачала = e.ДатаНачала,
                    ДатаОкончания = e.ДатаОкончания,
                    Инициатор = e.Пользователи.Логин,
                    КраткоеОписание = e.КраткоеОписание,
                    МероприятиеID = e.МероприятиеID,
                    НазваниеМероприятия = e.НазваниеМероприятия,
                    СтатусМероприятия = e.СтатусыМероприятий.НазваниеСтатуса
                }).ToList();

                var companyTree = new TreeViewItem { Header = "CorporatePortal" };
                foreach (var item in _departments)
                {
                    var departmentTree = new TreeViewItem
                    {
                        Header = item.НазваниеПодразделения,
                        DataContext = item
                    };

                    companyTree.Items.Add(departmentTree);
                }
                DepartamentCompany.Items.Add(companyTree);
            }
        }
        private void DepartamentCompany_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (DepartamentCompany.SelectedItem is TreeViewItem selectedItem && selectedItem.DataContext is Department selectedDepartment)
            {
                int departmentId = selectedDepartment.ПодразделениеID;

                using (var context = new CorporatePortalEntities())
                {
                    {
                        var departmentParticipantEventIds = context.УчастникиМероприятия
                            .Where(p => p.Пользователи.ПодразделениеID == departmentId)
                            .Select(p => p.МероприятиеID)
                            .Distinct()
                            .ToList();

                        var eventsInDepartment = _allEvents
                            .Where(ev => departmentParticipantEventIds
                            .Contains(ev.МероприятиеID))
                            .ToList();

                        _selectedDepartmentEvents = eventsInDepartment;
                    }

                    DatagridEvents.ItemsSource = null;
                    ClearEventDetails();
                }
            }
        }

        private void EventCalendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
                var selectedDate = eventCalendar.SelectedDate.Value;
                var selectedEvents = _selectedDepartmentEvents
                .Where(ev => ev.ДатаНачала.Date <= selectedDate.Date && ev.ДатаОкончания.Date >= selectedDate.Date)
                .ToList();
                DatagridEvents.ItemsSource = selectedEvents;
                ClearEventDetails();
        }

        private void ClearEventDetails()
        {
            eventName.Text = "";
            eventType.Text = "";
            eventStatus.Text = "";
            eventDateTime.Text = "";
            eventResponsible.Text = "";
            eventDescription.Text = "";
            participantDataGrid.ItemsSource = null;
        }

        private void EditEventButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Функция редактирования мероприятия в разработке");
        }



        private void DatagridEvents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DatagridEvents.SelectedItem is Event selectedEvent)
            {
                eventName.Text = selectedEvent.НазваниеМероприятия;
                eventType.Text = selectedEvent.ТипМероприятия;
                eventStatus.Text = selectedEvent.СтатусМероприятия;
                eventDateTime.Text = $"{selectedEvent.ДатаНачала} - {selectedEvent.ДатаОкончания}";
                eventResponsible.Text = selectedEvent.Инициатор;
                eventDescription.Text = selectedEvent.КраткоеОписание;

                using (var context = new CorporatePortalEntities())
                {
                    _participants = context.УчастникиМероприятия
                        .Where(p => p.МероприятиеID == selectedEvent.МероприятиеID)
                        .Select(p => new User
                        {
                            Имя = p.Пользователи.Имя,
                            Фамилия = p.Пользователи.Фамилия
                        }).ToList();

                    participantDataGrid.ItemsSource = _participants;
                }
            }
        }
    }
}
    