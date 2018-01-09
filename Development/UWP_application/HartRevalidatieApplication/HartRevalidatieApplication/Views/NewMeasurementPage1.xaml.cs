using HartRevalidatieApplication.Helpers;
using HartRevalidatieApplication.Models;
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
    public sealed partial class NewMeasurementPage1 : Page
    {
        public NewMeasurementPage1()
        {
            this.InitializeComponent();
            DataContext = MeasurePageViewModel.SingleInstance;
        }

        private void Diary_Click(object sender, RoutedEventArgs e)
        {
            GlobalClickMethods.Diary_Click(sender, e);
        }
        private void Contact_Click(object sender, RoutedEventArgs e)
        {
            GlobalClickMethods.Contact_Click(sender, e);
        }
        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            GlobalClickMethods.Settings_Click(sender, e);
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            GlobalClickMethods.Back_Click(sender, e);
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            if (UpperPressure_IsValidInput() & LowerPressure_IsValidInput())
            {
                MeasurePageViewModel.SingleInstance.SetFirstMeasurementPageMeasureData(Convert.ToInt32(bloodPressureUpperTextBox.Text),
                    Convert.ToInt32(bloodPressureLowerTextBox.Text));
                ((Frame)Window.Current.Content).Navigate(typeof(NewMeasurementPage2));
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Measurement m = e.Parameter as Measurement;
            if (m != null)
                MeasurePageViewModel.SingleInstance.StartNewMeasurement(m);
            else
            {
                bloodPressureUpperTextBox.Text = "";
                bloodPressureLowerTextBox.Text = "";
            }

            MeasurePageViewModel.SingleInstance.RemoveNotification();
            
            if (MeasurePageViewModel.SingleInstance.UserDataUpdateRequired())
            {
                ChangePopUpStatus(ChangeDataPopup);
            }


            base.OnNavigatedTo(e);
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

        private async void SaveSettings_Click(object sender, RoutedEventArgs e)
        {
            int tempVar;
            if (int.TryParse(LengthTextBox.Text, out tempVar) && int.TryParse(WeightTextBox.Text, out tempVar))
            {
                await SettingsPageViewModel.SingleInstance.UpdateUser(Convert.ToInt16(LengthTextBox.Text), Convert.ToInt16(WeightTextBox.Text));
                ChangePopUpStatus(ChangeDataPopup);
            }
        }

        private void CancelChangeData_Click(object sender, RoutedEventArgs e)
        {
            GlobalClickMethods.Measure_Click(sender, e);
            ChangePopUpStatus(ChangeDataPopup);
        }

        private void bloodPressureUpperTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpperPressure_IsValidInput();
        }

        private void bloodPressureLowerTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            LowerPressure_IsValidInput();
        }

        private bool UpperPressure_IsValidInput()
        {
            int tempVar;

            if (string.IsNullOrWhiteSpace(bloodPressureUpperTextBox.Text))
            {
                SetErrorUI(UpperPressureError, bloodPressureUpperTextBox, true, "Waarde kan niet leeg zijn");

                return false;
            }

            else if (!int.TryParse(bloodPressureUpperTextBox.Text, out tempVar))
            {
                SetErrorUI(UpperPressureError, bloodPressureUpperTextBox, true, "Alleen nummers toegestaan");

                return false;
            }

            else
            {
                SetErrorUI(UpperPressureError, bloodPressureUpperTextBox, false, "");

                return true;
            }
        }

        private bool LowerPressure_IsValidInput()
        {
            int tempVar;

            if (string.IsNullOrWhiteSpace(bloodPressureLowerTextBox.Text))
            {
                SetErrorUI(LowerPressureError, bloodPressureLowerTextBox, true, "Waarde kan niet leeg zijn");

                return false;
            }
            else if (!int.TryParse(bloodPressureLowerTextBox.Text, out tempVar))
            {
                SetErrorUI(LowerPressureError, bloodPressureLowerTextBox, true, "Alleen nummers toegestaan");

                return false;
            }

            else
            {
                SetErrorUI(LowerPressureError, bloodPressureLowerTextBox, false, "");

                return true;
            }
        }

        private void SetErrorUI(TextBlock errorTextBlock, TextBox inputTextBox, bool isError, string errorText)
        {
            errorTextBlock.Text = errorText;
            if (isError)
            {

                inputTextBox.BorderThickness = new Thickness(1);
                inputTextBox.BorderBrush = new SolidColorBrush(Colors.Red);
                errorTextBlock.Visibility = Visibility.Visible;
            }
            else
            {
                inputTextBox.BorderThickness = new Thickness(0);
                errorTextBlock.Visibility = Visibility.Collapsed;
            }
        }
    }
}
