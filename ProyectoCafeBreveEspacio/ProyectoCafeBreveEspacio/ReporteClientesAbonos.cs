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
    public partial class ReporteClientesAbonos : Form
    {
        public string Nombre { get; set; }
        public ReporteClientesAbonos()
        {
            InitializeComponent();
        }

        private void ReporteClientesAbonos_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DataSet1.Reporte_Clientes_Abonos' Puede moverla o quitarla según sea necesario.
            this.Reporte_Clientes_AbonosTableAdapter.Fill(this.DataSet1.Reporte_Clientes_Abonos,Nombre);

            this.reportViewer1.RefreshReport();
        }
    }
}
