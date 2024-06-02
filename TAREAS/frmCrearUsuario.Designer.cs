
namespace TAREAS
{
    partial class frmCrearUsuario
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            btnRegistrarUsuario = new Button();
            groupBox1 = new GroupBox();
            txtConfirmarPass = new TextBox();
            label5 = new Label();
            txtPassword = new TextBox();
            txtUsuario = new TextBox();
            label4 = new Label();
            label3 = new Label();
            txtNombre = new TextBox();
            label2 = new Label();
            label1 = new Label();
            cbxRol = new ComboBox();
            dgvUsuarios = new DataGridView();
            txtUsuarioId = new TextBox();
            btnActualizar = new Button();
            btnNuevo = new Button();
            btnEliminar = new Button();
            errorProvider1 = new ErrorProvider(components);
            txtBuscar = new TextBox();
            label6 = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // btnRegistrarUsuario
            // 
            btnRegistrarUsuario.Font = new Font("Segoe UI", 12F);
            btnRegistrarUsuario.Location = new Point(397, 194);
            btnRegistrarUsuario.Name = "btnRegistrarUsuario";
            btnRegistrarUsuario.Size = new Size(113, 40);
            btnRegistrarUsuario.TabIndex = 10;
            btnRegistrarUsuario.Text = "Registrar";
            btnRegistrarUsuario.UseVisualStyleBackColor = true;
            btnRegistrarUsuario.Click += btnRegistrarUsuario_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtConfirmarPass);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(txtPassword);
            groupBox1.Controls.Add(txtUsuario);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtNombre);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(cbxRol);
            groupBox1.Font = new Font("Segoe UI", 12F);
            groupBox1.Location = new Point(13, 11);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(939, 182);
            groupBox1.TabIndex = 13;
            groupBox1.TabStop = false;
            groupBox1.Text = "Datos";
            // 
            // txtConfirmarPass
            // 
            txtConfirmarPass.Font = new Font("Segoe UI", 12F);
            txtConfirmarPass.Location = new Point(623, 124);
            txtConfirmarPass.Name = "txtConfirmarPass";
            txtConfirmarPass.PasswordChar = '*';
            txtConfirmarPass.Size = new Size(284, 34);
            txtConfirmarPass.TabIndex = 19;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F);
            label5.Location = new Point(447, 132);
            label5.Name = "label5";
            label5.Size = new Size(179, 23);
            label5.TabIndex = 18;
            label5.Text = "Confirmar contraseña:";
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 12F);
            txtPassword.Location = new Point(113, 124);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(272, 34);
            txtPassword.TabIndex = 17;
            // 
            // txtUsuario
            // 
            txtUsuario.Font = new Font("Segoe UI", 12F);
            txtUsuario.Location = new Point(114, 74);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(271, 34);
            txtUsuario.TabIndex = 16;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F);
            label4.Location = new Point(6, 132);
            label4.Name = "label4";
            label4.Size = new Size(101, 23);
            label4.TabIndex = 15;
            label4.Text = "Contraseña:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F);
            label3.Location = new Point(34, 83);
            label3.Name = "label3";
            label3.Size = new Size(72, 23);
            label3.TabIndex = 14;
            label3.Text = "Usuario:";
            // 
            // txtNombre
            // 
            txtNombre.Font = new Font("Segoe UI", 12F);
            txtNombre.Location = new Point(174, 29);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(733, 34);
            txtNombre.TabIndex = 13;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F);
            label2.Location = new Point(6, 37);
            label2.Name = "label2";
            label2.Size = new Size(157, 23);
            label2.TabIndex = 12;
            label2.Text = "Nombre Completo:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F);
            label1.Location = new Point(483, 83);
            label1.Name = "label1";
            label1.Size = new Size(134, 23);
            label1.TabIndex = 11;
            label1.Text = "Tipo de Usuario:";
            // 
            // cbxRol
            // 
            cbxRol.Font = new Font("Segoe UI", 12F);
            cbxRol.FormattingEnabled = true;
            cbxRol.Location = new Point(623, 75);
            cbxRol.Name = "cbxRol";
            cbxRol.Size = new Size(284, 36);
            cbxRol.TabIndex = 10;
            // 
            // dgvUsuarios
            // 
            dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsuarios.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsuarios.Location = new Point(13, 315);
            dgvUsuarios.Margin = new Padding(2);
            dgvUsuarios.Name = "dgvUsuarios";
            dgvUsuarios.RowHeadersWidth = 51;
            dgvUsuarios.Size = new Size(939, 361);
            dgvUsuarios.TabIndex = 16;
            dgvUsuarios.CellContentClick += dgvUsuarios_CellContentClick;
            // 
            // txtUsuarioId
            // 
            txtUsuarioId.Enabled = false;
            txtUsuarioId.Location = new Point(97, 199);
            txtUsuarioId.Name = "txtUsuarioId";
            txtUsuarioId.Size = new Size(125, 30);
            txtUsuarioId.TabIndex = 17;
            txtUsuarioId.Visible = false;
            // 
            // btnActualizar
            // 
            btnActualizar.Font = new Font("Segoe UI", 12F);
            btnActualizar.Location = new Point(519, 194);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(132, 40);
            btnActualizar.TabIndex = 18;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // btnNuevo
            // 
            btnNuevo.Font = new Font("Segoe UI", 12F);
            btnNuevo.Location = new Point(265, 194);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(113, 40);
            btnNuevo.TabIndex = 19;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Font = new Font("Segoe UI", 12F);
            btnEliminar.Location = new Point(669, 194);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(113, 40);
            btnEliminar.TabIndex = 20;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(176, 268);
            txtBuscar.Margin = new Padding(2);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(744, 30);
            txtBuscar.TabIndex = 22;
            txtBuscar.TextChanged += txtBuscar_TextChanged_1;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(13, 270);
            label6.Name = "label6";
            label6.Size = new Size(160, 23);
            label6.TabIndex = 21;
            label6.Text = "Buscar por nombre:";
            // 
            // frmCrearUsuario
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(966, 685);
            Controls.Add(txtBuscar);
            Controls.Add(label6);
            Controls.Add(btnEliminar);
            Controls.Add(btnNuevo);
            Controls.Add(btnActualizar);
            Controls.Add(txtUsuarioId);
            Controls.Add(dgvUsuarios);
            Controls.Add(groupBox1);
            Controls.Add(btnRegistrarUsuario);
            Font = new Font("Segoe UI", 10F);
            Name = "frmCrearUsuario";
            Text = "Crear Usuario";
            Load += frmCrearUsuario_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion
        private Button btnRegistrarUsuario;
        private GroupBox groupBox1;
        private TextBox txtConfirmarPass;
        private Label label5;
        private TextBox txtPassword;
        private TextBox txtUsuario;
        private Label label4;
        private Label label3;
        private TextBox txtNombre;
        private Label label2;
        private Label label1;
        private ComboBox cbxRol;
        private DataGridView dgvUsuarios;
        private TextBox txtUsuarioId;
        private Button btnActualizar;
        private Button btnNuevo;
        private Button btnEliminar;
        private ErrorProvider errorProvider1;
        private TextBox txtBuscar;
        private Label label6;
    }
}