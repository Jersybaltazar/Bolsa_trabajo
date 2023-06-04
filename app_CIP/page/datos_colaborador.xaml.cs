using app_CIP.clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace app_CIP.page
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class datos_colaborador : ContentPage
    {
        public datos_colaborador(Clase_colaboradores colaborador)
        {
            InitializeComponent();
            foto.Source = colaborador.Imagen;
            name.Text = colaborador.nombre_usuario;
            apellido.Text = colaborador.apellido;
            experiencia.Text = colaborador.experiencia;
            correo.Text = colaborador.correo;
            telefono.Text = colaborador.telefono;
            cip.Text = colaborador.registro_cip;
            grado.Text = colaborador.grado_academico;

            nombre_especialidad.Text = string.Join(Environment.NewLine + " - ", colaborador.nombre_especialidad);

            empleo.Text = string.Join(Environment.NewLine + " - ", colaborador.empleo);

        }
        private async void telefonos_Clicked_1(object sender, EventArgs e)
        {
            // Obtener el número de teléfono
            string numeroTelefono = telefono.Text;

            // Reemplazar los espacios y otros caracteres especiales
            numeroTelefono = numeroTelefono.Replace(" ", "").Replace("+", "").Replace("-", "");

            // Abrir WhatsApp con el número de teléfono en formato internacional
            await Launcher.OpenAsync($"https://wa.me/{numeroTelefono}");

        }
    }
}