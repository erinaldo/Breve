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
    public partial class Detalle_Corte_Abono : Form
    {
        Conexion c = new Conexion();
        public Detalle_Corte_Abono()
        {
            InitializeComponent();
        }

        private void Detalle_Corte_Abono_Load(object sender, EventArgs e)
        {
            int total=0;
            c.CorteCajaAbonos(dataGridView1, DateTime.Now);
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                total += Convert.ToInt32(row.Cells[1].Value);
            }
            lblVentas.Text = Convert.ToString(total);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
            
            

        }
    }
}
