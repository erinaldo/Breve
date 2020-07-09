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
    public partial class ReporteCortesCajacs : Form
    {
        public DateTime Fecha { get; set; }
        public DateTime Fecha2 { get; set; }
        public ReporteCortesCajacs()
        {
            InitializeComponent();
        }

        private void ReporteCortesCajacs_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DataSet1.Historial_CC' Puede moverla o quitarla según sea necesario.
            this.Historial_CCTableAdapter.Fill(this.DataSet1.Historial_CC,Fecha,Fecha2);

            this.reportViewer1.RefreshReport();
        }
    }
}
