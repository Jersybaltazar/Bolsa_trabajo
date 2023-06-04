using System;
using System.Collections.Generic;
using System.Text;

namespace app_CIP.clases
{
    public class Clase_producto
    {
        public int id_producto { get; set; }
        public string imagen { get; set; }
        public string nombre { get; set; }
        public string descripcionC { get; set; }
        public string precio { get; set; }
        public int estado { get; set; }
        public int descuento_estado { get; set; }
        public string descuento { get; set; }
        public int delivery_estado { get; set; }
        public string descripcionL { get; set; }

        public int id_empresa { get; set; }
    }
}
