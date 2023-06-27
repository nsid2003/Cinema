using Cinema.Models;
using Cinema.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cinema.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchMoviesPage : ContentPage
    {
        public SearchMoviesPage()
        {
            InitializeComponent();
        }

        private async void EntSearchMovie_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ( e.NewTextValue == null)
            {
                return;
            }

            var movieslist = await ApiService.FindMovies(e.NewTextValue.ToLower());
            CvMovies.ItemsSource = movieslist;
        }

        private void CvMovies_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var CurrentSelection = e.CurrentSelection.FirstOrDefault() as FindMovie;
            if (CurrentSelection == null) return;
            Navigation.PushModalAsync(new MovieDetailPage(CurrentSelection.Id));
            ((CollectionView)sender).SelectedItem = null;
        }

        private void ImgBack_Tapped(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}