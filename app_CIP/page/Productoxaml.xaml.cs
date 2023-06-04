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
    public partial class Productoxaml : ContentPage
    {
        public int id_empresa = 0;
        public Productoxaml(Clase_empren infor)
        {
            InitializeComponent();
            id_empresa = UserData.empresaId;
            traerProduu();
        }
        private async void traerProduu()
        {
            ApiAccess apiAccess = new ApiAccess();
            string result = await apiAccess.Produc2(id_empresa);
            // hacer algo con el resultado, como mostrarlo en una vista

            List<Clase_Prod> datos;

            try
            {
                datos = JsonConvert.DeserializeObject<List<Clase_Prod>>(result);

            }
            catch (Exception ex)
            {
                await DisplayAlert("system", ex.Message, "cerrar");

                return;
            }

            lista_productoo.ItemsSource = datos;
        }

        private void lista_productoo_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new registro_producto());
        }
    }
}