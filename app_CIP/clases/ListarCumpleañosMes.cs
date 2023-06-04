using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace app_CIP.clases
{
    public class ListarCumpleañosMes
    {
        public int id_usuario { get; set; }
        public string nombre_usuario { get; set; }
        public string apellidos { get; set; }
        public DateTime f_nacimiento { get; set; }
        public string foto { get; set; }
        public ImageSource Imagen { get; internal set; }
    }
}
