using System.Data.SqlClient;
using System.Data;
using LIBRERUMTEST.Models;

namespace LIBRERUMTEST.Datos
{
    public class VentaDatos
    {

        public List<VentaModel> Listar()
        {

            var oLista = new List<VentaModel>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open(); // Abre la conexion 
                SqlCommand cmd = new SqlCommand("sp_Listar_ventas", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new VentaModel()
                        {
                            CodigoVenta = dr["CodigoVenta"].ToString(),
                            CodigoProducto = dr["CodigoProducto"].ToString(),
                            FechaVenta = dr["FechaVenta"].ToString(),
                            PuntoVenta = dr["PuntoVenta"].ToString(),
                            Total = Convert.ToDecimal(dr["Total"]),
                            ClienteModel = new ClienteModel()
                            {
                                Cedula = dr["Cedula"].ToString(),
                                Nombres = dr["Nombres"].ToString(),
                                Telefono = dr["Telefono"].ToString(),
                                Direccion = dr["Direccion"].ToString()
                            }
                           
                        }) ;
                    }
                }
                conexion.Close();
            }

            return oLista;
        }


        public VentaModel Obtener(int IdContacto)
        {

            var oVenta = new VentaModel();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open(); // Abre la conexion 
                SqlCommand cmd = new SqlCommand("sp_obtener_ventas", conexion); // ejcutamos el procedimiento almacendo
                cmd.Parameters.AddWithValue("IdContacto", IdContacto); // Enviamos parametro al procedimiento almacenado
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oVenta.CodigoVenta = dr["CodigoVenta"].ToString();
                        oVenta.CodigoProducto = dr["CodigoProducto"].ToString();
                        oVenta.FechaVenta = dr["FechaVenta"].ToString();
                        oVenta.PuntoVenta = dr["PuntoVenta"].ToString();
                        oVenta.Total = Convert.ToDecimal(dr["Total"]);
                        oVenta.ClienteModel = new ClienteModel()
                        {
                            Cedula = dr["Cedula"].ToString(),
                            Nombres = dr["Nombres"].ToString(),
                            Telefono = dr["Telefono"].ToString(),
                            Direccion = dr["Direccion"].ToString()
                        };

                    }
                }
                conexion.Close();
            }

            return oVenta;
        }


        public bool Guardar(VentaModel oventa)
        {
            bool rpta;

            try
            {

                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open(); // Abre la conexion 
                    SqlCommand cmd = new SqlCommand("sp_Guardar_ventas", conexion); // ejcutamos el procedimiento almacendo
                    cmd.Parameters.AddWithValue("CodigoVenta", oventa.CodigoVenta); // Enviamos parametro al procedimiento almacenado
                    cmd.Parameters.AddWithValue("CodigoProducto", oventa.CodigoProducto); // Enviamos parametro al procedimiento almacenado
                    cmd.Parameters.AddWithValue("FechaVenta", oventa.FechaVenta); // Enviamos parametro al procedimiento almacenado
                    cmd.Parameters.AddWithValue("PuntoVenta", oventa.PuntoVenta); // Enviamos parametro al procedimiento almacenado
                    cmd.Parameters.AddWithValue("CedulaCliente", oventa.ClienteModel.Cedula); // Enviamos parametro al procedimiento almacenado
                    cmd.Parameters.AddWithValue("Total", oventa.Total); // Enviamos parametro al procedimiento almacenado
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



        public bool Editar(VentaModel oventa)
        {
            bool rpta;

            try
            {

                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open(); // Abre la conexion 
                    SqlCommand cmd = new SqlCommand("sp_Editar_ventas", conexion); // ejcutamos el procedimiento almacendo
                    cmd.Parameters.AddWithValue("CodigoVenta", oventa.CodigoVenta); // Enviamos parametro al procedimiento almacenado
                    cmd.Parameters.AddWithValue("CodigoProducto", oventa.CodigoProducto); // Enviamos parametro al procedimiento almacenado
                    cmd.Parameters.AddWithValue("FechaVenta", oventa.FechaVenta); // Enviamos parametro al procedimiento almacenado
                    cmd.Parameters.AddWithValue("PuntoVenta", oventa.PuntoVenta); // Enviamos parametro al procedimiento almacenado
                    cmd.Parameters.AddWithValue("CedulaCliente", oventa.ClienteModel.Cedula); // Enviamos parametro al procedimiento almacenado
                    cmd.Parameters.AddWithValue("Total", oventa.Total); // Enviamos parametro al procedimiento almacenado
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


        public bool Eliminar(int CodigoVenta)
        {
            bool rpta;

            try
            {

                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open(); // Abre la conexion 
                    SqlCommand cmd = new SqlCommand("sp_Eliminar_ventas", conexion); // ejcutamos el procedimiento almacendo
                    cmd.Parameters.AddWithValue("CodigoVenta", CodigoVenta); // Enviamos parametro al procedimiento almacenado
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

        internal bool Eliminar(string? codigoVenta)
        {
            throw new NotImplementedException();
        }
    }
}
