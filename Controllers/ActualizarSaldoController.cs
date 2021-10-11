using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApi4645.Entidad;
using WebApi4645.Datos;
using System.Data.SqlClient;
using System.Data;


namespace WebApi4645.Controllers
{
    public class ActualizarSaldoController : ApiController
    {
        public IHttpActionResult PUT(Clientes clientes)
        {



            try
            {
                ActualizaSaldo conCli = new ActualizaSaldo();
                bool res = conCli.actualizaSaldo(clientes);

                if (res)
                    return Content(HttpStatusCode.OK, "Actualizado con exito");
                else
                    return Content(HttpStatusCode.BadRequest, "Error al actualizar informacion");

            }


            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, "Error en el servidor" + ex.Message);

            }
        }

        [HttpGet]
     
        public Clientes Get(int id)
        {
            string cadenaconexion = "Data Source = localhost; Initial Catalog = Creditos4645; User ID = sa; password=1234567";
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();

            myConnection.ConnectionString = cadenaconexion;

            SqlCommand sqlCmd = new SqlCommand();

            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "SELECT codigo_cliente, saldo  FROM CLIENTES WHERE codigo_cliente=" + id + "";
            sqlCmd.Connection = myConnection;

            myConnection.Open();

            reader = sqlCmd.ExecuteReader();

            Clientes cli = null;

            while (reader.Read())
            {
                cli = new Clientes();

                cli.codigo_cliente = Convert.ToInt32(reader.GetValue(0));
                cli.saldo = Convert.ToInt32(reader.GetValue(1));
                //cli.nombre = reader.GetValue(1).ToString();
                //cli.apellido = reader.GetValue(2).ToString();
            }

            myConnection.Close();

            return cli;






        }

    }
}










    


