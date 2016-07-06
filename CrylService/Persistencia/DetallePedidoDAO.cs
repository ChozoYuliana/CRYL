using CrylService.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CrylService.Persistencia
{
    public class DetallePedidoDAO : BaseDAO<DetallePedido, int>
    {
        string cadenaConexion = "server=.;database=CRYL_ventas;integrated security=true";

         public List<DetallePedido> ListarxPedido(string idpedido)

           {
                List<DetallePedido> listado = new List<DetallePedido>();

               using (SqlConnection conexion = new SqlConnection(cadenaConexion))
               {
                  conexion.Open();
                   SqlCommand comando = new SqlCommand("select nropedido,nombremedicamento,precioUnidad,cantidad,descuento,nrofactura from DetallePedidos dp inner join Medicamentos m on dp.codmedicamento=m.codmedicamento where nropedido=@pr1 and unidadesenexistencia>=1", conexion);
                comando.CommandType = CommandType.Text;
                comando.Parameters.AddWithValue("@pr1", idpedido);

                SqlDataReader lector = comando.ExecuteReader();
                  if (lector != null && lector.HasRows)
                  {
                       DetallePedido detpedido;
                       Pedido pedido;
                       Medicamento medicamento;
                       while (lector.Read())
                       {
                           detpedido = new DetallePedido();
                           pedido = new Pedido();
                           medicamento = new Medicamento();

                           pedido.NroPedido = (lector["NroPedido"].ToString());
                           medicamento.NombreMedicamento = (lector["nombremedicamento"].ToString());
                        medicamento.PrecioUnidad = double.Parse(lector["precioUnidad"].ToString());
                           detpedido.Cantidad = int.Parse(lector["Cantidad"].ToString());
                          detpedido.Descuento = double.Parse(lector["Descuento"].ToString());
                        detpedido.Factura = int.Parse(lector["NroFactura"].ToString());
                        detpedido.Pedi = pedido;
                        detpedido.Medicamen = medicamento;


                           listado.Add(detpedido);
                      }
                  }
                }
               return listado;
          }

        public bool CrearParticipante(DetallePedido detpedido)
        {
            bool exito = false;
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("insert into DetallePedidos values (@pr1, @pr2, @pr3, @pr4,@pr5)", conexion);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@pr1", detpedido.Pedi.NroPedido);
                cmd.Parameters.AddWithValue("@pr2", detpedido.Medicamen.CodMedicamento);
                cmd.Parameters.AddWithValue("@pr3", detpedido.Cantidad);
                cmd.Parameters.AddWithValue("@pr4", detpedido.Descuento);
                cmd.Parameters.AddWithValue("@pr5", detpedido.Factura);

                exito = cmd.ExecuteNonQuery() > 0;
            }

            return exito;
        }



    }
}