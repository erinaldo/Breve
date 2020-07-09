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
    public partial class Modificar_Cuenta : Form
    {
        Conexion c = new Conexion();
        public Modificar_Cuenta()
        {
            InitializeComponent();
        }

        private void Modificar_Cuenta_Load(object sender, EventArgs e)
        {
            c.cargar_tablacuentas(tablaCuentas);
            txtID.Enabled=false;
            txtNombre.Enabled = false;
            txtTelefono.Enabled = false;
            txtDireccion.Enabled = false;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (txtID.Text.Length>0 && txtNombre.Text.Length>0 && txtDireccion.Text.Length>0 && txtTelefono.Text.Length>0)
            {
                MessageBox.Show(this,c.actualizar(txtID.Text, txtNombre.Text, txtDireccion.Text, txtTelefono.Text),"EXITO",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                txtID.Text = "";
                txtNombre.Text = "";
                txtDireccion.Text = "";
                txtTelefono.Text = "";
                txtBuscar.Text = "";
                c.cargar_tablacuentas(tablaCuentas);
                txtNombre.Enabled = false;
                txtDireccion.Enabled = false;
                txtTelefono.Enabled = false;
            }
            else
            {
                MessageBox.Show(this,"Favor de ingresar todos los datos","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //c.eliminar_abono(txtID.Text);
            //c.eliminarAdeudo(txtID.Text);
            //MessageBox.Show(c.Eliminar(txtID.Text));
            txtID.Text = "";
            txtNombre.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            txtBuscar.Text = "";
            c.cargar_tablacuentas(tablaCuentas);
        } //NO EXISTE

        private void tablaCuentas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = tablaCuentas.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtNombre.Text = tablaCuentas.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtDireccion.Text = tablaCuentas.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtTelefono.Text = tablaCuentas.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtNombre.Enabled = true;
            txtDireccion.Enabled = true;
            txtTelefono.Enabled = true;
        }

        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            c.Key_up_Cuentas(txtBuscar.Text, tablaCuentas);
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
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

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Space))
            {
                MessageBox.Show("No se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
    }
}
