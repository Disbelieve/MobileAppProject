using HartRevalidatieApplication.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HartRevalidatieApplication.ViewModels
{
    class FAQPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaiseProperty(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));


        public static FAQPageViewModel SingleInstance { get; } = new FAQPageViewModel();
        public ObservableCollection<QA> faq { get; set; }
        public FAQPageViewModel()
        {
            LoadData();
        }


        public async void LoadData()
        {
            try
            {
                await GetFAQ();
            }
            catch { }
        }
        private async Task<int> GetFAQ()
        {
            faq = await ApiData.SingleInstance.GetFAQ();

            OnPropertyChanged(nameof(faq));

            return 1;
        }
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
