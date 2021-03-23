using AutiAssist_Mobile.Models;
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
    public partial class CoffeePage : ContentPage
    {
        CoffeeViewModel coffeeViewModel;
        public CoffeePage()
        {
            InitializeComponent();

            BindingContext = coffeeViewModel = new CoffeeViewModel();
        }
        protected async override void OnAppearing()
        {
            await coffeeViewModel.GetCoffees();
        }

    }
}