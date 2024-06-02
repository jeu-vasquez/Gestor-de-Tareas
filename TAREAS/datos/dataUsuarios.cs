using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.Data;

using TAREAS.modelos;
using System.Xml;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Drawing;
using System.Runtime.ConstrainedExecution;
using TAREAS.datos.controllers;

namespace TAREAS.datos
{
    public class dataUsuarios
    {
        usuarioController objd = new usuarioController();
        public static int Login(string usuario, string password)
        {
            int idUsuario = 0;

            using (SqlConnection conn = new SqlConnection(conexionSQL.cn))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("loginUsuario", conn);
                    cmd.Parameters.AddWithValue("usuario", usuario);

                    // Calcular hash SHA-256 de la contraseña 
                    byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                    byte[] hashBytes;
                    using (SHA256 sha256 = SHA256.Create())
                    {
                        hashBytes = sha256.ComputeHash(passwordBytes);
                    }

                    // Parámetro passwordHash
                    cmd.Parameters.AddWithValue("passwordHash", hashBytes);
                    cmd.Parameters.Add("idUsuario", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    cmd.ExecuteNonQuery();

                    idUsuario = Convert.ToInt32(cmd.Parameters["idUsuario"].Value);
                }
                catch (Exception)
                {
                    idUsuario = 0;
                }
                finally
                {
                    conn.Close();
                }
            }


            return idUsuario;
        }

        public List<modelos.Menus> ObtenerPermisos(int p_idUsuario)
        {
            List<Menus> PermisosUsuarios = new List<Menus>();

            using (SqlConnection conn = new SqlConnection(conexionSQL.cn))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("obtenerPermisos", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idUsuario", p_idUsuario); // Asegúrate de que el nombre del parámetro sea correcto

                    conn.Open();
                    frmCrearUsuario frmCrear = new frmCrearUsuario();

                    // Leemos los datos XML generados por el procedimiento almacenado
                    using (XmlReader leerxml = cmd.ExecuteXmlReader())
                    {
                        while (leerxml.Read())
                        {
                            XDocument doc = XDocument.Load(leerxml);

                            if (doc.Element("Permisos") != null)
                            {
                                PermisosUsuarios = doc.Element("Permisos")?.Element("DetalleMenu") == null ? new List<Menus>() :
                                    (from menu in doc.Element("Permisos")?.Element("DetalleMenu")?.Elements("MENU")
                                     select new Menus()
                                     {
                                         Nombre = menu.Element("nombre")?.Value ?? string.Empty,
                                         Icono = menu.Element("otros")?.Value ?? string.Empty,
                                         ListaSubMenu = menu.Element("DetalleSubMenu") == null ? new List<SubMenu>() :
                                         (from submenu in menu.Element("DetalleSubMenu")?.Elements("SUBMENU")
                                          select new SubMenu()
                                          {
                                              Nombre = submenu.Element("nombre")?.Value ?? string.Empty,
                                              NombreFormulario = submenu.Element("nombreFormulario")?.Value ?? string.Empty,
                                          }).ToList()
                                     }).ToList();
                            }
                        }
                    }

                }
                catch (Exception)
                {
                    PermisosUsuarios = new List<Menus>();
                }
                finally
                {
                    conn.Close();
                }
            }

            return PermisosUsuarios;
        }

        public DataTable nListarUsuario() {
            return objd.listarUsuarios();
         }

        public DataTable nBuscarUsuarios(Usuarios obje) {
            return objd.buscarUsuarios(obje);
        }
        public string nCrudUsuarios(Usuarios obje)
        {
            //return Convert.ToString(obje);
            return objd.crudUsuarios(obje);
        }
    }
}
