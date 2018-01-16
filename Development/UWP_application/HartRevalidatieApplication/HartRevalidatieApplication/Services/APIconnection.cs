using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Windows.UI.Popups;
using HartRevalidatieApplication.Models;
using Newtonsoft.Json.Linq;

namespace HartRevalidatieApplication.Services
{
    public static class APIconnection
    {
        private const string BASE_URL = "https://zvh-api.herokuapp.com/";

        public static async Task<HttpResponseMessage> ConnectToAPI(HttpMethod type, string apiURL, dynamic content = null)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.TryAddWithoutValidation("x-authtoken", User.SingleInstance.authToken);
                    var request = new HttpRequestMessage(type, BASE_URL + apiURL);


                    if (content != null)
                    {
                        request.Content = new StringContent(content,
                                    Encoding.UTF8,
                                    "application/json");
                            }


                    return await client.SendAsync(request);  //bij deze regel code was de error op school
                }
            }

            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
