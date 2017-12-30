using HartRevalidatieApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Security.Credentials;
using HartRevalidatieApplication.Services;
using System.Net.Http;
using Newtonsoft.Json;

namespace HartRevalidatieApplication.ViewModels
{
    public sealed class SettingsPageViewModel
    {
        public static SettingsPageViewModel SingleInstance { get; } = new SettingsPageViewModel();
        public User user { get; set; }

        public SettingsPageViewModel()
        {
            user = User.SingleInstance;
        }
        public void Logout()
        {
            var loginCredential = LoginPageViewModel.SingleInstance.GetCredentialFromLocker();

            if (loginCredential != null)
            {
                loginCredential.RetrievePassword();

                var vault = new PasswordVault();
                vault.Remove(new PasswordCredential(
                    "Login", loginCredential.UserName, loginCredential.Password));
            }
        }

        public async void UpdateUser(int length, int weight)
        {
            user.length = length;
            user.weight = weight;

            try
            {
                string parameters = "{\"length\":\"" + length + "\",\"weight\":\"" + weight + "\"}";
                var response = await APIconnection.ConnectToAPI(HttpMethod.Put, "Users", parameters);
                var str = await response.Content.ReadAsStringAsync();
            }

            catch (Exception ex)
            {
            }
        }
    }
}
