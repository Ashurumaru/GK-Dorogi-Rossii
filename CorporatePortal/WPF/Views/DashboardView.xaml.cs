using CorporatePortal.WPF.Models;
using CorporatePortal.WPF.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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
using WPF.Data;
using CorporatePortal.WPF.Views.Pages;
using WPF.Views.Pages;

namespace CorporatePortal.WPF.Views
{
    /// <summary>
    /// 
    /// </summary>
    public partial class DashboardView : Window
    {
        private User _currentUser;

        public DashboardView(User currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser;
            MessageBox.Show(_currentUser.ToString());
        }

        private void NavigateToUsers(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ControlEmployees());
        }

        private void NavigateToIventsCalendar(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new IventCalendar());
        }
    }
}
