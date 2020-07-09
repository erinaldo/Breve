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
    public partial class ReporteProductos : Form
    {
        public ReporteProductos()
        {
            InitializeComponent();
        }

        private void ReporteProductos_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DataSet1.productos' Puede moverla o quitarla según sea necesario.
            this.productosTableAdapter.Fill(this.DataSet1.productos);

            this.reportViewer1.RefreshReport();
        }
    }
}
