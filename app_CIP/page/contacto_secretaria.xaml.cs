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
    public partial class contacto_secretaria : ContentPage
    {
        public contacto_secretaria()
        {
            InitializeComponent();
            TraerDatosSecretaria();
        }
        private async void TraerDatosSecretaria()
        {
            ApiAccess apiAccess = new ApiAccess();
            string result = await apiAccess.contacto_secretaria();
            // hacer algo con el resultado, como mostrarlo en una vista

            List<clase_contacto_secretaria> datos;

            try
            {
                datos = JsonConvert.DeserializeObject<List<clase_contacto_secretaria>>(result);

            }
            catch (Exception ex)
            {
                await DisplayAlert("system", ex.Message, "cerrar");

                return;
            }

            listarDatosSecretaria.ItemsSource = datos;
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
 
            try
            {
                // Obtener el número de teléfono de la secretaría
                var celularLabel = (Label)((ImageButton)sender).Parent.FindByName("celular");
                string phoneNumber = celularLabel.Text;

                // Crear el URI de WhatsApp
                string message = "";
                string uri = "whatsapp://send?phone=" + phoneNumber;

                // Abrir la aplicación de WhatsApp o la conversación
                await Launcher.OpenAsync(new Uri(uri));



            }
            catch (Exception ex)
            {
                // Manejar cualquier error que pueda ocurrir
                await DisplayAlert("Error", ex.Message, "OK");
            }
            
            
        }
    }
}