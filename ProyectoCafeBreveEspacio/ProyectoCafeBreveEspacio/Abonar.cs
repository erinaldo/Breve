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
    public partial class Abonar : Form
    {
        Conexion c = new Conexion();
        public Abonar()
        {
            InitializeComponent();
        }

        private void Abonar_Load(object sender, EventArgs e)
        {
            comboBox1.Focus();
        }

        private void btnAbonar_Click(object sender, EventArgs e)
        {
            if (txtAbono.Text.Length>0 && txtDireccion.Text.Length>0 && txtSaldo.Text.Length>0 && comboBox1.Text.Length>0)
            {
                c.abono(lblID.Text, Convert.ToInt32(txtAbono.Text), DateTime.Now);
                // c.abono_dia(comboBox1.Text, Convert.ToInt32(txtAbono.Text), DateTime.Now);
                int SaldoActual = Convert.ToInt32(txtSaldo.Text) - Convert.ToInt32(txtAbono.Text);
                if (SaldoActual == 0)
                {
                    c.eliminarAbonoLiquida(lblID.Text);
                    // c.eliminarAdeudo(lblID.Text);
                    MessageBox.Show("Cuenta Liquidada, El saldo actual es: " + SaldoActual);
                }
                else
                {
                    MessageBox.Show("El saldo actual es: " + SaldoActual);
                }
                this.Close();
            }
            else
            {
                MessageBox.Show(this,"Favor de ingresar todos los datos correspondientes","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
           
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            c.Completar_TextBox(comboBox1);
        }

        private void comboBox1_KeyUp(object sender, KeyEventArgs e)
        {
            c.completarTxtDireccion(comboBox1.Text, txtDireccion, lblID);
            if (txtDireccion.Text.Length>0)
            {
                c.totalAdeudo_Abonar(txtSaldo, comboBox1.Text);
                int aux = Convert.ToInt32(txtSaldo.Text);
                if (aux > 0)
                {
                    btnAbonar.Enabled = true;
                }
                else
                {
                    btnAbonar.Enabled = false;
                }
            }
        }

        private void comboBox1_Enter(object sender, EventArgs e)
        {
           
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            lblID.Text = "";
            txtDireccion.Text = "";
            txtSaldo.Text = "";
            txtAbono.Text = "";
        }

        private void txtAbono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("No se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
    }
}
