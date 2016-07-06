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
    public partial class AgregarMedicamento : Form
    {
        public AgregarMedicamento()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
           

           
           
  
        }

        private void AgregarMedicamento_Load(object sender, EventArgs e)
        {
            TransaccionClient proxy = new TransaccionClient();
            proxy.Open();
            int cantidad = proxy.ListarMedicamento().Length;
            //txtCodMedicamento.Text = (cantidad + 1).ToString();

            cboMedicamento.DataSource = null;
            cboMedicamento.DataSource = proxy.ListarTodosMedicamentos();
            cboMedicamento.DisplayMember = "NombreMedicamento";
            cboMedicamento.ValueMember = "CodMedicamento";
        }
    }
}
