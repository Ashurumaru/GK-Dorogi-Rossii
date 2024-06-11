using CorporatePortal.WPF.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WPF.Views.Pages;

namespace CorporatePortal.WPF.Views
{
    /// <summary>
    /// 
    /// </summary>
    public partial class DashboardView : Window
    {
        private User _currentUser;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="currentUser"></param>
        public DashboardView(User currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser;
            MessageBox.Show(_currentUser.ToString());
        }
        /// <summary>
        /// 
        /// </summary>
        public DashboardView()
        {
            InitializeComponent();
        }


        private void BtnEmployeePortal_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new EmployeePortal());
        }



        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var employeePortalPage = MainFrame.Content as EmployeePortal;
            if (employeePortalPage != null)
            {
                employeePortalPage.SearchItems(SearchTextBox.Text);
            }
        }

        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btn_maximize_Click(object sender, RoutedEventArgs e)
        {
            SwitchWindowState();
        }

        private void btn_minimize_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).WindowState = WindowState.Minimized;
        }
        private void DockPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount >= 2)
            {
                SwitchWindowState();
                return;
            }

            if (Window.GetWindow(this).WindowState == WindowState.Maximized)
            {
                return;
            }
            else
            {
                if (e.LeftButton == MouseButtonState.Pressed) Window.GetWindow(this).DragMove();
            }
        }

        private void MaximizeWindow()
        {
            Window.GetWindow(this).WindowState = WindowState.Maximized;
        }

        private void RestoreWindow()
        {
            Window.GetWindow(this).WindowState = WindowState.Normal;
        }

        private void SwitchWindowState()
        {
            if (Window.GetWindow(this).WindowState == WindowState.Normal) MaximizeWindow();
            else RestoreWindow();
        }

        private void MinimizeAndDragMove(MouseButtonEventArgs e)
        {
            if (Window.GetWindow(this).WindowState == WindowState.Maximized)
            {
                double percentHorizontal = e.GetPosition(this).X / ActualWidth;
                double targetHorizontal = Window.GetWindow(this).RestoreBounds.Width * percentHorizontal;

                double percentVertical = e.GetPosition(this).Y / ActualHeight;
                double targetVertical = Window.GetWindow(this).RestoreBounds.Height * percentVertical;

                Window.GetWindow(this).WindowStyle = WindowStyle.None;
                RestoreWindow();

                var mousePosition = e.GetPosition(this);

                Window.GetWindow(this).Left = mousePosition.X - targetHorizontal;
                Window.GetWindow(this).Top = mousePosition.Y - targetVertical;
            }

            if (e.LeftButton == MouseButtonState.Pressed) Window.GetWindow(this).DragMove();
            Window.GetWindow(this).WindowStyle = WindowStyle.SingleBorderWindow;
        }

        public void WindowStateChanged(WindowState state)
        {
            if (Window.GetWindow(this).WindowState == WindowState.Maximized)
            {
                btn_maximize.Content = "\uE923";
                titleBar.Height = 24;
            }
            else if (Window.GetWindow(this).WindowState == WindowState.Normal)
            {
                btn_maximize.Content = "\uE922";
                titleBar.Height = 32;
            }
        }
    }
}
