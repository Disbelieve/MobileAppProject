using HartRevalidatieApplication.Helpers;
using HartRevalidatieApplication.Models;
using HartRevalidatieApplication.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HartRevalidatieApplication.ViewModels
{
    public sealed class DiaryPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaiseProperty(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));


        public static DiaryPageViewModel SingleInstance { get; } = new DiaryPageViewModel();
        public ObservableCollection<Measurement> diary { get; set; }
        public List<HealthIssue> healthIssues { get; set; }

        public DiaryPageViewModel()
        {
            LoadData();
        }

        public async void LoadData()
        {
            await GetHealthIssues();
            await InitMeasurements();
            SetMeasurementHealthIssues();
        }

        private async Task<int> InitMeasurements()
        {
            var response = await APIconnection.ConnectToAPI(HttpMethod.Get, "measurements");
            diary = JsonConvert.DeserializeObject<ObservableCollection<Measurement>>(await response.Content.ReadAsStringAsync());
            OnPropertyChanged(nameof(diary));

            return 1;
        }
        private async Task<int> GetHealthIssues()
        {
            var response = await APIconnection.ConnectToAPI(HttpMethod.Get, "healthissues");
            healthIssues = JsonConvert.DeserializeObject< List <HealthIssue>>(await response.Content.ReadAsStringAsync());
            OnPropertyChanged(nameof(diary));

            return 1;
        }

        private void SetMeasurementHealthIssues()
        {
            foreach (Measurement m in diary)
            {
                m.healthIssues = new List<string>();
                if (m.healthIssueIds != null)
                {
                    foreach (string healthIssueID in m.healthIssueIds)
                    {
                        foreach (HealthIssue hE in healthIssues)
                        {
                            if (hE._id == healthIssueID)
                            {
                                m.healthIssues.Add(hE.name);
                                break;
                            }
                        }
                    }
                }
                else
                {
                    m.healthIssues.Add("Geen");
                }
            }
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
