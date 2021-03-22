using AutiAssist_Mobile.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AutiAssist_Mobile.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string email;
        private string password;

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
            RegisterCommand = new Command(OnRegisterClicked);
        }
        
        public string Email
        {
            get => email;
            set => SetProperty(ref email, value);
        }

        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }
        public Command LoginCommand { get; }

        public Command RegisterCommand { get; }

        
        private async void OnLoginClicked(object obj)
        {
            if(IsBusy)
            {
                return;
            }

            try
            {
                IsBusy = true;

                await Task.Delay(2000);
                await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
            }
            catch(Exception ex)
            {
                Debug.WriteLine($"Authentication error: {ex.Message}");
                await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async void OnRegisterClicked(object obj)
        {
            await Shell.Current.GoToAsync($"{nameof(RegisterPage)}");
        }
    }
}
