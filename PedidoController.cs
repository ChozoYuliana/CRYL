using CrylWeb.CrylWS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrylWeb.Controllers
{
    public class PedidoController : Controller
    {
        //
        // GET: /Pedido/
        public ActionResult Index()
        {
            TransaccionClient proxy = new TransaccionClient();
            var listado = proxy.ListarPedido();
            return View(listado);
        }
        public ActionResult Crear()
        {
            var proxy = new TransaccionClient();
            var listaCliente = proxy.ListarCliente();
            ViewBag.CodCliente = new SelectList(listaCliente, "CodCliente", "Nombre");
            var listaEmpleado = proxy.ListarEmpleado();
            ViewBag.CodEmpleado = new SelectList(listaEmpleado, "CodEmpleado", "Nombre");


            return View();
        }

        [HttpPost]
        public ActionResult Crear(Pedido nuevoPedido, int CodCliente, int CodEmpleado)
        {
            var proxy = new TransaccionClient();
            var codcliente = proxy.ObtenerCliente(CodCliente);
            nuevoPedido.CodCliente = codcliente;
            var codempleado = proxy.ObtenerEmpleado(CodEmpleado);
            nuevoPedido.CodEmpleado = codempleado;
            proxy.CrearPedido(nuevoPedido);
            return RedirectToAction("Index");
        }

        public ActionResult Actualizar(int? NroPedido)
        {
            if (NroPedido.HasValue)
            {
                var proxy = new TransaccionClient();
                var listaCliente = proxy.ListarCliente();
                ViewBag.CodCliente = new SelectList(listaCliente, "CodCliente", "Nombre");
                var listaEmpleado = proxy.ListarEmpleado();
                ViewBag.CodEmpleado = new SelectList(listaEmpleado, "CodEmpleado", "Nombre");
                var emp = proxy.ObtenerPedido(NroPedido.Value);
                return View(emp);
            }
            else
            {
                return RedirectToAction("Index");
            }

        }
        [HttpPost]
        public ActionResult Actualizar(Pedido pedido, int CodCliente, int CodEmpleado)
        {
            var proxy = new TransaccionClient();
            var codcliente = proxy.ObtenerCliente(CodCliente);
            pedido.CodCliente = codcliente;
            var codempleado = proxy.ObtenerEmpleado(CodEmpleado);
            pedido.CodEmpleado = codempleado;
            proxy.ModificarPedido(pedido);
            return RedirectToAction("Index");
        }
	}
}