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
    public partial class ListaPedidos : Form
    {
        public static string NroPedido;

        public ListaPedidos()
        {
            InitializeComponent();
        }

        private void ListaMedicamentos_Load(object sender, EventArgs e)
        {
            TransaccionClient proxy = new TransaccionClient();
            proxy.Open();
            dgvMedicamentos.DataSource = proxy.ListarPedido();
        }

        private void dgvMedicamentos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

       IngresarFactura factura = new IngresarFactura();
       
           IngresarFactura.num = dgvMedicamentos.Rows[e.RowIndex].Cells[5].Value.ToString();
            
            IngresarFactura medicamento = new IngresarFactura();

            MenuPrincipal menus = new MenuPrincipal();
            medicamento.MdiParent = this.MdiParent;
            medicamento.Show();
            this.Hide();

        }

        private void dgvMedicamentos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvMedicamentos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
           
            

        }
    }
}
