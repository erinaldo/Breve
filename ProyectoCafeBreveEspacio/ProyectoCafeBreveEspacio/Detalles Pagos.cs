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
    public partial class Detalles_Pagos : Form
    {
        Conexion c = new Conexion();
        public Detalles_Pagos()
        {
            InitializeComponent();
        }
        int total;
        private void Detalles_Pagos_Load(object sender, EventArgs e)
        {
            c.mostrar_detalles_pago(DateTime.Now, dataGridView1);
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                total += Convert.ToInt32(row.Cells[0].Value);
            }

            lblTotal.Text = Convert.ToString(total);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
    }
}
