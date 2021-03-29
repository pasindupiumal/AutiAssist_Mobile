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
    public partial class InternetCoffeePage : ContentPage
    {
        InternetCoffeeViewModel internetCoffeeViewModel;
        public InternetCoffeePage()
        {
            InitializeComponent();

            BindingContext = internetCoffeeViewModel = new InternetCoffeeViewModel();
        }
        protected async override void OnAppearing()
        {
            await internetCoffeeViewModel.GetCoffees();
        }
    }
}