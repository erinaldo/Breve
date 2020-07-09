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
    public partial class Pagos : Form
    {
        Conexion c = new Conexion();
        public Pagos()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnRealizar_Click(object sender, EventArgs e)
        {
            if (txtPago.Text.Length<=0 || txtDescripcion.Text.Length<=0)
            {
                MessageBox.Show(this,"Favor de ingresar la informacion correspondiente","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                if (txtPago.Text.Length<=5)
                {
                    MessageBox.Show(c.insertar_pago(Convert.ToInt32(txtPago.Text), txtDescripcion.Text, DateTime.Now));
                    txtPago.Text = "";
                    txtDescripcion.Text = "";
                }
                else
                {
                    MessageBox.Show(this, "Favor de ingresar una cantidad valida", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            
            }
        }

        private void Pagos_Load(object sender, EventArgs e)
        {
           
        }

        private void txtPago_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
