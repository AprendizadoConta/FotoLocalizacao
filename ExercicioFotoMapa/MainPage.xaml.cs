using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace ExercicioFotoMapa
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void btnTirarFoto_Clicked(object sender, EventArgs e)
        {
            var result = await MediaPicker.CapturePhotoAsync();
            if (result != null)
            {
                var stream = await result.OpenReadAsync();
                FotoTirada.Source = ImageSource.FromStream(() => stream);
                
            }
            
        }
        public async Task MostrarMapa()
        {
            var location = await Geolocation.GetLocationAsync(new GeolocationRequest()
            { DesiredAccuracy = GeolocationAccuracy.Best });
            var locationinfo = new Location(location.Latitude, location.Longitude);
            var options = new MapLaunchOptions { Name = "Meu Local" };
            await Map.OpenAsync(locationinfo, options);
        }

        async void btnMostrarMapa_Clicked(object sender, EventArgs e)
        {
            if (FotoTirada.Source== null)
            {
                
                await DisplayAlert("Tire uma foto primeiro","topzeira" ,"OK");
            }
            else
            {
                await MostrarMapa();
            }
            
        }
    }
}
