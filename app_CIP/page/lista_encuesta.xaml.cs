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
    public partial class lista_encuesta : ContentPage
    {
        public lista_encuesta()
        {
            InitializeComponent();
            TraerEncuesta();
        }
        private async void TraerEncuesta()
        {
            ApiAccess apiAccess = new ApiAccess();
            string result = await apiAccess.listar_encuestas(1);
            // hacer algo con el resultado, como mostrarlo en una vista

            List<clase_encuesta> datos;

            try
            {
                datos = JsonConvert.DeserializeObject<List<clase_encuesta>>(result);

            }
            catch (Exception ex)
            {
                await DisplayAlert("system", ex.Message, "cerrar");

                return;
            }


            encuestaListView.ItemsSource = datos;
        }
        private void OnLabelTapped(object sender, EventArgs e)
        {
            var label = sender as Label;
            var url = label.Text;

            if (Uri.IsWellFormedUriString(url, UriKind.Absolute))
            {
                Device.OpenUri(new Uri(url));
            }
            else
            {
                DisplayAlert("Error", "El enlace no es válido", "Aceptar");
            }
        }
    }
}