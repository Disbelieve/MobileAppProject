﻿using HartRevalidatieApplication.Helpers;
using HartRevalidatieApplication.Models;
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
    public sealed partial class DiaryEntryPage : Page
    {
        public DiaryEntryPage()
        {
            DataContext = DiaryPageViewModel.SingleInstance;
            this.InitializeComponent();
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
        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            GlobalClickMethods.Settings_Click(sender, e);
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            GlobalClickMethods.Back_Click(sender, e);
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            DiaryPageViewModel.SingleInstance.SetDiaryEntry(e.Parameter as Measurement);
            if (DiaryPageViewModel.SingleInstance.diaryEntry == null) return;
            base.OnNavigatedTo(e);
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            ((Frame)Window.Current.Content).Navigate(typeof(NewMeasurementPage1), DiaryPageViewModel.SingleInstance.diaryEntry);
        }
    }
}
