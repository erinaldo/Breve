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
    public partial class Detalles_Cuenta : Form
    {
        Conexion c = new Conexion();
        public Detalles_Cuenta()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }// no se usa

        private void Detalles_Cuenta_Load(object sender, EventArgs e)
        {
            c.buscar_cuenta(lblID.Text, tablaAdeudos);
            c.muestra_abono(lblID.Text, tablaAbonos);
            c.total_adeudo(tablaAdeudos, lblTotal, lblID.Text);
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
    }
}
