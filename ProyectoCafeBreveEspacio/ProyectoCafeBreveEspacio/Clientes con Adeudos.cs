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
    public partial class Clientes_con_Adeudos : Form
    {
        Conexion c = new Conexion();
        public Clientes_con_Adeudos()
        {
            InitializeComponent();
        }

        private void Clientes_con_Adeudos_Load(object sender, EventArgs e)
        {
            c.ver_adeudos(tablaCuentas);
        }

        private void tablaCuentas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Detalles_Cuenta da = new Detalles_Cuenta();
            string aux = Convert.ToString(tablaCuentas.CurrentRow.Cells[0].Value);
            da.lblID.Text = aux;
            da.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
    }
}
