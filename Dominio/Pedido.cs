using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrylService.Dominio
{
    public class Pedido
    {
        public string NroPedido { get; set; }

        public Cliente Clien{ get; set; }
        public Empleado Emplea { get; set; }
        public DateTime FechaPedido { get; set; }
        public DateTime FechaEntrega { get; set; }
        public string DireccionDestinatario { get; set; }

        
    }
}