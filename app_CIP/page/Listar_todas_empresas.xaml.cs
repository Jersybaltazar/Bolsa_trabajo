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
    public partial class Listar_todas_empresas : ContentPage
    {
        public Listar_todas_empresas()
        {
            InitializeComponent();
            traerEmpren();
        }
        private async void traerEmpren()
        {
            ApiAccess apiAccess = new ApiAccess();
            string result = await apiAccess.Listar_todas_Empresas();
            // hacer algo con el resultado, como mostrarlo en una vista

            List<Clase_empren> datos;

            try
            {
                datos = JsonConvert.DeserializeObject<List<Clase_empren>>(result);

            }
            catch (Exception ex)
            {
                await DisplayAlert("system", ex.Message, "cerrar");

                return;
            }

            lista_empren.ItemsSource = datos;
        }

        private async void lista_empren_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var empresas = e.SelectedItem as Clase_empren;
            await Navigation.PushAsync(new detalle_empresa(empresas));
        }
    }
}