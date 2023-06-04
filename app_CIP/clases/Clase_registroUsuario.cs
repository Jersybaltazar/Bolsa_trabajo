using System;
using System.Collections.Generic;
using System.Text;

namespace app_CIP.clases
{
    public class Clase_registroUsuario
    {
        public int dni { get; set; }
        public string nombre_usuario { get; set; }
        public string apellidos { get; set; }
        public string direccion { get; set; }
        public string correo { get; set; }
        public string correo2 { get; set; }
        public int telefono { get; set; }
        public int telefono2 { get; set; }
        public string sexo { get; set; }
        public DateTime f_nacimiento { get; set; }
        public bool paternidad { get; set; }
        public string registro_cip { get; set; }
        public string tipo_colegiado { get; set; }
        public string password { get; set; }
        public string Presentacion { get; set; }
        public string url_cv { get; set; }
        public string foto { get; set; }
        public int id_carrera { get; set; }
        public int id_g_academico { get; set; }
        public int id_experiencia { get; set; }
        public int id_autorizacion { get; set; }
        public int id_u_procedencia { get; set; }
        public int id_politicaPrivacidad { get; set; }
        public int id_busqueda_laboral { get; set; }

    }
}
