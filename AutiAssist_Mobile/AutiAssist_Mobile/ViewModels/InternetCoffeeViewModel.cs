using AutiAssist_Mobile.Models;
using AutiAssist_Mobile.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using MvvmHelpers;
using MvvmHelpers.Commands;

namespace AutiAssist_Mobile.ViewModels
{
    class InternetCoffeeViewModel : BaseViewModel
    {
        public ObservableRangeCollection<Coffee> Coffee { get; set; }
        public ObservableRangeCollection<Grouping<string, Coffee>> CoffeeGroups { get; set; }
        public AsyncCommand RefreshCommand { get; }
        public AsyncCommand<Coffee> FavouriteCommand { get; }
        public AsyncCommand<object> SelectedCommand { get; }
        public AsyncCommand AddCommand { get; }
        public AsyncCommand<Coffee> RemoveCommand { get; }

        Coffee selectedCoffee;
        bool initialLoad = false;

        public Coffee SelectedCoffee
        {
            get => selectedCoffee;
            set => SetProperty(ref selectedCoffee, value);
        }
        public InternetCoffeeViewModel()
        {
            Title = "Internet Coffees";
            Coffee = new ObservableRangeCollection<Coffee>();
            CoffeeGroups = new ObservableRangeCollection<Grouping<string, Coffee>>();
            RefreshCommand = new AsyncCommand(Refresh);
            FavouriteCommand = new AsyncCommand<Coffee>(Favourite);
            SelectedCommand = new AsyncCommand<object>(Selected);
            RemoveCommand = new AsyncCommand<Coffee>(RemoveCoffee);
            AddCommand = new AsyncCommand(AddCoffee);
        }
        public bool InitialLoad
        {
            get { return initialLoad; }
            set { SetProperty(ref initialLoad, value); OnPropertyChanged(nameof(IsNotInitialLoad)); }
        }

        public bool IsNotInitialLoad => !InitialLoad;

        async Task Refresh()
        {
            IsBusy = true;

            Coffee.Clear();
            var coffees = await CoffeeInternetDataService.GetCoffee();
            Coffee.AddRange(coffees);

            IsBusy = false;
        }

        async Task AddCoffee()
        {
            var name = await App.Current.MainPage.DisplayPromptAsync("Name", "Enter coffee name");
            var roaster = await App.Current.MainPage.DisplayPromptAsync("Roaster", "Enter details");
            await CoffeeInternetDataService.AddCoffee(name, roaster);
            await Refresh();
        }

        async Task RemoveCoffee(Coffee coffee)
        {
            await CoffeeInternetDataService.RemoveCoffee(coffee.Id);
            await Refresh();
        }
        async Task Selected(object args)
        {
            var coffee = args as Coffee;

            if (coffee == null)
            {
                return;
            }

            SelectedCoffee = null;

            await Application.Current.MainPage.DisplayAlert("Coffee Selected", coffee.Name, "OK");
        }

        async Task Favourite(Coffee coffee)
        {
            if (Coffee == null)
            {
                return;
            }

            await Application.Current.MainPage.DisplayAlert("Coffee Favourited", coffee.Name, "OK");
        }

        public async Task GetCoffees()
        {
            if (IsBusy)
            {
                return;
            }

            try
            {

                await Refresh();

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get coffees: {ex.Message}");
                await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
