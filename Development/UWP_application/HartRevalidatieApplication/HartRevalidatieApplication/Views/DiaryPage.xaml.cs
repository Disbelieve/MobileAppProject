using HartRevalidatieApplication.Helpers;
using HartRevalidatieApplication.Models;
using HartRevalidatieApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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
    public sealed partial class DiaryPage : Page
    {
        public DiaryPage()
        {
            this.InitializeComponent();
            DataContext = DiaryPageViewModel.SingleInstance;
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            LoadData();
            base.OnNavigatedTo(e);
        }


        private async void LoadData()
        {
            try
            {
                await DiaryPageViewModel.SingleInstance.LoadData();
                WeekButton_Click(null, null);
                SetLayoutOfEmptyDiary();
            }
            catch { }
        }

        private void SetLayoutOfEmptyDiary()
        {
            if (DiaryPageViewModel.SingleInstance.fullDiary == null || DiaryPageViewModel.SingleInstance.fullDiary.Count == 0)
                EmptyDiaryPopup.Visibility = Visibility.Visible;
            else
                EmptyDiaryPopup.Visibility = Visibility.Collapsed;
        }

        private void NavigateToDiaryEntryPage(object sender, ItemClickEventArgs e)
        {
            Measurement dE = e.ClickedItem as Measurement;
            ((Frame)Window.Current.Content).Navigate(typeof(DiaryEntryPage), dE);
        }

        private void Measure_Click(object sender, RoutedEventArgs e)
        {
            GlobalClickMethods.Measure_Click(sender, e);
        }
        private void Contact_Click(object sender, RoutedEventArgs e)
        {
            GlobalClickMethods.Contact_Click(sender, e);
        }
        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            GlobalClickMethods.Settings_Click(sender, e);
        }

        private void StartMeasure_Click(object sender, RoutedEventArgs e)
        {
            ((Frame)Window.Current.Content).Navigate(typeof(NewMeasurementPage1));
        }

        private void WeekButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (WeekCheckmark.Visibility == Visibility.Collapsed)
                {
                    DiaryPageViewModel.SingleInstance.SetDiaryWeekly();
                    WeekBorder.Background = new SolidColorBrush(Color.FromArgb(255, 224, 224, 224));
                    MonthBorder.Background = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
                    WeekCheckmark.Visibility = Visibility.Visible;
                    MonthCheckmark.Visibility = Visibility.Collapsed;
                }
            }
            catch { }
        }

        private void MonthButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MonthCheckmark.Visibility == Visibility.Collapsed)
                {
                    DiaryPageViewModel.SingleInstance.SetDiaryMonthly();
                    MonthBorder.Background = new SolidColorBrush(Color.FromArgb(255, 224, 224, 224));
                    WeekBorder.Background = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
                    MonthCheckmark.Visibility = Visibility.Visible;
                    WeekCheckmark.Visibility = Visibility.Collapsed;
                }
            }

            catch { }
        }
    }
}
