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
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace HartRevalidatieApplication.ViewModels
{
    public sealed class SettingsPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaiseProperty(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));


        public static SettingsPageViewModel SingleInstance { get; } = new SettingsPageViewModel();
        public User user { get; set; } = User.SingleInstance;

        public SettingsPageViewModel()
        {
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

        public async Task<bool> UpdateUser(int length, int weight)
        {
            try
            {
                string parameters = "{\"length\":\"" + length + "\",\"weight\":\"" + weight + "\"}";
                var response = await APIconnection.ConnectToAPI(HttpMethod.Put, "Users", parameters);
                var str = await response.Content.ReadAsStringAsync();

                user.length = length;
                user.weight = weight;
                OnPropertyChanged(nameof(user));
                Settings.SetUserDataUpdateTime();
            }

            catch (Exception ex)
            {
            }

            return true;
        }


        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
