using HartRevalidatieApplication.Helpers;
using HartRevalidatieApplication.Models;
using HartRevalidatieApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public sealed partial class SettingsPage : Page
    {
        public SettingsPage()
        {
            this.InitializeComponent();
            DataContext = SettingsPageViewModel.SingleInstance;
        }

        private void Toggle_AutomaticLogin(object sender, RoutedEventArgs e)
        {
            Settings.SetAutomaticLogin(automaticLogin.IsOn);
        }

        private void Toggle_LargeFonts(object sender, RoutedEventArgs e)
        {
            Settings.SetLargeFonts(largeFonts.IsOn);
        }

        private void Toggle_DailyReminders(object sender, RoutedEventArgs e)
        {
            Settings.SetDailyReminders(dailyReminders.IsOn);
        }

        private void Toggle_SendMeasurements(object sender, RoutedEventArgs e)
        {
            Settings.SetSendMeasurements(sendMeasurements.IsOn);
        }

        private void Measure_Click(object sender, RoutedEventArgs e)
        {
            GlobalClickMethods.Measure_Click(sender, e);
        }
        private void Diary_Click(object sender, RoutedEventArgs e)
        {
            GlobalClickMethods.Diary_Click(sender, e);
        }
        private void Contact_Click(object sender, RoutedEventArgs e)
        {
            GlobalClickMethods.Contact_Click(sender, e);
        }

        private void ChangeLengthSetting_Click(object sender, RoutedEventArgs e)
        {
            ChangePopUpStatus(ChangeLengthPopup);
        }

        private void ChangeWeightSetting_Click(object sender, RoutedEventArgs e)
        {
            ChangePopUpStatus(ChangeWeightPopup);
        }

        private async void SaveLengthSettings_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Length_IsValidInput())
                { 
                    await SettingsPageViewModel.SingleInstance.UpdateUser(Convert.ToInt16(LengthTextBox.Text), Convert.ToInt16(WeightTextBox.Text));
                    ChangePopUpStatus(ChangeLengthPopup);
                }
            }

            catch { }
        }

        private async void SaveWeightSettings_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Weight_IsValidInput())
                {
                    await SettingsPageViewModel.SingleInstance.UpdateUser(Convert.ToInt16(LengthTextBox.Text), Convert.ToInt16(WeightTextBox.Text));
                    ChangePopUpStatus(ChangeWeightPopup);
                }
            }

            catch { }
        }

        private bool Length_IsValidInput()
        {
            int tempVar;

            if (string.IsNullOrWhiteSpace(LengthTextBox.Text) || !int.TryParse(LengthTextBox.Text, out tempVar))
            {
                LengthTextBox.BorderThickness = new Thickness(1);
                LengthTextBox.BorderBrush = new SolidColorBrush(Colors.Red);
                LengthTextBox.Header = "Lengte kan niet leeg zijn";

                return false;
            }

            else if (Convert.ToInt32(LengthTextBox.Text) > 250 || Convert.ToInt32(LengthTextBox.Text) < 100)
            {
                LengthTextBox.BorderThickness = new Thickness(1);
                LengthTextBox.BorderBrush = new SolidColorBrush(Colors.Red);
                LengthTextBox.Header = "De gekozen lengte is niet toegestaan";

                return false;
            }

            else
            {
                LengthTextBox.BorderThickness = new Thickness(0);
                LengthTextBox.Header = " ";

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
                WeightTextBox.Header = "Gewicht kan niet leeg zijn";

                return false;
            }

            else if (Convert.ToInt32(WeightTextBox.Text) > 300 || Convert.ToInt32(WeightTextBox.Text) < 30)
            {
                WeightTextBox.BorderThickness = new Thickness(1);
                WeightTextBox.BorderBrush = new SolidColorBrush(Colors.Red);
                WeightTextBox.Header = "Het gekozen gewicht is niet toegestaan";

                return false;
            }

            else
            {
                WeightTextBox.BorderThickness = new Thickness(0);
                WeightTextBox.Header = " ";

                return true;
            }
        }

        private void CancelChangeLength_Click(object sender, RoutedEventArgs e)
        {
            ChangePopUpStatus(ChangeLengthPopup);
        }

        private void CancelChangeWeight_Click(object sender, RoutedEventArgs e)
        {
            ChangePopUpStatus(ChangeWeightPopup);
        }

        private void LogoutSetting_Click(object sender, RoutedEventArgs e)
        {
            ChangePopUpStatus(LogoutPopup);
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            SettingsPageViewModel.SingleInstance.Logout();
            ((Frame)Window.Current.Content).Navigate(typeof(MainPage));
        }

        private void CancelLogout_Click(object sender, RoutedEventArgs e)
        {
            ChangePopUpStatus(LogoutPopup);
        }

        private void FAQPage_Click(object sender, RoutedEventArgs e)
        {
            ((Frame)Window.Current.Content).Navigate(typeof(FAQPage));
        }

        private void ChangePopUpStatus(Grid popup)
        {
            if (popup.Visibility == Visibility.Collapsed)
            {
                popup.Visibility = Visibility.Visible;
                PopupSettingsBackground.Visibility = Visibility.Visible;
            }
            else
            {
                popup.Visibility = Visibility.Collapsed;
                PopupSettingsBackground.Visibility = Visibility.Collapsed;
            }
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            SetSettingsUI();
            base.OnNavigatedTo(e);
        }

        private void SetSettingsUI()
        {
            automaticLogin.IsOn = (bool)Settings.localSettings.Values["automaticLogin"];
            largeFonts.IsOn = (bool)Settings.localSettings.Values["largeFonts"];
            dailyReminders.IsOn = (bool)Settings.localSettings.Values["dailyReminders"];
            sendMeasurements.IsOn = (bool)Settings.localSettings.Values["sendMeasurements"];
        }
    }
}
