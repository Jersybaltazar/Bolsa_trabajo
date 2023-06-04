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
    public partial class registrar_bolsa_trabajo : ContentPage
    {
        public registrar_bolsa_trabajo()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            int estado = 1;
           

            clase_bolsa_trabajo bolsa_Trabajo = new clase_bolsa_trabajo();

            bolsa_Trabajo.contacto2 = contac2.Text;
            bolsa_Trabajo.contacto = contacto1.Text;
            bolsa_Trabajo.id_usuario = id_use.Text;
            bolsa_Trabajo.descripcion = descripcion.Text;
            bolsa_Trabajo.estado = estado;
            

            ApiAccess api = new ApiAccess();
            var respuesta = await api.crear_bolsa_trabajo(bolsa_Trabajo);
            await DisplayAlert("alert", respuesta, "ok");
        }
    }
}