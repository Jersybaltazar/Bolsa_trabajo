using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace app_CIP.page
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FlyoutPage1Flyout : ContentPage
    {
        public ListView ListView;

        public FlyoutPage1Flyout()
        {
            InitializeComponent();

            BindingContext = new FlyoutPage1FlyoutViewModel();
            ListView = MenuItemsListView;
        }

        private async void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is FlyoutPage1FlyoutMenuItem menuItem)
            {
                // Crear la nueva página a la que deseas navegar
                ContentPage nextPage = null;

                switch (menuItem.Id)
                {
                    case 0:
                        // Opción 1 seleccionada
                        //nextPage = new pagina_principal(datos);
                        // Realizar acciones adicionales o navegar a la página correspondiente si es necesario
                        break;

                    case 1:
                        
                        break;
                    case 2:
                        //lstar empresa segun el usuario
                        nextPage = new listar_empresa_segun_user();
                        break;

                    case 3:
                        //lista de producto segun el emprendimiento - agregar
                        nextPage = new lista_emprendi_user();
                        break;
                    case 4:
                        nextPage = new listar_bolsa_trabajo();
                        break;

                    case 5:
                        nextPage = new Listar_todas_empresas();
                        break;

                    case 6:
                        nextPage = new listar_productos();
                        break;
                    case 7:
                        nextPage = new listar_colaboradores_registrados();
                        break;

                    case 8:
                        var action8 = await DisplayActionSheet("Seleccione una opción", "Cancelar", null, "Ver Publicaciones", "Comparta un Documento");
                        if (action8 == "Ver Publicaciones")
                        {
                            nextPage = new listar_libros();
                            break;
                        }
                        else if (action8 == "Comparta un Documento")
                        {
                            //poner para registrar libro
                            nextPage = new registrar_libro();
                            break;
                        }
                        break;

                    case 9:
                        var action9 = await DisplayActionSheet("Seleccione una opción", "Cancelar", null, "Junta Directiva", "Redes Sociales","Sugerencias","Encuestas");
                        if (action9 == "Junta Directiva")
                        {
                            nextPage = new junta_directiva();
                            break;
                        }
                        else if (action9 == "Redes Sociales")
                        {
                            nextPage = new redes_sociales();
                            break;
                        }
                        else if(action9 == "Sugerencias")
                        {
                            nextPage = new Registrar_sugerencia();
                        }
                        else if (action9 == "Encuestas")
                        {
                            nextPage = new lista_encuesta();
                        }

                        break;

                    case 10:
                        var action10 = await DisplayActionSheet("Seleccione una opción", "Cancelar", null, "CIP CD Huánuco", "CIP Nacional");
                        if (action10 =="CIP CD Huánuco")
                        {
                            nextPage = new convenedor_cip_huanuco();
                            break;
                        }
                        else if (action10 == "CIP Nacional")
                        {
                            //pagina de botones
                            break;
                        }

                        break;

                    case 11:
                        var action11 = await DisplayActionSheet("Seleccione una opción", "Cancelar", null, "Capacitaciones Realizadas", "Eventos Programados");
                        if (action11 == "Capacitaciones Realizadas")
                        {
                            nextPage = new Videos_Interes();
                            break;
                        }
                        else if (action11 == "Eventos Programados")
                        {
                            nextPage = new Listar_eventos_programados();
                            break;
                        }

                        break;

                }

                // Acceder a la instancia del FlyoutPage principal
                var flyoutPage = (FlyoutPage)Application.Current.MainPage;

                if (nextPage != null)
                {
                    // Establecer la nueva página como Detail del FlyoutPage
                    flyoutPage.Detail = new NavigationPage(nextPage);

                    // Cerrar el menú lateral
                    flyoutPage.IsPresented = false;
                }

                // Deseleccionar el elemento del menú
                ((ListView)sender).SelectedItem = null;
            }
        }
        private class FlyoutPage1FlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<FlyoutPage1FlyoutMenuItem> MenuItems { get; set; }

            public FlyoutPage1FlyoutViewModel()
            {
                MenuItems = new ObservableCollection<FlyoutPage1FlyoutMenuItem>(new[]
                {
                    new FlyoutPage1FlyoutMenuItem { Id = 0, Title = "Inicio" },
                    new FlyoutPage1FlyoutMenuItem { Id = 1, Title = "Mi Perfil" },
                    new FlyoutPage1FlyoutMenuItem { Id = 2, Title = "Mis Emprendimientos" },
                    new FlyoutPage1FlyoutMenuItem { Id = 3, Title = "Mis Productos" },
                    new FlyoutPage1FlyoutMenuItem { Id = 4, Title = "Bolsa de Trabajo" },
                    new FlyoutPage1FlyoutMenuItem { Id = 5, Title = "Comprale a un ING. Industrial" },
                    new FlyoutPage1FlyoutMenuItem { Id = 6, Title = "Busqueda de Producto" },
                    new FlyoutPage1FlyoutMenuItem { Id = 7, Title = "Busqueda de Profesional" },
                    new FlyoutPage1FlyoutMenuItem { Id = 8, Title = "Documentos de Interes" },
                    new FlyoutPage1FlyoutMenuItem { Id = 9, Title = "Contactanos" },
                    new FlyoutPage1FlyoutMenuItem { Id = 10, Title = "Servicios Institucionales" },
                    new FlyoutPage1FlyoutMenuItem { Id = 11, Title = "Actividades del Capitulo" },
                    new FlyoutPage1FlyoutMenuItem { Id = 12, Title = "Cerrar Sesion" },
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}