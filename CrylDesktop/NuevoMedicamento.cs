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
    public partial class NuevoMedicamento : Form
    {
        public NuevoMedicamento()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtNombre.Enabled = true;
            txtPrecioUnidad.Enabled = true;
            txtUnidades.Enabled = true;
            btnGuardar.Enabled = true;
            btnNuevo.Enabled = false;

            TransaccionClient proxy = new TransaccionClient();
            proxy.Open();
            int cantidad = proxy.ListarTodosMedicamentos().Length+1;
            lblId.Text = cantidad.ToString();

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text.Length == 0)
            {
                MessageBox.Show("Debe ingresar el Nombre...!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtPrecioUnidad.Text.Length == 0)
            {
                MessageBox.Show("Debe ingresar el Precio...!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtUnidades.Text.Length == 0)
            {
                MessageBox.Show("Debe ingresar las Unidades...!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                TransaccionClient proxy = new TransaccionClient();
                proxy.Open();
                Medicamento medi = new Medicamento();

                double precio = Double.Parse(txtPrecioUnidad.Text) / 100;
                medi.NombreMedicamento = txtNombre.Text;
                medi.PrecioUnidad = precio;
                medi.UnidadesEnExistencia = int.Parse(txtUnidades.Text);
                DialogResult Confirmacion = MessageBox.Show("Esta seguro de Guardar los Cambios?", "CONFIRMACION", MessageBoxButtons.YesNo);
                if (Confirmacion == DialogResult.Yes)
                {
                    proxy.CrearMedicamento(medi);
                    MessageBox.Show("MEDICAMENTO AGREGADO CORRECTAMENTE","EXITO",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                    lblId.Text = "";
                    txtNombre.Text = "";
                    txtPrecioUnidad.Text = "";
                    txtUnidades.Text = "";

                    txtNombre.Enabled = false;
                    txtPrecioUnidad.Enabled = false;
                    txtUnidades.Enabled = false;
                    btnGuardar.Enabled = false;
                    btnNuevo.Enabled = true;

                }
                //else if (Confirmacion == DialogResult.No)
                //{
                   
                //}
                
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
