using HartRevalidatieApplication.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HartRevalidatieApplication.ViewModels
{
    public sealed class ContactPageViewModel
    {
        public static ContactPageViewModel SingleInstance { get; } = new ContactPageViewModel();

        public ContactPageViewModel() { }

        public async Task<bool> SendMessage(string subject, string message)
        {
            try
            {
                string parameters = "{\"subject\":\"" + subject + "\",\"message\":\"" + message + "\"}";
                var response = await APIconnection.ConnectToAPI(HttpMethod.Post, "messages", parameters);
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
