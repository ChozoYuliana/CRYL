using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrylDesktop
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void mEDICAMENTOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
}

        private void fACTURAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IngresarFactura factura = new IngresarFactura();
            factura.MdiParent = this;
            factura.Show();
        }

        private void pEDIDOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pedidos pedido = new Pedidos();
            pedido.MdiParent = this;
            pedido.Show();
        }

        private void sTOCKToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void nUEVOPRODUCTOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NuevoMedicamento MEDI = new NuevoMedicamento();
            MEDI.MdiParent = this;
            MEDI.Show();
        }
    }
}
