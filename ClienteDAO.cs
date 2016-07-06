using CrylService.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CrylService.Persistencia
{
    public class ClienteDAO : BaseDAO<Cliente, int>
    {
        string cadenaConexion = "server=.;database=CRYL_ventas;integrated security=yes";

        public bool IniciarSesion(Cliente clien)
        {
            bool condicion = false;
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("select * from cliente where nombre=@pr1 and dni=@pr2", conexion);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@pr1", clien.Nombre);
                cmd.Parameters.AddWithValue("@pr2", clien.Dni);


                SqlDataReader lector = cmd.ExecuteReader();
                if (lector != null && lector.HasRows)
                {
                    condicion = true;
                    //Cliente client;
                    //while (lector.Read())
                    //{
                    //    client = new Cliente();


                    //    pedido.NroPedido = (lector["NroPedido"].ToString());
                    //    medicamento.CodMedicamento = int.Parse(lector["CodMedicamento"].ToString());
                    //    detpedido.Cantidad = int.Parse(lector["Cantidad"].ToString());
                    //    detpedido.Descuento = double.Parse(lector["Descuento"].ToString());
                    //    detpedido.Pedido = pedido;
                    //    detpedido.Medicamento = medicamento;


                    //    listado.Add(detpedido);
                }
                else
                {
                    condicion = false;
                }
                }
            return condicion;
            }

        public Cliente BuscarCliente(Cliente clien)


        {
            Cliente listado = new Cliente();

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand("select codcliente from Cliente where nombre=@pr1 and dni=@pr2", conexion);
                comando.CommandType = CommandType.Text;
                comando.Parameters.AddWithValue("@pr1", clien.Nombre);
                comando.Parameters.AddWithValue("@pr2", clien.Dni);

                SqlDataReader lector = comando.ExecuteReader();
                if (lector != null && lector.HasRows)
                {
                    Cliente clientes;
                    while (lector.Read())
                    {
                        clientes = new Cliente();
                        
                         clientes.CodCliente= int.Parse(lector["CodCliente"].ToString());

                        //pedido.NroPedido = (lector["NroPedido"].ToString());
                        //medicamento.CodMedicamento = int.Parse(lector["CodMedicamento"].ToString());
                        //detpedido.Cantidad = int.Parse(lector["Cantidad"].ToString());
                        //detpedido.Descuento = double.Parse(lector["Descuento"].ToString());
                        //detpedido.Factura = int.Parse(lector["NroFactura"].ToString());
                        //detpedido.Pedi = pedido;
                        //detpedido.Medicamen = medicamento;
listado.CodCliente = clientes.CodCliente;
 }
                    
                }
            }
            return listado;
            
        }

    }

            
        }
    
