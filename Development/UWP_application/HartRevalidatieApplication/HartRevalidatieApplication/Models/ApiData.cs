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

namespace HartRevalidatieApplication.Models
{
    public sealed class ApiData
    {
        public static ApiData SingleInstance { get; } = new ApiData();
        
        private ObservableCollection<Consultant> consultants { get; set; }
        private ObservableCollection<HealthIssue> healthIssues { get; set; }
        private ObservableCollection<QA> faq { get; set; }

        public List<Measurement> diary { get; set; }

        public ApiData() { }

        public async Task<ObservableCollection<Consultant>> GetConsultants()
        {
            if (consultants == null)
            {
                var response = await APIconnection.ConnectToAPI(HttpMethod.Get, "consultants");
                consultants = JsonConvert.DeserializeObject<ObservableCollection<Consultant>>(await response.Content.ReadAsStringAsync());
            }

            return consultants;
        }

        public async Task<List<Measurement>> InitMeasurements()
        {
            var response = await APIconnection.ConnectToAPI(HttpMethod.Get, "measurements");

            var str = await response.Content.ReadAsStringAsync();
            diary = JsonConvert.DeserializeObject<List<Measurement>>(await response.Content.ReadAsStringAsync());

            return diary;
        }

        public async Task<ObservableCollection<HealthIssue>> GetHealthIssues()
        {
            if (healthIssues == null)
            {
                var response = await APIconnection.ConnectToAPI(HttpMethod.Get, "healthissues");
                healthIssues = JsonConvert.DeserializeObject<ObservableCollection<HealthIssue>>(await response.Content.ReadAsStringAsync());
            }

            return healthIssues;
        }

        public async Task<ObservableCollection<QA>> GetFAQ()
        {
            if (faq == null)
            {
                var response = await APIconnection.ConnectToAPI(HttpMethod.Get, "faq");
                faq = JsonConvert.DeserializeObject<ObservableCollection<QA>>(await response.Content.ReadAsStringAsync());
            }

            return faq;
        }
    }
}
