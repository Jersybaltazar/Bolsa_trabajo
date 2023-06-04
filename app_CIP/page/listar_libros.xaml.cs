using app_CIP.clases;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace app_CIP.page
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class listar_libros : ContentPage
    {
        public listar_libros()
        {
            InitializeComponent();
            traer_documentoscompartidos();
        }
        private async void traer_documentoscompartidos()
        {
            ApiAccess apiAccess = new ApiAccess();
            string result = await apiAccess.listarlibro();

            List<Clase_BuscarLibroG> datos;

            try
            {
                datos = JsonConvert.DeserializeObject<List<Clase_BuscarLibroG>>(result);

            }
            catch (Exception ex)
            {
                await DisplayAlert("system", ex.Message, "cerrar");

                return;
            }
            listarlibros.ItemsSource = datos;
        }

        private async void listarlibros_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var documento_compartido = e.SelectedItem as Clase_BuscarLibroG;
            await Navigation.PushAsync(new datos_libro(documento_compartido));
        }

        private async void buscarold_TextChanged(object sender, TextChangedEventArgs e)
        {
            ApiAccess apiAccess = new ApiAccess();
            string nombre = buscarold.Text;
            string result = await apiAccess.BuscarLibroGeneral(nombre);

            List<Clase_BuscarLibroG> datos;

            try
            {
                datos = JsonConvert.DeserializeObject<List<Clase_BuscarLibroG>>(result);

            }
            catch (Exception ex)
            {
                await DisplayAlert("system", ex.Message, "cerrar");

                return;
            }
            listarlibros.ItemsSource = datos;
        }
    }
}