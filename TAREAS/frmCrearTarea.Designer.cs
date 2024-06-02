namespace TAREAS
{
    partial class frmCrearTarea
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCrearTarea));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            txtTarea = new TextBox();
            txtMedio = new TextBox();
            mtbFechaA = new MaskedTextBox();
            btnAgregar = new Button();
            btnEditar = new Button();
            btnEliminar = new Button();
            label7 = new Label();
            dwvTareas = new DataGridView();
            mtbFechaE = new MaskedTextBox();
            txtTareaID = new TextBox();
            label8 = new Label();
            txtMateria = new TextBox();
            txtEstado = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dwvTareas).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(52, 109);
            label1.Name = "label1";
            label1.Size = new Size(37, 15);
            label1.TabIndex = 0;
            label1.Text = "Tarea:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.Control;
            label2.Location = new Point(52, 142);
            label2.Name = "label2";
            label2.Size = new Size(47, 15);
            label2.TabIndex = 1;
            label2.Text = "Materia";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = SystemColors.Control;
            label3.Location = new Point(52, 183);
            label3.Name = "label3";
            label3.Size = new Size(114, 15);
            label3.TabIndex = 2;
            label3.Text = "Fecha de asignacion";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = SystemColors.Control;
            label4.Location = new Point(52, 223);
            label4.Name = "label4";
            label4.Size = new Size(97, 15);
            label4.TabIndex = 3;
            label4.Text = "Fecha de entrega";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = SystemColors.Control;
            label5.Location = new Point(52, 266);
            label5.Name = "label5";
            label5.Size = new Size(100, 15);
            label5.TabIndex = 4;
            label5.Text = "Medio de entrega";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = SystemColors.Control;
            label6.Location = new Point(52, 309);
            label6.Name = "label6";
            label6.Size = new Size(42, 15);
            label6.TabIndex = 5;
            label6.Text = "Estado";
            // 
            // txtTarea
            // 
            txtTarea.Location = new Point(175, 105);
            txtTarea.Name = "txtTarea";
            txtTarea.Size = new Size(164, 23);
            txtTarea.TabIndex = 6;
            // 
            // txtMedio
            // 
            txtMedio.Location = new Point(175, 263);
            txtMedio.Name = "txtMedio";
            txtMedio.Size = new Size(164, 23);
            txtMedio.TabIndex = 7;
            // 
            // mtbFechaA
            // 
            mtbFechaA.Location = new Point(177, 183);
            mtbFechaA.Mask = "00/00/0000";
            mtbFechaA.Name = "mtbFechaA";
            mtbFechaA.Size = new Size(100, 23);
            mtbFechaA.TabIndex = 10;
            mtbFechaA.ValidatingType = typeof(DateTime);
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(52, 358);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(83, 35);
            btnAgregar.TabIndex = 12;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(177, 358);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(80, 35);
            btnEditar.TabIndex = 13;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(294, 358);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(81, 35);
            btnEliminar.TabIndex = 14;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ForeColor = SystemColors.Control;
            label7.Location = new Point(34, 18);
            label7.Name = "label7";
            label7.Size = new Size(223, 30);
            label7.TabIndex = 15;
            label7.Text = "¡Crea una nueva tarea!";
            // 
            // dwvTareas
            // 
            dwvTareas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dwvTareas.Location = new Point(412, 46);
            dwvTareas.Name = "dwvTareas";
            dwvTareas.Size = new Size(479, 300);
            dwvTareas.TabIndex = 16;
            dwvTareas.CellContentClick += dwvTareas_CellContentClick;
            // 
            // mtbFechaE
            // 
            mtbFechaE.Location = new Point(175, 223);
            mtbFechaE.Mask = "00/00/0000";
            mtbFechaE.Name = "mtbFechaE";
            mtbFechaE.Size = new Size(100, 23);
            mtbFechaE.TabIndex = 17;
            mtbFechaE.ValidatingType = typeof(DateTime);
            // 
            // txtTareaID
            // 
            txtTareaID.Enabled = false;
            txtTareaID.Location = new Point(175, 67);
            txtTareaID.Name = "txtTareaID";
            txtTareaID.Size = new Size(82, 23);
            txtTareaID.TabIndex = 19;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.ForeColor = SystemColors.Control;
            label8.Location = new Point(52, 71);
            label8.Name = "label8";
            label8.Size = new Size(48, 15);
            label8.TabIndex = 18;
            label8.Text = "TareaID:";
            // 
            // txtMateria
            // 
            txtMateria.Location = new Point(175, 142);
            txtMateria.Name = "txtMateria";
            txtMateria.Size = new Size(164, 23);
            txtMateria.TabIndex = 20;
            // 
            // txtEstado
            // 
            txtEstado.Location = new Point(175, 306);
            txtEstado.Name = "txtEstado";
            txtEstado.Size = new Size(164, 23);
            txtEstado.TabIndex = 21;
            // 
            // btnLimpiar
            // 
           /* btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(81, 35);
            btnLimpiar.TabIndex = 22;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;*/
            // 
            // Tareas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Maroon;
            ClientSize = new Size(932, 417);
            //Controls.Add(btnLimpiar);
            Controls.Add(txtEstado);
            Controls.Add(txtMateria);
            Controls.Add(txtTareaID);
            Controls.Add(label8);
            Controls.Add(mtbFechaE);
            Controls.Add(dwvTareas);
            Controls.Add(label7);
            Controls.Add(btnEliminar);
            Controls.Add(btnEditar);
            Controls.Add(btnAgregar);
            Controls.Add(mtbFechaA);
            Controls.Add(txtMedio);
            Controls.Add(txtTarea);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Tareas";
            Text = resources.GetString("$this.Text");
            Load += Tareas_Load;
            ((System.ComponentModel.ISupportInitialize)dwvTareas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox txtTarea;
        private TextBox txtMedio;
        private MaskedTextBox mtbFechaA;
        private Button btnAgregar;
        private Button btnEditar;
        private Button btnEliminar;
        private Label label7;
        private DataGridView dwvTareas;
        private MaskedTextBox mtbFechaE;
        private TextBox txtTareaID;
        private Label label8;
        private TextBox txtMateria;
        private TextBox txtEstado;
    }
}