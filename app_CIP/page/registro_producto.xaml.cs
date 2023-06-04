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
    public partial class registro_producto : ContentPage
    {
        public registro_producto()
        {
            InitializeComponent();
        }
        private async void button_guardar_Clicked(object sender, EventArgs e)
        {

            int valor = miCheckBox.IsChecked ? 1 : 0;
            int radioButtonValue = radioButtonSi.IsChecked ? 1 : 0;
            int radiodelivery = Si_delivery.IsChecked ? 1 : 0;


            Clase_producto productos = new Clase_producto();

            productos.nombre = nombre_producto.Text;
            productos.precio = precio.Text;
            productos.estado = valor;
            productos.descuento_estado = radioButtonValue;
            productos.delivery_estado = radiodelivery;
            productos.descuento = porcentaje.Text;
            productos.descripcionC = descripcion_corta.Text;
            productos.descripcionL = descripcion_larga.Text;
            productos.imagen = link.Text;
            productos.id_empresa = UserData.empresaId;



            ApiAccess api = new ApiAccess();
            var respuesta = await api.crear_producto(productos);
            await DisplayAlert("alert", respuesta, "ok");

        }
    }
}