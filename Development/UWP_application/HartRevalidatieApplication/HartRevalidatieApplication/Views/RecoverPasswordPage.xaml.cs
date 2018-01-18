using HartRevalidatieApplication.Helpers;
using HartRevalidatieApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
    public sealed partial class RecoverPasswordPage : Page
    {
        public RecoverPasswordPage()
        {
            this.InitializeComponent();
            DataContext = RecoverPasswordPageViewModel.SingleInstance;
            RecoverCodeTextBox.BorderThickness = new Thickness(0);
            RecoverCodeTextBox.Header = " ";
        }

        private async void RecoverPassword_Click(object sender, RoutedEventArgs e)
        {
            if (RecoverCode_IsValidInput() & Password_IsValidInput() & RepeatPassword_IsValidInput())
            {
                if (await RecoverPasswordPageViewModel.SingleInstance.RecoverPassword(RecoverCodeTextBox.Text,
                     HashFunction.GetHash(PasswordBox.Password), HashFunction.GetHash(RepeatPasswordBox.Password)))
                    ((Frame)Window.Current.Content).Navigate(typeof(RecoverPasswordFinishedPage));
                else
                {
                    RecoverCodeTextBox.BorderThickness = new Thickness(1);
                    RecoverCodeTextBox.BorderBrush = new SolidColorBrush(Colors.Red);
                    RecoverCodeTextBox.Header = "Ongeldige code";
                }

            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            GlobalClickMethods.Back_Click(sender, e);
        }

        private bool RecoverCode_IsValidInput()
        {
            if (string.IsNullOrWhiteSpace(RecoverCodeTextBox.Text))
            {
                RecoverCodeTextBox.BorderThickness = new Thickness(1);
                RecoverCodeTextBox.BorderBrush = new SolidColorBrush(Colors.Red);
                RecoverCodeTextBox.Header = "Herstelcode kan niet leeg zijn";

                return false;
            }

            else
            {
                RecoverCodeTextBox.BorderThickness = new Thickness(0);
                RecoverCodeTextBox.Header = " ";

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
