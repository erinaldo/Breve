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
    public partial class Agregar_Producto : Form
    {
        Conexion c = new Conexion();
        public Agregar_Producto()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }// no se usa

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }// no se usa

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (txtProducto.Text.Length>0 && txtPrecio.Text.Length>0)
            {
                MessageBox.Show(this,c.AgregarProducto(txtProducto.Text, Convert.ToInt32(txtPrecio.Text)),"EXITO",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                txtProducto.Text = "";
                txtPrecio.Text = "";
            }
            else
            {
                MessageBox.Show(this,"Favor de ingresar todos los datos","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
           
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
    }
}
