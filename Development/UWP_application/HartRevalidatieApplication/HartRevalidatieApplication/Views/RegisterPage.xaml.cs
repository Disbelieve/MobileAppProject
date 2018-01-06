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
    public sealed partial class RegisterPage : Page
    {
        private int selectedGender = 0;

        public RegisterPage()
        {
            this.InitializeComponent();
            DataContext = RegisterPageViewModel.SingleInstance;
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {


            if (FirstName_IsValidInput() & LastName_IsValidInput() & BirthDate_IsValidInput() & Consultant_IsValidInput())
            {
                if (IsMale.IsChecked == true)
                    selectedGender = 1;
                else if (IsFemale.IsChecked == true)
                    selectedGender = 2;
                RegisterPageViewModel.SingleInstance.SetFirstRegisterPageUserData(FirstNameTextBox.Text, LastNameTextBox.Text,
                BirthDateTextBox.Date.ToString(), ConsultantTextBox.SelectedValue.ToString(), selectedGender);

                ((Frame)Window.Current.Content).Navigate(typeof(RegisterPage2));
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            GlobalClickMethods.Back_Click(sender, e);
        }

        private void FirstNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            FirstName_IsValidInput();
        }

        private void LastNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            LastName_IsValidInput();
        }

        private void BirthDateTextBox_Changed(object sender, CalendarDatePickerDateChangedEventArgs e)
        {
            BirthDate_IsValidInput();
        }

        private void ConsultantTextBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Consultant_IsValidInput();
        }

        private bool FirstName_IsValidInput()
        {
            if (string.IsNullOrWhiteSpace(FirstNameTextBox.Text))
            {
                FirstNameTextBox.BorderThickness = new Thickness(1);
                FirstNameTextBox.BorderBrush = new SolidColorBrush(Colors.Red);
                FirstNameError.Visibility = Visibility.Visible;

                return false;
            }

            else
            {
                FirstNameTextBox.BorderThickness = new Thickness(0);
                FirstNameError.Visibility = Visibility.Collapsed;

                return true;
            }
        }

        private bool LastName_IsValidInput()
        {
            if (string.IsNullOrWhiteSpace(LastNameTextBox.Text))
            {
                LastNameTextBox.BorderThickness = new Thickness(1);
                LastNameTextBox.BorderBrush = new SolidColorBrush(Colors.Red);
                LastNameError.Visibility = Visibility.Visible;

                return false;
            }

            else
            {
                LastNameTextBox.BorderThickness = new Thickness(0);
                LastNameError.Visibility = Visibility.Collapsed;

                return true;
            }
        }

        private bool BirthDate_IsValidInput()
        {
            if (string.IsNullOrWhiteSpace(BirthDateTextBox.Date.ToString()))
            {
                BirthDateTextBox.BorderThickness = new Thickness(1);
                BirthDateTextBox.BorderBrush = new SolidColorBrush(Colors.Red);
                BirthDateError.Visibility = Visibility.Visible;

                return false;
            }

            else
            {
                BirthDateTextBox.BorderThickness = new Thickness(0);
                BirthDateError.Visibility = Visibility.Collapsed;

                return true;
            }
        }

        private bool Consultant_IsValidInput()
        {
            if (ConsultantTextBox.SelectedValue == null)
            {
                ConsultantTextBox.BorderThickness = new Thickness(1);
                ConsultantTextBox.BorderBrush = new SolidColorBrush(Colors.Red);
                ConsultantError.Visibility = Visibility.Visible;

                return false;
            }

            else
            {
                ConsultantTextBox.BorderThickness = new Thickness(0);
                ConsultantError.Visibility = Visibility.Collapsed;

                return true;
            }
        }
    }
}
