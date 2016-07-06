using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrylService.Persistencia
{
    public class ConexionUtil
    {
        public static String ObtenerCadena()
        {
            return "server=.;database=CRYL_ventas;integrated security=true";
            
        }
    }
}