using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrylWeb.CrylWS;

namespace CrylWeb.Controllers
{
    public class ClienteController : Controller
    {
        //
        // GET: /Cliente/
        public ActionResult Index()
        {
            TransaccionClient proxy = new TransaccionClient();
            var listado = proxy.ListarCliente();
            return View(listado);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Cliente nuevoCliente)
        {
            var proxy = new TransaccionClient();
            proxy.CrearCliente(nuevoCliente);
            return RedirectToAction("Index");
        }

        public ActionResult Actualizar(int? CodCliente)
        {
            if (CodCliente.HasValue)
            {
                var proxy = new TransaccionClient();
                var emp = proxy.ObtenerCliente(CodCliente.Value);
                return View(emp);
            }
            else
            {
                return RedirectToAction("Index");
            }

        }
        [HttpPost]
        public ActionResult Actualizar(Cliente cliente)
        {
            var proxy = new TransaccionClient();
            proxy.ModificarCliente(cliente);
            return RedirectToAction("Index");
        }
	}
}