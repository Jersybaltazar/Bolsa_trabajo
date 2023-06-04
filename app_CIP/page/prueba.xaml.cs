using app_CIP.clases;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace app_CIP.page
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class prueba : ContentPage
    {
        public prueba()
        {
            InitializeComponent();
            traerCumple();
            
        }
        private async void traerCumple()
        {

            ApiAccess apiAccess = new ApiAccess();
            string result = await apiAccess.lista_cumple();

            List<clase_cumple> datos;

            try
            {
                datos = JsonConvert.DeserializeObject<List<clase_cumple>>(result);

                // Descodificar las imágenes en base64
                foreach (var colaborador in datos)
                {
                    // Obtener los bytes de la imagen decodificando el string base64
                    byte[] imageBytes = Convert.FromBase64String(colaborador.foto);

                    // Crear un ImageSource a partir de los bytes de la imagen
                    ImageSource imageSource = ImageSource.FromStream(() => new MemoryStream(imageBytes));

                    // Asignar el ImageSource al objeto colaborador
                    colaborador.Imagen = imageSource;
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("system", ex.Message, "cerrar");
                return;
            }

            cumpleListView.ItemsSource = datos;


        }
    }
}