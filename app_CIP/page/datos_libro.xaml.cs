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
    public partial class datos_libro : ContentPage
    {
        public datos_libro(Clase_BuscarLibroG buscarLibros)
        {
            InitializeComponent();
            //cargar datos de colaborador con id_libros
            nombre_documento.Text = buscarLibros.nombre_documento;
            foto.Source = buscarLibros.imagen;
            fuente.Text = buscarLibros.fuente;
            tipo.Text = buscarLibros.tipo;
            categoria.Text = buscarLibros.categoria_documento;
            name.Text = buscarLibros.nombre_usuario;
            apellido.Text = buscarLibros.apellidos;
        }
    }
}