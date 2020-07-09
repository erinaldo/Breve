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
    public partial class Modificar_Producto : Form
    {
        Conexion c = new Conexion();
        public Modificar_Producto()
        {
            InitializeComponent();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (txtID.Text.Length>0 && txtPrecio.Text.Length>0 && txtProducto.Text.Length>0)
            {
                MessageBox.Show(this,c.ModificarProducto(Convert.ToInt32(txtID.Text), txtProducto.Text, Convert.ToInt32(txtPrecio.Text)),"EXITO",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                txtID.Text = "";
                txtProducto.Text = "";
                txtPrecio.Text = "";
                txtBuscar.Text = "";
                c.cargar_tablaProductos(tablaProductos);
                txtProducto.Enabled = false;
                txtPrecio.Enabled = false;
            }
            else
            {
                MessageBox.Show(this,"Favor de ingresar todos los datos","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
           
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
           /* MessageBox.Show(c.EliminarProducto(Convert.ToInt32(txtID.Text)));
            txtID.Text = "";
            txtProducto.Text = "";
            txtPrecio.Text = "";
            txtBuscar.Text = "";
            c.cargar_tablaProductos(tablaProductos);*/
        }

        private void tablaProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = tablaProductos.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtProducto.Text = tablaProductos.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtPrecio.Text = tablaProductos.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtPrecio.Enabled = true;
            txtProducto.Enabled = true;
        }

        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            c.key_up(txtBuscar.Text, tablaProductos);
        }

        private void Modificar_Producto_Load(object sender, EventArgs e)
        {
            c.cargar_tablaProductos(tablaProductos);
            txtID.Enabled = false;
            txtProducto.Enabled = false;
            txtPrecio.Enabled = false;
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

        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
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
