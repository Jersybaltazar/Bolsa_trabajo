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
    public partial class ingresar_video : ContentPage
    {
        public ingresar_video()
        {
            InitializeComponent();
        }
        private async void videoguardarClicked(object sender, EventArgs e)
        {
            Clase_videos_interes videos = new Clase_videos_interes();

            videos.nombre = tituloText.Text;
            videos.link = linkText.Text;


            ApiAccess api = new ApiAccess();
            var respuesta = await api.Ingresar_video(videos);
            await DisplayAlert("alert", respuesta, "ok");

        }
    }
}