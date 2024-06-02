using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Capa_Entidad;
using Capa_Negocio;

namespace TAREAS
{
    public partial class frmCrearTarea : Form
    {
        ClassEntidad objent = new ClassEntidad();
        ClassNegocio objeng = new ClassNegocio();
        public frmCrearTarea()
        {
            InitializeComponent();
        }

        void mantenimiento(string Accion)
        {
            objent.TareaID = txtTareaID.Text;
            objent.Tarea = txtTarea.Text;
            objent.Materia = txtMateria.Text;
            objent.Fecha_asignacion = DateTime.Parse(mtbFechaA.Text);
            objent.Fecha_entrega = DateTime.Parse(mtbFechaE.Text);
            objent.MedioEntrega = txtMedio.Text;
            objent.Estado = txtEstado.Text;
            objent.Accion = Accion;
            string men = objeng.N_mantenimiento_tareas(objent);
            MessageBox.Show(men, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Tareas_Load(object sender, EventArgs e)
        {
            dwvTareas.DataSource = objeng.N_listar_tareas();
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtTareaID.Text == "")
            {
                if (MessageBox.Show("Deseas registrar la tarea: " + txtTarea.Text + "?", "Mensaje",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)

                {
                    mantenimiento("1");
                }
            }
            dwvTareas.DataSource = objeng.N_listar_tareas();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (txtTareaID.Text != "")
            {
                if (MessageBox.Show("Deseas editar la tarea: " + txtTarea.Text + "?", "Mensaje",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)

                {
                    mantenimiento("2");
                }
            }
            dwvTareas.DataSource = objeng.N_listar_tareas();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtTareaID.Text != "")
            {
                if (MessageBox.Show("Deseas eliminar la tarea: " + txtTarea.Text + "?", "Mensaje",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)

                {
                    mantenimiento("3");
                }
            }
            dwvTareas.DataSource = objeng.N_listar_tareas();
        }

        private void dwvTareas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = dwvTareas.CurrentCell.RowIndex;

            txtTareaID.Text = dwvTareas[0,fila].Value.ToString();
            txtTarea.Text = dwvTareas[1, fila].Value.ToString();
            txtMateria.Text = dwvTareas[2, fila].Value.ToString();
            mtbFechaA.Text = dwvTareas[3, fila].Value.ToString();
            mtbFechaE.Text = dwvTareas[4, fila].Value.ToString();
            txtMateria.Text = dwvTareas[5, fila].Value.ToString();
            txtEstado.Text = dwvTareas[6, fila].Value.ToString();
        }
    }
}
