using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrylService.Dominio
{
    public class DetallePedido
    {
        public Pedido Pedi { get; set; }
        public Medicamento Medicamen { get; set; }
        public int Cantidad { get; set; }
        public double Descuento { get; set; }
        public int Factura { get; set; }


    }
}