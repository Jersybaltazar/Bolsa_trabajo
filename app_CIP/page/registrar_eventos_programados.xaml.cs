using app_CIP.clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;
using DatePicker = Xamarin.Forms.DatePicker;

namespace app_CIP.page
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class registrar_eventos_programados : ContentPage
    {
        public registrar_eventos_programados()
        {
            InitializeComponent();
        }
        private async void guardar_eventoClicked(object sender, EventArgs e)
        {
            var datePicker = new DatePicker
            {
                Format = "yyyy/MM/dd",
                MaximumDate = new DateTime(2023, 12, 31),
                MinimumDate = new DateTime(2021, 1, 1),
                Date = DateTime.Today
            };

            TimeSpan selectedTime = TimeSpan.FromTicks(timePicker.Time.Ticks);
            string opcionSeleccionada = (string)comboBox.SelectedItem;

            Clase_eventos eventos = new Clase_eventos();

            eventos.nombre_evento = tituloText.Text;
            eventos.ruta_img = linkText.Text;
            eventos.modalidad = opcionSeleccionada;
            eventos.fecha = datePicker.Date;
            eventos.hora = timePicker.Time;
            eventos.descripcion_modalidad = direccionText.Text;



            ApiAccess api = new ApiAccess();
            var respuesta = await api.Ingresar_eventos_programados(eventos);
            await DisplayAlert("alert", respuesta, "ok");

        }
    }
}