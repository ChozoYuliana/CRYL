using CrylWeb.CrylWS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrylWeb.Controllers
{
    public class EmpleadoController : Controller
    {
        //
        // GET: /Empleado/
        public ActionResult Index()
        {
            TransaccionClient proxy = new TransaccionClient();
            var listado = proxy.ListarEmpleado();
            return View(listado);
        }
        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Crear(Empleado nuevoEmpleado)
        {
            var proxy = new TransaccionClient();
            proxy.CrearEmpleado(nuevoEmpleado);
            return RedirectToAction("Index");
        }

        public ActionResult Actualizar(int? CodEmpleado)
        {
            if (CodEmpleado.HasValue)
            {
                var proxy = new TransaccionClient();
                var emp = proxy.ObtenerEmpleado(CodEmpleado.Value);
                return View(emp);
            }
            else
            {
                return RedirectToAction("Index");
            }

        }
        [HttpPost]
        public ActionResult Actualizar(Empleado empleado)
        {
            var proxy = new TransaccionClient();
            proxy.ModificarEmpleado(empleado);
            return RedirectToAction("Index");
        }
	}
}