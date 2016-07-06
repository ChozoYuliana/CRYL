using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using CrylService.Dominio;
using CrylService.Persistencia;

namespace CrylService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Transaccion" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Transaccion.svc o Transaccion.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Transaccion : ITransaccion
    {

        #region Cliente
        private ClienteDAO clienteDAO = null;
        private ClienteDAO ClienteDAO ///patron single
        {
            get
            {
                if (clienteDAO == null)
                    clienteDAO = new ClienteDAO();
                return clienteDAO;
            }
        }

        public Dominio.Cliente CrearCliente(Dominio.Cliente nuevoCliente)
        {
            return ClienteDAO.Crear(nuevoCliente);
        }

        public IList<Dominio.Cliente> ListarCliente()
        {
            return ClienteDAO.ListarTodos();
        }

        public Dominio.Cliente ModificarCliente(Dominio.Cliente clienteModificar)
        {
            return ClienteDAO.Modificar(clienteModificar);
        }

        public Dominio.Cliente ObtenerCliente(int CodCliente)
        {
            return ClienteDAO.Obtener(CodCliente);
        }

        public bool IniciarSesion(Cliente clien)
        {
            
            return ClienteDAO.IniciarSesion(clien);
        }

        #endregion

        #region Empleado

        private EmpleadoDAO empleadoDAO = null;
        private EmpleadoDAO EmpleadoDAO ///patron single
        {
            get
            {
                if (empleadoDAO == null)
                    empleadoDAO = new EmpleadoDAO();
                return empleadoDAO;
            }
        }
        public Empleado CrearEmpleado(Empleado nuevoEmpleado)
        {
            return EmpleadoDAO.Crear(nuevoEmpleado);
        }

        public IList<Empleado> ListarEmpleado()
        {
            return EmpleadoDAO.ListarTodos();
        }

        public Empleado ModificarEmpleado(Empleado empleadoModificar)
        {
            return EmpleadoDAO.Modificar(empleadoModificar);
        }

        public Empleado ObtenerEmpleado(int CodEmpleado)
        {
            return EmpleadoDAO.Obtener(CodEmpleado);
        }
        #endregion
        
        #region Medicamentos

        private MedicamentoDAO medicamentoDAO = null;
        private MedicamentoDAO MedicamentoDAO 
        {
            get
            {
                if (medicamentoDAO == null)
                    medicamentoDAO = new MedicamentoDAO();
                return medicamentoDAO;
            }
        }
        

        public Medicamento CrearMedicamento(Medicamento nuevoMedicamento)
        {
            return MedicamentoDAO.Crear(nuevoMedicamento);
        }

        public IList<Medicamento> ListarMedicamento()
        {
            return MedicamentoDAO.ListarMedicamentos();
        }

        public Medicamento ModificarMedicamento(Medicamento medicamentoModificar)
        {
            return MedicamentoDAO.Modificar(medicamentoModificar);
        }
        public IList<Medicamento> ListarTodosMedicamentos()
        {
            return MedicamentoDAO.ListarTodos();
        }

        public Medicamento ObtenerMedicamentos(int CodMedicamento)
        {
            return MedicamentoDAO.Obtener(CodMedicamento);
        }
        #endregion

        #region Pedido
        private PedidoDAO pedidoDAO = null;
        private PedidoDAO PedidoDAO
        {
            get
            {
                if (pedidoDAO == null)
                    pedidoDAO = new PedidoDAO();
                return pedidoDAO;
            }
        }

        public IList<Pedido> ListarPedido()
        {
            return PedidoDAO.ListarTodos();
        }

       

        //public Pedido ModificarPedido(Pedido pedidoModificar)
        //{
        //    return PedidoDAO.Modificar(pedidoModificar);
        //}

        

        #endregion

        #region DetallePedido

        private DetallePedidoDAO detallePedidoDAO = null;
        private DetallePedidoDAO DetallePedidoDAO
        {
            get
            {
                if (detallePedidoDAO == null)
                    detallePedidoDAO = new DetallePedidoDAO();
                return detallePedidoDAO;
            }
        }

        //public IList<DetallePedido> ListarDetallePedido()
        //{
        //    return DetallePedidoDAO.ListarTodos();
        //}

        public bool CrearDetallePedido(DetallePedido nuevoDetallePedido)
        {
            return DetallePedidoDAO.CrearParticipante(nuevoDetallePedido);
        }

        public IList<DetallePedido> ListarxPedido(string idpedido)
        {
            return DetallePedidoDAO.ListarxPedido(idpedido);
        }

        public Pedido ObtenerPedido(string NroPedido)
        {
            return PedidoDAO.Obtener(NroPedido);
        }

        //public Dominio.Cliente ObtenerCliente(int CodCliente)
        //{
        //    return ClienteDAO.Obtener(CodCliente);
        //}








        //public IList<DetallePedido> ListarDetallePedido()
        //{
        //    throw new NotImplementedException();
        //}

        //public DetallePedido ModificarDetallePedido(DetallePedido detallePedidoModificar)
        //{
        //    throw new NotImplementedException();
        //}

        //public DetallePedido ObtenerDetallePedido(int NroFactura)
        //{
        //    throw new NotImplementedException();
        //}

        //public DetallePedido ModificarDetallePedido(DetallePedido detallePedidoModificar)
        //{
        //    return DetallePedidoDAO.Modificar(detallePedidoModificar);
        //}

        //public DetallePedido ObtenerDetallePedido(int NroFactura)
        //{
        //    return DetallePedidoDAO.Obtener(NroFactura);
        //}

        #endregion



        public bool CrearPedido(Pedido nuevoPedido)
        {
            return PedidoDAO.CrearParticipante(nuevoPedido);
        }

        public Cliente BuscarCliente(Cliente clien)
        {
            return ClienteDAO.BuscarCliente(clien);
        }

        public Medicamento ListarUnidadesxMedicamento(int id)
        {
            return MedicamentoDAO.ListarCantidadxMedicamento(id);
        }

        
    }
}
