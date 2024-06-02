using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Capa_Entidad;
using TAREAS.datos;

namespace Capa_Datos
{
    public class ClassDatos
    {
        SqlConnection conn = new SqlConnection(conexionSQL.cn);

        public DataTable D_listar_tareas()
        {
            SqlCommand cmd = new SqlCommand("sp_listar_tareas", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public object D_mantenimiento_tareas(ClassEntidad obje)
        {
            string Accion = "";
            SqlCommand cmd = new SqlCommand("sp_mantenimiento_tareas", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TareaID", obje.TareaID);
            cmd.Parameters.AddWithValue("@Tarea", obje.Tarea);
            cmd.Parameters.AddWithValue("@Materia", obje.Materia);
            cmd.Parameters.AddWithValue("@Fecha_asignación", obje.Fecha_asignacion);
            cmd.Parameters.AddWithValue("@Fecha_entrega", obje.Fecha_entrega);
            cmd.Parameters.AddWithValue("@MedioEntrega", obje.MedioEntrega);
            cmd.Parameters.AddWithValue("@Estadoid", obje.Estado);
            cmd.Parameters.Add("@Accion", SqlDbType.VarChar, 50).Value = obje.Accion;
            cmd.Parameters["@Accion"].Direction = ParameterDirection.InputOutput;
            if (conn.State == ConnectionState.Open) conn.Close();
            conn.Open();
            cmd.ExecuteNonQuery();
            Accion = cmd.Parameters["@Accion"].Value.ToString();
            
            conn.Close();
            return Accion;

        }
    }
}
