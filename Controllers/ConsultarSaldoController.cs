using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi4645.Entidad;
using System.Data.SqlClient;
using System.Data;

namespace WebApi4645.Controllers
{
    public class ConsultarSaldoController : ApiController
    {

        [HttpGet]
       
        public ClienteSaldoPendiente Get(int id)
        {
            string cadenaconexion = "Data Source = localhost; Initial Catalog = Creditos4645; User ID = sa; password=1234567";
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();

            myConnection.ConnectionString = cadenaconexion;

            SqlCommand sqlCmd = new SqlCommand();

            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "SELECT codigo_cliente, nombre, apellido, saldo  FROM CLIENTES WHERE codigo_cliente=" + id + "";
            sqlCmd.Connection = myConnection;

            myConnection.Open();

            reader = sqlCmd.ExecuteReader();

            ClienteSaldoPendiente cli = null;

            while (reader.Read())
            {
                cli = new ClienteSaldoPendiente();

                cli.codigo_cliente = Convert.ToInt32(reader.GetValue(0));
                cli.nombre = reader.GetValue(1).ToString();
                cli.apellido = reader.GetValue(2).ToString();
                cli.saldo = Convert.ToInt32(reader.GetValue(3));
           
            }

            myConnection.Close();

            return cli;





        }
    }
}