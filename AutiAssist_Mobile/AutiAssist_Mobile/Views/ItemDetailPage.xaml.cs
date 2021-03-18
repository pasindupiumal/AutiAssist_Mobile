using AutiAssist_Mobile.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace AutiAssist_Mobile.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}