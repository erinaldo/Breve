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
    public partial class Historial_Cortes : Form
    {
        Conexion c = new Conexion();
        public Historial_Cortes()
        {
            InitializeComponent();
        }
        string meses;
        string dias;

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxMes.SelectedIndex==0 || cbxMes.SelectedIndex==2 || cbxMes.SelectedIndex==4 || cbxMes.SelectedIndex==6 || cbxMes.SelectedIndex==7 || cbxMes.SelectedIndex==9 || cbxMes.SelectedIndex==11)
            {
                cbxDia.Items.Clear();
                int cont=1;
                for (int i = 0; i < 31; i++)
                {
                    cbxDia.Items.Add(cont);
                    cont++;
                }
            }
            else
            {
                if (cbxMes.SelectedIndex==3 || cbxMes.SelectedIndex==5 || cbxMes.SelectedIndex==8 || cbxMes.SelectedIndex==10)
                {
                    cbxDia.Items.Clear();
                    int cont=1;
                    for (int i = 0; i < 30; i++)
                    {
                        cbxDia.Items.Add(cont);
                        cont++;
                    }
                }
                else
                {
                    cbxDia.Items.Clear();
                    int cont = 1;
                    for (int i = 0; i < 29; i++)
                    {
                        cbxDia.Items.Add(cont);
                        cont++;
                    }
                }
            }
        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            
        } // no se usa

        private void Historial_Cortes_Load(object sender, EventArgs e)
        {
            c.cargar_historial(tablaCortes);
            txtAño.Focus();
            txtAño.Text = DateTime.Now.Year.ToString();
            
        }
        string aux1;
        int aux2;
        private void btnBuscar_Click(object sender, EventArgs e)
        {
                
            if (cbxMes.Text.Length<=0 && cbxDia.Text.Length<=0)
            {
                c.buscar_historial_año(txtAño.Text, tablaCortes);
            }
            else if(txtAño.Text.Length<=0 && cbxDia.Text.Length<=0)
            {
                meses = mes(cbxMes.Text);
                c.buscar_historial_mes(meses, tablaCortes);
            }
            else if (cbxDia.Text.Length<=0)
            {
                meses = mes(cbxMes.Text);
                c.buscar_hidtorial_añoymes(txtAño.Text, meses, tablaCortes);
            }
            else
            {
                meses = mes(cbxMes.Text);
                aux2 = Convert.ToInt32(cbxDia.Text);
                dias = dia(aux2, cbxDia.Text);
                c.buscar_historial(txtAño.Text, meses, dias, tablaCortes);
            }
           
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)//no se usa
        {
           
        }

        public string mes(string mes)
        {
            if (mes=="Enero")
            {
                aux1 = "01";
            }
            if (mes == "Febrero")
            {
                aux1 = "02";
            }
            if (mes == "Marzo")
            {
                aux1 = "03";
            }
            if (mes == "Abril")
            {
                aux1 = "04";
            }
            if (mes == "Mayo")
            {
                aux1 = "05";
            }
            if (mes == "Junio")
            {
                aux1 = "06";
            }
            if (mes == "Julio")
            {
                aux1 = "07";
            }
            if (mes == "Agosto")
            {
                aux1 = "08";
            }
            if (mes == "Septiembre")
            {
                aux1 = "09";
            }
            if (mes == "Octubre")
            {
                aux1 = "10";
            }
            if (mes == "Noviembre")
            {
                aux1 = "11";
            }
            if (mes == "Diciembre")
            {
                aux1 = "12";
            }
            return aux1;
        }

        public string dia(int day, string dia)
        {
            if (day<10)
            {
                aux1 = "0" + dia;
            }
            else
            {
                aux1 = dia;
            }
            return aux1;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void btnExcell_Click(object sender, EventArgs e)
        {
            ExportarDataGridViewExcel(tablaCortes);
        }

        private void ExportarDataGridViewExcel(DataGridView grd)
        {
            SaveFileDialog fichero = new SaveFileDialog();
            fichero.Filter = "Excel (*.xls)|*.xls";
            if (fichero.ShowDialog() == DialogResult.OK)
            {
                Microsoft.Office.Interop.Excel.Application aplicacion;
                Microsoft.Office.Interop.Excel.Workbook libros_trabajo;
                Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo;
                aplicacion = new Microsoft.Office.Interop.Excel.Application();
                libros_trabajo = aplicacion.Workbooks.Add();
                hoja_trabajo =
                    (Microsoft.Office.Interop.Excel.Worksheet)libros_trabajo.Worksheets.get_Item(1);
                int IndiceColumna = 0;

                foreach (DataGridViewColumn col in grd.Columns)
                {
                    IndiceColumna++;
                    hoja_trabajo.Cells[1, IndiceColumna] = col.Name;
                }

                int IndiceFila = 0;

                foreach (DataGridViewRow row in grd.Rows)
                {
                    IndiceFila++;
                    IndiceColumna = 0;

                    foreach (DataGridViewColumn col in grd.Columns)
                    {
                        IndiceColumna++;

                        hoja_trabajo.Cells[IndiceFila + 1, IndiceColumna] = row.Cells[col.Name].Value;
                    }

                }
                libros_trabajo.SaveAs(fichero.FileName,
                    Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
                libros_trabajo.Close(true);
                aplicacion.Quit();
            }
        }

    }
}
