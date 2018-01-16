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
            int tempVar;
            try
            {
                if (int.TryParse(LengthTextBox.Text, out tempVar))
                { 
                    await SettingsPageViewModel.SingleInstance.UpdateUser(Convert.ToInt16(LengthTextBox.Text), Convert.ToInt16(WeightTextBox.Text));
                    ChangePopUpStatus(ChangeLengthPopup);
                }
            }

            catch { }
        }

        private async void SaveWeightSettings_Click(object sender, RoutedEventArgs e)
        {
            int tempVar;
            try
            {
                if (int.TryParse(WeightTextBox.Text, out tempVar))
                {
                    await SettingsPageViewModel.SingleInstance.UpdateUser(Convert.ToInt16(LengthTextBox.Text), Convert.ToInt16(WeightTextBox.Text));
                    ChangePopUpStatus(ChangeWeightPopup);
                }
            }

            catch { }
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
