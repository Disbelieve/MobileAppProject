using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Windows.UI.Popups;

namespace HartRevalidatieApplication.Services
{
    public static class APIconnection
    {
        private const string BASE_URL = "http://placeholder.com/api/";

        public static async Task<HttpResponseMessage> ConnectToAPI(HttpMethod type, string apiURL)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    return await client.SendAsync(new HttpRequestMessage(type, BASE_URL + apiURL));
                }
            }

            catch (Exception ex)
            {
                var dialog = new MessageDialog(ex.Message);
                return null;
            }
        }
    }
}
