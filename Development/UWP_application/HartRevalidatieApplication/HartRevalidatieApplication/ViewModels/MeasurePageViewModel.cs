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
using Windows.UI.Notifications;

namespace HartRevalidatieApplication.ViewModels
{
    public sealed class MeasurePageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaiseProperty(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));


        public static MeasurePageViewModel SingleInstance { get; } = new MeasurePageViewModel();
        public User user { get; set; } = User.SingleInstance;
        public ObservableCollection<HealthIssue> healthIssues { get; set; }

        public string salutation { get; set; }

        public Measurement newMeasurement { get; set; } = new Measurement();

        public MeasurePageViewModel()
        {
            SetSalutation();
            LoadData();
        }

        private void SetSalutation()
        {
            if (user.gender == 1)
                salutation = "meneer";
            else
                salutation = "mevrouw";
        }

        public async void LoadData()
        {
           await GetHealthIssues();
        }
        private async Task<int> GetHealthIssues()
        {
            healthIssues = await ApiData.SingleInstance.GetHealthIssues();

            OnPropertyChanged(nameof(healthIssues));

            return 1;
        }

        public void StartNewMeasurement(Measurement newMeasurement)
        {
            if (newMeasurement != null)
            {
                this.newMeasurement = newMeasurement;
                SetSelectedHealthIssues();
            }
            else
                this.newMeasurement = new Measurement();

            OnPropertyChanged(nameof(this.newMeasurement));
        }

        public void SetFirstMeasurementPageMeasureData(int bloodPressureUpper, int bloodPressureLower)
        {
            newMeasurement.bloodPressureUpper = bloodPressureUpper;
            newMeasurement.bloodPressureLower = bloodPressureLower;
        }

        //unfinished
        public void SetSecondMeasurementPageMeasureData(string healthIssueOther)
        {
            SetMeasurementSelectedHealthIssues();
            newMeasurement.healthIssueOther = healthIssueOther;
        }

        private void SetSelectedHealthIssues()
        {            
            foreach (HealthIssue hE in healthIssues)
            {
                hE.isSelected = false;
                foreach (string healthIssue in newMeasurement.healthIssues)
                {
                    if (healthIssue == hE.name)
                    {
                        hE.isSelected = true;
                        break;
                    }
                }
            }
        }

        private void SetMeasurementSelectedHealthIssues()
        {
            List<string> ids = new List<string>();
            List<string> names = new List<string>();
            foreach (HealthIssue hE in healthIssues)
            {
                if (hE.isSelected)
                {
                    ids.Add(hE._id);
                    names.Add(hE.name);
                }
            }

            newMeasurement.healthIssueIds = ids;
            newMeasurement.healthIssues = names;
        }

        public void ClearSelectedHealthIssues()
        {
            foreach (HealthIssue hE in healthIssues)
            {
                hE.isSelected = false;
            }
        }

        public async Task<bool> SendMeasurement()
        {
            HttpMethod methodType;
            if (newMeasurement._id != null)
            {
                methodType = HttpMethod.Put;
            }
            else
            {
                methodType = HttpMethod.Post;
            }

            try
            {
                string parameters = JsonConvert.SerializeObject(newMeasurement);
                var response = await APIconnection.ConnectToAPI(methodType, "measurements", parameters);
                var str = await response.Content.ReadAsStringAsync();

                Settings.SetLastMeasurementUpdate(newMeasurement.measurementDateTime);
                return true;
            }

            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UserDataUpdateRequired()
        {
            DateTimeOffset? lastUpdate = (DateTimeOffset?)Settings.localSettings.Values["lastWeightAndLengthUpdate"];
            if (lastUpdate == null || (DateTimeOffset.Now - (DateTimeOffset)lastUpdate).Days >= 21)
                return true;
            else
                return false;

        }

        public bool DailyMeasurementFinished()
        {
            DateTimeOffset? lastUpdate = (DateTimeOffset?)Settings.localSettings.Values["lastMeasurementUpdate"];
            if (lastUpdate != null && (DateTimeOffset.Now.ToString("d") == lastUpdate.Value.ToString("d")))
                return true;
            else
                return false;

        }

        public void RemoveNotification()
        {
            ToastNotifier toastNotifier = ToastNotificationManager.CreateToastNotifier();
            var scheduled = toastNotifier.GetScheduledToastNotifications();

            for (int i = 0; i < scheduled.Count; i++)
            {
                if (scheduled[i].DeliveryTime.Date == DateTimeOffset.Now.Date)
                    toastNotifier.RemoveFromSchedule(scheduled[i]);
            }
        }

        public void SetNotification()
        {
            ToastNotifier toastNotifier = ToastNotificationManager.CreateToastNotifier();
            Windows.Data.Xml.Dom.XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastImageAndText02);
            Windows.Data.Xml.Dom.XmlNodeList toastNodeList = toastXml.GetElementsByTagName("text");
            toastNodeList.Item(0).AppendChild(toastXml.CreateTextNode("Zorg voor uw hart"));
            toastNodeList.Item(1).AppendChild(toastXml.CreateTextNode("Het is weer tijd voor uw meting!"));
            Windows.Data.Xml.Dom.IXmlNode toastNode = toastXml.SelectSingleNode("/toast");
            Windows.Data.Xml.Dom.XmlElement audio = toastXml.CreateElement("audio");
            audio.SetAttribute("src", "ms-winsoundevent:Notification.SMS");

            DateTime notifierDateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day + 1, 20, 0, 0);
            
            ScheduledToastNotification toast = new ScheduledToastNotification(toastXml, notifierDateTime);
            toastNotifier.AddToSchedule(toast);
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
