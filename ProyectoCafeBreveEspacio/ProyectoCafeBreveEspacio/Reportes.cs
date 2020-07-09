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
    public partial class Reportes : Form
    {
        Conexion c = new Conexion();
        public Reportes()
        {
            InitializeComponent();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            
            string sqlFormattedDate = dtpFecha1.Value.ToString("yyyy-MM-dd HH:mm:ss");
            DateTime dt = Convert.ToDateTime(sqlFormattedDate);
            string  sqlFormattedDate2 = dtpFecha2.Value.ToString("yyyy-MM-dd HH:mm:ss");
            DateTime dt1 = Convert.ToDateTime(sqlFormattedDate2);
            ReporteCortesCajacs RCC= new ReporteCortesCajacs();
            RCC.Fecha = dt;
            RCC.Fecha2 = dt1;

            RCC.ShowDialog();

        }

        private void Reportes_Load(object sender, EventArgs e)
        {
            dtpFecha1.Format = DateTimePickerFormat.Custom;
            dtpFecha1.CustomFormat = ("yyyy-MM-dd HH:mm:ss");
            dtpFecha2.Format = DateTimePickerFormat.Custom;
            dtpFecha2.CustomFormat = ("yyyy-MM-dd HH:mm:ss");
        }

        private void btnAdeudos_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text.Length <=0)
            {
                MessageBox.Show(this, "Favor de ingresar el dato correspondiente", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                ReporteClientes RC = new ReporteClientes();
                RC.Nombre = comboBox1.Text;

                RC.ShowDialog();
            }
        }

        private void btnAbonos_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReporteProductos RP = new ReporteProductos();
            RP.ShowDialog();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            c.Completar_TextBox(comboBox1);
        }
    }
}
