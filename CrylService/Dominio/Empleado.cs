using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrylService.Dominio
{
    public class Empleado
    {
        public int CodEmpleado { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public int Dni { get; set; }
        public string Email { get; set; }
        public int Telefono { get; set; }
        public int Edad { get; set; }
        public string Sexo { get; set; }
        public string Cargo { get; set; }
    }
}