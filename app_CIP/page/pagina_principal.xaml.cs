using app_CIP.clases;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace app_CIP.page
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class pagina_principal : ContentPage
    {

        private List<Clase_ListarU> datosUsuario;
        Image image = new Image();

        public pagina_principal(List<Clase_ListarU> datos)
        {
            InitializeComponent();
            //NavigationPage.SetHasBackButton(this, false);
            //NavigationPage.SetHasNavigationBar(this, true);

            listarUsuarioCumpleMes();
            datosUsuario = datos;
            foreach (var login in datos)
            {
                string nombreUsuario = login.nombre_usuario;
                nombre.Text = login.nombre_usuario;
                apellido.Text = login.apellidos;

                byte[] imageBytes = Convert.FromBase64String(login.foto);

                // Crear un ImageSource a partir de los bytes de la imagen
                ImageSource imageSource = ImageSource.FromStream(() => new MemoryStream(imageBytes));

                // Asignar el ImageSource al objeto colaborador
                login.Imagen = imageSource;
                ImagenPerfil.Source = login.Imagen;

                DateTime fechaActual = DateTime.Now;
                DateTime fechaUsuario = login.f_nacimiento;

                if (fechaUsuario.Day == fechaActual.Day && fechaUsuario.Month == fechaActual.Month)
                {
                    celebracion.Text = "Feliz Cumpleaños";
                }
                else if (fechaActual.Month == 5 && fechaActual.DayOfWeek == DayOfWeek.Sunday && fechaActual.Day > 7 && fechaActual.Day <= 14)
                {
                    if (login.sexo == "Femenino" && login.paternidad == "si")
                    {
                        celebracion.Text = "Feliz Día de la Madre";
                    }
                    else
                    {
                        celebracion.Text = "¡Bienvenido!";
                    }
                }
                else if (fechaActual.Month == 6 && fechaActual.DayOfWeek == DayOfWeek.Sunday && fechaActual.Day > 14 && fechaActual.Day <= 21)
                {
                    if (login.sexo == "Masculino" && login.paternidad == "si")
                    {
                        celebracion.Text = "Feliz Día del Padre";
                    }
                    else
                    {
                        celebracion.Text = "¡Bienvenido!";
                    }
                }
                else
                {
                    celebracion.Text = "¡Bienvenido!";
                }

            }
        }

        private async void listarUsuarioCumpleMes()
        {
            ApiAccess apiAccess = new ApiAccess();
            string result = await apiAccess.listarUcumple();

            List<ListarCumpleañosMes> datos;

            try
            {
                datos = JsonConvert.DeserializeObject<List<ListarCumpleañosMes>>(result);

                // Descodificar las imágenes en base64
                foreach (var day in datos)
                {
                    // Obtener los bytes de la imagen decodificando el string base64
                    byte[] imageBytes = Convert.FromBase64String(day.foto);

                    // Crear un ImageSource a partir de los bytes de la imagen
                    ImageSource imageSource = ImageSource.FromStream(() => new MemoryStream(imageBytes));

                    // Asignar el ImageSource al objeto colaborador
                    day.Imagen = imageSource;
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("system", ex.Message, "cerrar");
                return;
            }

            MenuUserMes.ItemsSource = datos;

        }



    private void CerrarSesion_Clicked(object sender, EventArgs e)
        {
            // Restablecer el estado de inicio de sesión
            Application.Current.Properties["IsLoggedIn"] = false;
            Application.Current.SavePropertiesAsync();

            // Navegar de regreso a la página de inicio de sesión
            Navigation.PopToRootAsync();
        }
    }
}