using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace app_CIP.clases
{
    public class Clase_colaboradores
    {
        public int id_usuario { get; set; }
        public string nombre_usuario { get; set; }
        public string apellido { get; set; }
        public string foto { get; set; }
        public string grado_academico { get; set; }
        public string Presentacion { get; set; }
        public string experiencia { get; set; }
        public string correo { get; set; }
        public string telefono { get; set; }
        public string registro_cip { get; set; }
        public string url_cv { get; set; }
        public List<string> nombre_especialidad { get; set; }

        public List<string> empleo { get; set; }
        public ImageSource Imagen { get; internal set; }
    }
}
