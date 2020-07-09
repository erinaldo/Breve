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
    public partial class Corte_Caja : Form
    {
        Conexion c = new Conexion();
        public Corte_Caja()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void label10_DoubleClick(object sender, EventArgs e)
        {
          
        }// no se usa

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (lblTotalVentas.Text.Length <= 0)
            {
                MessageBox.Show(this, "Realizar el Corte de Caja para Ver detalles", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (lblTotalVentas.Text == "0")
                {
                    MessageBox.Show(this, "No se realizo ninguna venta en el dia", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Detalle_Corte_Caja dcc = new Detalle_Corte_Caja();
                    dcc.Show();
                }
            }
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void detalle2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (lblTotalAbonos.Text.Length<=0)
            {
                MessageBox.Show(this, "Realizar el Corte de Caja para Ver detalles","ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (lblTotalAbonos.Text=="0")
                {
                    MessageBox.Show(this, "No se realizo ningun abono en el dia","INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Detalle_Corte_Abono dca = new Detalle_Corte_Abono();
                    dca.Show();
                    
                }
            }
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show(this, "Esta Seguro que desea finalizar el corte de caja","ADVERTENCIA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                c.insertar_historial(Convert.ToInt32(lblTotalAbonos.Text),Convert.ToInt32(lblTotalVentas.Text),Convert.ToInt32(lblCredito.Text),Convert.ToInt32(lblPagos.Text), Convert.ToInt32(lblTotalDia.Text), DateTime.Now);
                lblTotalVentas.Text = "";
                lblTotalAbonos.Text = "";
                lblCredito.Text = "";
                lblPagos.Text = "";
                lblTotalDia.Text = "";
            }
        }

        private void detalle_pagos_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (lblPagos.Text.Length <= 0)
            {
                MessageBox.Show(this, "Realizar el Corte de Caja para Ver detalles", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (lblPagos.Text == "0")
                {
                    MessageBox.Show(this, "No se realizo ningun pago en el dia", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Detalles_Pagos dp = new Detalles_Pagos();
                    dp.Show();
                }
            }
            
        }

        private void linkLabel2_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void Corte_Caja_Load(object sender, EventArgs e)
        {
            c.realizar_corte_ventas(DateTime.Now, lblTotalVentas);
            c.realizar_corte_abonos(DateTime.Now, lblTotalAbonos);
            c.realizar_corte_credito(DateTime.Now, lblCredito);
            c.realizar_corte_pagos(DateTime.Now, lblPagos);
            int suma = Convert.ToInt32(lblTotalAbonos.Text) + Convert.ToInt32(lblTotalVentas.Text) - Convert.ToInt32(lblPagos.Text);
            lblTotalDia.Text = Convert.ToString(suma);
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (lblTotalAbonos.Text.Length <= 0)
            {
                MessageBox.Show(this, "Realizar el Corte de Caja para Ver detalles", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (lblTotalAbonos.Text == "0")
                {
                    MessageBox.Show(this, "No se realizo ningun abono en el dia", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    DetallesCredito dca = new DetallesCredito();
                    dca.Show();
                }
            }
        }
    }
}
