using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoCafeBreveEspacio
{
    public partial class Cancelar_Venta : Form
    {
        Conexion c = new Conexion();
        public Cancelar_Venta()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
           
        }//no se usa

        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }// no se usa

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (tablaCuentas.RowCount==0)
            {
                MessageBox.Show(this, "Debe de seleccionar la venta que desea cancelar","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                if ((MessageBox.Show(this, "Esta seguro que desea cancelar la venta", "CANCELAR VENTA", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)) == DialogResult.Yes)
                {
                    MessageBox.Show(c.Eliminar_Venta(Convert.ToInt32(lblID.Text)));
                    tablaCuentas.DataSource = null;
                    c.cancelar_venta(DateTime.Now, dataGridView1);
                }
            }
            
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void Cancelar_Venta_Load(object sender, EventArgs e)
        {
            c.cancelar_venta(DateTime.Now, dataGridView1);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Detalles_Venta dc = new Detalles_Venta();
            int aux = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            lblID.Text = Convert.ToString(aux);
            c.obtener_venta(aux, tablaCuentas);
        }
    }
}
