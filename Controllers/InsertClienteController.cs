using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApi4645.Entidad;
using WebApi4645.Datos;


namespace WebApi4645.Controllers
{
    public class InsertClienteController : ApiController
    {

        //http://localhost:56160/api/InsertCliente
        //Publicado
        //https://webapiprestamos.azurewebsites.net/api/InsertCliente
        public IHttpActionResult POST(Clientes clientes)
        {



            try
            {
                InsertarClientes conCli = new InsertarClientes();
                bool res = conCli.InsertCliente(clientes);

                if (res)
                    return Content(HttpStatusCode.OK, "Guardado con exito");
                else
                    return Content(HttpStatusCode.BadRequest, "Error al insertar informacion");

            }


            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, "Error en el servidor" + ex.Message);

            }




        }
    }
}
