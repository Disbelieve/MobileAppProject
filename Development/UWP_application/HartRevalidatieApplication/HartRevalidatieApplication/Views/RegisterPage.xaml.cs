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
            if (FirstName_IsValidInput() & LastName_IsValidInput() & BirthDate_IsValidInput() & Weight_IsValidInput() & Length_IsValidInput())
            {
                if (IsMale.IsChecked == true)
                    selectedGender = 1;
                else if (IsFemale.IsChecked == true)
                    selectedGender = 2;
                RegisterPageViewModel.SingleInstance.SetFirstRegisterPageUserData(FirstNameTextBox.Text, LastNameTextBox.Text,
                BirthDateTextBox.Date.ToString(), selectedGender, WeightTextBox.Text, LengthTextBox.Text);

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

        private void WeightTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Weight_IsValidInput();
        }

        private void LengthTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Length_IsValidInput();
        }

        private bool Weight_IsValidInput()
        {
            int tempVar;

            if (string.IsNullOrWhiteSpace(WeightTextBox.Text) || !int.TryParse(WeightTextBox.Text, out tempVar))
            {
                WeightTextBox.BorderThickness = new Thickness(1);
                WeightTextBox.BorderBrush = new SolidColorBrush(Colors.Red);
                WeightError.Visibility = Visibility.Visible;

                return false;
            }

            else
            {
                WeightTextBox.BorderThickness = new Thickness(0);
                WeightError.Visibility = Visibility.Collapsed;

                return true;
            }
        }

        private bool Length_IsValidInput()
        {
            int tempVar;

            if (string.IsNullOrWhiteSpace(LengthTextBox.Text) || !int.TryParse(LengthTextBox.Text, out tempVar))
            {
                LengthTextBox.BorderThickness = new Thickness(1);
                LengthTextBox.BorderBrush = new SolidColorBrush(Colors.Red);
                LengthError.Visibility = Visibility.Visible;

                return false;
            }

            else
            {
                LengthTextBox.BorderThickness = new Thickness(0);
                LengthError.Visibility = Visibility.Collapsed;

                return true;
            }
        }
    }
}
