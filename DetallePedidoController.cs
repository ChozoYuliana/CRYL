using CrylWeb.CrylWS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrylWeb.Controllers
{
    public class DetallePedidoController : Controller
    {
        //
        // GET: /DetallePedido/
        public ActionResult Index()
        {
            TransaccionClient proxy = new TransaccionClient();
            var listado = proxy.ListarDetallePedido();
            return View(listado);
        }

        public ActionResult Crear()
        {
            var proxy = new TransaccionClient();
            var listaPedido = proxy.ListarPedido();
            ViewBag.NroPedido = new SelectList(listaPedido, "NroPedido", "NroPedido");
            var listaMedicamento = proxy.ListarMedicamento();
            ViewBag.CodMedicamento = new SelectList(listaMedicamento, "CodMedicamento", "NombreMedicamento");


            return View();
        }

        [HttpPost]
        public ActionResult Crear(DetallePedido nuevoDetallePedido, int NroPedido, int CodMedicamento)
        {
            var proxy = new TransaccionClient();
            var nropedido = proxy.ObtenerPedido(NroPedido);
            //nuevoDetallePedido.NroPedido = nropedido;
            var codmedicament = proxy.ObtenerMedicamentos(CodMedicamento);
            //nuevoDetallePedido.CodMedicamento = codmedicament;
            proxy.CrearDetallePedido(nuevoDetallePedido);
            return RedirectToAction("Index");
        }
	}
}