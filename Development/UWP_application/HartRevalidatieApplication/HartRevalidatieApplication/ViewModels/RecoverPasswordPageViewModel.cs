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
    class RecoverPasswordPageViewModel
    {


        public static RecoverPasswordPageViewModel SingleInstance { get; } = new RecoverPasswordPageViewModel();
        public RecoverPasswordPageViewModel() { }
        public RecoverPasswordTemplate recoverPasswordTemplate { get; set; } = new RecoverPasswordTemplate(); 

        public async Task<bool> RecoverPassword(string recoverCode, string password, string repeatPassword)
        {
            recoverPasswordTemplate.token = recoverCode;
            recoverPasswordTemplate.password = password;
            recoverPasswordTemplate.confirmedPassword = repeatPassword;
            try
            {
                string parameters = JsonConvert.SerializeObject(recoverPasswordTemplate);
                var response = await APIconnection.ConnectToAPI(HttpMethod.Put, "Users/resetPassword/", parameters);

                if (response.StatusCode.ToString() == "OK")
                    return true;
                else
                    return false;
            }

            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
