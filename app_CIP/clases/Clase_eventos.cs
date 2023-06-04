using System;
using System.Collections.Generic;
using System.Text;

namespace app_CIP.clases
{
    public class Clase_eventos
    {
        public string nombre_evento { get; set; }
        public string ruta_img { get; set; }
        public string modalidad { get; set; }
        public DateTime fecha { get; set; }
        public TimeSpan hora { get; set; }
        public string descripcion_modalidad { get; set; }
    }
}
