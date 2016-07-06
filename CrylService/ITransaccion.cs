using CrylService.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CrylService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "ITransaccion" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface ITransaccion
    {

        #region Cliente
        [OperationContract]
        Cliente CrearCliente(Cliente nuevoCliente);

        [OperationContract]
        IList<Cliente> ListarCliente();

        [OperationContract]
        Cliente ModificarCliente(Cliente clienteModificar);

        [OperationContract]
        Cliente ObtenerCliente(int CodCliente);

        [OperationContract]
        Cliente BuscarCliente(Cliente clien);

        [OperationContract]
        bool IniciarSesion(Cliente clien);
        #endregion

        #region Empleado
        [OperationContract]
        Empleado CrearEmpleado(Empleado nuevoEmpleado);

        [OperationContract]
        IList<Empleado> ListarEmpleado();

        [OperationContract]
        Empleado ModificarEmpleado(Empleado empleadoModificar);

        [OperationContract]
        Empleado ObtenerEmpleado(int CodEmpleado);
        #endregion

        #region Medicamento
        [OperationContract]
        Medicamento CrearMedicamento(Medicamento nuevoMedicamento);

        [OperationContract]
        IList<Medicamento> ListarMedicamento();

        [OperationContract]
        Medicamento ModificarMedicamento(Medicamento medicamentoModificar);

        [OperationContract]
        Medicamento ListarUnidadesxMedicamento(int id);

        [OperationContract]
        IList<Medicamento> ListarTodosMedicamentos();

        [OperationContract]
        Medicamento ObtenerMedicamentos(int CodMedicamento);
        #endregion

        #region Pedido
        [OperationContract]
        IList<Pedido> ListarPedido();

        [OperationContract]
        bool CrearPedido(Pedido nuevoPedido);

       
        //Pedido ModificarPedido(Pedido pedidoModificar);

        //[OperationContract]
        //Pedido ObtenerPedido(string nropedido);
        [OperationContract]
        Pedido ObtenerPedido(string NroPedido);
        #endregion

        #region DetallePedido
        //[OperationContract]
        //IList<DetallePedido> ListarDetallePedido();

        [OperationContract]
        bool CrearDetallePedido(DetallePedido nuevoDetallePedido);
        [OperationContract]
        IList<DetallePedido> ListarxPedido(string idpedido);

        //[OperationContract]
        //DetallePedido ModificarDetallePedido(DetallePedido detallePedidoModificar);

        //[OperationContract]
        //DetallePedido ObtenerDetallePedido(int NroFactura);
        #endregion

    }
}
