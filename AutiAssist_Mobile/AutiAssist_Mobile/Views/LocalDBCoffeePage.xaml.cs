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
    public partial class LocalDBCoffeePage : ContentPage
    {
        LocalDBCoffeeViewModel localDBCoffeeViewModel;
        public LocalDBCoffeePage()
        {
            InitializeComponent();

            BindingContext = localDBCoffeeViewModel = new LocalDBCoffeeViewModel();
        }

        protected async override void OnAppearing()
        {
            await localDBCoffeeViewModel.GetCoffees();
        }
    }
}
