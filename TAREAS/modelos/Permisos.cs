using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAREAS.datos;
using System.Data.SqlClient;

namespace TAREAS.modelos
{
    public class Permisos
    {
        
        public string permisosXML;
        // Método para cargar los permisos del usuario
        public void CargarPermisos(int idUsuario)
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
        public bool TienePermiso(string nombreFormulario, string permisosXML)
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
    }
}
