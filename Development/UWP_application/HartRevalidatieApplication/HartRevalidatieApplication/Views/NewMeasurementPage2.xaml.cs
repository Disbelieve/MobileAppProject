using HartRevalidatieApplication.Helpers;
using HartRevalidatieApplication.ViewModels;
using System;
using System.Collections.Generic;
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
    public sealed partial class NewMeasurementPage2 : Page
    {
        public NewMeasurementPage2()
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
        private async void Next_Click(object sender, RoutedEventArgs e)
        {
            MeasurePageViewModel.SingleInstance.SetSecondMeasurementPageMeasureData(HealthIssueOtherTextBox.Text);
         
            await MeasurePageViewModel.SingleInstance.SendMeasurement();

            MeasurePageViewModel.SingleInstance.SetNotification();

            MeasurePageViewModel.SingleInstance.ClearSelectedHealthIssues();
            ((Frame)Window.Current.Content).Navigate(typeof(NewMeasurementFinishedPage));
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            GlobalClickMethods.Back_Click(sender, e);
        }

        private void noComplaints_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                if ((bool)noComplaints.IsChecked)
                    healthIssuesPanel.Visibility = Visibility.Collapsed;
                else
                    healthIssuesPanel.Visibility = Visibility.Visible;
            }
            catch { }
        }

        private void yesComplaints_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                if ((bool)yesComplaints.IsChecked)
                    healthIssuesPanel.Visibility = Visibility.Visible;
                else
                    healthIssuesPanel.Visibility = Visibility.Collapsed;
            }
            catch { }
        }
    }
}
