using CrylWeb.CrylWS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrylWeb.Controllers
{
    public class MedicamentoController : Controller
    {
        //
        // GET: /Medicamento/
        public ActionResult Index()
        {
            TransaccionClient proxy = new TransaccionClient();
            var listado = proxy.ListarMedicamento();
            return View(listado);
        }

        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Crear(Medicamento nuevoMedicamento)
        {
            var proxy = new TransaccionClient();
            proxy.CrearMedicamento(nuevoMedicamento);
            return RedirectToAction("Index");
        }

        public ActionResult Actualizar(int? CodMedicamento)
        {
            if (CodMedicamento.HasValue)
            {
                var proxy = new TransaccionClient();
                var emp = proxy.ObtenerMedicamentos(CodMedicamento.Value);
                return View(emp);
            }
            else
            {
                return RedirectToAction("Index");
            }

        }
        [HttpPost]
        public ActionResult Actualizar(Medicamento medicamento)
        {
            var proxy = new TransaccionClient();
            proxy.ModificarMedicamento(medicamento);
            return RedirectToAction("Index");
        }
	}
}