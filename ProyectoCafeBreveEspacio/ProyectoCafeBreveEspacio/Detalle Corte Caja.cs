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
    public partial class Detalle_Corte_Caja : Form
    {
        Conexion c = new Conexion();
        public Detalle_Corte_Caja()
        {
            InitializeComponent();
        }

        private void Detalle_Corte_Caja_Load(object sender, EventArgs e)
        {
            
            int total = 0;
            c.CorteCaja(dataGridView1, DateTime.Now);
            lblVentas.Text = Convert.ToString(dataGridView1.RowCount);
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                total += Convert.ToInt32(row.Cells[1].Value);
            }
            lblTotal.Text = Convert.ToString(total);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Detalles_Venta dc = new Detalles_Venta();
            string aux = Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value);
            dc.txtVenta.Text = aux;
            dc.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
    }
}
