using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using YoutubeExplode;
using YoutubeExplode.Videos;
using YoutubeExplode.Videos.Streams;

namespace Cinema.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VideoPlayerPage : ContentPage
    {
        public VideoPlayerPage(string videoUrl)
        {
            InitializeComponent();
        }

        private async void PlayVideo(String VideoUrl)
        {
            var youtube = new YoutubeClient();

            var streamManifest = await youtube.Videos.Streams.GetManifestAsync(VideoUrl);
            var streamInfo = streamManifest.GetMuxedStreams().GetWithHighestVideoQuality();


            if (streamInfo != null) 
            {
                var stream = await youtube.Videos.Streams.GetAsync(streamInfo);
                AILoader.IsVisible = false;
                AILoader.IsRunning = false;

                MediaElementVideo.Source = streamInfo.Url;
            }
        }

        private void ImgBack_Tapped(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}