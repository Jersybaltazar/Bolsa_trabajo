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
    public partial class pagina_inicio : ContentPage
    {
        public pagina_inicio()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new login());
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new registro_usuario());
        }

        private async void Button_Clicked_2(object sender, EventArgs e)
        {
            var action = await DisplayActionSheet("Seleccionar imagen", "Cancelar", null, "Galería", "Cámara");
        }
    }
}