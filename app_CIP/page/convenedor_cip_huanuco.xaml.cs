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
    public partial class convenedor_cip_huanuco : ContentPage
    {
        public convenedor_cip_huanuco()
        {
            InitializeComponent();
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Complejo_deportivo());
        }

        private async void ImageButton_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Salon_eventos());
        }

        private async void ImageButton_Clicked_2(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new contacto_secretaria());
        }

        private async void ImageButton_Clicked_3(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Listar_convenios());
        }
    }
}