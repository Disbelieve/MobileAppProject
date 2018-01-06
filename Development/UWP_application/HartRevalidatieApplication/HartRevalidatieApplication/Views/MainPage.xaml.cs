using HartRevalidatieApplication.ViewModels;
using HartRevalidatieApplication.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
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
            this.InitializeComponent();
            DataContext = MainPageViewModel.SingleInstance;
            CheckIfLoggedIn();
        }

        public async void CheckIfLoggedIn()
        {
            if (await LoginPageViewModel.SingleInstance.IsAutomaticallyLoggedIn())
                ((Frame)Window.Current.Content).Navigate(typeof(MeasurePage));
        }


        private void Login_Click(object sender, RoutedEventArgs e)
        {
            ((Frame)Window.Current.Content).Navigate(typeof(LoginPage));
        }
        private void Register_Click(object sender, RoutedEventArgs e)
        {
            ((Frame)Window.Current.Content).Navigate(typeof(RegisterPage));
        }
    }
}
