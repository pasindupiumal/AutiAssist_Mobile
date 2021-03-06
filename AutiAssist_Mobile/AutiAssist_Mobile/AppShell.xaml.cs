using AutiAssist_Mobile.ViewModels;
using AutiAssist_Mobile.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace AutiAssist_Mobile
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            RegisterRoutes();
            InitializeDefaultViews();
        }

        private void RegisterRoutes()
        {
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));
        }

        private void InitializeDefaultViews()
        {
            BrowseFlyout.CurrentItem = BrowseTab;
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
