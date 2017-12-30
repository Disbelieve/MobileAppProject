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

namespace HartRevalidatieApplication.ViewModels
{
    public sealed class RegisterPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaiseProperty(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        public static RegisterPageViewModel SingleInstance { get; } = new RegisterPageViewModel();

        private RegisterUser newUser;

        public ObservableCollection<Consultant> consultants { get; set; }

        public RegisterPageViewModel()
        {
            LoadData();
        }

        public async void LoadData()
        {
            await GetConsultants();
        }

        public void SetFirstRegisterPageUserData(string name, string birthDate, string consultantId, int gender)
        {
            newUser = new RegisterUser();

            newUser.firstname = name;
            newUser.lastname = name;
            newUser.dateOfBirth = birthDate;
            newUser.consultantId = consultantId;
            newUser.gender = gender;
        }

        public void SetSecondRegisterPageUserData(string email, string password, string repeatPassword)
        {
            newUser.emailAddress = email;
            newUser.password = password;
        }

        private async Task<int> GetConsultants()
        {
            var response = await APIconnection.ConnectToAPI(HttpMethod.Get, "consultants");
            consultants = JsonConvert.DeserializeObject<ObservableCollection<Consultant>>(await response.Content.ReadAsStringAsync());
            OnPropertyChanged(nameof(consultants));

            return 1;
        }

        public async Task<bool> Register()
        {
            try
            {
                string parameters = JsonConvert.SerializeObject(newUser);
                var response = await APIconnection.ConnectToAPI(HttpMethod.Post, "Users/register/", parameters);
                var str = await response.Content.ReadAsStringAsync();

                return true;
            }

            catch (Exception ex)
            {
                return false;
            }
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
