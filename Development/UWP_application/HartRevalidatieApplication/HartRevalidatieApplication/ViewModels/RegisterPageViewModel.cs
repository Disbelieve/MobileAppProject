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

        public RegisterUser newUser { get; set; }

        public ObservableCollection<Consultant> consultants { get; set; } = new ObservableCollection<Consultant>();

        public RegisterPageViewModel()
        {
            try
            {
                LoadData();
            }
            catch { }
        }
        
        public void SetFirstRegisterPageUserData(string firstName, string lastName, string birthDate, int gender, string weight, string length)
        {
            newUser = new RegisterUser();

            newUser.firstname = firstName;
            newUser.lastname = lastName;
            newUser.dateOfBirth = birthDate;
            newUser.gender = gender;
            newUser.weight = weight;
            newUser.length = length;
        }

        public void SetSecondRegisterPageUserData(string email, string password, string repeatPassword)
        {
            newUser.emailAddress = email;
            newUser.password = password;
        }

        public void SetThirdRegisterPageUserData(string consultantId)
        {
            newUser.consultantId = consultantId;
        }

        private async Task<int> GetConsultants()
        {
            consultants = await ApiData.SingleInstance.GetConsultants();
            OnPropertyChanged(nameof(consultants));

            return 1;
        }

        public async Task<bool> Register()
        {
            try
            {
                string parameters = JsonConvert.SerializeObject(newUser);
                var response = await APIconnection.ConnectToAPI(HttpMethod.Post, "Users/register/", parameters);


                if (response.StatusCode.ToString() == "OK")
                {
                    Settings.SetUserDataUpdateTime(newUser.emailAddress);
                    return true;
                }
                else
                    return false;
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

        public async void LoadData()
        {
            try
            {
                await GetConsultants();
            }
            catch { }
        }            
    }
}
