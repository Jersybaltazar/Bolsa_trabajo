using app_CIP.clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace app_CIP.page
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class producto_detalle : ContentPage
    {
        public producto_detalle(Clase_producto producto)
        {
            InitializeComponent();
            //imagen.Source = producto.imagen;
            nombre.Text = producto.nombre;
            precio.Text = producto.precio;
            nombre_producto.Text = producto.nombre;
            //descuento.Text = producto.descuento;
            //descripcionC.Text = producto.descripcionC;
            int id_empresa = producto.id_empresa;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {

            DisplayAlert("Proxima actualizacion", "para la proxima version", "cancelar");

            
        }
    }
}