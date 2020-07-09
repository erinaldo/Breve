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
    public partial class Form1 : Form
    {
        private Form _Ajustes;
        public Form1()
        {
            InitializeComponent();
        }
        Conexion con = new Conexion();
        private void efectivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void creditoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Now.ToShortDateString();
        }

        private void eliminarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void nuevaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void corteCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }// no se usa

        private void buscarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void cancelarToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void verAdeudosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void abonarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void configuracionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void realizarCorteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void historialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void pagosToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ventasToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void eFECTIVOToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _Ajustes = new Venta_Efectivo
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill

            };
            panelAjustar.Controls.Clear();
            panelAjustar.Controls.Add(_Ajustes);
            _Ajustes.Show();
        }

        private void cREDITOToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           
        }

        private void cANCELARToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Cancelar_Venta cv = new Cancelar_Venta();
            panelAjustar.Controls.Clear();
            cv.Show();
        }

        private void aBONARToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Abonar abono = new Abonar();
            panelAjustar.Controls.Clear();
            abono.Show();
        }

        private void pAGOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void cREARCUENTAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _Ajustes = new Agregar_Cuenta
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill

            };
            panelAjustar.Controls.Clear();
            panelAjustar.Controls.Add(_Ajustes);
            _Ajustes.Show();
        }

        private void mODIFICAROELIMINARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _Ajustes = new Modificar_Cuenta
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill

            };
            panelAjustar.Controls.Clear();
            panelAjustar.Controls.Add(_Ajustes);
            _Ajustes.Show();
        }

        private void bUSCARToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _Ajustes = new Buscar_Cuenta
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill

            };
            panelAjustar.Controls.Clear();
            panelAjustar.Controls.Add(_Ajustes);
            _Ajustes.Show();
        }

        private void vERADEUDOSToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _Ajustes = new Clientes_con_Adeudos
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill

            };
            panelAjustar.Controls.Clear();
            panelAjustar.Controls.Add(_Ajustes);
            _Ajustes.Show();
        }

        private void aGREGARToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _Ajustes = new Agregar_Producto
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill

            };
            panelAjustar.Controls.Clear();
            panelAjustar.Controls.Add(_Ajustes);
            _Ajustes.Show();
        }

        private void mODIFICAROELIMINARToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _Ajustes = new Modificar_Producto
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill

            };
            panelAjustar.Controls.Clear();
            panelAjustar.Controls.Add(_Ajustes);
            _Ajustes.Show();
        }

        private void corteDeCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void rEALIZARCORTEToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _Ajustes = new Corte_Caja
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill

            };
            panelAjustar.Controls.Clear();
            panelAjustar.Controls.Add(_Ajustes);
            _Ajustes.Show();
        }

        private void vERHISTORIALToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _Ajustes = new Historial_Cortes
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill

            };
            panelAjustar.Controls.Clear();
            panelAjustar.Controls.Add(_Ajustes);
            _Ajustes.Show();
        }

        private void ventasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void rEALIZARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pagos p = new Pagos();
            panelAjustar.Controls.Clear();
            p.Show();
        }

        private void hISTORIALToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            _Ajustes = new Historial_Compras
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill

            };
            panelAjustar.Controls.Clear();
            panelAjustar.Controls.Add(_Ajustes);
            _Ajustes.Show();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
          
        }

        private void configuraciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _Ajustes = new Reportes
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill

            };
            panelAjustar.Controls.Clear();
            panelAjustar.Controls.Add(_Ajustes);
            _Ajustes.Show();
            
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            con.logout();
            Application.Exit();
        }
    }
}
