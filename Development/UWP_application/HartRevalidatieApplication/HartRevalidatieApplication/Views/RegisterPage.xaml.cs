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
            if (IsMale.IsChecked == true)
                selectedGender = 1;
            else if (IsFemale.IsChecked == true)
                selectedGender = 2;


            RegisterPageViewModel.SingleInstance.SetFirstRegisterPageUserData(NameTextBox.Text, BirthDateTextBox.Date.ToString(), 
                ConsultantTextBox.SelectedValue.ToString(), selectedGender);

            ((Frame)Window.Current.Content).Navigate(typeof(RegisterPage2));
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            GlobalClickMethods.Back_Click(sender, e);
        }
    }
}
