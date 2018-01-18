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
                if (IsLogicalInput())
                {
                    MeasurePageViewModel.SingleInstance.SetFirstMeasurementPageMeasureData(Convert.ToInt32(bloodPressureUpperTextBox.Text),
                    Convert.ToInt32(bloodPressureLowerTextBox.Text));
                    ((Frame)Window.Current.Content).Navigate(typeof(NewMeasurementPage2));
                }
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Measurement m = e.Parameter as Measurement;
            MeasurePageViewModel.SingleInstance.StartNewMeasurement(m);

            MeasurePageViewModel.SingleInstance.RemoveNotification();
            
            if (MeasurePageViewModel.SingleInstance.UserDataUpdateRequired())
            {
                ChangePopUpStatus(ChangeDataPopup);
            }


            base.OnNavigatedTo(e);
            if (m == null)
            {
                bloodPressureUpperTextBox.Text = "";
                bloodPressureLowerTextBox.Text = "";
                SetErrorUI(UpperPressureError, bloodPressureUpperTextBox, false, " ");
                SetErrorUI(LowerPressureError, bloodPressureLowerTextBox, false, " ");
            }
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
            if (Length_IsValidInput() & Weight_IsValidInput())
            {
                await SettingsPageViewModel.SingleInstance.UpdateUser(Convert.ToInt16(LengthTextBox.Text), Convert.ToInt16(WeightTextBox.Text));
                ChangePopUpStatus(ChangeDataPopup);
            }
        }

        private bool Length_IsValidInput()
        {
            int tempVar;

            if (string.IsNullOrWhiteSpace(LengthTextBox.Text) || !int.TryParse(LengthTextBox.Text, out tempVar))
            {
                LengthTextBox.BorderThickness = new Thickness(1);
                LengthTextBox.BorderBrush = new SolidColorBrush(Colors.Red);
                LengthError.Text = "Lengte kan niet leeg zijn";

                return false;
            }

            else if (Convert.ToInt32(LengthTextBox.Text) > 250 || Convert.ToInt32(LengthTextBox.Text) < 100)
            {
                LengthTextBox.BorderThickness = new Thickness(1);
                LengthTextBox.BorderBrush = new SolidColorBrush(Colors.Red);
                LengthError.Text = "De gekozen lengte is niet toegestaan";

                return false;
            }

            else
            {
                LengthTextBox.BorderThickness = new Thickness(0);
                LengthError.Text = " ";

                return true;
            }
        }

        private bool Weight_IsValidInput()
        {
            int tempVar;

            if (string.IsNullOrWhiteSpace(WeightTextBox.Text) || !int.TryParse(WeightTextBox.Text, out tempVar))
            {
                WeightTextBox.BorderThickness = new Thickness(1);
                WeightTextBox.BorderBrush = new SolidColorBrush(Colors.Red);
                WeightError.Text = "Gewicht kan niet leeg zijn";

                return false;
            }

            else if (Convert.ToInt32(WeightTextBox.Text) > 300 || Convert.ToInt32(WeightTextBox.Text) < 30)
            {
                WeightTextBox.BorderThickness = new Thickness(1);
                WeightTextBox.BorderBrush = new SolidColorBrush(Colors.Red);
                WeightError.Text = "Het gekozen gewicht is niet toegestaan";

                return false;
            }

            else
            {
                WeightTextBox.BorderThickness = new Thickness(0);
                WeightError.Text = " ";

                return true;
            }
        }

        private bool UpperPressure_IsValidInput()
        {
            int tempVar;

            if (string.IsNullOrWhiteSpace(bloodPressureUpperTextBox.Text))
            {
                SetErrorUI(UpperPressureError, bloodPressureUpperTextBox, true, "Bovendruk kan niet leeg zijn");

                return false;
            }

            else if (!int.TryParse(bloodPressureUpperTextBox.Text, out tempVar))
            {
                SetErrorUI(UpperPressureError, bloodPressureUpperTextBox, true, "Alleen cijfers zijn toegestaan");

                return false;
            }

            else if (Convert.ToInt32(bloodPressureUpperTextBox.Text) > 300 || Convert.ToInt32(bloodPressureUpperTextBox.Text) < 30)
            {
                SetErrorUI(LowerPressureError, bloodPressureLowerTextBox, true, "De gekozen bovendruk is niet toegestaan");

                return false;
            }

            else
            {
                SetErrorUI(UpperPressureError, bloodPressureUpperTextBox, false, " ");

                return true;
            }
        }

        private bool LowerPressure_IsValidInput()
        {
            int tempVar;

            if (string.IsNullOrWhiteSpace(bloodPressureLowerTextBox.Text))
            {
                SetErrorUI(LowerPressureError, bloodPressureLowerTextBox, true, "Onderdruk kan niet leeg zijn");

                return false;
            }
            else if (!int.TryParse(bloodPressureLowerTextBox.Text, out tempVar))
            {
                SetErrorUI(LowerPressureError, bloodPressureLowerTextBox, true, "Alleen cijfers zijn toegestaan");

                return false;
            }

            else if (Convert.ToInt32(bloodPressureLowerTextBox.Text) > 300 || Convert.ToInt32(bloodPressureLowerTextBox.Text) < 30)
            {
                SetErrorUI(LowerPressureError, bloodPressureLowerTextBox, true, "De gekozen onderdruk is niet toegestaan");

                return false;
            }

            else
            {
                SetErrorUI(LowerPressureError, bloodPressureLowerTextBox, false, " ");

                return true;
            }
        }

        private bool IsLogicalInput()
        {
            if (Convert.ToInt16(bloodPressureLowerTextBox.Text) > Convert.ToInt16(bloodPressureUpperTextBox.Text))
            {
                valuesComparedError.Text = "Onderdruk moet kleiner dan bovendruk zijn";
                valuesComparedError.Visibility = Visibility.Visible;
                return false;
            }
            else
            {
                valuesComparedError.Text = "";
                valuesComparedError.Visibility = Visibility.Collapsed;
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
