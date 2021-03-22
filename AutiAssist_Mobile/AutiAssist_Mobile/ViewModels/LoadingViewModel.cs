using AutiAssist_Mobile.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using MvvmHelpers.Commands;

namespace AutiAssist_Mobile.ViewModels
{
    class LoadingViewModel : BaseViewModel
    {
        public LoadingViewModel()
        {

        }

        public async Task Authenticate()
        {
            string number = "1";

            if (int.Parse(number) == 1)
            {
                await Task.Delay(3000);

                //await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
                await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
            }
            else
            {
                await Task.Delay(2000);

                await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
            }

        }
    }
}
