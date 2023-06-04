using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace app_CIP.clases
{
    public class Clase_ListarU
    {
        public int id_usuario { get; set; }
        public int dni { get; set; }
        public string nombre_usuario { get; set; }
        public string apellidos { get; set; }
        public DateTime f_nacimiento { get; set; }
        public  string paternidad { get; set; }
        public string foto { get; set; }
        public string password { get; set; }
        public string sexo { get; set; }
        public ImageSource Imagen { get; internal set; }
    }
}
