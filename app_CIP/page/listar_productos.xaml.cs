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
    public partial class listar_productos : ContentPage
    {
        public listar_productos()
        {
            InitializeComponent();
            Traerproducto();
        }
        private async void Traerproducto()
        {
            ApiAccess apiAccess = new ApiAccess();
            string result = await apiAccess.Producto();
            // hacer algo con el resultado, como mostrarlo en una vista

            List<Clase_producto> datos;

            try
            {
                datos = JsonConvert.DeserializeObject<List<Clase_producto>>(result);

            }
            catch (Exception ex)
            {
                await DisplayAlert("system", ex.Message, "cerrar");

                return;
            }

            lista_producto.ItemsSource = datos;
        }

        private async void buscarproducto_TextChanged(object sender, TextChangedEventArgs e)
        {
            ApiAccess apiAccess = new ApiAccess();
            string result = await apiAccess.Producto_buscar(buscarproducto.Text);
            // hacer algo con el resultado, como mostrarlo en una vista

            List<Clase_producto> datos;

            try
            {
                datos = JsonConvert.DeserializeObject<List<Clase_producto>>(result);

            }
            catch (Exception ex)
            {
                await DisplayAlert("system", ex.Message, "cerrar");

                return;
            }

            lista_producto.ItemsSource = datos;
        }

        private async void lista_producto_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var detalle_producto = e.SelectedItem as Clase_producto;
            await Navigation.PushAsync(new producto_detalle(detalle_producto));
        }
    }
}