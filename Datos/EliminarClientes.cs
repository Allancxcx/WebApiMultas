using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi4645.Entidad;
using System.Data.SqlClient;
using System.Data;

namespace WebApi4645.Datos
{
    public class EliminarClientes
    {

        public bool EliminaCredito(Clientes clientes)
        {
            string constring = "Data Source = svr-sql-ctezo.southcentralus.cloudapp.azure.com; Initial Catalog=db_progII;User ID=usr_manto;password=!ngGu@t@";


            try
            {
                using (SqlConnection con = new SqlConnection(constring))

                {
                    string command = "update CLIENTES set estado_eliminado = 1 where codigo_cliente=@cliente ";
                    using (SqlCommand cmd = new SqlCommand(command, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@cliente", clientes.codigo_cliente);
                        

                        con.Open();

                        int rowaffected = cmd.ExecuteNonQuery();

                        if (rowaffected > 0)
                            return true;


                        else
                            return false;


                    }

                }
            }
            catch (Exception ex)
            {

                return false;
            }



        }
    }
}