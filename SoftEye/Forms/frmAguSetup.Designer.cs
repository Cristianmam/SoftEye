namespace SoftEye
{
    partial class frmAguSetup
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
            this.grbTipo = new System.Windows.Forms.GroupBox();
            this.btnOpenFolder = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.cmbBoxAlfabeto = new System.Windows.Forms.ComboBox();
            this.grbOpciones = new System.Windows.Forms.GroupBox();
            this.rbtColor = new System.Windows.Forms.RadioButton();
            this.rbtSinColor = new System.Windows.Forms.RadioButton();
            this.grbColor = new System.Windows.Forms.GroupBox();
            this.btnEdit2 = new System.Windows.Forms.Button();
            this.btnEdit1 = new System.Windows.Forms.Button();
            this.picBoxSample2 = new System.Windows.Forms.PictureBox();
            this.picBoxSample1 = new System.Windows.Forms.PictureBox();
            this.chkColor2 = new System.Windows.Forms.CheckBox();
            this.chkColor1 = new System.Windows.Forms.CheckBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblPaciente = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.colDiag = new System.Windows.Forms.ColorDialog();
            this.cmbEscala = new System.Windows.Forms.ComboBox();
            this.lblEscala = new System.Windows.Forms.Label();
            this.grbTipo.SuspendLayout();
            this.grbOpciones.SuspendLayout();
            this.grbColor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxSample2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxSample1)).BeginInit();
            this.SuspendLayout();
            // 
            // grbTipo
            // 
            this.grbTipo.Controls.Add(this.btnOpenFolder);
            this.grbTipo.Controls.Add(this.btnRefresh);
            this.grbTipo.Controls.Add(this.cmbBoxAlfabeto);
            this.grbTipo.Location = new System.Drawing.Point(11, 217);
            this.grbTipo.Margin = new System.Windows.Forms.Padding(2);
            this.grbTipo.Name = "grbTipo";
            this.grbTipo.Padding = new System.Windows.Forms.Padding(2);
            this.grbTipo.Size = new System.Drawing.Size(143, 61);
            this.grbTipo.TabIndex = 0;
            this.grbTipo.TabStop = false;
            this.grbTipo.Text = "Tipo de alfabeto";
            // 
            // btnOpenFolder
            // 
            this.btnOpenFolder.Location = new System.Drawing.Point(113, 21);
            this.btnOpenFolder.Name = "btnOpenFolder";
            this.btnOpenFolder.Size = new System.Drawing.Size(25, 26);
            this.btnOpenFolder.TabIndex = 2;
            this.btnOpenFolder.Text = "...";
            this.btnOpenFolder.UseVisualStyleBackColor = true;
            this.btnOpenFolder.Click += new System.EventHandler(this.btnOpenFolder_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(85, 21);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(25, 26);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "R";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // cmbBoxAlfabeto
            // 
            this.cmbBoxAlfabeto.FormattingEnabled = true;
            this.cmbBoxAlfabeto.Location = new System.Drawing.Point(6, 24);
            this.cmbBoxAlfabeto.Name = "cmbBoxAlfabeto";
            this.cmbBoxAlfabeto.Size = new System.Drawing.Size(73, 21);
            this.cmbBoxAlfabeto.TabIndex = 0;
            // 
            // grbOpciones
            // 
            this.grbOpciones.Controls.Add(this.lblEscala);
            this.grbOpciones.Controls.Add(this.cmbEscala);
            this.grbOpciones.Controls.Add(this.rbtColor);
            this.grbOpciones.Controls.Add(this.rbtSinColor);
            this.grbOpciones.Controls.Add(this.grbColor);
            this.grbOpciones.Location = new System.Drawing.Point(11, 43);
            this.grbOpciones.Margin = new System.Windows.Forms.Padding(2);
            this.grbOpciones.Name = "grbOpciones";
            this.grbOpciones.Padding = new System.Windows.Forms.Padding(2);
            this.grbOpciones.Size = new System.Drawing.Size(285, 162);
            this.grbOpciones.TabIndex = 1;
            this.grbOpciones.TabStop = false;
            this.grbOpciones.Text = "Opciones";
            // 
            // rbtColor
            // 
            this.rbtColor.AutoCheck = false;
            this.rbtColor.AutoSize = true;
            this.rbtColor.Location = new System.Drawing.Point(21, 49);
            this.rbtColor.Margin = new System.Windows.Forms.Padding(2);
            this.rbtColor.Name = "rbtColor";
            this.rbtColor.Size = new System.Drawing.Size(115, 17);
            this.rbtColor.TabIndex = 2;
            this.rbtColor.TabStop = true;
            this.rbtColor.Text = "Con color de fondo";
            this.rbtColor.UseVisualStyleBackColor = true;
            this.rbtColor.Click += new System.EventHandler(this.rbtColor_Click);
            // 
            // rbtSinColor
            // 
            this.rbtSinColor.AutoSize = true;
            this.rbtSinColor.Checked = true;
            this.rbtSinColor.Location = new System.Drawing.Point(21, 22);
            this.rbtSinColor.Margin = new System.Windows.Forms.Padding(2);
            this.rbtSinColor.Name = "rbtSinColor";
            this.rbtSinColor.Size = new System.Drawing.Size(111, 17);
            this.rbtSinColor.TabIndex = 1;
            this.rbtSinColor.TabStop = true;
            this.rbtSinColor.Text = "Sin color de fondo";
            this.rbtSinColor.UseVisualStyleBackColor = true;
            this.rbtSinColor.Click += new System.EventHandler(this.rbtSinColor_Click);
            // 
            // grbColor
            // 
            this.grbColor.Controls.Add(this.btnEdit2);
            this.grbColor.Controls.Add(this.btnEdit1);
            this.grbColor.Controls.Add(this.picBoxSample2);
            this.grbColor.Controls.Add(this.picBoxSample1);
            this.grbColor.Controls.Add(this.chkColor2);
            this.grbColor.Controls.Add(this.chkColor1);
            this.grbColor.Location = new System.Drawing.Point(10, 79);
            this.grbColor.Margin = new System.Windows.Forms.Padding(2);
            this.grbColor.Name = "grbColor";
            this.grbColor.Padding = new System.Windows.Forms.Padding(2);
            this.grbColor.Size = new System.Drawing.Size(251, 71);
            this.grbColor.TabIndex = 0;
            this.grbColor.TabStop = false;
            this.grbColor.Text = "Color";
            // 
            // btnEdit2
            // 
            this.btnEdit2.Enabled = false;
            this.btnEdit2.Location = new System.Drawing.Point(218, 33);
            this.btnEdit2.Name = "btnEdit2";
            this.btnEdit2.Size = new System.Drawing.Size(26, 24);
            this.btnEdit2.TabIndex = 5;
            this.btnEdit2.Text = "...";
            this.btnEdit2.UseVisualStyleBackColor = true;
            this.btnEdit2.Click += new System.EventHandler(this.btnEdit2_Click);
            // 
            // btnEdit1
            // 
            this.btnEdit1.Enabled = false;
            this.btnEdit1.Location = new System.Drawing.Point(82, 33);
            this.btnEdit1.Name = "btnEdit1";
            this.btnEdit1.Size = new System.Drawing.Size(26, 24);
            this.btnEdit1.TabIndex = 4;
            this.btnEdit1.Text = "...";
            this.btnEdit1.UseVisualStyleBackColor = true;
            this.btnEdit1.Click += new System.EventHandler(this.btnEdit1_Click);
            // 
            // picBoxSample2
            // 
            this.picBoxSample2.BackColor = System.Drawing.Color.White;
            this.picBoxSample2.Location = new System.Drawing.Point(147, 41);
            this.picBoxSample2.Name = "picBoxSample2";
            this.picBoxSample2.Size = new System.Drawing.Size(65, 16);
            this.picBoxSample2.TabIndex = 3;
            this.picBoxSample2.TabStop = false;
            // 
            // picBoxSample1
            // 
            this.picBoxSample1.BackColor = System.Drawing.Color.White;
            this.picBoxSample1.Location = new System.Drawing.Point(11, 41);
            this.picBoxSample1.Name = "picBoxSample1";
            this.picBoxSample1.Size = new System.Drawing.Size(65, 16);
            this.picBoxSample1.TabIndex = 2;
            this.picBoxSample1.TabStop = false;
            // 
            // chkColor2
            // 
            this.chkColor2.AutoSize = true;
            this.chkColor2.Enabled = false;
            this.chkColor2.Location = new System.Drawing.Point(150, 19);
            this.chkColor2.Margin = new System.Windows.Forms.Padding(2);
            this.chkColor2.Name = "chkColor2";
            this.chkColor2.Size = new System.Drawing.Size(62, 17);
            this.chkColor2.TabIndex = 1;
            this.chkColor2.Text = "Color 2:";
            this.chkColor2.UseVisualStyleBackColor = true;
            // 
            // chkColor1
            // 
            this.chkColor1.AutoSize = true;
            this.chkColor1.Enabled = false;
            this.chkColor1.Location = new System.Drawing.Point(14, 19);
            this.chkColor1.Margin = new System.Windows.Forms.Padding(2);
            this.chkColor1.Name = "chkColor1";
            this.chkColor1.Size = new System.Drawing.Size(62, 17);
            this.chkColor1.TabIndex = 0;
            this.chkColor1.Text = "Color 1:";
            this.chkColor1.UseVisualStyleBackColor = true;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(15, 6);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(176, 13);
            this.lblTitulo.TabIndex = 2;
            this.lblTitulo.Text = "Prueba de Snellen para el paciente:";
            // 
            // lblPaciente
            // 
            this.lblPaciente.AutoSize = true;
            this.lblPaciente.Location = new System.Drawing.Point(37, 22);
            this.lblPaciente.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPaciente.Name = "lblPaciente";
            this.lblPaciente.Size = new System.Drawing.Size(65, 13);
            this.lblPaciente.TabIndex = 3;
            this.lblPaciente.Text = "PlaceHolder";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(158, 251);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(2);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(67, 26);
            this.btnAceptar.TabIndex = 19;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(229, 251);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(67, 26);
            this.btnCancelar.TabIndex = 20;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // cmbEscala
            // 
            this.cmbEscala.FormattingEnabled = true;
            this.cmbEscala.Items.AddRange(new object[] {
            "100%",
            "90%",
            "80%",
            "70%",
            "60%",
            "50%"});
            this.cmbEscala.Location = new System.Drawing.Point(181, 45);
            this.cmbEscala.Name = "cmbEscala";
            this.cmbEscala.Size = new System.Drawing.Size(73, 21);
            this.cmbEscala.TabIndex = 3;
            // 
            // lblEscala
            // 
            this.lblEscala.AutoSize = true;
            this.lblEscala.Location = new System.Drawing.Point(154, 24);
            this.lblEscala.Name = "lblEscala";
            this.lblEscala.Size = new System.Drawing.Size(100, 13);
            this.lblEscala.TabIndex = 4;
            this.lblEscala.Text = "Escala de simbolos:";
            // 
            // frmAguSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 288);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblPaciente);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.grbOpciones);
            this.Controls.Add(this.grbTipo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "frmAguSetup";
            this.Text = "Configuracion Snellen";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmAguSetup_FormClosed);
            this.Load += new System.EventHandler(this.frmAguSetup_Load);
            this.grbTipo.ResumeLayout(false);
            this.grbOpciones.ResumeLayout(false);
            this.grbOpciones.PerformLayout();
            this.grbColor.ResumeLayout(false);
            this.grbColor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxSample2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxSample1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grbTipo;
        private System.Windows.Forms.GroupBox grbOpciones;
        private System.Windows.Forms.GroupBox grbColor;
        private System.Windows.Forms.CheckBox chkColor2;
        private System.Windows.Forms.CheckBox chkColor1;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblPaciente;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.RadioButton rbtColor;
        private System.Windows.Forms.RadioButton rbtSinColor;
        private System.Windows.Forms.Button btnEdit2;
        private System.Windows.Forms.Button btnEdit1;
        private System.Windows.Forms.PictureBox picBoxSample2;
        private System.Windows.Forms.PictureBox picBoxSample1;
        private System.Windows.Forms.ColorDialog colDiag;
        private System.Windows.Forms.ComboBox cmbBoxAlfabeto;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnOpenFolder;
        private System.Windows.Forms.ComboBox cmbEscala;
        private System.Windows.Forms.Label lblEscala;
    }
}