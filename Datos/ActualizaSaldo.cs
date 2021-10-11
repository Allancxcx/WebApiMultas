using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using WebApi4645.Entidad;


namespace WebApi4645.Datos
{
    public class ActualizaSaldo
    {


        public bool actualizaSaldo(Clientes clientes)
        {

            string constring = "Data Source = svr-sql-ctezo.southcentralus.cloudapp.azure.com; Initial Catalog=db_progII;User ID=usr_manto;password=!ngGu@t@";


            try
            {
                using (SqlConnection con = new SqlConnection(constring))

                {
                    string command = "update CLIENTES set abono =@abono+abono where codigo_cliente = @cliente " +
                        "UPDATE CLIENTES set saldo = monto_préstamo - abono where codigo_cliente = @cliente";
                    using (SqlCommand cmd = new SqlCommand(command, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@cliente", clientes.codigo_cliente);
                        cmd.Parameters.AddWithValue("@abono", clientes.abono);

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
