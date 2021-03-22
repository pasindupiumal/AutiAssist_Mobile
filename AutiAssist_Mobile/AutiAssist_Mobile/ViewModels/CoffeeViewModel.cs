using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutiAssist_Mobile.Models;
using MvvmHelpers;
using MvvmHelpers.Commands;
using Xamarin.Forms;

namespace AutiAssist_Mobile.ViewModels
{
    public class CoffeeViewModel : BaseViewModel
    {
        public ObservableRangeCollection<Coffee> Coffee { get; set; }
        public ObservableRangeCollection<Grouping<string, Coffee>> CoffeeGroups { get; set; }
        public AsyncCommand RefreshCommand { get; }
        public AsyncCommand<Coffee> FavouriteCommand { get; }
        public AsyncCommand<object> SelectedCommand { get; }

        Coffee selectedCoffee;

        public Coffee SelectedCoffee
        {
            get => selectedCoffee;
            set => SetProperty(ref selectedCoffee, value);
        }

        public CoffeeViewModel()
        {
            Title = "Coffees ListView";

            Coffee = new ObservableRangeCollection<Coffee>();
            CoffeeGroups = new ObservableRangeCollection<Grouping<string, Coffee>>();
            RefreshCommand = new AsyncCommand(Refresh);
            FavouriteCommand = new AsyncCommand<Coffee>(Favourite);
            SelectedCommand = new AsyncCommand<object>(Selected);

            var image = "https://www.yesplz.coffee/app/uploads/2020/11/emptybag-min.png";

            Coffee.Add(new Coffee { Roaster = "Yes Plz", Name = "Sip of Sunshine", Image = image });
            Coffee.Add(new Coffee { Roaster = "Yes Plz", Name = "Potent Potable", Image = image });
            Coffee.Add(new Coffee { Roaster = "Blue Bottle", Name = "Kenya Kiambu Handege", Image = image });
            Coffee.Add(new Coffee { Roaster = "Blue Bottle", Name = "Kenya Kiambu Handege", Image = image });
            Coffee.Add(new Coffee { Roaster = "Blue Bottle", Name = "Kenya Kiambu Handege", Image = image });
            Coffee.Add(new Coffee { Roaster = "Blue Bottle", Name = "Kenya Kiambu Handege", Image = image });
            Coffee.Add(new Coffee { Roaster = "Blue Bottle", Name = "Kenya Kiambu Handege", Image = image });
            Coffee.Add(new Coffee { Roaster = "Blue Bottle", Name = "Kenya Kiambu Handege", Image = image });
            Coffee.Add(new Coffee { Roaster = "Blue Bottle", Name = "Kenya Kiambu Handege", Image = image });
            Coffee.Add(new Coffee { Roaster = "Blue Bottle", Name = "Kenya Kiambu Handege", Image = image });
            Coffee.Add(new Coffee { Roaster = "Blue Bottle", Name = "Kenya Kiambu Handege", Image = image });
            Coffee.Add(new Coffee { Roaster = "Blue Bottle", Name = "Kenya Kiambu Handege", Image = image });
            Coffee.Add(new Coffee { Roaster = "Blue Bottle", Name = "Kenya Kiambu Handege", Image = image });
            Coffee.Add(new Coffee { Roaster = "Blue Bottle", Name = "Kenya Kiambu Handege", Image = image });
            Coffee.Add(new Coffee { Roaster = "Blue Bottle", Name = "Kenya Kiambu Handege", Image = image });
            Coffee.Add(new Coffee { Roaster = "Blue Bottle", Name = "Kenya Kiambu Handege", Image = image });
            Coffee.Add(new Coffee { Roaster = "Blue Bottle", Name = "Kenya Kiambu Handege", Image = image });

            CoffeeGroups.Add(new Grouping<string, Coffee>("Blue Bottle", new[] { Coffee[2] }));
            CoffeeGroups.Add(new Grouping<string, Coffee>("Yes Plz", new[] { Coffee[5] }));
        }


        async Task Refresh()
        {
            IsBusy = true;

            await Task.Delay(2000);

            IsBusy = false;
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
            if(Coffee == null)
            {
                return;
            }

            await Application.Current.MainPage.DisplayAlert("Coffee Favourited", coffee.Name, "OK");
        }

    }
}
