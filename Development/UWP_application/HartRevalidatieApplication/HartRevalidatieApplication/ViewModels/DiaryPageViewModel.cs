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
        public List<Measurement> fullDiary { get; set; }
        public ObservableCollection<Measurement> diary { get; set; } = new ObservableCollection<Measurement>();
        public ObservableCollection<HealthIssue> healthIssues { get; set; }
        public Measurement diaryEntry { get; set; }

        public DiaryPageViewModel()
        {
        }

        public async Task<int> LoadData()
        {
            try
            {
                await GetHealthIssues();
                await InitMeasurements();
                SetMeasurementHealthIssues();
            }
            catch { }

            return 1;
        }

        public void SetDiaryEntry(Measurement dE)
        {
            diaryEntry = dE;

            OnPropertyChanged(nameof(diaryEntry.healthIssues));
        }

        private async Task<int> GetHealthIssues()
        {
            healthIssues = await ApiData.SingleInstance.GetHealthIssues();

            OnPropertyChanged(nameof(healthIssues));

            return 1;
        }

        private async Task<int> InitMeasurements()
        {
            fullDiary = await ApiData.SingleInstance.InitMeasurements();
            OnPropertyChanged(nameof(fullDiary));
            OnPropertyChanged(nameof(diary));

            return 1;
        }

        private void SetMeasurementHealthIssues()
        {
            foreach (Measurement m in fullDiary)
            {
                m.healthIssues = new List<string>();
                if (m.healthIssueIds != null && m.healthIssueIds.Count != 0 || !string.IsNullOrWhiteSpace(m.healthIssueOther))
                {
                    try
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
                    catch { }

                    try
                    {
                        if (!string.IsNullOrWhiteSpace(m.healthIssueOther))
                        {
                            if (m.healthIssueIds != null && m.healthIssueIds.Count != 0)
                            {
                                m.healthIssues.Add("");
                                m.healthIssues.Add("Overige klachten:");
                            }

                            m.healthIssues.Add(m.healthIssueOther);
                        }
                    }
                    catch
                    {
                    }
                }
                else
                {
                    m.healthIssues.Add("Geen bijzondere klachten");
                }
            }
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void SetDiaryWeekly()
        {
            List<Measurement> tempDiary = fullDiary.Take(7).ToList();

            diary.Clear();
            foreach (Measurement m in tempDiary)
                diary.Add(m);
        }

        public void SetDiaryMonthly()
        {
            List<Measurement> tempDiary = fullDiary.Take(30).ToList();

            diary.Clear();
            foreach (Measurement m in tempDiary)
                diary.Add(m);
        }
    }
}
