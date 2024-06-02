using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TAREAS.modelos;
using TAREAS.datos;
using System.Data.SqlClient;
using System.Xml.Linq;
using Microsoft.IdentityModel.Tokens;

namespace TAREAS
{
    public partial class frmCrearUsuario : Form
    {
        Usuarios objent = new Usuarios();
        dataUsuarios objneg = new dataUsuarios();
        private int idUsuario;
        private string permisosXML;
        private ErrorProvider errorProvider = new ErrorProvider();
        public frmCrearUsuario(int idUsuario_esperado = 0)
        {
            InitializeComponent();
            idUsuario = idUsuario_esperado;
        }
        // validar con errorProvider
        private bool ValidarControles()
        {
            bool esValido = true;
            errorProvider.Clear();

            if (string.IsNullOrEmpty(txtUsuarioId.Text))
            {
                errorProvider.SetError(txtUsuarioId, "El ID de usuario no puede estar vacío.");
                esValido = false;
            }

            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                errorProvider.SetError(txtNombre, "El nombre no puede estar vacío.");
                esValido = false;
            }

            if (string.IsNullOrEmpty(txtUsuario.Text))
            {
                errorProvider.SetError(txtUsuario, "El usuario no puede estar vacío.");
                esValido = false;
            }

            if (cbxRol.SelectedItem == null || !(cbxRol.SelectedItem is ComboboxItem))
            {
                errorProvider.SetError(cbxRol, "Seleccione un rol válido.");
                esValido = false;
            }

            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                errorProvider.SetError(txtPassword, "La contraseña no puede estar vacía.");
                esValido = false;
            }

            if (txtPassword.Text != txtConfirmarPass.Text)
            {
                errorProvider.SetError(txtConfirmarPass, "Las contraseñas no coinciden.");
                esValido = false;
            }

