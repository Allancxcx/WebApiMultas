using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi4645.Entidad;
using WebApi4645.Datos;

namespace WebApi4645.Controllers
{
    public class EliminarLogicamenteController : ApiController
    {
        public IHttpActionResult PUT(Clientes clientes)
        {



            try
            {
                EliminarClientes conCli = new EliminarClientes();
                bool res = conCli.EliminaCredito(clientes);

                if (res)
                    return Content(HttpStatusCode.OK, "Crédito eliminado con exito");
                else
                    return Content(HttpStatusCode.BadRequest, "Error al eliminar informacion");

            }


            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, "Error en el servidor" + ex.Message);

            }
        }


    }
}
