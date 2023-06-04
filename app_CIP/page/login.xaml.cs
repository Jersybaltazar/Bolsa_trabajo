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
    public partial class login : ContentPage
    {
        public login()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (Application.Current.Properties.ContainsKey("IsLoggedIn") && (bool)Application.Current.Properties["IsLoggedIn"])
            {
                // Usuario ya ha iniciado sesión, navega a la página del menú
                //Navigation.PushAsync(new pagina_principal());
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

            int dni = int.Parse(usuario.Text);
            string pass = password.Text;

            consulta(dni, pass);

            // Si las credenciales son válidas
            //Application.Current.Properties["IsLoggedIn"] = true;
            //Application.Current.SavePropertiesAsync();
            //Navigation.PushAsync(new pagina_principal());

        }

        private async void consulta2(int dni, string pass)
        {
            ApiAccess apiAccess = new ApiAccess();
            string result = await apiAccess.usuario_login(dni, pass);
            // hacer algo con el resultado, como mostrarlo en una vista

            List<clase_login> datos;
            try
            {
                datos = JsonConvert.DeserializeObject<List<clase_login>>(result);
                if (datos.Count() != 1)
                {
                    await DisplayAlert("Error", "No se encontró ningún usuario o se encontró más de uno", "Cerrar");
                    return;
                }
                else
                {
                    await DisplayAlert("Autentificacion Exitosa", "Los datos ingresados son los correctos", "Botón de aceptar");
                    //await Navigation.PushAsync(new pagina_principal());
                    //// Establecer el estado de inicio de sesión como verdadero
                    Application.Current.Properties["IsLoggedIn"] = true;
                    await Application.Current.SavePropertiesAsync();

                    //// Navegar a la página principal
                    //await Navigation.PushAsync(new pagina_principal());
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Autentificacion no encontrada", "El usuario o la contrasela ingresada no existen", "Cerrar");
                return;
            }


        }
        private async void consulta(int dni, string pass)
        {
            ApiAccess apiAccess = new ApiAccess();
            string result = await apiAccess.usuario_login(dni, pass);
            // hacer algo con el resultado, como mostrarlo en una vista

            List<Clase_ListarU> datos;

            try
            {
                datos = JsonConvert.DeserializeObject<List<Clase_ListarU>>(result);

                if (datos.Count() != 1)
                {
                    await DisplayAlert("Error", "No se encontró ningún usuario o se encontró más de uno", "Cerrar");
                    return;
                }
                else
                {
                    await DisplayAlert("Autentificacion Exitosa", "Los datos ingresados son los correctos", "Botón de aceptar"); 
                    
                    //obtener el id del usuario
                    Clase_ListarU usuario = datos[0];
                    int userId_obtenido = usuario.id_usuario;


                    int idUsuario = userId_obtenido;

                    // Asigna el valor del ID del usuario a la propiedad estática
                    UserData.UserId = idUsuario;

                    await Navigation.PushAsync(new pagina_principal(datos));
                }

            }
            catch (Exception ex)
            {
                await DisplayAlert("Autentificacion no encontrada", "El usuario o la contrasela ingresada no existen 6", "Cerrar");
                return;
            }
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new restablecer_password());
        }
    }
}