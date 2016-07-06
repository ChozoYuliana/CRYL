using CrylService.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CrylService.Persistencia
{
    public class PedidoDAO : BaseDAO<Pedido, string>
    {
        string cadenaConexion = "server=.;database=CRYL_ventas;integrated security=true";
        public bool CrearParticipante(Pedido detpedido)
        {
            bool exito = false;
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("insert into Pedidos values (@pr1, @pr2, @pr3, @pr4 , @pr5 , @pr6)", conexion);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@pr1", detpedido.NroPedido);
                cmd.Parameters.AddWithValue("@pr2", detpedido.Clien.CodCliente);
                cmd.Parameters.AddWithValue("@pr3", detpedido.Emplea.CodEmpleado);
                cmd.Parameters.AddWithValue("@pr4", detpedido.FechaPedido);
                cmd.Parameters.AddWithValue("@pr5", detpedido.FechaEntrega);
                cmd.Parameters.AddWithValue("@pr6", detpedido.DireccionDestinatario);

                exito = cmd.ExecuteNonQuery() > 0;
            }

            return exito;
        }
    }
}