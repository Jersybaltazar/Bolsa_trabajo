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
    public partial class Listar_convenios : ContentPage
    {
        public Listar_convenios()
        {
            InitializeComponent();
            TraerConvenios();
        }
        private async void TraerConvenios()
        {
            ApiAccess apiAccess = new ApiAccess();
            string result = await apiAccess.listar_convenios();
            // hacer algo con el resultado, como mostrarlo en una vista

            List<Clase_convenios> datos;

            try
            {
                datos = JsonConvert.DeserializeObject<List<Clase_convenios>>(result);

            }
            catch (Exception ex)
            {
                await DisplayAlert("system", ex.Message, "cerrar");

                return;
            }


            conveniosListView.ItemsSource = datos;
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
                DisplayAlert("Error", "El enlace no existe", "Aceptar");
            }
        }

    }
}