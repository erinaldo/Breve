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
    public partial class Detalles_Venta : Form
    {
        Conexion c = new Conexion();
        public Detalles_Venta()
        {
            InitializeComponent();
        }

        private void Detalles_Venta_Load(object sender, EventArgs e)
        {
            int total = 0;
            c.obtener_venta(Convert.ToInt32(txtVenta.Text), dataGridView1);
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                total += Convert.ToInt32(row.Cells[2].Value);
            }
            lblTotal.Text = Convert.ToString(total);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
    }
}
