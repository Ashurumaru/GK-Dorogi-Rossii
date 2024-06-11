﻿using CorporatePortal.WPF.Utils;
using CorporatePortal.WPF.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CorporatePortal.WPF.Views
{
    /// <summary>
    /// Логика взаимодействия для LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        private List<User> Users;
        private User currentUser;
        private string _password;
        private readonly ApiClient _apiClient;

        public LoginView()
        {
            InitializeComponent();
            _apiClient = new ApiClient("https://localhost:7201/");
            LoadUsers();

        }


        private void LoadUsers()
        {
           
        }
 
        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string login = txtLogin.Text;
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(_password))
            {
                ErrorMessage.Text = "Введите логин и пароль.";
                return; 
            }

            try
            {
                User user = await _apiClient.AuthorizeUserAsync(login, _password);
                if (user != null)
                {
                    DashboardView dashbord = new DashboardView(user);
                    dashbord.Show();
                    this.Close();
                }
                else
                {
                    ErrorMessage.Text = "Неверный логин или пароль.";
                    ErrorMessage.Opacity = 1;
                }

            }
            catch (Exception ex)
            {
                ErrorMessage.Text = "Ошибка: " + ex.Message;
                MessageBox.Show(ex.Message);
                ErrorMessage.Opacity = 1;
            }
        }
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            var passwordBox = (PasswordBox)sender;
            _password = passwordBox.Password;
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

        private void GitHub_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Process.Start("https://github.com/Ashurumaru");
        }
    }
}
