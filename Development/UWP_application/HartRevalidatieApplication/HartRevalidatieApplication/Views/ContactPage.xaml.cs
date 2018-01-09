using HartRevalidatieApplication.Helpers;
using HartRevalidatieApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Popups;
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
    public sealed partial class ContactPage : Page
    {
        public ContactPage()
        {
            this.InitializeComponent();
            DataContext = ContactPageViewModel.SingleInstance;
        }
        private async void Send_Click(object sender, RoutedEventArgs e)
        {
            if (Subject_IsValidInput() & Message_IsValidInput())
            {
                await ContactPageViewModel.SingleInstance.SendMessage(SubjectTextBox.Text, MessageTextBox.Text);
                ((Frame)Window.Current.Content).Navigate(typeof(ContactFinishedPage));
            }
        }

        private void Measure_Click(object sender, RoutedEventArgs e)
        {
            GlobalClickMethods.Measure_Click(sender, e);
        }
        private void Diary_Click(object sender, RoutedEventArgs e)
        {
            GlobalClickMethods.Diary_Click(sender, e);
        }
        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            GlobalClickMethods.Settings_Click(sender, e);
        }

        private void SubjectTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Subject_IsValidInput();
        }

        private void MessageTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Message_IsValidInput();
        }

        private bool Subject_IsValidInput()
        {
            if (string.IsNullOrWhiteSpace(SubjectTextBox.Text))
            {
                SubjectTextBox.BorderThickness = new Thickness(1);
                SubjectTextBox.BorderBrush = new SolidColorBrush(Colors.Red);
                SubjectError.Visibility = Visibility.Visible;

                return false;
            }

            else
            {
                SubjectTextBox.BorderThickness = new Thickness(0);
                SubjectError.Visibility = Visibility.Collapsed;

                return true;
            }
        }

        private bool Message_IsValidInput()
        {
            if (string.IsNullOrWhiteSpace(MessageTextBox.Text))
            {
                MessageTextBox.BorderThickness = new Thickness(1);
                MessageTextBox.BorderBrush = new SolidColorBrush(Colors.Red);
                MessageError.Visibility = Visibility.Visible;

                return false;
            }

            else
            {
                MessageTextBox.BorderThickness = new Thickness(0);
                MessageError.Visibility = Visibility.Collapsed;

                return true;
            }
        }
    }
}