            return esValido;
        }
        // CRUD DE USUARIOS
        void mantenimiento(string accion)
        {
            try
            {
                /*if (!ValidarControles())
                {
                    throw new Exception("Hay errores en el formulario.");
                }*/

                if (!string.IsNullOrEmpty(txtUsuarioId.Text))
                {
                    objent.usuarioId = Convert.ToInt32(txtUsuarioId.Text);
                }

                objent.nombre = txtNombre.Text;
                objent.usuario = txtUsuario.Text;

                // Obtener el roleId desde el ComboBox de forma segura
                if (cbxRol.SelectedItem is ComboboxItem selectedRole)
                {
                    objent.roleId = (int)selectedRole.Value;
                }
                else
                {
                    throw new Exception("Seleccione un rol válido.");
                }

                objent.passwordHash = txtPassword.Text;
                string confirmarPass = txtConfirmarPass.Text;
                objent.accion = accion;

                string men = objneg.nCrudUsuarios(objent);
                MessageBox.Show(men, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        void limpiar()
        {
            txtNombre.Text = "";
            txtUsuario.Text = "";
            txtPassword.Text = "";
            txtConfirmarPass.Text = "";
            txtBuscar.Text = "";
            txtNombre.Focus();

            dgvUsuarios.DataSource = objneg.nListarUsuario();
        }



        // Método para cargar los permisos del usuario
        private void CargarPermisos(int idUsuario)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(conexionSQL.cn))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("obtenerPermisos", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idUsuario", idUsuario);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        // Guardar el XML de permisos en una variable
                        permisosXML = reader.GetString(0);
                    }
                    //MessageBox.Show(Convert.ToString( reader.Read()));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los permisos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para validar permisos según el nombre del formulario
        private bool TienePermiso(string nombreFormulario, string permisosXML)
        {
            bool tienePermiso = false;

            try
            {
                // Cargar el XML de permisos en un objeto DataSet
                DataSet dsPermisos = new DataSet();
                dsPermisos.ReadXml(new System.IO.StringReader(permisosXML));

                // Buscar el nombre del formulario en el XML
                foreach (DataRow menu in dsPermisos.Tables["MENU"].Rows)
                {
                    foreach (DataRow submenu in menu.GetChildRows("DetalleMenu")[0].GetChildRows("DetalleSubMenu"))
                    {
                        if (submenu["nombreFormulario"].ToString() == nombreFormulario)
                        {
                            tienePermiso = true;
                            //MessageBox.Show(Convert.ToString(tienePermiso));
                            break;
                        }
                    }
                    if (tienePermiso)
                        break;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al procesar los permisos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return tienePermiso;
        }

        private void frmCrearUsuario_Load(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(conexionSQL.cn))
            {
                try
                {
                    string rolQuery = "SELECT roleId, roleNombre FROM Roles";
                    SqlCommand cmd = new SqlCommand(rolQuery, conn);

                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    // Agregar un elemento "Placeholder" al ComboBox
                    cbxRol.Items.Add("Seleccione un rol...");
                    cbxRol.SelectedIndex = 0; // Seleccionar el placeholder por defecto
                    cbxRol.DropDownStyle = ComboBoxStyle.DropDownList; // Establecer el estilo para que el ComboBox sea de solo lectura
                    while (reader.Read())
                    {
                        // Obtener el ID y el nombre del rol
                        int roleId = reader.GetInt32(0);
                        string roleName = reader.GetString(1);

                        // Agregar el nombre del rol al ComboBox con el ID como valor
                        cbxRol.Items.Add(new ComboboxItem(roleName, roleId));
                    }

                }
                catch (Exception ex)
                {
                    // Manejar la excepción
                    MessageBox.Show("Error al cargar los roles: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            try
            {
                DataTable dtUsuarios = objneg.nListarUsuario();
                dgvUsuarios.DataSource = dtUsuarios;

                if (dtUsuarios.Columns.Contains("usuarioId"))
                    dgvUsuarios.Columns["usuarioId"].Visible = false;
                if (dtUsuarios.Columns.Contains("roleNombre"))
                    if (dtUsuarios.Columns.Contains("roleId"))
                    dgvUsuarios.Columns["roleId"].Visible = false;
                if (dtUsuarios.Columns.Contains("roleNombre"))
                    dgvUsuarios.Columns["roleNombre"].HeaderText = "Rol de Usuario";
                if (dtUsuarios.Columns.Contains("nombre"))
                    dgvUsuarios.Columns["nombre"].HeaderText = "Nombre Completo";
                if (dtUsuarios.Columns.Contains("usuario"))
                    dgvUsuarios.Columns["usuario"].HeaderText = "Nombre de Usuario";
                if (dtUsuarios.Columns.Contains("create_at"))
                    dgvUsuarios.Columns["create_at"].HeaderText = "Fecha de Creacion";

                dgvUsuarios.DataError += new DataGridViewDataErrorEventHandler(dgvUsuarios_DataError);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los usuarios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Cargar y validar los permisos del usuario
            CargarPermisos(idUsuario);

        }

        // Método para verificar si el usuario tiene permisos específicos
        public void ValidarPermisosFormulario(string nombreFormulario)
        {
            if (nombreFormulario.IsNullOrEmpty())
            {
                btnActualizar.Enabled = false;
                btnEliminar.Enabled = false;
            }
            else
            {
                bool tienePermiso = TienePermiso(nombreFormulario, permisosXML);

                // Aquí ajustas los permisos de los controles según el resultado
                btnActualizar.Enabled = tienePermiso;
                btnEliminar.Enabled = tienePermiso;

                //MessageBox.Show(Convert.ToString(tienePermiso));
            }
            // Validar si el usuario tiene permiso para editar y eliminar según el nombre del formulario

        }
        private void btnRegistrarUsuario_Click(object sender, EventArgs e)
        {
            if (txtUsuarioId.Text == "")
            {
                if (txtPassword.Text == txtConfirmarPass.Text)
                {
                    if (MessageBox.Show("¿Deseas registrar a " + txtNombre.Text + "?", "Mensaje", MessageBoxButtons.YesNo,
                   MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                    {
                        mantenimiento("1");
                        limpiar();
                    }
                }
                else
                {
                    MessageBox.Show("Contraseña no Coinciden");
                }
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(txtUsuarioId.Text);
           if (txtUsuarioId.Text != "")
            {
                if (MessageBox.Show("¿Deseas modificar a " + txtNombre.Text + "?", "Mensaje", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    mantenimiento("2");
                    limpiar();
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtUsuarioId.Text != "")
            {
                if (MessageBox.Show("¿Deseas eliminar a " + txtNombre.Text + "?", "Mensaje", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    mantenimiento("3");
                    limpiar();
                }
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscar.Text != "")
            {
                objent.nombre = txtBuscar.Text;
                DataTable dt = new DataTable();
                dt = objneg.nBuscarUsuarios(objent);
                dgvUsuarios.DataSource = dt;
            }
            else
            {
                dgvUsuarios.DataSource = objneg.nListarUsuario();
            }
        }

        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = dgvUsuarios.CurrentCell.RowIndex;

            txtUsuarioId.Text = dgvUsuarios[0, fila].Value.ToString();
            cbxRol.Text = dgvUsuarios[2, fila].Value.ToString();
            txtNombre.Text = dgvUsuarios[3, fila].Value.ToString();
            txtUsuario.Text = dgvUsuarios[4, fila].Value.ToString();
        }

        private void dgvUsuarios_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // Mostrar un mensaje de error detallado
            MessageBox.Show($"Error en la columna {e.ColumnIndex + 1}, fila {e.RowIndex + 1}: {e.Exception.Message}",
                "Error de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);

            // Prevenir que el error se propague
            e.ThrowException = false;
        }

        public class ComboboxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }

            public ComboboxItem(string text, object value)
            {
                Text = text;
                Value = value;
            }

            public override string ToString()
            {
                return Text;
            }
        }
        private void cbxRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Si el usuario intenta seleccionar el placeholder, restaurar la selección al índice 0
            if (cbxRol.SelectedIndex == 0)
            {
                cbxRol.SelectedIndex = -1; // Desseleccionar el placeholder
            }
        }

        private void txtBuscar_TextChanged_1(object sender, EventArgs e)
        {
            /* if (txtBuscar.Text != "")
            {
                objent.nombre = txtBuscar.Text;
                DataTable dt = new DataTable();
                dt = objneg.nBuscarUsuarios(objent);
                dgvUsuarios.DataSource = dt;
            }
            else
            {
                dgvUsuarios.DataSource = objneg.nListarUsuario();
            }*/
        }
    }
}
