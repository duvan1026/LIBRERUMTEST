using LIBRERUMTEST.Models;
using System.Data.SqlClient;
using System.Data;

namespace LIBRERUMTEST.Datos
{
    public class ClienteDatos
    {

        public List<ClienteModel> Listar()
        {

            var oLista = new List<ClienteModel>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open(); // Abre la conexion 
                SqlCommand cmd = new SqlCommand("sp_listar_cliente", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new ClienteModel()
                        {
                            Cedula = dr["Cedula"].ToString(),
                            Nombres = dr["Nombres"].ToString(),
                            Telefono = dr["Telefono"].ToString(),
                            Direccion = dr["Direccion"].ToString()
                        });
                    }
                }
            }

            return oLista;
        }


        public bool Guardar(ClienteModel ocliente)
        {
            bool rpta;

            try
            {

                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open(); // Abre la conexion 
                    SqlCommand cmd = new SqlCommand("sp_Guardar_cliente", conexion); // ejcutamos el procedimiento almacendo
                    cmd.Parameters.AddWithValue("Cedula", ocliente.Cedula); // Enviamos parametro al procedimiento almacenado
                    cmd.Parameters.AddWithValue("Nombres", ocliente.Nombres); // Enviamos parametro al procedimiento almacenado
                    cmd.Parameters.AddWithValue("Telefono", ocliente.Telefono); // Enviamos parametro al procedimiento almacenado
                    cmd.Parameters.AddWithValue("Direccion", ocliente.Direccion); // Enviamos parametro al procedimiento almacenado
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery(); // Ejecutamos el procedimiento almacenado
                }
                rpta = true;

            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }


            return rpta;

        }


        public ClienteModel Obtener(string Cedula)
        {
            try
            {
                ClienteModel oCVenta = null;

                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open(); // Abre la conexion 
                    SqlCommand cmd = new SqlCommand("sp_obtener_cliente", conexion); // ejcutamos el procedimiento almacendo
                    cmd.Parameters.AddWithValue("Cedula", Cedula); // Enviamos parametro al procedimiento almacenado
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oCVenta = new  ClienteModel();
                            oCVenta.Cedula = dr["Cedula"].ToString();
                            oCVenta.Nombres = dr["Nombres"].ToString();
                            oCVenta.Telefono = dr["Telefono"].ToString();
                            oCVenta.Direccion = dr["Direccion"].ToString();
                        }
                    }
                }

                return oCVenta;
            }
            catch (Exception)
            {
                return null;
            }

        }

    }
}
