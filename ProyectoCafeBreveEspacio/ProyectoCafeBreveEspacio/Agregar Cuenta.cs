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
    public partial class Agregar_Cuenta : Form
    {
        Conexion c = new Conexion();
        public Agregar_Cuenta()
        {
            InitializeComponent();
        }

        private void Agregar_Cuenta_Load(object sender, EventArgs e)
        {

        }// no se usa

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (txtID.Text.Length>0 && txtNombre.Text.Length>0 && txtDireccion.Text.Length>0 && txtTelefono.Text.Length>0)
            {
                if (c.persona_registrada(txtID.Text) == 0)
                {
                    MessageBox.Show(this,c.insertar(txtID.Text, txtNombre.Text, txtDireccion.Text, txtTelefono.Text),"EXITO",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                    // c.abono_creacuenta(txtID.Text);
                    txtID.Text = "";
                    txtNombre.Text = "";
                    txtDireccion.Text = "";
                    txtTelefono.Text = "";
                }
                else
                {
                    MessageBox.Show(this,"Imposible de registrar, ya existe una persona con el mismo ID","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    txtID.Text = "";
                }
                
            }
            else
            {
                MessageBox.Show(this,"Favor de ingresar todos los datos para registrar","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
           
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

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {

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

        private void txtID_KeyUp(object sender, KeyEventArgs e)
        {
            txtTelefono.Text = txtID.Text;
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
