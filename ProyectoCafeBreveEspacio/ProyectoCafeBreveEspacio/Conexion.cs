using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Collections;

namespace ProyectoCafeBreveEspacio
{
    class Conexion
    {
        SqlConnection cn;
        SqlCommand cmd, cmp;
        SqlDataReader dr;
        int contador = 0;

        public Conexion()
        {
            try
            {
                cn = new SqlConnection("Data Source=.;Initial Catalog=BreveEspacioCafe;integrated security=yes");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se conecto con la base de datos: " + ex);
            }
        }

        public bool cone(string x, string y)
        {
            bool aux = false;
            try
            {
                login(x);
                cn.Open();
                cmd = new SqlCommand("select * from usuarios where usuario ='" + x + "' and contraseña='" + y + "'", cn);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    aux = true;
                }
                else
                {
                    MessageBox.Show("usuario o contaseña incorrecta");
                }

                dr.Close();
                cn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return aux;
        }

        public void login(string x)
        {
            try
            {
                cn.Open();
                cmd = new SqlCommand("insert into logged(usuario, usuario_sistema) values ('" + x + "',system_user)", cn);
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void logout()
        {
            try
            {
                cn.Open();
                cmd = new SqlCommand("delete from logged where usuario_sistema= system_user", cn);
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public string insertar(string ID, string nombre, string direccion, string telefono)// crea la cuenta
        {

            string salida = "Registrado Exitosamente";
            try
            {
                cn.Open();
                cmd = new SqlCommand("insert into Clientes(id_cliente,nombre,direccion, telefono)values('" + ID + "','" + nombre + "','" + direccion + "','" + telefono + "')", cn);
                cmd.ExecuteNonQuery();
                cn.Close();
            }

            catch (Exception ex)
            {
                salida = "No se conecto: " + ex.ToString();
            }
            return salida;
        }

        public int persona_registrada(string ID)// verifica si existe una cuenta con el mismo id
        {

            int contador = 0;
            try
            {
                cn.Open();
                cmd = new SqlCommand("select * from clientes where id_cliente like '" + ID + "'", cn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    contador++;
                }
                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo consultar: " + ex.ToString());
            }
            return contador;
        }

        /*public void abono_creacuenta(string id)
        {
            int abono = 0;
            try
            {
                cn.Open();
                cmd = new SqlCommand("insert into abonos(id_cliente,abono)values('" + id + "'," + abono + ")", cn);
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }//se crea el abono al crear la cuenta */

        public string actualizar(string ID, string Nombre, string Direccion, string telefono)//modifica cuenta
        {

            string salida = "se actualizaron los datos";
            try
            {
                cn.Open();
                cmd = new SqlCommand("Update clientes set Nombre='" + Nombre + "', direccion='" + Direccion + "' ,telefono='" + telefono + "' where id_cliente like'" + ID + "'", cn);
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            catch (Exception ex)
            {
                salida = "No se actualizo" + ex.ToString();
            }
            return salida;
        }

        /*public void eliminar_abono(string id)
        {
            try
            {
                cn.Open();
                cmd = new SqlCommand("Delete from abonos where id_cliente like'%" + id + "'", cn);
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }//Elimina abono para cuenta */

        /*public string Eliminar(string ID)// Elimina cuenta
        {

            string salida = "se elimino correctamente";
            try
            {
                cn.Open();
                cmd = new SqlCommand("Delete from clientes where id_cliente like'%" + ID + "'", cn);
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            catch (Exception ex)
            {
                salida = "No se pudo eliminar: " + ex.ToString();
            }
            return salida;
        }*/

        public string AgregarProducto(string producto, int precio)
        {
            string salida = "Se ha agregado el producto correctamente";

            try
            {
               // insert into logged(id,usuario, usuario_sistema) values ((select max(id)+1 from logged),'" + x + "',system_user)", cn);
                cn.Open();
                cmd = new SqlCommand("insert into productos(nombreproducto,precio)values('" + producto + "'," + precio + ")", cn);
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            catch (Exception ex)
            {
                salida = "No se ha podido ingresar por: " + ex.ToString();
            }
            return salida;
        }

        public string ModificarProducto(int id, string producto, int precio)
        {
            string salida = "Se actualizaron los datos";
            try
            {
                cn.Open();
                cmd = new SqlCommand("update productos set nombreproducto='" + producto + "', precio=" + precio + " where id_producto=" + id + "", cn);
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            catch (Exception ex)
            {
                salida = "No se pudieron actualizar los datos: " + ex.ToString();
            }
            return salida;
        }

        /* public string EliminarProducto(int id)
         {
             string salida = "Producto Eliminado";
             try
             {
                 cn.Open();
                 cmd = new SqlCommand("Delete from productos where id_producto like'%" + id + "'", cn);
                 cmd.ExecuteNonQuery();
                 cn.Close();
             }
             catch (Exception ex)
             {
                 salida = "No se pudo eliminar: " + ex.ToString();
             }
             return salida;
         }*/

        public void key_up(string txtNombre, DataGridView dgt)//buscador de productos
        {

            try
            {
                cn.Open();
                SqlCommand cmp = cn.CreateCommand();
                cmp.CommandType = CommandType.Text;
                cmp.CommandText = "select * from ventas where nombreproducto like ('%" + txtNombre + "%')";
                cmp.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmp);
                da.Fill(dt);

                dgt.DataSource = dt;
                cn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        public void Key_up_Cuentas(string nombre, DataGridView dgt)// buscador de cuentas
        {
            try
            {
                cn.Open();
                SqlCommand cmp = cn.CreateCommand();
                cmp.CommandType = CommandType.Text;
                cmp.CommandText = "select * from vistaclientes where nombre like '%" + nombre + "%'";
                cmp.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmp);
                da.Fill(dt);

                dgt.DataSource = dt;
                cn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void cargar_tablacuentas(DataGridView dgt)
        {
            try
            {
                cn.Open();
                SqlCommand cmp = cn.CreateCommand();
                cmp.CommandType = CommandType.Text;
                cmp.CommandText = "select * from vistaclientes";
                cmp.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmp);
                da.Fill(dt);

                dgt.DataSource = dt;
                cn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }// llena las tablas de cuentas al abrir la forma

        public void cargar_tablaProductos(DataGridView dgt)
        {
            try
            {
                cn.Open();
                SqlCommand cmp = cn.CreateCommand();
                cmp.CommandType = CommandType.Text;
                cmp.CommandText = "select * from ventas";
                cmp.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmp);
                da.Fill(dt);

                dgt.DataSource = dt;
                cn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }// llena las tablas de productos al abrir la forma

        public int Contador_Venta()// obtiene el id_venta para la tabla venta
        {
            string str;
            int aux = 1;
            try
            {
                cn.Open();
                cmd = new SqlCommand("select conta from contador where id_cont=" + aux + "", cn);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    str = dr["Conta"].ToString();
                    contador = Convert.ToInt32(str);
                }

                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return contador;
        }

        public void Actualizar_Contador(int contador)//aumenta el id de la tabla venta
        {
            int aux = 1;
            try
            {
                cn.Open();
                cmd = new SqlCommand("update contador set conta=" + contador + " where id_cont=" + aux + "", cn);
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void venta(int aux, ArrayList ventas, ArrayList precio, DateTime fecha)//Registra la venta
        {
            string estado = "Realizada";
            string sqlFormattedDate = fecha.ToString("yyyy-MM-dd HH:mm:ss");
            try
            {
                for (int i = 0; i < ventas.Count; i++)
                {
                    cn.Open();
                    cmd = new SqlCommand("insert into venta(id_venta,id_producto,precio,fecha_venta,estado)values(" + aux + "," + ventas[i] + "," + precio[i] + ",'" + sqlFormattedDate + "','" + estado + "')", cn);
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Completar_TextBox(ComboBox cb)
        {
            try
            {
                cn.Open();
                cmd = new SqlCommand("select nombre from clientes", cn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cb.AutoCompleteCustomSource.Add(dr["nombre"].ToString());
                }
                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }//llena el combobox de ventas

        public void completarTxtDireccion(string nombre, TextBox txt, Label lbl)
        {
            try
            {
                cn.Open();
                cmd = new SqlCommand("select direccion, id_cliente from clientes where nombre='" + nombre + "'", cn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    txt.Text = dr["direccion"].ToString();
                    lbl.Text = dr["id_cliente"].ToString();
                }
                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }//llena el textbox direccion de ventas

        public void adeudos(int aux, ArrayList adeudo, ArrayList precio, DateTime fecha, string id)//registra la venta cuando es a credito
        {
            string estdos = "Adeudo";
            string sqlFormattedDate = fecha.ToString("yyyy-MM-dd HH:mm:ss");
            try
            {
                for (int i = 0; i < adeudo.Count; i++)
                {
                    cn.Open();
                    cmd = new SqlCommand("insert into adeudo(id_adeudo,id_cliente,id_producto,precio,fecha_adeudo, estado)values(" + aux + ",'" + id + "'," + adeudo[i] + "," + precio[i] + ",'" + sqlFormattedDate + "','" + estdos + "')", cn);
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void obtener_venta(int id, DataGridView dgt)//obtiene la venta para despues eliminarla
        {
            try
            {
                cn.Open();
                SqlCommand cmp = cn.CreateCommand();
                cmp.CommandType = CommandType.Text;
                cmp.CommandText = "select id_producto, nombreproducto, precio from detallesventa where id_venta=" + id + " and estado='realizada'";
                cmp.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmp);
                da.Fill(dt);

                dgt.DataSource = dt;
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public string Eliminar_Venta(int id)
        {
            string salida = "Se ha Cancelado la venta correctamente";
            try
            {
                cn.Open();
                cmd = new SqlCommand("Update venta set estado = 'Cancelada' where id_venta=" + id + "", cn);
                cmd.ExecuteNonQuery();
                cn.Close();

            }
            catch (Exception ex)
            {
                salida = "No se pudo cancelar " + ex.ToString();
            }
            return salida;
        }//cancela o elimina una venta

        public void buscar_cuenta(string id, DataGridView dgt)//busca la cuenta para observar cuando debe el cliente
        {
            try
            {
                cn.Open();
                SqlCommand cmp = cn.CreateCommand();
                cmp.CommandType = CommandType.Text;
                cmp.CommandText = "select estado, fecha_adeudo, nombreproducto, precio,id_producto from detallescuenta where id_cliente like '" + id + "' order by estado";
                cmp.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmp);
                da.Fill(dt);

                dgt.DataSource = dt;
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void total_adeudo(DataGridView dgt, Label lbl, string id)//calcula el total a pagar de los adeudos
        {
            int total = 0, totalf = 0;
            Label lbl2 = new Label();
            try
            {
                foreach (DataGridViewRow row in dgt.Rows)
                {
                    total += Convert.ToInt32(row.Cells[3].Value);
                }

                obtener_abono(id, lbl2);
                totalf = total - Convert.ToInt32(lbl2.Text);
                lbl.Text = Convert.ToString(totalf);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void obtener_abono(string str, Label lbl)
        {
            try
            {
                cn.Open();
                cmd = new SqlCommand("select sum(abono)suma from abonos where id_cliente='" + str + "'", cn);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    lbl.Text = dr["suma"].ToString();
                }
                if (lbl.Text == "")
                {
                    lbl.Text = Convert.ToString(0);
                }

                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            // return aux;
        }//obtiene los abono que ha hecho el cliente

        public void muestra_abono(string id, DataGridView dgt)//muestra los abonos realizados por los clientes
        {
            try
            {
                cn.Open();
                SqlCommand cmp = cn.CreateCommand();
                cmp.CommandType = CommandType.Text;
                cmp.CommandText = "select abono, fecha_abono from  abonos where id_cliente = '" + id + "' and abono>0";
                cmp.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmp);
                da.Fill(dt);

                dgt.DataSource = dt;
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ver_adeudos(DataGridView dgt)
        {
            try
            {
                cn.Open();
                SqlCommand cmp = cn.CreateCommand();
                cmp.CommandType = CommandType.Text;
                cmp.CommandText = "select * from adeudos1 where estado='adeudo'";
                cmp.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmp);
                da.Fill(dt);

                dgt.DataSource = dt;
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }// muestra los clientes que tienen adeudos

        public void abono(string id, int abono, DateTime fecha)
        {
            string sqlFormattedDate = fecha.ToString("yyyy-MM-dd HH:mm:ss");
            try
            {
                cn.Open();
                cmd = new SqlCommand("insert into abonos(id_cliente,abono,fecha_abono)values('" + id + "'," + abono + ",'" + sqlFormattedDate + "')", cn);
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }//registra el abono

        /* public void abono_dia(string nombre, int abono, DateTime fecha)
         {
             string sqlFormattedDate = fecha.ToString("yyyy-MM-dd HH:mm:ss");
             try
             {
                 cn.Open();
                 cmd = new SqlCommand("insert into abono_dia(nombre,abono,fecha_abono)values('" + nombre + "'," + abono + ",'" + sqlFormattedDate + "')", cn);
                 cmd.ExecuteNonQuery();
                 cn.Close();
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }
         }//registra el abono cc */

        public void eliminarAbonoLiquida(string id)
        {
            try
            {
                cn.Open();
                cmd = new SqlCommand("Update adeudo set estado = 'Pagado' where id_cliente='" + id + "'", cn);
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }//elimina los abonos hechos al liquidar

        /* public void eliminarAdeudo(string id)
         {
             try
             {
                 cn.Open();
                 cmd = new SqlCommand("delete from adeudos where id_cliente=" + id + "", cn);
                 cmd.ExecuteNonQuery();
                 cn.Close();
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }
         }// elimina el adeudo al liquidar */

        public string total;
        public void totalAdeudo_Abonar(TextBox txt, string nombre)
        {
            Label lbl = new Label();
            int totalf = 0;
            try
            {
                cn.Open();
                cmd = new SqlCommand("select sum(a.precio)suma from adeudo a,clientes c where c.nombre='" + nombre + "' and c.id_cliente= a.id_cliente", cn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    total = dr["suma"].ToString();
                }
                dr.Close();
                obtenerAbono_Abonar(nombre, lbl);
                if (total == "")
                {
                    total = Convert.ToString(0);
                }
                totalf = Convert.ToInt32(total) - Convert.ToInt32(lbl.Text);
                if (totalf < 0)
                {
                    txt.Text = Convert.ToString(0);
                }
                else
                {
                    txt.Text = Convert.ToString(totalf);
                }

                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }// form abonos

        public void obtenerAbono_Abonar(string str, Label lbl)
        {
            try
            {
                cmp = new SqlCommand("select sum(abono)suma from abonos a,clientes c where c.id_cliente= a.id_cliente and c.nombre='" + str + "'", cn);
                dr = cmp.ExecuteReader();
                if (dr.Read())
                {
                    lbl.Text = dr["suma"].ToString();
                }
                if (lbl.Text == "")
                {
                    lbl.Text = Convert.ToString(0);
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }// form abonos

        public void CorteCaja(DataGridView dgt, DateTime fecha)//realiza el corte de caja
        {
            string sqlFormattedDate = fecha.ToString("yyyy-MM-dd HH:mm:ss");
            string sqlFormattedDate2 = fecha.ToString("yyyy-MM-dd 00:00:00");
            try
            {
                cn.Open();
                SqlCommand cmp = cn.CreateCommand();
                cmp.CommandType = CommandType.Text;
                cmp.CommandText = "select id_venta, sum(v.precio)Total_Venta from productos p, venta v where v.id_producto=p.id_producto and fecha_venta between '" + sqlFormattedDate2 + "' and '" + sqlFormattedDate + "' and estado='realizada' group by id_venta";
                cmp.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmp);
                da.Fill(dt);

                dgt.DataSource = dt;
                cn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void CorteCajaAbonos(DataGridView dgt, DateTime fecha)
        {
            string sqlFormattedDate = fecha.ToString("yyyy-MM-dd HH:mm:ss");
            string sqlFormattedDate2 = fecha.ToString("yyyy-MM-dd 00:00:00");
            try
            {
                cn.Open();
                SqlCommand cmp = cn.CreateCommand();
                cmp.CommandType = CommandType.Text;
                cmp.CommandText = "select nombre, abono, fecha_abono from corteAbonos where fecha_abono between '" + sqlFormattedDate2 + "' and '" + sqlFormattedDate + "'";
                cmp.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmp);
                da.Fill(dt);

                dgt.DataSource = dt;
                cn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void realizar_corte_ventas(DateTime fecha, Label lbl)
        {
            string sqlFormattedDate = fecha.ToString("yyyy-MM-dd HH:mm:ss");
            string sqlFormattedDate2 = fecha.ToString("yyyy-MM-dd 00:00:00");
            try
            {
                cn.Open();
                cmd = new SqlCommand("select sum(v.precio)suma from venta v, productos p where fecha_venta between '" + sqlFormattedDate2 + "' and '" + sqlFormattedDate + "' and v.id_producto= p.id_producto and v.estado='Realizada'", cn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lbl.Text = dr["suma"].ToString();
                }
                if (lbl.Text == "")
                {
                    lbl.Text = Convert.ToString(0);
                }
                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }//ventas del dia

        public void realizar_corte_abonos(DateTime fecha, Label lbl)
        {
            string sqlFormattedDate = fecha.ToString("yyyy-MM-dd HH:mm:ss");
            string sqlFormattedDate2 = fecha.ToString("yyyy-MM-dd 00:00:00");
            try
            {
                cn.Open();
                cmd = new SqlCommand("select sum(abono)suma from abonos where fecha_abono between '" + sqlFormattedDate2 + "' and '" + sqlFormattedDate + "' ", cn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lbl.Text = dr["suma"].ToString();
                }
                if (lbl.Text == "")
                {
                    lbl.Text = Convert.ToString(0);
                }
                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }// abonos realizados en el dia

        /*  public void eliminar_abono_diario()
          {
              try
              {
                  cn.Open();
                  cmd = new SqlCommand("delete from abono_dia",cn);
                  cmd.ExecuteNonQuery();
                  cn.Close();
              }
              catch (Exception ex)
              {
                  MessageBox.Show(ex.Message);
              }
          } //elimina el abono al hacer el corte */

        /*  public void eliminar_ventas_diarias()
          {
              try
              {
                  cn.Open();
                  cmd = new SqlCommand("Delete from venta",cn);
                  cmd.ExecuteNonQuery();
                  cn.Close();
              }
              catch (Exception ex)
              {
                  MessageBox.Show(ex.Message);
              }
          }// elimina las ventas al realizar el crte de caja */


        public void insertar_historial(int abono, int venta, int credito, int pagos, int total, DateTime fecha)
        {
            string sqlFormattedDate = fecha.ToString("yyyy-MM-dd HH:mm:ss");
            try
            {
                cn.Open();
                cmd = new SqlCommand("insert into historial_CorteCaja (total_abonos, total_ventas,total_credito,total_pago, total_dia, fecha_corte)values(" + abono + "," + venta + "," + credito + "," + pagos + "," + total + ",'" + sqlFormattedDate + "')", cn);
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }// crea una tabla para el corte diario de la caja

        public void cargar_historial(DataGridView dgt)
        {

            try
            {
                cn.Open();
                SqlCommand cmp = cn.CreateCommand();
                cmp.CommandType = CommandType.Text;
                cmp.CommandText = "select * from historialcc order by fecha_corte desc";
                cmp.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmp);
                da.Fill(dt);

                dgt.DataSource = dt;
                cn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }// muestra la tabla historial de cortes de caja

        public void buscar_historial(string año, string mes, string dia, DataGridView dgt)
        {
            string sqlFormattedDate = (año + mes + dia + " 00:00:00");
            string sqlFormattedDate2 = (año + mes + dia + " 23:59:00");

            try
            {
                cn.Open();
                SqlCommand cmp = cn.CreateCommand();
                cmp.CommandType = CommandType.Text;
                cmp.CommandText = "select * from historialcc where fecha_corte between '" + sqlFormattedDate + "' and '" + sqlFormattedDate2 + "'";
                cmp.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmp);
                da.Fill(dt);

                dgt.DataSource = dt;
                cn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        } // muestra la fecha seleccionada del historial de cc

        public void buscar_historial_año(string año, DataGridView dgt)
        {
            try
            {
                cn.Open();
                SqlCommand cmp = cn.CreateCommand();
                cmp.CommandType = CommandType.Text;
                cmp.CommandText = "select * from historialcc where year(fecha_corte)='" + año + "'";
                cmp.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmp);
                da.Fill(dt);

                dgt.DataSource = dt;
                cn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void buscar_historial_mes(string mes, DataGridView dgt)
        {
            try
            {
                cn.Open();
                SqlCommand cmp = cn.CreateCommand();
                cmp.CommandType = CommandType.Text;
                cmp.CommandText = "select * from historialcc where month(fecha_corte)='" + mes + "'";
                cmp.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmp);
                da.Fill(dt);

                dgt.DataSource = dt;
                cn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void buscar_hidtorial_añoymes(string año, string mes, DataGridView dgt)
        {
            try
            {
                cn.Open();
                SqlCommand cmp = cn.CreateCommand();
                cmp.CommandType = CommandType.Text;
                cmp.CommandText = "select * from historialcc where year(fecha_corte)='" + año + "' and month(fecha_corte)='" + mes + "'";
                cmp.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmp);
                da.Fill(dt);

                dgt.DataSource = dt;
                cn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public string insertar_pago(int pago, string descripcion, DateTime fecha)
        {
            string sqlformat = fecha.ToString("yyyy-MM-dd HH:mm:ss");
            string Salida = "Pago Registrado Exitosamente";
            try
            {
                cn.Open();
                cmd = new SqlCommand("insert into pagos (pago, descripcion, fecha_pago) values (" + pago + ",'" + descripcion + "','" + sqlformat + "')", cn);
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            catch (Exception ex)
            {
                Salida = "No se pudo insertar: " + ex.ToString();
            }
            return Salida;
        }

        public void realizar_corte_pagos(DateTime fecha, Label lbl)
        {
            string sqlFormattedDate = fecha.ToString("yyyy-MM-dd HH:mm:ss");
            string sqlFormattedDate2 = fecha.ToString("yyyy-MM-dd 00:00:00");
            try
            {
                cn.Open();
                cmd = new SqlCommand("select sum(pago)suma from pagos where fecha_pago between '" + sqlFormattedDate2 + "' and '" + sqlFormattedDate + "' ", cn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lbl.Text = dr["suma"].ToString();
                }
                if (lbl.Text == "")
                {
                    lbl.Text = Convert.ToString(0);
                }
                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void realizar_corte_credito(DateTime fecha, Label lbl)
        {
            string sqlFormattedDate = fecha.ToString("yyyy-MM-dd HH:mm:ss");
            string sqlFormattedDate2 = fecha.ToString("yyyy-MM-dd 00:00:00");
            try
            {
                cn.Open();
                cmd = new SqlCommand("select sum(v.precio)suma from adeudo v, productos p where fecha_adeudo between '" + sqlFormattedDate2 + "' and '" + sqlFormattedDate + "' and v.id_producto= p.id_producto ", cn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lbl.Text = dr["suma"].ToString();
                }
                if (lbl.Text == "")
                {
                    lbl.Text = Convert.ToString(0);
                }
                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void mostrar_detalles_pago(DateTime fecha, DataGridView dgt)
        {
            string sqlFormattedDate = fecha.ToString("yyyy-MM-dd 00:00:00");
            string sqlFormattedDate2 = fecha.ToString("yyyy-MM-dd HH:mm:ss");

            try
            {
                cn.Open();
                SqlCommand cmp = cn.CreateCommand();
                cmp.CommandType = CommandType.Text;
                cmp.CommandText = "select * from Pago where fecha_Pago between '" + sqlFormattedDate + "' and '" + sqlFormattedDate2 + "'";
                cmp.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmp);
                da.Fill(dt);

                dgt.DataSource = dt;
                cn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void cargar_historial_pagos(DataGridView dgt)
        {
            try
            {
                cn.Open();
                SqlCommand cmp = cn.CreateCommand();
                cmp.CommandType = CommandType.Text;
                cmp.CommandText = "select * from historialpagos order by fecha_pago desc";
                cmp.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmp);
                da.Fill(dt);

                dgt.DataSource = dt;
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void buscar_historial_pago(string año, string mes, string dia, DataGridView dgt)
        {
            string sqlFormattedDate = (año + mes + dia + " 00:00:00");
            string sqlFormattedDate2 = (año + mes + dia + " 23:59:00");

            try
            {
                cn.Open();
                SqlCommand cmp = cn.CreateCommand();
                cmp.CommandType = CommandType.Text;
                cmp.CommandText = "select * from historialpagos where fecha_pago between '" + sqlFormattedDate + "' and '" + sqlFormattedDate2 + "'";
                cmp.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmp);
                da.Fill(dt);

                dgt.DataSource = dt;
                cn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        } // muestra la fecha seleccionada del historial de cc

        public void buscar_historial_año_pago(string año, DataGridView dgt)
        {
            try
            {
                cn.Open();
                SqlCommand cmp = cn.CreateCommand();
                cmp.CommandType = CommandType.Text;
                cmp.CommandText = "select * from historialpagos where year(fecha_pago)='" + año + "'";
                cmp.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmp);
                da.Fill(dt);

                dgt.DataSource = dt;
                cn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void buscar_historial_mes_pago(string mes, DataGridView dgt)
        {
            try
            {
                cn.Open();
                SqlCommand cmp = cn.CreateCommand();
                cmp.CommandType = CommandType.Text;
                cmp.CommandText = "select * from historialpagos where month(fecha_pago)='" + mes + "'";
                cmp.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmp);
                da.Fill(dt);

                dgt.DataSource = dt;
                cn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void buscar_hidtorial_añoymes_pago(string año, string mes, DataGridView dgt)
        {
            try
            {
                cn.Open();
                SqlCommand cmp = cn.CreateCommand();
                cmp.CommandType = CommandType.Text;
                cmp.CommandText = "select * from historialpagos where year(fecha_pago)='" + año + "' and month(fecha_pago)='" + mes + "'";
                cmp.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmp);
                da.Fill(dt);

                dgt.DataSource = dt;
                cn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void detalles_credito(DateTime fecha, DataGridView dgt)
        {
           
                string sqlFormattedDate = fecha.ToString("yyyy-MM-dd HH:mm:ss");
                string sqlFormattedDate2 = fecha.ToString("yyyy-MM-dd 00:00:00");
                try
                {
                    cn.Open();
                    SqlCommand cmp = cn.CreateCommand();
                    cmp.CommandType = CommandType.Text;
                    cmp.CommandText = "select id_adeudo , nombre, nombreproducto, precio, fecha_adeudo from detalles_credito where fecha_adeudo between '" + sqlFormattedDate2 + "' and '" + sqlFormattedDate + "'";
                    cmp.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmp);
                    da.Fill(dt);

                    dgt.DataSource = dt;
                    cn.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        public void cancelar_venta(DateTime fecha, DataGridView dgt)
        {
            string sqlFormattedDate = fecha.ToString("yyyy-MM-dd HH:mm:ss");
            string sqlFormattedDate2 = fecha.ToString("yyyy-MM-dd 00:00:00");
            try
            {
                cn.Open();
                SqlCommand cmp = cn.CreateCommand();
                cmp.CommandType = CommandType.Text;
                cmp.CommandText = "select id_venta, sum(v.precio)Total_Venta from productos p, venta v where v.id_producto=p.id_producto and fecha_venta between '" + sqlFormattedDate2 + "' and '" + sqlFormattedDate + "' and estado='realizada' group by id_venta";
                cmp.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmp);
                da.Fill(dt);

                dgt.DataSource = dt;
                cn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        }
    }
