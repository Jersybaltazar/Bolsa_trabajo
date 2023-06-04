using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace app_CIP.clases
{
    public class clase_cumple
    {
        public int id_usuario { get; set; }
        public string nombre_usuario { get; set; }
        public string apellidos { get; set; }
        public string foto { get; set; }
        
        public string f_nacimiento { get; set; }
        public ImageSource Imagen { get; internal set; }
    }
}
