using CrylService.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CrylService.Persistencia
{
    public class MedicamentoDAO: BaseDAO<Medicamento, int>
    {
        string cadenaConexion = "server=.;database=CRYL_ventas;integrated security=true";

        public List<Medicamento> ListarMedicamentos()

        {
            List<Medicamento> listado = new List<Medicamento>();

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand("select * from medicamentos where unidadesenexistencia>=1", conexion);
                

                SqlDataReader lector = comando.ExecuteReader();
                if (lector != null && lector.HasRows)
                {
                    
                    Medicamento medicamento;
                    while (lector.Read())
                    {
                        
                        medicamento = new Medicamento();

                        medicamento.CodMedicamento = int.Parse(lector["CodMedicamento"].ToString());
                        medicamento.NombreMedicamento = (lector["nombremedicamento"].ToString());
                        medicamento.PrecioUnidad = double.Parse(lector["precioUnidad"].ToString());
                        medicamento.UnidadesEnExistencia = int.Parse(lector["unidadesenexistencia"].ToString());
                        


                        listado.Add(medicamento);
                    }
                }
            }
            return listado;
        }

       

        public Medicamento ListarCantidadxMedicamento(int id)

        {
            Medicamento listado = new Medicamento();

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand("select unidadesenexistencia from medicamentos where codmedicamento=@pr1", conexion);
                comando.CommandType = CommandType.Text;
                comando.Parameters.AddWithValue("@pr1", id);

                SqlDataReader lector = comando.ExecuteReader();
                if (lector != null && lector.HasRows)
                {
                    
                    Medicamento medicamento;
                    while (lector.Read())
                    {
                        
                        medicamento = new Medicamento();

                        //pedido.NroPedido = (lector["NroPedido"].ToString());
                        //medicamento.NombreMedicamento = (lector["nombremedicamento"].ToString());
                        medicamento.UnidadesEnExistencia = int.Parse(lector["unidadesenexistencia"].ToString());
                        //detpedido.Cantidad = int.Parse(lector["Cantidad"].ToString());
                        //detpedido.Descuento = double.Parse(lector["Descuento"].ToString());
                        //detpedido.Factura = int.Parse(lector["NroFactura"].ToString());
                        //detpedido.Pedi = pedido;
                        //detpedido.Medicamen = medicamento;


                        listado.UnidadesEnExistencia = medicamento.UnidadesEnExistencia;
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