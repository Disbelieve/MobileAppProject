using HartRevalidatieApplication.Helpers;
using HartRevalidatieApplication.Models;
using HartRevalidatieApplication.Services;
using HartRevalidatieApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
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
    public sealed partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
            DataContext = LoginPageViewModel.SingleInstance;
        }
        private async void Login_Click(object sender, RoutedEventArgs e)
        {
            if (Email_IsValidInput() & Password_IsValidInput())
            {
                if (await LoginPageViewModel.SingleInstance.Login(EmailTextBox.Text, PasswordBox.Password))
                {
                    Settings.SetAutomaticLogin(AutoLoginCheckBox.IsChecked.Value);
                    ((Frame)Window.Current.Content).Navigate(typeof(MeasurePage));
                }
                else
                {
                    LoginFailError.Visibility = Visibility.Visible;
                }
            }
        }
        private void RememberPassword_Click(object sender, RoutedEventArgs e)
        {
            ChangePopUpStatus(RememberPasswordPopup);
        }

        private void ChangePopUpStatus(Grid popup)
        {
            if (popup.Visibility == Visibility.Collapsed)
            {
                popup.Visibility = Visibility.Visible;
                PopupBackground.Visibility = Visibility.Visible;
            }
            else
            {
                popup.Visibility = Visibility.Collapsed;
                PopupBackground.Visibility = Visibility.Collapsed;
            }
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            ChangePopUpStatus(RememberPasswordPopup);
        }
        private async void RequestRecoveryMail_Click(object sender, RoutedEventArgs e)
        {
            await LoginPageViewModel.SingleInstance.RequestRecoveryMail(RecoverMailTextBox.Text);
            ChangePopUpStatus(RememberPasswordPopup);
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            ((Frame)Window.Current.Content).Navigate(typeof(MainPage));
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            AutoLoginCheckBox.IsChecked = (bool)Settings.localSettings.Values["automaticLogin"];
            base.OnNavigatedTo(e);
        }

        private void EmailTextBox_TextChanged(object sender, RoutedEventArgs e)
        {
            Email_IsValidInput();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            Password_IsValidInput();
        }

        private bool Email_IsValidInput()
        {
            if (string.IsNullOrWhiteSpace(EmailTextBox.Text))
            {
                EmailTextBox.BorderThickness = new Thickness(1);
                EmailTextBox.BorderBrush = new SolidColorBrush(Colors.Red);
                EmailError.Visibility = Visibility.Visible;
                EmailError.Text = "E-mail kan niet leeg zijn";

                return false;
            }

            else
            {
                EmailTextBox.BorderThickness = new Thickness(0);
                EmailError.Visibility = Visibility.Collapsed;

                return true;
            }
        }

        private bool Password_IsValidInput()
        {
            if (string.IsNullOrWhiteSpace(PasswordBox.Password))
            {
                PasswordBox.BorderThickness = new Thickness(1);
                PasswordBox.BorderBrush = new SolidColorBrush(Colors.Red);
                PasswordError.Visibility = Visibility.Visible;
                PasswordError.Text = "Wachtwoord kan niet leeg zijn";

                return false;
            }

            else
            {
                PasswordBox.BorderThickness = new Thickness(0);
                PasswordError.Visibility = Visibility.Collapsed;

                return true;
            }
        }
    }
}
