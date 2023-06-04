using app_CIP.clases;
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
    public partial class Registrar_sugerencia : ContentPage
    {
        public Registrar_sugerencia()
        {
            InitializeComponent();
        }
        private async void button_registrar_Clicked(object sender, EventArgs e)
        {
            int userId = UserData.UserId;

            int valor = miCheckBox.IsChecked ? 1 : 0;

            clase_sugerencia sugerencia = new clase_sugerencia();

            sugerencia.texto_sugerencia = suger.Text;
            sugerencia.contactame = valor;
            sugerencia.id_usuario = userId;

            ApiAccess api = new ApiAccess();
            var respuesta = await api.ingresar_sugerencia(sugerencia);
            await DisplayAlert("alert", respuesta, "ok");

        }
    }
}