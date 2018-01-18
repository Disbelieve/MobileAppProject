using HartRevalidatieApplication.Models;
using HartRevalidatieApplication.ViewModels;
using HartRevalidatieApplication.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace HartRevalidatieApplication
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            if (Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.UI.ViewManagement.StatusBar"))
            {
                showStatusbar();
            }

            DataContext = MainPageViewModel.SingleInstance;
            InitializeComponent();
            LoadData();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            ((Frame)Window.Current.Content).Navigate(typeof(LoginPage));
        }
        private void Register_Click(object sender, RoutedEventArgs e)
        {
            ((Frame)Window.Current.Content).Navigate(typeof(RegisterPage));
        }

        async void LoadData()
        {
            try
            {
                if (NetworkInterface.GetIsNetworkAvailable())
                {
                    ApiData.SingleInstance.GetConsultants();
                    ApiData.SingleInstance.GetHealthIssues();
                    ApiData.SingleInstance.GetFAQ();
                    await CheckIfLoggedIn();
                }
                else
                {
                    ErrorPopup.Visibility = Visibility.Visible;
                }
            }

            catch (Exception ex)
            {
                ErrorPopup.Visibility = Visibility.Visible;
            }
        }

        private void showStatusbar()
        {
            StatusBar statusBar = StatusBar.GetForCurrentView();
            statusBar.BackgroundColor = Color.FromArgb(0, 80, 214, 207);
            statusBar.BackgroundOpacity = 1;
        }

        public async Task<bool> CheckIfLoggedIn()
        {
            try
            {
                if (await LoginPageViewModel.SingleInstance.IsAutomaticallyLoggedIn())
                    ((Frame)Window.Current.Content).Navigate(typeof(MeasurePage));
            }
            catch { }

            return true;
        }
    }
}
