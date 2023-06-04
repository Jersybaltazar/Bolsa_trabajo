using System;
using System.Collections.Generic;
using System.Text;

namespace app_CIP.clases
{
    public class Clase_libro
    {
        public string nombre { get; set; }
        public int id_tipoDocumento { get; set; }
        public string id_categoria { get; set; }
        public string otros { get; set; }
        public string fuente { get; set; }
        public string img_ruta { get; set; }
        public string descripcion { get; set; }
        public int id_politica { get; set; }
        public int id_usuario { get; set; }
    }
}
