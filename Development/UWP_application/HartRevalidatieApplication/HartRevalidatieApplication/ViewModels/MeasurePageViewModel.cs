using HartRevalidatieApplication.Models;
using HartRevalidatieApplication.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HartRevalidatieApplication.ViewModels
{
    public sealed class MeasurePageViewModel
    {
        public static MeasurePageViewModel SingleInstance { get; } = new MeasurePageViewModel();
        public User user { get; set; }

        Measurement newMeasurement;

        public MeasurePageViewModel()
        {
            user = User.SingleInstance;
        }

        public void SetFirstMeasurementPageMeasureData(int bloodPressureUpper, int bloodPressureLower)
        {
            newMeasurement = new Measurement();

            newMeasurement.bloodPressureUpper = bloodPressureUpper;
            newMeasurement.bloodPressureLower = bloodPressureLower;
        }

        //unfinished
        public void SetSecondMeasurementPageMeasureData()
        {
            //healthIssueIds
            //healthIssueOther
            newMeasurement.measurementDateTime = DateTime.Now;
        }
        public async Task<bool> SendMeasurement()
        {
            try
            {
                string parameters = JsonConvert.SerializeObject(newMeasurement);
                var response = await APIconnection.ConnectToAPI(HttpMethod.Post, "measurements", parameters);
                var str = await response.Content.ReadAsStringAsync();

                return true;
            }

            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
