using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using WebApi4645.Entidad;


namespace WebApi4645.Datos
{
    public class InsertarClientes
    {
        public bool InsertCliente(Clientes clientes)
        {

            string constring = "Data Source = svr-sql-ctezo.southcentralus.cloudapp.azure.com; Initial Catalog=db_progII;User ID=usr_manto;password=!ngGu@t@";


            try
            {
                using (SqlConnection con = new SqlConnection(constring))

                {
                    string command = "insert into CLIENTES(nombre,apellido,dirección,telefono,codigo_de_credito,tipo_de_credito,monto_préstamo,abono,estado_eliminado) values(@nombre,@apellido,@direccion,@telefono,@codigo,@tipo,@monto,0,@estado)";
                    using (SqlCommand cmd = new SqlCommand(command, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@nombre", clientes.nombre);
                        cmd.Parameters.AddWithValue("@apellido", clientes.apellido);
                        cmd.Parameters.AddWithValue("@direccion", clientes.dirección);
                        cmd.Parameters.AddWithValue("@telefono", clientes.telefono);
                        cmd.Parameters.AddWithValue("@codigo", clientes.codigo_de_credito);
                        cmd.Parameters.AddWithValue("@tipo", clientes.tipo_de_credito);
                        cmd.Parameters.AddWithValue("@monto", clientes.monto_préstamo);
                        cmd.Parameters.AddWithValue("@estado", clientes.estado_eliminado);



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