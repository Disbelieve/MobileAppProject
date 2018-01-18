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
                if (await LoginPageViewModel.SingleInstance.Login(EmailTextBox.Text, HashFunction.GetHash(PasswordBox.Password)))
                {
                    Settings.SetAutomaticLogin(AutoLoginCheckBox.IsChecked.Value);
                    ((Frame)Window.Current.Content).Navigate(typeof(MeasurePage));
                }
                else
                {
                    LoginFailError.Text = "Onjuist email en/of wachtwoord";
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
            if (RecoverEmail_IsValidInput())
            {
                await LoginPageViewModel.SingleInstance.RequestRecoveryMail(RecoverMailTextBox.Text);
                RememberPasswordPopup.Visibility = Visibility.Collapsed;
                RememberPasswordMailSent.Visibility = Visibility.Visible;
            }
        }
        private void RecoverPassword_Click(object sender, RoutedEventArgs e)
        {
            ChangePopUpStatus(RememberPasswordMailSent);
            ((Frame)Window.Current.Content).Navigate(typeof(RecoverPasswordPage));
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

        private bool RecoverEmail_IsValidInput()
        {
            if (string.IsNullOrWhiteSpace(RecoverMailTextBox.Text))
            {
                RecoverMailTextBox.BorderThickness = new Thickness(1);
                RecoverMailTextBox.BorderBrush = new SolidColorBrush(Colors.Red);
                RecoverMailTextBox.Header = "E-mail kan niet leeg zijn";

                return false;
            }

            else if (!IsValidEmailAddress(RecoverMailTextBox.Text))
            {
                RecoverMailTextBox.BorderThickness = new Thickness(1);
                RecoverMailTextBox.BorderBrush = new SolidColorBrush(Colors.Red);
                RecoverMailTextBox.Header = "Geen geldig e-mail adres";

                return false;
            }

            else
            {
                RecoverMailTextBox.BorderThickness = new Thickness(0);
                RecoverMailTextBox.Header = " ";

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
    }
}
