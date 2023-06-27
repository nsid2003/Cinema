using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinema.Services;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cinema.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpPage : ContentPage
    {
        public SignUpPage()
        {
            InitializeComponent();
        }

        private async void ImgSignup_Tapped(object sender, EventArgs e)
        {
            var response = await ApiService.RegisterUser(EntName.Text, EntEmail.Text, EntPassword.Text);
            if(response)
            {
                await DisplayAlert("Bonjour", "Votre compte a déjà été crée", "D'accord");
                await Navigation.PushModalAsync(new LoginPage());
            }
            else
            {
                await DisplayAlert("Oops", "Quelque chose s'est produit", "Annuler");
            }
        }

        private async void LblLogin_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync (new LoginPage());
        }
    }
}