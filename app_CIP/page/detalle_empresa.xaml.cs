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
    public partial class detalle_empresa : ContentPage
    {
        public detalle_empresa(Clase_empren empresa)
        {
            InitializeComponent();
            int id_empresa = empresa.id_empresa;
            traerdatosempresa(id_empresa);

            
        }

        public async void traerdatosempresa(int id_emp)
        {
            ApiAccess apiAccess = new ApiAccess();
            string result = await apiAccess.detalle_empresa(id_emp);
            // hacer algo con el resultado, como mostrarlo en una vista

            List<CLase_reigstroTienda> datos;

            try
            {
                datos = JsonConvert.DeserializeObject<List<CLase_reigstroTienda>>(result);

            }
            catch (Exception ex)
            {
                await DisplayAlert("system", ex.Message, "cerrar");

                return;
            }

            lista_info.ItemsSource = datos;
        }
    }
    
}