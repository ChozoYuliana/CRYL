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
    public partial class Pedidos : Form
    {
        public static int nro;
        public Pedidos()
        {
            InitializeComponent();
        }

        private void Pedidos_Load(object sender, EventArgs e)
        {
            TransaccionClient proxy = new TransaccionClient();
            dataGridView1.DataSource = proxy.ListarPedido();
        }

        private void btnVerDetalle_Click(object sender, EventArgs e)
        {

            TransaccionClient proxy = new TransaccionClient();
           
            Pedido pe = new Pedido();


            dataGridView2.DataSource = proxy.ListarxPedido(dataGridView1.CurrentRow.Cells[5].Value.ToString());
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //this.txt1.Text = Convert.ToString(this.dtg1.CurrentRow.Cells[0].Value);
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
