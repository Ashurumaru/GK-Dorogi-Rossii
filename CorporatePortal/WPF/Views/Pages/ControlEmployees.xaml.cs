using CorporatePortal.WPF.Models;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace CorporatePortal.WPF.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для ControlEmployees.xaml
    /// </summary>
    public partial class ControlEmployees : Page
    {
        private List<User> _allUsers;
        private List<Department> _departments;

        public ControlEmployees()
        {
            InitializeComponent();
            LoadEmployees();
        }
        private void LoadEmployees()
        {
            //using (var context = new CorporatePortalEntities())
            //{
            //    _departments = (List<Department>)context.Подразделения.Select(p => new Department
            //    {
            //        ПодразделениеID = p.ПодразделениеID,
            //        НазваниеПодразделения = p.НазваниеПодразделения,
            //        ПомощникРуководителя = p.ПомощникРуководителя,
            //        РуководительПодразделения = p.ПомощникРуководителя
            //    }).ToList();

            //    _allUsers = (List<User>)context.Пользователи.Select(p => new User
            //    {
            //        Имя = p.Имя,
            //        Фамилия = p.Фамилия,
            //        ПутьКФото = p.ПутьКФото,
            //        ДатаРождения = p.ДатаРождения,
            //        Должность = p.Должность,
            //        ДомашнийТелефон = p.ДомашнийТелефон,
            //        ЗаменяющийID = p.ЗаменяющийID,
            //        Логин = p.Логин,
            //        Отчество= p.Отчество,
            //        ЭлПочта = p.ЭлПочта,
            //        РабочийТелефон = p.РабочийТелефон,
            //        РольID = p.РольID,
            //        ПользовательID = p.ПользовательID,
            //        ПодразделениеID = p.ПодразделениеID,
            //        РуководительID = p.РуководительID
            //    }).ToList();
            //}

            //var companyNode = new TreeViewItem { Header = "Corporate Portal" };

            //foreach (var department in _departments)
            //{
            //    var departmentNode = new TreeViewItem
            //    {
            //        Header = department.НазваниеПодразделения,
            //        DataContext = department
            //    };
            //    companyNode.Items.Add(departmentNode);
            //}

            //CompanyStructureTreeView.Items.Add(companyNode);
            //companyNode.IsSelected = true;
            //EmployeeDataGrid.ItemsSource = _allUsers;
        }
        private void CompanyStructureTreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            //if (CompanyStructureTreeView.SelectedItem is TreeViewItem selectedItem)
            //{
            //    if (selectedItem.Header.ToString() == "Corporate Portal")
            //    {
            //        EmployeeDataGrid.ItemsSource = _allUsers;
            //    }
            //    else if (selectedItem.DataContext is Department selectedDepartment)
            //    {
            //        var usersInDepartment = _allUsers.Where(u => u.ПодразделениеID == selectedDepartment.ПодразделениеID).ToList();
            //        EmployeeDataGrid.ItemsSource = usersInDepartment;
            //    }
            //}
        }
    }
}
