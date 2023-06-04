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
    public partial class registro_convenios : ContentPage
    {
        public registro_convenios()
        {
            InitializeComponent();
        }
        private async void button_registrar_Clicked(object sender, EventArgs e)
        {
            Clase_convenios convenios = new Clase_convenios();

            convenios.entidad = entidad.Text;
            convenios.direccion = direccion.Text;
            convenios.pagina = pagina.Text;
            convenios.firma = firma.Text;
            convenios.contacto = contacto.Text;

            ApiAccess api = new ApiAccess();
            var respuesta = await api.crear_convenio(convenios);
            await DisplayAlert("alert", respuesta, "ok");

        }
    }
}