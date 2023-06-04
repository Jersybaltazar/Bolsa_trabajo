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
    public partial class registrar_libro : ContentPage
    {
        public registrar_libro()
        {
            InitializeComponent();
            cargarTipo();
        }
        private async void button_registrar_Clicked(object sender, EventArgs e)
        {
            Clase_libro libro = new Clase_libro();

            int id_userObtenido = UserData.UserId;


            libro.nombre = nombre.Text;
            libro.id_tipoDocumento = 1;
            libro.id_categoria = categoria.Text;
            libro.otros = otros.Text;
            libro.img_ruta = img_ruta.Text;
            libro.descripcion = descripcion.Text;
            libro.id_usuario = id_userObtenido;

            ApiAccess api = new ApiAccess();
            var respuesta = await api.crear_libro(libro);
            await DisplayAlert("alert", respuesta, "ok");

        }

        private async void cargarTipo()
        {
            ApiAccess apiAccess = new ApiAccess();
            string result = await apiAccess.cargarcomboTipo();

            List<Clase_Tipo> datos;

            try
            {
                datos = JsonConvert.DeserializeObject<List<Clase_Tipo>>(result);

            }
            catch (Exception ex)
            {
                await DisplayAlert("system", ex.Message, "cerrar");

                return;
            }
            tipo_documento.ItemsSource = datos;

        }



        private void tipo_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            var selectedOption = (Clase_Tipo)tipo_documento.SelectedItem;
            var selectedOptionName = selectedOption.tipo_documento;
            var selectedOptionId = selectedOption.id_tipoDocumento;

        }
    }
}