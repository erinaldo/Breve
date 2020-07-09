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
    public partial class DetallesCredito : Form
    {
        Conexion c = new Conexion();
        public DetallesCredito()
        {
            InitializeComponent();
        }

        private void DetallesCredito_Load(object sender, EventArgs e)
        {
            c.detalles_credito(DateTime.Now, dataGridView1);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
    }
}
