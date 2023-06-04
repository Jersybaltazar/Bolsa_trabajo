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
    public partial class listar_colaboradores_registrados : ContentPage
    {
        public listar_colaboradores_registrados()
        {
            InitializeComponent();
            traerColaboracionesgenerales();
        }
        private async void traerColaboracionesgenerales()
        {
            ApiAccess apiAccess = new ApiAccess();
            string result = await apiAccess.ListarColaboradores();

            List<Clase_colaboradores> datos;

            try
            {
                datos = JsonConvert.DeserializeObject<List<Clase_colaboradores>>(result);

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

            listaColaboracion1.ItemsSource = datos;


        }

        //obtienes el id y lo mandas a la sigueinte vista con los datos obtenidos
        private async void listaColaboracion1_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var colaborador = e.SelectedItem as Clase_colaboradores;
            await Navigation.PushAsync(new datos_colaborador(colaborador));
        }

        private async void buscarold_TextChanged(object sender, TextChangedEventArgs e)
        {
            ApiAccess apiAccess = new ApiAccess();
            string nombre = buscarold.Text;
            string result = await apiAccess.colaboradores(nombre);

            List<Clase_colaboradores> datos;

            try
            {
                datos = JsonConvert.DeserializeObject<List<Clase_colaboradores>>(result);

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

            listaColaboracion1.ItemsSource = datos;
        }
    }
}