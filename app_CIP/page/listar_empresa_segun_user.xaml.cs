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
    public partial class listar_empresa_segun_user : ContentPage
    {
        public listar_empresa_segun_user()
        {
            InitializeComponent();
            traerEmpren();
        }
        private async void traerEmpren()
        {
            int id_user = UserData.UserId;
            ApiAccess apiAccess = new ApiAccess();
            string result = await apiAccess.Empren(id_user);
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

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new registro_tienda());
        }
    }
}