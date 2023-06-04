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
    public partial class registro_tienda : ContentPage
    {
        public registro_tienda()
        {
            InitializeComponent();
        }
        private async void registrar_tienda_Clicked(object sender, EventArgs e)
        {
            CLase_reigstroTienda tienda = new CLase_reigstroTienda();
            tienda.ruc = ruc.Text;
            tienda.ruta_imagen = foto_empresa.Text;
            tienda.razon_social = razon_social.Text;
            tienda.direcion = direccion.Text;
            tienda.ubicacion = ubicacion.Text;
            tienda.catalogo = catalogo.Text;
            tienda.celular = celular.Text;
            tienda.telefono = telefono.Text;
            tienda.pagina_web = pagina_web.Text;
            tienda.face = facebook.Text;
            tienda.watsap = whatsap.Text;
            tienda.instagram = instagram.Text;
            tienda.otros = otrasR.Text;
            tienda.id_usuario = UserData.UserId;

            ApiAccess api = new ApiAccess();
            var respuesta = await api.crear_tienda(tienda);
            await DisplayAlert("alert", respuesta, "ok");
            limiarceladas();

        }

        private void limiarceladas()
        {
            ruc.Text = "";
            foto_empresa.Text = "";
            razon_social.Text = "";
            direccion.Text = "";
            ubicacion.Text = "";
            catalogo.Text = "";
            celular.Text = "";
            telefono.Text = "";
            pagina_web.Text = "";
            facebook.Text = "";
            whatsap.Text = "";
            instagram.Text = "";
            otrasR.Text = "";
        }

    }
}