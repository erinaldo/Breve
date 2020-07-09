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
    public partial class Buscar_Cuenta : Form
    {
        Conexion c = new Conexion();
        public Buscar_Cuenta()
        {
            InitializeComponent();
        }

        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            c.Key_up_Cuentas(txtBuscar.Text, tablaCuentas);
        }

        private void tablaCuentas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Detalles_Cuenta dc = new Detalles_Cuenta();
            string aux = Convert.ToString(tablaCuentas.CurrentRow.Cells[0].Value);
            dc.lblID.Text = aux;
            dc.Show();
           
        }

        private void Buscar_Cuenta_Load(object sender, EventArgs e)
        {
            c.cargar_tablacuentas(tablaCuentas);
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
    }
}
