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
using System.Windows.Shapes;

namespace WPF.Utils
{
    /// <summary>
    /// Логика взаимодействия для PasswordGenerate.xaml
    /// </summary>
    public partial class PasswordGenerate : Window
    {
        public PasswordGenerate()
        {
            InitializeComponent();
        }
        private void GenerateHash_Click(object sender, RoutedEventArgs e)
        {
            string password = PasswordBox.Password;

            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Password cannot be empty. Please enter a valid password.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

            HashedPasswordTextBox.Text = hashedPassword;
        }

        private void VerifyPassword_Click(object sender, RoutedEventArgs e)
        {
            string passwordToVerify = VerifyPasswordBox.Password;
            string hashedPassword = HashedPasswordToVerifyTextBox.Text;

            if (string.IsNullOrWhiteSpace(passwordToVerify) || string.IsNullOrWhiteSpace(hashedPassword))
            {
                MessageBox.Show("Both password fields must be filled. Please enter valid passwords.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(passwordToVerify, hashedPassword);

            if (isPasswordValid)
            {
                MessageBox.Show("Password verification successful.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Password verification failed. The password does not match the hash.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
