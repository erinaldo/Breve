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
    public partial class Pago : Form
    {
        public Pago()
        {
            InitializeComponent();
        }

        private void Pago_Load(object sender, EventArgs e)
        {

        }// no se usa

        private void txtEfectivo_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtEfectivo.Text.Length <= 0)
            {
                txtCambio.Text = "";
            }
            else
            {
                if (txtEfectivo.Text.Length <= 5)
                {
                    int aux = Convert.ToInt32(txtEfectivo.Text) - Convert.ToInt32(txtTotal.Text);
                    txtCambio.Text = Convert.ToString(aux);
                }
                else
                {
                    MessageBox.Show(this, "Favor de ingresar una cantidad valida", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
        }

        private void txtEfectivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            if (txtEfectivo.Text.Length<=0)
            {
                MessageBox.Show("Ingrese la cantidad");
                txtEfectivo.Focus();
            }
            else
            {
                this.Close();
                MessageBox.Show("Venta Finalizada");
            }
           
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void txtEfectivo_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
    }
}
