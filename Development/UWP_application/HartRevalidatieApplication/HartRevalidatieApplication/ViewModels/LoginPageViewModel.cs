using HartRevalidatieApplication.Models;
using HartRevalidatieApplication.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Credentials;

namespace HartRevalidatieApplication.ViewModels
{
    public sealed class LoginPageViewModel
    {
        public static LoginPageViewModel SingleInstance { get; } = new LoginPageViewModel();

        public LoginPageViewModel() { }
        
        public async Task<bool> Login(string email, string password)
        {
            try
            {
                string parameters = "{\"emailAddress\":\"" + email + "\",\"password\":\""+password + "\"}";
                var response = await APIconnection.ConnectToAPI(HttpMethod.Post, "Users/login/", parameters);

                if (response.StatusCode.ToString() == "OK")
                {
                    User.SetUser(JsonConvert.DeserializeObject<User>(await response.Content.ReadAsStringAsync()));
                    StoreLoginCredentials(email, password);

                    return true;
                }
                else
                {
                    return false;
                }
            }

            catch (Exception ex)
            {
                return false;
            }
        }
        
        public async Task<bool> RequestRecoveryMail(string email)
        {
            try
            {
                var response = await APIconnection.ConnectToAPI(HttpMethod.Post, "Users/forgotPassword?emailAddress=" + email);
                var str = await response.Content.ReadAsStringAsync();

                return true;
            }

            catch (Exception ex)
            {
                return false;
            }
        }

        public void StoreLoginCredentials(string email, string password)
        {
            var vault = new PasswordVault();
            vault.Add(new PasswordCredential("Login", email, password));
        }

        public async Task<bool> IsAutomaticallyLoggedIn()
        {
            var loginCredential = GetCredentialFromLocker();

            if (AutoLoginEnabled() && loginCredential != null)
            {
                loginCredential.RetrievePassword();
                string email = loginCredential.UserName;
                string password = loginCredential.Password;
                return await Login(email, password);
            }

            return false;
        }

        public PasswordCredential GetCredentialFromLocker()
        {
            try
            {
                PasswordCredential credential = null;

                var vault = new PasswordVault();
                var credentialList = vault.FindAllByResource("Login");

                if (credentialList != null && credentialList.Count > 0)
                {
                    credential = credentialList[0];
                }

                return credential;
            }

            catch
            {
                return null;
            }
        }

        public bool AutoLoginEnabled()
        {
            return (bool)Settings.localSettings.Values["automaticLogin"];
        }
    }
}
