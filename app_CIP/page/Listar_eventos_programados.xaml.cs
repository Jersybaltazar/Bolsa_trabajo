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
    public partial class Listar_eventos_programados : ContentPage
    {
        public Listar_eventos_programados()
        {
            InitializeComponent();
            TraerEventos_programados();
        }
        private async void TraerEventos_programados()
        {
            ApiAccess apiAccess = new ApiAccess();
            string result = await apiAccess.eventos_programados();
            // hacer algo con el resultado, como mostrarlo en una vista

            List<Clase_eventos> datos;

            try
            {
                datos = JsonConvert.DeserializeObject<List<Clase_eventos>>(result);

            }
            catch (Exception ex)
            {
                await DisplayAlert("system", ex.Message, "cerrar");

                return;
            }


            eventosProgramadosListView.ItemsSource = datos;
        }

        private async void DescripcionLabel_Tapped(object sender, EventArgs e)
        {
            // Obtener el valor del Text del Label
            var direccion = (sender as Label)?.Text;

            if (!string.IsNullOrEmpty(direccion))
            {
                if (direccion.StartsWith("http"))
                {
                    // Navegar a una página web en un navegador integrado
                    await Browser.OpenAsync(direccion, BrowserLaunchMode.SystemPreferred);
                }
                else
                {
                    // Abrir la dirección en una aplicación externa
                    var uri = new Uri(direccion);
                    Device.OpenUri(uri);
                }
            }
        }

    }
}