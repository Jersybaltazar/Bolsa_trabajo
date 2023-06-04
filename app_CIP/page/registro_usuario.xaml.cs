using app_CIP.clases;
using Newtonsoft.Json;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace app_CIP.page
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class registro_usuario : ContentPage
    {
        public registro_usuario()
        {
            InitializeComponent();
            cargarGacademico();
            cargarUniversidad();
            cargarespecialidad();
            NavigationPage.SetHasNavigationBar(this, true);
            this.Title = "BIENVENIDO USUARIO";
        }
        private async void cargarGacademico()
        {
            ApiAccess apiAccess = new ApiAccess();
            string result = await apiAccess.cargarcomboAcademico();

            List<Clase_Gacademico> datos;

            try
            {
                datos = JsonConvert.DeserializeObject<List<Clase_Gacademico>>(result);

            }
            catch (Exception ex)
            {
                await DisplayAlert("system", ex.Message, "cerrar");

                return;
            }
            g_academico.ItemsSource = datos;

        }
        private async void cargarUniversidad()
        {
            ApiAccess apiAccess = new ApiAccess();
            string result = await apiAccess.cargarcomboUni();

            List<Clase_CUni> datos;

            try
            {
                datos = JsonConvert.DeserializeObject<List<Clase_CUni>>(result);

            }
            catch (Exception ex)
            {
                await DisplayAlert("system", ex.Message, "cerrar");

                return;
            }
            universiadad.ItemsSource = datos;

        }

        private async void cargarespecialidad()
        {
            ApiAccess apiAccess = new ApiAccess();
            string result = await apiAccess.cargarespecialidades();

            List<Clase_Cespecialidad> datos;

            try
            {
                datos = JsonConvert.DeserializeObject<List<Clase_Cespecialidad>>(result);

            }
            catch (Exception ex)
            {
                await DisplayAlert("system", ex.Message, "cerrar");

                return;
            }
            especialidad.ItemsSource = datos;

        }
        public int SelectedGAcademicoId { get; private set; }
        public int SelectedUniversidadId { get; private set; }

        private void g_academico_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedOption = (Clase_Gacademico)g_academico.SelectedItem;
            var selectedOptionName = selectedOption.nombre;
            var selectedOptionId = selectedOption.id_g_academico;
            SelectedGAcademicoId = selectedOptionId;

        }

        private void universiadad_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedOption = (Clase_CUni)universiadad.SelectedItem;
            var selectedOptionName = selectedOption.nombre_uni;
            var selectedOptionId = selectedOption.id_u_procedencia;
            SelectedUniversidadId = selectedOptionId;
        }

        public ObservableCollection<string> EspecialidadesSeleccionadas { get; set; } = new ObservableCollection<string>();
        private void especialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedOption = (Clase_Cespecialidad)especialidad.SelectedItem;
            var selectedOptionName = selectedOption.nombre_especialidad;
            var selectedOptionId = selectedOption.id_especialidad;

            if (selectedOptionName == "OTROS")
            {
                otrosEntry.IsEnabled = true;
                otrosEntry.IsVisible = true;
                boton_otros.IsEnabled = true;
                boton_otros.IsVisible = true;
            }
            else
            {
                otrosEntry.IsEnabled = false;
                otrosEntry.IsVisible = false;
                boton_otros.IsEnabled = false;
                boton_otros.IsVisible = false;
                // Agregar la especialidad seleccionada a la lista
                EspecialidadesSeleccionadas.Add(selectedOptionName);
                MiLista.ItemsSource = EspecialidadesSeleccionadas;
            }
        }

        private async void registrar_usuario_Clicked(object sender, EventArgs e)
        {

            Clase_registroUsuario usuario = new Clase_registroUsuario();
            usuario.dni = int.Parse(dni.Text);
            usuario.nombre_usuario = nombre.Text;
            usuario.apellidos = apellido.Text;
            usuario.direccion = direccion.Text;
            usuario.correo = correo.Text;
            usuario.correo2 = correo2.Text;
            usuario.telefono = int.Parse(telefono.Text);
            usuario.telefono2 = int.Parse(telefono1.Text);
            usuario.sexo = selectedSexo;
            usuario.f_nacimiento = fecha_nacimiento.Date;
            usuario.paternidad = selectedpartnidad;
            usuario.id_u_procedencia = SelectedUniversidadId;
            usuario.tipo_colegiado = selectedColegiado;
            usuario.registro_cip = registro_cip.Text;
            usuario.password = passwordConfirm.Text;
            usuario.Presentacion = presentacion.Text;
            usuario.url_cv = CV.Text;
            usuario.id_carrera = 1;
            usuario.id_g_academico = SelectedGAcademicoId;
            usuario.id_experiencia = ValorSlider;
            usuario.id_autorizacion = valorAutorizacion;
            usuario.id_politicaPrivacidad = 1;
            usuario.id_busqueda_laboral = valorOportunidad;

            string fotoBase64 = Convert.ToBase64String(selectedImageSource);
            usuario.foto = fotoBase64;

            ApiAccess api = new ApiAccess();
            var respuesta = await api.crearUsuario(usuario);
            await DisplayAlert("alert", respuesta, "ok");

            await Navigation.PushAsync(new login());

        }




        private string selectedSexo;
        private void RadioButton_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.IsChecked)
            {
                selectedSexo = radioButton == masculino ? "Masculino" : "Femenino";
            }
        }

        //private void ver_que_Clicked(object sender, EventArgs e)
        //{

        //    DisplayAlert("alerta", EspecialidadesSeleccionadas.ToString(), "ok");
        //}


        private bool selectedpartnidad;
        private void paternidad_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.IsChecked)
            {
                selectedpartnidad = radioButton == SI ? true : false;
            }

        }

        private string selectedColegiado;
        private void tipoColegiado_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.IsChecked)
            {
                selectedColegiado = radioButton == Colegiado ? "Colegiado" : "No Colegiado";
            }
        }

        private void passwordConfirm_Unfocused(object sender, FocusEventArgs e)
        {
            if (!string.IsNullOrEmpty(password.Text) && !string.IsNullOrEmpty(passwordConfirm.Text))
            {
                if (password.Text != passwordConfirm.Text)
                {
                    // Las contraseñas no coinciden, muestra un mensaje de error
                    DisplayAlert("Error", "Las contraseñas no coinciden", "OK");
                }
                else
                {
                    // Las contraseñas coinciden, puedes guardar el valor en una variable o propiedad
                    string passwordValue = password.Text;

                }
            }
        }

        private void PoliticaPriacidad_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value == true)
            {
                btnregistrar_usuario.IsEnabled = true;
            }
            else
            {
                btnregistrar_usuario.IsEnabled = false;
            }
        }


        //registrar fotos por medio de la libreria xam:plugin:media, buscarlo en la libreria nuget con el mismo nombre
        private ImageSource imageSource;
        public ImageSource ImageSource
        {
            get { return imageSource; }
            set
            {
                imageSource = value;
                OnPropertyChanged(nameof(ImageSource));
            }
        }


        private byte[] selectedImageSource;
        private async void registrarFoto_Clicked(object sender, EventArgs e)
        {
            var action = await DisplayActionSheet("Seleccionar imagen", "Cancelar", null, "Galería", "Cámara");

            if (action == "Galería")
            {
                // Obtener imagen de la galería
                var file = await CrossMedia.Current.PickPhotoAsync();

                if (file != null)
                {
                    selectedImageSource = File.ReadAllBytes(file.Path);
                    imagenCIP.Source = ImageSource.FromStream(() => file.GetStream());
                    // Crear un objeto ImageSource a partir de la imagen seleccionada
                    //selectedImageSource = ImageSource.FromFile(file.Path);

                    //// Mostrar la imagen en el ImageButton
                    //imagenCIP.Source = selectedImageSource;
                }
            }
            else if (action == "Cámara")
            {
                // Tomar foto con la cámara
                var file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions());

                if (file != null)
                {
                    selectedImageSource = File.ReadAllBytes(file.Path);
                    imagenCIP.Source = ImageSource.FromStream(() => file.GetStream());
                    // Crear un objeto ImageSource a partir de la imagen capturada
                    //selectedImageSource = ImageSource.FromFile(file.Path);

                    //// Mostrar la imagen en el ImageButton
                    //imagenCIP.Source = selectedImageSource;
                }
            }
        }

        private void limipardata()
        {
            dni.Text = string.Empty;
            nombre.Text = string.Empty;
            apellido.Text = string.Empty;
            direccion.Text = string.Empty;
            correo.Text = string.Empty;
            correo2.Text = string.Empty;
            telefono.Text = string.Empty;
            telefono1.Text = string.Empty;
            registro_cip.Text = string.Empty;
            password.Text = string.Empty;
            passwordConfirm.Text = string.Empty;
            presentacion.Text = string.Empty;
            CV.Text = string.Empty;

        }

        int valorAutorizacion;
        private void autorizo_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (autorizo.IsChecked)
            {
                valorAutorizacion = 1;
            }
            else if (noautorizo.IsChecked)
            {
                valorAutorizacion = 2;
            }
            else
            {
                DisplayAlert("ERROR", "ACEPTE LA AUTORIZACION", "OK");
            }
        }

        int valorOportunidad;
        private void busqueda_laboral_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (busqueda_laboral.IsChecked)
            {
                valorOportunidad = 1;
            }
            else if (disponible_laboral.IsChecked)
            {
                valorOportunidad = 2;
            }
            else
            {
                DisplayAlert("ERROR", "Seleccione una de las 2 opciones", "OK");
            }
        }

        public int ValorSlider;
        private void linea_ex_ValueChanged_1(object sender, ValueChangedEventArgs e)
        {
            var slider = (Slider)sender;

            if (slider.Value < 0.5)
            {
                ValorSlider = 1;
            }
            else if (slider.Value >= 0.5 && slider.Value < 1.5)
            {
                ValorSlider = 2;
            }
            else
            {
                ValorSlider = 3;
            }
        }

        private void boton_otros_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(otrosEntry.Text))
            {
                // Agregar la especialidad ingresada a la lista
                EspecialidadesSeleccionadas.Add(otrosEntry.Text);
                MiLista.ItemsSource = EspecialidadesSeleccionadas;
                otrosEntry.Text = string.Empty; // Limpiar el Entry después de agregar la especialidad
            }
        }

        private void btn_eliminar_Clicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var especialidad = (string)button.CommandParameter;

            // Eliminar la especialidad de la lista
            EspecialidadesSeleccionadas.Remove(especialidad);
        }
    }
}