using System;
using System.Collections;
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
    public partial class Venta_Efectivo : Form
    {
        Conexion c = new Conexion();
        public Venta_Efectivo()
        {
            InitializeComponent();
        }

        private void Venta_Efectivo_Load(object sender, EventArgs e)
        {
            c.cargar_tablaProductos(tablaProductos);
        }

        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            c.key_up(txtBuscar.Text, tablaProductos);
        }

        int totalf,aux1;
        bool flag = false;
        ArrayList venta = new ArrayList();
        ArrayList Precio = new ArrayList();
        ArrayList ventaCant = new ArrayList();
       
        private void tablaProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int aux = Convert.ToInt32(tablaProductos.CurrentRow.Cells[0].Value);
            venta.Add(aux);
            int aux2 = Convert.ToInt32(tablaProductos.CurrentRow.Cells[2].Value);
            Precio.Add(aux2);

           
                int total = 0;
                int cant = 0;


                                if (dataGridView1.Rows.Count>0)
                                {
                                    foreach (DataGridViewRow row in dataGridView1.Rows)
                                    {
                                        if (Convert.ToInt32(row.Cells[0].Value)==aux)
                                        {
                                            row.Cells[3].Value = Convert.ToString(Convert.ToInt32(row.Cells[3].Value) + 1);
                                            flag = true;
                                        }
                                    }
                                    if (!flag)
                                    {
                                        dataGridView1.Rows.Add(new string[] {
                                Convert.ToString(tablaProductos[0, tablaProductos.CurrentRow.Index].Value),
                                Convert.ToString(tablaProductos[1, tablaProductos.CurrentRow.Index].Value),
                                Convert.ToString(tablaProductos[2, tablaProductos.CurrentRow.Index].Value),
                                Convert.ToString(1)
                    });
                                        
                                    }
                                    flag = false;
                                }
                                else
                                {
                                    dataGridView1.Rows.Add(new string[] {
                                Convert.ToString(tablaProductos[0, tablaProductos.CurrentRow.Index].Value),
                                Convert.ToString(tablaProductos[1, tablaProductos.CurrentRow.Index].Value),
                                Convert.ToString(tablaProductos[2, tablaProductos.CurrentRow.Index].Value),
                                Convert.ToString(1)
                    });
                                }
                                foreach (DataGridViewRow row in dataGridView1.Rows)
                                {

                                    total += Convert.ToInt32(row.Cells[2].Value) * Convert.ToInt32(row.Cells[3].Value);

                                }
                                lblTotal.Text = Convert.ToString(total);

        }

        int contador;
        private void btnVenta_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount==0)
            {
                MessageBox.Show(this,"No se ha seleccionado ningun producto para vender","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                Pago pagar = new Pago();
                contador = c.Contador_Venta();
                c.venta(contador, venta, Precio, DateTime.Now);
                dataGridView1.Rows.Clear();
                venta.Clear();
                contador++;
                c.Actualizar_Contador(contador);
                pagar.txtTotal.Text = lblTotal.Text;
                pagar.Show();
                lblTotal.Text = "";
                totalf = 0;
                comboBox1.Text = "";
                txtDireccion.Text = "";
                lblID.Text = "";
                txtBuscar.Text = "";
                c.cargar_tablaProductos(tablaProductos);
                Precio.Clear();
            }
           
        }

        private void comboBox1_KeyUp(object sender, KeyEventArgs e)
        {
            c.completarTxtDireccion(comboBox1.Text, txtDireccion, lblID);
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            c.Completar_TextBox(comboBox1);
            lblID.Text = "";
            txtDireccion.Text = "";
        }

        private void tablaProductos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnCredito_Click(object sender, EventArgs e)
        {
            if (lblID.Text.Length > 0)
            {
                if (c.persona_registrada(lblID.Text) == 1)
                {
                    if (dataGridView1.RowCount == 0)
                    {
                        MessageBox.Show(this, "No se ha seleccionado ningun producto para vender", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        contador = c.Contador_Venta();
                        c.adeudos(contador, venta, Precio, DateTime.Now, lblID.Text);
                        MessageBox.Show("Venta Completada");
                        dataGridView1.Rows.Clear();
                        lblID.Text = "";
                        venta.Clear();
                        contador++;
                        c.Actualizar_Contador(contador);
                        comboBox1.Text = "";
                        txtDireccion.Text = "";
                        txtBuscar.Text = "";
                        lblID.Text = "";
                        lblTotal.Text = "";
                        totalf = 0;
                        c.cargar_tablaProductos(tablaProductos);
                        Precio.Clear();
                    }
                }
            }
                else
                {
                    if (lblID.Text == "")
                    {
                        MessageBox.Show(this,"Favor de ingresar una cuenta","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show(this,"No existe la cuenta ingresada, por favor ingrese una cuenta existente","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        lblID.Text = "";
                    }

                }
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void tablaProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount==0)
            {
                MessageBox.Show(this,"No hay nada que eliminar","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show(this, "Esta seguro que desea cancelar la venta", "ADVERTENCIA", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    dataGridView1.Rows.Clear();
                    lblTotal.Text = "";
                    venta.Clear();
                    Precio.Clear();
                }
            }
            
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            bool bandera = true;
            if (MessageBox.Show(this, "Desea Eliminar el Producto de la Venta", "QUITAR PRODUCTO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (Convert.ToInt32(dataGridView1.CurrentRow.Cells[3].Value) > 1)
                {
                    dataGridView1.CurrentRow.Cells[3].Value = Convert.ToString(Convert.ToInt32(dataGridView1.CurrentRow.Cells[3].Value) - 1);
                    int ip = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                    
                    for (int i = 0; i < venta.Count; i++)
                    {
                        if (Convert.ToInt32(venta[i])==ip && bandera==true)
                        {
                            venta.RemoveAt(i);
                            Precio.RemoveAt(i);
                            bandera = false;
                        }
                        
                    }
                    
                    int total = 0;
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        total += Convert.ToInt32(row.Cells[2].Value)*Convert.ToInt32(row.Cells[3].Value);
                    }
                    lblTotal.Text = Convert.ToString(total);
                }
                else
                {
                    bool bandera1 = true;
                    
                    int ip = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);

                    for (int i = 0; i < venta.Count; i++)
                    {
                        if (Convert.ToInt32(venta[i]) == ip && bandera1 == true)
                        {
                            venta.RemoveAt(i);
                            Precio.RemoveAt(i);
                            bandera = false;
                        }

                    }
                    dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
                   
                    int total = 0;
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        total += Convert.ToInt32(row.Cells[2].Value) * Convert.ToInt32(row.Cells[3].Value);
                    }
                    lblTotal.Text = Convert.ToString(total);
                }
            }
            
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Space))
            {
                MessageBox.Show("No se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            lblID.Text = "";
            txtDireccion.Text = "";
        }
    }
}
