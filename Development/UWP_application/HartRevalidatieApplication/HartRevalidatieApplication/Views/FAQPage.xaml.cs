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
    public sealed partial class FAQPage : Page
    {
        public FAQPage()
        {
            this.InitializeComponent();
            DataContext = FAQPageViewModel.SingleInstance;
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

        private void Listview_ItemClicked(object sender, ItemClickEventArgs e)
        {
            ListView lv = sender as ListView;
            ListViewItem item = (lv.ContainerFromItem(e.ClickedItem) as ListViewItem);
            

            if (item.ContentTemplate.Equals(Resources["NoSelectDataTemplate"] as DataTemplate))
                item.ContentTemplate = Resources["SelectDataTemplate"] as DataTemplate;
            else
                item.ContentTemplate = Resources["NoSelectDataTemplate"] as DataTemplate;
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //can't run if I don't have a SelectionChanged in Listview for some reason
        }
    }
}
