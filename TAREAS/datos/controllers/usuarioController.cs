using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

using System.Security.Cryptography;
using TAREAS.modelos;

namespace TAREAS.datos.controllers
{
    public  class usuarioController
    {
        /* CRUD DE USUARIO*/
        public DataTable listarUsuarios()
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(conexionSQL.cn))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("listarUsuario", conn);
                    cmd.CommandType = CommandType.StoredProcedure; // Si es un procedimiento almacenado

                    SqlDataAdapter data = new SqlDataAdapter(cmd);
                    data.Fill(dt);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No hay Registros: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }

            return dt;
        }
        public DataTable buscarUsuarios(Usuarios obj)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(conexionSQL.cn))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("listarUsuario", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nombre", obj.nombre);
                    SqlDataAdapter data = new SqlDataAdapter(cmd);
                    
                    data.Fill(dt);

                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No hay Registros");
                }
                finally
                {
                    conn.Close();
                }
            }
            return dt;

        }

        public string crudUsuarios(Usuarios obj)
        {
            string accion = "";

            using (SqlConnection conn = new SqlConnection(conexionSQL.cn))
            {
                try
                {
                    // Calcular hash SHA-256 de la contraseña 
                    byte[] passwordBytes = Encoding.UTF8.GetBytes(obj.passwordHash);
                    byte[] hashBytes;
                    using (SHA256 sha256 = SHA256.Create())
                    {
                        hashBytes = sha256.ComputeHash(passwordBytes);
                    }
                    SqlCommand cmd = new SqlCommand("crudUsuario", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@usuarioId", obj.usuarioId);
                    cmd.Parameters.AddWithValue("@roleId", obj.roleId);
                    cmd.Parameters.AddWithValue("@nombre", obj.nombre);
                    cmd.Parameters.AddWithValue("@usuario", obj.usuario);

                    cmd.Parameters.AddWithValue("@passwordHash", hashBytes);
                    cmd.Parameters.AddWithValue("@accion", obj.accion);
                    
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    accion = cmd.Parameters["@accion"].Value.ToString();

                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No hay Registros");
                }
               
            }
            return accion;
        }
    }
}
