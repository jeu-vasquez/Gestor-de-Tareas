using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using TAREAS.datos;
using TAREAS.modelos;


namespace TAREAS
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnInicioSesion_Click(object sender, EventArgs e)
        {
            int idUsuario = dataUsuarios.Login(txtUsuario.Text, txtPassword.Text);
            //MessageBox.Show("usuario" + txtUsuario.Text + " pass: " + txtPassword.Text);
            if (idUsuario != 0)
            {
                this.Hide(); 
                Master master = new Master(idUsuario);
                master.Show();
                //frmCrearUsuario frmUsuario = new frmCrearUsuario(idUsuario);
            }
            else
            {
                MessageBox.Show("Usuario o clave incorrecta");
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmCrearUsuario frm = new frmCrearUsuario();
            frm.Show();
            string form="";
            frm.ValidarPermisosFormulario(form);

        }
    }
}
