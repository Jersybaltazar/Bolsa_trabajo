using app_CIP.clases;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace app_CIP.page
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Videos_Interes : ContentPage
    {
        public Videos_Interes()
        {
            InitializeComponent();
            TraerVideo();
        }
        private async void TraerVideo()
        {
            ApiAccess apiAccess = new ApiAccess();
            string result = await apiAccess.Videos();
            // hacer algo con el resultado, como mostrarlo en una vista

            List<Clase_videos_interes> datos;

            try
            {
                datos = JsonConvert.DeserializeObject<List<Clase_videos_interes>>(result);

            }
            catch (Exception ex)
            {
                await DisplayAlert("system", ex.Message, "cerrar");

                return;
            }

            lista_videos.ItemsSource = datos;
        }
        private async void OnVideoTapped(object sender, EventArgs e)
        {
           

            try
            {
                var video = (Clase_videos_interes)((TappedEventArgs)e).Parameter;
                bool answer = await DisplayAlert("Título", "¿Deseas abrir el enlace en un navegador?", "Aceptar", "Cancelar");

                if (answer)
                {
                    await Launcher.OpenAsync(new Uri(video.link));
                }

            }
            catch (Exception ex)
            {
                // Manejar cualquier error que pueda ocurrir
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}