using HartRevalidatieApplication.Helpers;
using HartRevalidatieApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Notifications;
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
    public sealed partial class MeasurePage : Page
    {
        public MeasurePage()
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
        private void Next_Click(object sender, RoutedEventArgs e)
        {
            ((Frame)Window.Current.Content).Navigate(typeof(NewMeasurementPage1));
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            greetingText.Text = MeasurePageViewModel.SingleInstance.GetGreeting();
            if (MeasurePageViewModel.SingleInstance.DailyMeasurementFinished())
            {
                NewMeasureText.Text = "U heeft vandaag al een meting gedaan, wilt u er nog een doen?";
            }
            else
            {
                NewMeasureText.Text = "Start hier een nieuwe meting";
            }

            base.OnNavigatedTo(e);
        }
    }
}
