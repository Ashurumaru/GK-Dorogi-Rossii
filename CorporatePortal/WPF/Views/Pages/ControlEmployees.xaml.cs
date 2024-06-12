using CorporatePortal.WPF.Models;
using CorporatePortal.WPF.Utils;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WPF.Views.Cards;

namespace CorporatePortal.WPF.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для ControlEmployees.xaml
    /// </summary>
    public partial class ControlEmployees : Page
    {
        private List<Department> _departments;
        private List<UserDto> _users;
        private readonly ApiClient _apiClient;

        public ControlEmployees(ApiClient apiClient)
        {
            InitializeComponent();
            _apiClient = apiClient;
            LoadData();
        }
        private async void LoadData()
        {
            _departments = (await _apiClient.GetDepartmentAsync()).ToList();
            _users = (await _apiClient.GetUsersAsync()).Select(u => new UserDto
            {
                Email = u.Email,
                FirstName = u.FirstName,
                SecondName = u.SecondName,
                Patronymic = u.Patronymic,
                BirthDay = u.BirthDay,
                WorkNumber = u.WorkNumber,
                DepartmentName = u.IdDepartmentNavigation.NameDepartment,
                IdDepartment = u.IdDepartment,
                IdPosition = u.IdPosition,
                IdUser = u.IdUser,
                IdSwapper = u.IdSwapper,
                HomeNumber = u.HomeNumber,
                PositionName = u.IdPositionNavigation.NamePosition
            }).ToList();
            PopulateTreeView();
        }

        private void PopulateTreeView()
        {
            var rootDepartments = _departments.Where(d => d.IdParentDepartment == null).ToList();
            DepartmentTreeView.ItemsSource = rootDepartments;
        }

        private void DepartmentTreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            var selectedDepartment = (Department)DepartmentTreeView.SelectedItem;
            if (selectedDepartment != null)
            {
                var employees = GetEmployeesForDepartment(selectedDepartment);
                EmployeeItemsControl.ItemsSource = employees;
            }
        }

        private List<UserDto> GetEmployeesForDepartment(Department department)
        {
            var departmentIds = new List<int> { department.IdDepartrment };
            GetChildDepartmentIds(department, departmentIds);
            return _users.Where(u => departmentIds.Contains(u.IdDepartment ?? 0)).ToList();
        }
        private void GetChildDepartmentIds(Department department, List<int> departmentIds)
        {
            foreach (var childDepartment in department.InverseIdParentDepartmentNavigation)
            {
                departmentIds.Add(childDepartment.IdDepartrment);
                GetChildDepartmentIds(childDepartment, departmentIds);
            }
        }

        private void OpenUserCard_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var user = (UserDto)button.Tag;
            var userCardWindow = new UsersCard(user.IdUser, _apiClient);
            userCardWindow.ShowDialog();
        }

        private void AddUserButton_Click(object sender, RoutedEventArgs e)
        {
            var newUser = new User();
            var userCardWindow = new UsersCard(newUser, _apiClient, true);
            if (userCardWindow.ShowDialog() == true)
            {
                LoadData();
            }
        }
    }
}
