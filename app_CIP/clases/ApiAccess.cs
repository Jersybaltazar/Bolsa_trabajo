using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace app_CIP.clases
{
    public class ApiAccess
    {
        public async Task<String> ServiceGET(string url)
        {
            string result;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Constantes.RestUrl);

                    var response = await client.GetAsync(url);

                    result = response.Content.ReadAsStringAsync().Result;
                }
            }
            catch (Exception EX1)
            {

                return EX1.ToString();
            }

            //try
            //{
            //    JsonConvert.DeserializeObject(result);
            return result;
            //}
            //catch (Exception EX2)
            //{
            //    return EX2.ToString();
            //}

        }



        public async Task<String> ServicePOST(string url, object ks)
        {
            string result;
            try
            {
                var jsonreq = JsonConvert.SerializeObject(ks);
                var conten = new StringContent(jsonreq, Encoding.UTF8, "text/json");

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Constantes.RestUrl);
                    var response = await client.PostAsync(url, conten);
                    result = response.Content.ReadAsStringAsync().Result;
                }

            }
            catch (Exception ex1)
            {
                return ex1.ToString();
            }

            return result;
        }

        //listar datos
        //andre
        public async Task<string> Produc1()
        {
            string url = string.Format(Constantes.CarpUrl + "/buscar_produc1.php");
            string result = await ServiceGET(url);
            return (result);
        }


        public async Task<string> alquileres(string alquiler)
        {
            string url = string.Format(Constantes.CarpUrl + "\\listar_alquileres.php?tipo_alquiler="+alquiler);
            string result = await ServiceGET(url);
            return (result);
        }
        public async Task<string> listar_convenios()
        {
            string url = string.Format(Constantes.CarpUrl + "//listar_convenios.php");
            string result = await ServiceGET(url);
            return (result);
        }
        public async Task<string> listar_encuestas(int estado)
        {
            string url = string.Format(Constantes.CarpUrl + "//listar_encuestas.php?estado="+estado);
            string result = await ServiceGET(url);
            return (result);
        }
        public async Task<string> Videos()
        {
            string url = string.Format(Constantes.CarpUrl + "/listar_video_interes.php");
            string result = await ServiceGET(url);
            return result;
        }

        public async Task<string> contacto_secretaria()
        {
            string url = string.Format(Constantes.CarpUrl + "/contacto_secretaria.php");
            string result = await ServiceGET(url);
            return result;
        }
        public async Task<string> bolsa_trabajo(int estado)
        {
            string url = string.Format(Constantes.CarpUrl + "/listar_bolsa_trabajo.php?estado"+estado);
            string result = await ServiceGET(url);
            return result;
        }
        public async Task<string> usuario_login2(int dni, string password)
        {
            string url = string.Format(Constantes.CarpUrl + "/listar_usuarios.php?dni="+dni+"&password="+password);
            string result = await ServiceGET(url);
            return result;
        }

        public async Task<string> lista_cumple()
        {
            string url = string.Format(Constantes.CarpUrl + "/lista_cumple.php");
            string result = await ServiceGET(url);
            return result;
        }
        //insertar
        public async Task<string> ingresar_sugerencia(clase_sugerencia sugerencia)
        {
            string url = string.Format(Constantes.CarpUrl + "/insertar_sugerencia.php");
            string result = await ServicePOST(url, sugerencia);
            return result;
        }
        public async Task<string> crear_convenio(Clase_convenios convenios)
        {
            string url = string.Format(Constantes.CarpUrl + "/insertar_convenio.php");
            string result = await ServicePOST(url, convenios);
            return result;
        }
        public async Task<string> crear_bolsa_trabajo(clase_bolsa_trabajo trabajo)
        {
            string url = string.Format(Constantes.CarpUrl + "/insertar_bolsa_trabajo.php");
            string result = await ServicePOST(url, trabajo);
            return result;
        }


        //emerson
        public async Task<string> colaboradores(string nombre_usuario)
        {
            string url = string.Format(Constantes.CarpUrl + "/colaboradores.php?nombre_usuario=" + nombre_usuario);
            string result = await ServiceGET(url);
            return result;

        }
        public async Task<string> ListarColaboradores()
        {
            string url = string.Format(Constantes.CarpUrl + "/colaboradores.php");
            string result = await ServiceGET(url);
            return result;

        }

        public async Task<string> crear_colaborador(Clase_colaboradores colaborador)
        {
            string url = string.Format(Constantes.CarpUrl + "/colaboradores.php");
            string result = await ServicePOST(url, colaborador);
            return result;
        }

        public async Task<string> crear_tienda(CLase_reigstroTienda tienda)
        {
            string url = string.Format(Constantes.CarpUrl + "/tiendaregistro.php");
            string result = await ServicePOST(url, tienda);
            return result;
        }

        public async Task<string> listarlibro()
        {

            string url = string.Format(Constantes.CarpUrl + "/comparteDocumento.php");
            string result = await ServiceGET(url);
            return result;
        }
        public async Task<string> BuscarLibroGeneral(string nombre_documento)
        {

            string url = string.Format(Constantes.CarpUrl + "/comparteDocumento.php?nombre_documento=" + nombre_documento);
            string result = await ServiceGET(url);
            return result;
        }
        //usuario//
        //insertar datos y listar los combobox en la pestana//
        public async Task<string> cargarcomboAcademico()
        {

            string url = string.Format(Constantes.CarpUrl + "/listarGcategoria.php");
            string result = await ServiceGET(url);
            return result;
        }
        //listar universidad
        public async Task<string> cargarcomboUni()
        {

            string url = string.Format(Constantes.CarpUrl + "/comboUni.php");
            string result = await ServiceGET(url);
            return result;
        }
        //listar especialidades
        public async Task<string> cargarespecialidades()
        {

            string url = string.Format(Constantes.CarpUrl + "/comboespecialidad.php");
            string result = await ServiceGET(url);
            return result;
        }



        //listar combos existentes en este campo//

        //fin del listado de los combox//

        //funcion insertar datos //
        public async Task<string> crearUsuario(Clase_registroUsuario usuario)
        {
            string url = string.Format(Constantes.CarpUrl + "/usuarioRegistro.php");
            string result = await ServicePOST(url, usuario);
            return result;
        }

        //isaias
        public async Task<string> crear_producto(Clase_producto productos)
        {
            string url = string.Format(Constantes.CarpUrl + "/insertar_producto.php");
            string result = await ServicePOST(url, productos);
            return result;
        }
        public async Task<string> Ingresar_video(Clase_videos_interes videos)
        {
            string url = string.Format(Constantes.CarpUrl + "/insertar_videos_interes.php");
            string result = await ServicePOST(url, videos);
            return result;
        }

        public async Task<string> Ingresar_eventos_programados(Clase_eventos eventos)
        {
            string url = string.Format(Constantes.CarpUrl + "/insertar_eventos_programados.php");
            string result = await ServicePOST(url, eventos);
            return result;
        }

        //emerson
        public async Task<string> usuario_login(int dni, string password)
        {
            string url = string.Format(Constantes.CarpUrl + "/listar_usuarios.php?dni=" + dni + "&password=" + password);
            string result = await ServiceGET(url);
            return result;
        }

        public async Task<string> listarUcumple()
        {
            string url = string.Format(Constantes.CarpUrl + "/ListarUsuarioCumple.php");
            string result = await ServiceGET(url);
            return result;
        }

        //andre
        public async Task<string> crear_libro(Clase_libro libro)
        {
            string url = string.Format(Constantes.CarpUrl + "/insertar_compartaDocumento.php");
            string result = await ServicePOST(url, libro);
            return result;
        }
        public async Task<string> cargarcomboTipo()
        {

            string url = string.Format(Constantes.CarpUrl + "/combo1.php");
            string result = await ServiceGET(url);
            return result;
        }
        public async Task<string> cargarcomboTipo2()
        {

            string url = string.Format(Constantes.CarpUrl + "/combo2.php");
            string result = await ServiceGET(url);
            return result;
        }

        //isaias
        public async Task<string> Producto()
        {
            string url = string.Format(Constantes.CarpUrl + "/listar_producto.php");
            string result = await ServiceGET(url);
            return result;
        }

        public async Task<string> Producto_buscar(string nombre)
        {
            string url = string.Format(Constantes.CarpUrl + "/listar_producto.php?nombre="+nombre);
            string result = await ServiceGET(url);
            return result;
        }

        public async Task<string> detalle_empresa(int id_empr)
        {
            string url = string.Format(Constantes.CarpUrl + "/listar_emprendimiento.php?id_empresa="+id_empr);
            string result = await ServiceGET(url);
            return (result);
        }
        public async Task<string> eventos_programados()
        {
            string url = string.Format(Constantes.CarpUrl + "//listar_eventos.php");
            string result = await ServiceGET(url);
            return (result);
        }

        public async Task<string> Empren(int id)
        {
            string url = string.Format(Constantes.CarpUrl + "/emprendimiento.php?id_usuario=" + id);
            string result = await ServiceGET(url);
            return (result);
        }

        public async Task<string> Produc2(int id2)
        {
            string url = string.Format(Constantes.CarpUrl + "/buscar_produc1.php?id_empresa=" + id2);
            string result = await ServiceGET(url);
            return (result);
        }
        public async Task<string> Listar_todas_Empresas()
        {
            string url = string.Format(Constantes.CarpUrl + "/listar_emprendimiento.php");
            string result = await ServiceGET(url);
            return (result);
        }

    }
}
   
