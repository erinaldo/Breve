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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        Conexion con = new Conexion();
        private void btnEntrar_Click(object sender, EventArgs e)
        {
            if (con.cone(txtUsuario.Text, txtContraseña.Text))
            {
                Form1 fr = new Form1();
                this.Hide();
                fr.Show();
            }
        }

        private void btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
