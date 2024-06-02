namespace TAREAS
{
    partial class frmCrearMaterias
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtNombreMateria = new TextBox();
            btnAgregar = new Button();
            btnEditar = new Button();
            btnEliminar = new Button();
            dataGridViewMateria = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridViewMateria).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(81, 109);
            label1.Name = "label1";
            label1.Size = new Size(310, 41);
            label1.TabIndex = 0;
            label1.Text = "¡Bienvenido (Usuario)!";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.Control;
            label2.Location = new Point(81, 188);
            label2.Name = "label2";
            label2.Size = new Size(162, 20);
            label2.TabIndex = 1;
            label2.Text = "Para comenzar ------->";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = SystemColors.Control;
            label3.Location = new Point(81, 227);
            label3.Name = "label3";
            label3.Size = new Size(296, 20);
            label3.TabIndex = 2;
            label3.Text = "Ingresa las materias que llevas actualmente";
            // 
            // txtNombreMateria
            // 
            txtNombreMateria.Location = new Point(96, 279);
            txtNombreMateria.Margin = new Padding(3, 4, 3, 4);
            txtNombreMateria.Name = "txtNombreMateria";
            txtNombreMateria.Size = new Size(199, 27);
            txtNombreMateria.TabIndex = 3;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(98, 372);
            btnAgregar.Margin = new Padding(3, 4, 3, 4);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(86, 31);
            btnAgregar.TabIndex = 4;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(210, 372);
            btnEditar.Margin = new Padding(3, 4, 3, 4);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(86, 31);
            btnEditar.TabIndex = 5;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(318, 372);
            btnEliminar.Margin = new Padding(3, 4, 3, 4);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(86, 31);
            btnEliminar.TabIndex = 6;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // dataGridViewMateria
            // 
            dataGridViewMateria.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewMateria.Location = new Point(501, 133);
            dataGridViewMateria.Margin = new Padding(3, 4, 3, 4);
            dataGridViewMateria.Name = "dataGridViewMateria";
            dataGridViewMateria.RowHeadersWidth = 51;
            dataGridViewMateria.Size = new Size(321, 227);
            dataGridViewMateria.TabIndex = 7;
            dataGridViewMateria.CellContentClick += dataGridViewMateria_CellContentClick;
            // 
            // frmCrearMaterias
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Maroon;
            ClientSize = new Size(914, 527);
            Controls.Add(dataGridViewMateria);
            Controls.Add(btnEliminar);
            Controls.Add(btnEditar);
            Controls.Add(btnAgregar);
            Controls.Add(txtNombreMateria);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "frmCrearMaterias";
            Text = "frmCrearMaterias";
            Load += Materias_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewMateria).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNombreMateria;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.DataGridView dataGridViewMateria;
    }
}
