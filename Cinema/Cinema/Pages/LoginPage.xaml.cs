using Cinema.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cinema.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void ImgBack_Tapped(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private async void ImgLogin_Tapped(object sender, EventArgs e)
        {
            var response = await ApiService.Login(EntEmail.Text, EntPassword.Text);
            Preferences.Set("email", EntEmail.Text);
            Preferences.Set("password", EntPassword.Text);
            if (response)
            {
                Application.Current.MainPage = new NavigationPage(new HomePage());
            }
            else
            {
                await DisplayAlert("Oops", "Quelque chose s'est produit!", "Annuler");
            }
        }
    }
}