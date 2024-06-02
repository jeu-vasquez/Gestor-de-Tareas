using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using TAREAS.datos;

namespace TAREAS
{
    public partial class frmCrearMaterias : Form
    {
        public frmCrearMaterias()
        {
            InitializeComponent();
            CargarDatosMaterias();
        }

        private void Materias_Load(object sender, EventArgs e)
        {
            CargarDatosMaterias();
        }

        private void CargarDatosMaterias()
        {
            try
            {
                string query = "SELECT * FROM Materias";
                using (SqlConnection conn = new SqlConnection(conexionSQL.cn))
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        DataTable dt = new DataTable();
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(dt);
                        dataGridViewMateria.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message);
            }
        }

        private void dataGridViewMateria_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewMateria.Rows[e.RowIndex];
                txtNombreMateria.Text = row.Cells["Materia"].Value.ToString();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewMateria.SelectedRows.Count > 0)
                {
                    int idMateria = Convert.ToInt32(dataGridViewMateria.SelectedRows[0].Cells["MateriaID"].Value);
                    string query = "DELETE FROM Materias WHERE MateriaID = @MateriaID";
                    using (SqlConnection conn = new SqlConnection(conexionSQL.cn))
                    {
                        conn.Open();
                        using (SqlCommand command = new SqlCommand(query, conn))
                        {
                            command.Parameters.AddWithValue("@MateriaID", idMateria);
                            command.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Materia eliminada con éxito");
                    CargarDatosMaterias();
                }
                else
                {
                    MessageBox.Show("Seleccione una materia para eliminar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar materia: " + ex.Message);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewMateria.SelectedRows.Count > 0)
                {
                    int idMateria = Convert.ToInt32(dataGridViewMateria.SelectedRows[0].Cells["MateriaID"].Value);
                    string query = "UPDATE Materias SET Materia = @Materia WHERE MateriaID = @MateriaID";
                    using (SqlConnection conn = new SqlConnection(conexionSQL.cn))
                    {
                        conn.Open();
                        using (SqlCommand command = new SqlCommand(query, conn))
                        {
                            command.Parameters.AddWithValue("@Materia", txtNombreMateria.Text);
                            command.Parameters.AddWithValue("@MateriaID", idMateria);
                            command.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Materia editada con éxito");
                    CargarDatosMaterias();
                }
                else
                {
                    MessageBox.Show("Seleccione una materia para editar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al editar materia: " + ex.Message);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "INSERT INTO Materias (Materia) VALUES (@Materia)";
                using (SqlConnection conn = new SqlConnection(conexionSQL.cn))
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@Materia", txtNombreMateria.Text);
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Materia agregada con éxito");
                CargarDatosMaterias();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar materia: " + ex.Message);
            }
        }
    }
}
