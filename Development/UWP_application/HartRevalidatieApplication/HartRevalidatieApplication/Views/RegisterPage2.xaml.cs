using HartRevalidatieApplication.Helpers;
using HartRevalidatieApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace HartRevalidatieApplication.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RegisterPage2 : Page
    {
        public RegisterPage2()
        {
            this.InitializeComponent();
            DataContext = RegisterPageViewModel.SingleInstance;
        }

        private async void Next_Click(object sender, RoutedEventArgs e)
        {
            if (Email_IsValidInput() & Password_IsValidInput() & RepeatPassword_IsValidInput())
            {
                RegisterPageViewModel.SingleInstance.SetSecondRegisterPageUserData(EmailTextBox.Text, PasswordBox.Password, RepeatPasswordBox.Password);
                
                ((Frame)Window.Current.Content).Navigate(typeof(RegisterPage3));
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            GlobalClickMethods.Back_Click(sender, e);
        }

        private bool Email_IsValidInput()
        {
            if (string.IsNullOrWhiteSpace(EmailTextBox.Text))
            {
                EmailTextBox.BorderThickness = new Thickness(1);
                EmailTextBox.BorderBrush = new SolidColorBrush(Colors.Red);
                EmailTextBox.Header = "E-mail kan niet leeg zijn";

                return false;
            }

            else if (!IsValidEmailAddress(EmailTextBox.Text))
            {
                EmailTextBox.BorderThickness = new Thickness(1);
                EmailTextBox.BorderBrush = new SolidColorBrush(Colors.Red);
                EmailTextBox.Header = "Geen geldig e-mail adres";

                return false;
            }

            else
            {
                EmailTextBox.BorderThickness = new Thickness(0);
                EmailTextBox.Header = " ";

                return true;
            }
        }
        
        private bool IsValidEmailAddress(string email)
        {
            try
            {
                return Regex.IsMatch(email, @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
            }
            catch
            {
                return false;
            }
        }

        private bool Password_IsValidInput()
        {
            if (string.IsNullOrWhiteSpace(PasswordBox.Password))
            {
                PasswordBox.BorderThickness = new Thickness(1);
                PasswordBox.BorderBrush = new SolidColorBrush(Colors.Red);
                PasswordBox.Header = "Wachtwoord kan niet leeg zijn";

                return false;
            }

            else
            {
                PasswordBox.BorderThickness = new Thickness(0);
                PasswordBox.Header = " ";

                return true;
            }
        }

        private bool RepeatPassword_IsValidInput()
        {
            if (RepeatPasswordBox.Password != PasswordBox.Password)
            {
                RepeatPasswordBox.BorderThickness = new Thickness(1);
                RepeatPasswordBox.BorderBrush = new SolidColorBrush(Colors.Red);
                RepeatPasswordBox.Header = "Wachtwoord komt niet overeen";

                return false;
            }

            else
            {
                RepeatPasswordBox.BorderThickness = new Thickness(0);
                RepeatPasswordBox.Header = " ";

                return true;
            }
        }
    }
}
