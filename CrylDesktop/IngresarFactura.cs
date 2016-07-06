using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrylDesktop.CrylService;

namespace CrylDesktop
{
    public partial class IngresarFactura : Form
    {
        public static string num;
        
        
        public IngresarFactura()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ListaPedidos medicamento = new ListaPedidos();
            
            MenuPrincipal menus = new MenuPrincipal();
            medicamento.MdiParent = this.MdiParent;
            medicamento.Show();
            Close();
            
            
            


        }

        public void lblPedido_Click(object sender, EventArgs e)
        {

        }

        private void IngresarFactura_Load(object sender, EventArgs e)
        {
            lblPedido.Text = num;
        }
    }
}
