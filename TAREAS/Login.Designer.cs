namespace TAREAS
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            label1 = new Label();
            label2 = new Label();
            txtUsuario = new TextBox();
            txtPassword = new TextBox();
            btnInicioSesion = new Button();
            groupBox1 = new GroupBox();
            pictureBox1 = new PictureBox();
            groupBox2 = new GroupBox();
            linkLabel1 = new LinkLabel();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(19, 91);
            label1.Name = "label1";
            label1.Size = new Size(83, 28);
            label1.TabIndex = 0;
            label1.Text = "Usuario:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(5, 185);
            label2.Name = "label2";
            label2.Size = new Size(97, 28);
            label2.TabIndex = 1;
            label2.Text = "Password:";
            // 
            // txtUsuario
            // 
            txtUsuario.Font = new Font("Segoe UI", 12F);
            txtUsuario.Location = new Point(108, 80);
            txtUsuario.Multiline = true;
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(301, 49);
            txtUsuario.TabIndex = 2;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 12F);
            txtPassword.Location = new Point(108, 176);
            txtPassword.Multiline = true;
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(301, 49);
            txtPassword.TabIndex = 3;
            // 
            // btnInicioSesion
            // 
            btnInicioSesion.BackColor = SystemColors.Highlight;
            btnInicioSesion.FlatAppearance.BorderSize = 2;
            btnInicioSesion.Font = new Font("Segoe UI", 12F);
            btnInicioSesion.ForeColor = Color.White;
            btnInicioSesion.Location = new Point(108, 262);
            btnInicioSesion.Name = "btnInicioSesion";
            btnInicioSesion.Size = new Size(301, 49);
            btnInicioSesion.TabIndex = 4;
            btnInicioSesion.Text = "Iniciar Sesión";
            btnInicioSesion.UseVisualStyleBackColor = false;
            btnInicioSesion.Click += btnInicioSesion_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(pictureBox1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(331, 375);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Logo";
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.BorderStyle = BorderStyle.Fixed3D;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(36, 38);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(240, 291);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(linkLabel1);
            groupBox2.Controls.Add(txtPassword);
            groupBox2.Controls.Add(btnInicioSesion);
            groupBox2.Controls.Add(txtUsuario);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(label2);
            groupBox2.Font = new Font("Segoe UI", 12F);
            groupBox2.Location = new Point(359, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(444, 392);
            groupBox2.TabIndex = 6;
            groupBox2.TabStop = false;
            groupBox2.Text = "Inicio de Sesion";
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Font = new Font("Segoe UI", 12F);
            linkLabel1.Location = new Point(187, 336);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(124, 28);
            linkLabel1.TabIndex = 6;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Crear Cuenta";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(815, 416);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "Login";
            Text = "Login";
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtUsuario;
        private TextBox txtPassword;
        private Button btnInicioSesion;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private LinkLabel linkLabel1;
        private PictureBox pictureBox1;
    }
}