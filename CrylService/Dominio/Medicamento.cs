using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrylService.Dominio
{
    public class Medicamento
    {
        public int CodMedicamento { get; set; }
        public string NombreMedicamento { get; set; }
        public double PrecioUnidad { get; set; }
        public int UnidadesEnExistencia { get; set; }
    }
}