using AutiAssist_Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AutiAssist_Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoadingPage : ContentPage
    {
        LoadingViewModel loadingViewModel;
        public LoadingPage()
        {
            InitializeComponent();

            BindingContext = loadingViewModel = new LoadingViewModel();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            await loadingViewModel.Authenticate();
        }
    }
}