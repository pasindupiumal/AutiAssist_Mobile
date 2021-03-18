using AutiAssist_Mobile.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AutiAssist_Mobile.ViewModels
{
    [QueryProperty(nameof(RandomNumber), nameof(RandomNumber))]
    public class LoginViewModel : BaseViewModel
    {
        string randomNumber;

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
            RegisterCommand = new Command(OnRegisterClicked);
        }

        public string RandomNumber
        {
            get => randomNumber;

            set => SetProperty(ref randomNumber, value);
        }
        public Command LoginCommand { get; }

        public Command RegisterCommand { get; }

        
        private async void OnLoginClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
        }

        private async void OnRegisterClicked(object obj)
        {
            await Shell.Current.GoToAsync($"{nameof(RegisterPage)}");
        }
    }
}
