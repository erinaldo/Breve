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
    public partial class ReporteClientes : Form
    {
        public string Nombre { get; set; }
        public ReporteClientes()
        {
            InitializeComponent();
        }

        private void ReporteClientes_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DataSet1.datosclientes' Puede moverla o quitarla según sea necesario.
            this.datosclientesTableAdapter.Fill(this.DataSet1.datosclientes,Nombre);
            // TODO: esta línea de código carga datos en la tabla 'DataSet1.Reporte_Clientes_Abonos' Puede moverla o quitarla según sea necesario.
            this.Reporte_Clientes_AbonosTableAdapter.Fill(this.DataSet1.Reporte_Clientes_Abonos,Nombre);
            // TODO: esta línea de código carga datos en la tabla 'DataSet1.Reporte_Clientes_Adeudos' Puede moverla o quitarla según sea necesario.
            this.Reporte_Clientes_AdeudosTableAdapter.Fill(this.DataSet1.Reporte_Clientes_Adeudos,Nombre);

           
            this.reportViewer1.RefreshReport();
        }
    }
}
