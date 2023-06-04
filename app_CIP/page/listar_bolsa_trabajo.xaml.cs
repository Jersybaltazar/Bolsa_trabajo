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
    public partial class listar_bolsa_trabajo : ContentPage
    {
        public listar_bolsa_trabajo()
        {
            InitializeComponent();
            TraerBolsaTrabajo();
        }


        private async void TraerBolsaTrabajo()
        {
            ApiAccess apiAccess = new ApiAccess();
            string result = await apiAccess.bolsa_trabajo(1);
            // hacer algo con el resultado, como mostrarlo en una vista

            List<clase_bolsa_trabajo> datos;

            try
            {
                datos = JsonConvert.DeserializeObject<List<clase_bolsa_trabajo>>(result);

            }
            catch (Exception ex)
            {
                await DisplayAlert("system", ex.Message, "cerrar");

                return;
            }


            bolsaTrabajoListView.ItemsSource = datos;
        }
        
    }
}