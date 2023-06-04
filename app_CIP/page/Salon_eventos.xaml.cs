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
    public partial class Salon_eventos : ContentPage
    {
        public Salon_eventos()
        {
            InitializeComponent();
            Traeralquileres();
        }

        private async void Traeralquileres()
        {
            ApiAccess apiAccess = new ApiAccess();
            string result = await apiAccess.alquileres("salon eventos");
            // hacer algo con el resultado, como mostrarlo en una vista

            List<clase_alquiler> datos;

            try
            {
                datos = JsonConvert.DeserializeObject<List<clase_alquiler>>(result);

            }
            catch (Exception ex)
            {
                await DisplayAlert("system", ex.Message, "cerrar");

                return;
            }

            lista_alquileres.ItemsSource = datos;
        }


        private async void OnWhatsAppButtonClicked(object sender, EventArgs e)
        {
            try
            {
                // Número de teléfono y mensaje para enviar
                string phoneNumber = "+51939925891";
                string message = "Hola, ¿cómo estás?";

                // Crear el URI de WhatsApp
                string uri = "whatsapp://send?phone=" + phoneNumber + "&text=" + message;

                // Abrir la aplicación de WhatsApp o la conversación
                await Launcher.OpenAsync(new Uri(uri));
            }
            catch (Exception ex)
            {
                // Manejar cualquier error que pueda ocurrir
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }
        private async void OnCIPButtonClicked(object sender, EventArgs e)
        {
            try
            {
                // Enlace que se abrirá al hacer clic en el botón
                //string link = ruta.Text;

                // Abrir el enlace en el navegador del dispositivo
                //await Launcher.OpenAsync(new Uri(link));
            }
            catch (Exception ex)
            {
                // Manejar cualquier error que pueda ocurrir
                await DisplayAlert("Error", ex.Message, "OK");
            }

        }
    }
}