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
    public partial class Complejo_deportivo : ContentPage
    {
        public Complejo_deportivo()
        {
            InitializeComponent();
            TraerAlquiler();
            NavigationPage.SetHasBackButton(this, false);
            NavigationPage.SetHasNavigationBar(this, true);
        }
        private async void TraerAlquiler()
        {
            ApiAccess apiAccess = new ApiAccess();
            string result = await apiAccess.alquileres("complejo");
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


            alquilerListView.ItemsSource = datos;
        }
    }
}