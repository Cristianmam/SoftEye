
namespace SoftEye.Forms
{
    partial class frmTelefonos
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
            this.lblTelefono = new System.Windows.Forms.Label();
            this.dataGridTelefonos = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnPorDefecto = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.lblTelDePaciente = new System.Windows.Forms.Label();
            this.btnVolver = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTelefonos)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Location = new System.Drawing.Point(12, 9);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(52, 13);
            this.lblTelefono.TabIndex = 0;
            this.lblTelefono.Text = "Telefono:";
            // 
            // dataGridTelefonos
            // 
            this.dataGridTelefonos.AllowUserToAddRows = false;
            this.dataGridTelefonos.AllowUserToDeleteRows = false;
            this.dataGridTelefonos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridTelefonos.ColumnHeadersVisible = false;
            this.dataGridTelefonos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.telefono});
            this.dataGridTelefonos.Location = new System.Drawing.Point(12, 105);
            this.dataGridTelefonos.Name = "dataGridTelefonos";
            this.dataGridTelefonos.ReadOnly = true;
            this.dataGridTelefonos.RowHeadersVisible = false;
            this.dataGridTelefonos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridTelefonos.Size = new System.Drawing.Size(276, 302);
            this.dataGridTelefonos.TabIndex = 3;
            this.dataGridTelefonos.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridTelefonos_RowEnter);
            // 
            // id
            // 
            this.id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // telefono
            // 
            this.telefono.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.telefono.HeaderText = "telefono";
            this.telefono.Name = "telefono";
            this.telefono.ReadOnly = true;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Enabled = false;
            this.txtTelefono.Location = new System.Drawing.Point(12, 25);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(275, 20);
            this.txtTelefono.TabIndex = 7;
            this.txtTelefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTelefono_KeyPress);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(12, 51);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(58, 28);
            this.btnAgregar.TabIndex = 10;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnPorDefecto
            // 
            this.btnPorDefecto.Enabled = false;
            this.btnPorDefecto.Location = new System.Drawing.Point(15, 413);
            this.btnPorDefecto.Name = "btnPorDefecto";
            this.btnPorDefecto.Size = new System.Drawing.Size(110, 29);
            this.btnPorDefecto.TabIndex = 9;
            this.btnPorDefecto.Text = "Asignar por defecto";
            this.btnPorDefecto.UseVisualStyleBackColor = true;
            this.btnPorDefecto.Click += new System.EventHandler(this.btnPorDefecto_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Enabled = false;
            this.btnModificar.Location = new System.Drawing.Point(76, 51);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(58, 29);
            this.btnModificar.TabIndex = 8;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Enabled = false;
            this.btnEliminar.Location = new System.Drawing.Point(140, 50);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(58, 29);
            this.btnEliminar.TabIndex = 11;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // lblTelDePaciente
            // 
            this.lblTelDePaciente.AutoSize = true;
            this.lblTelDePaciente.Location = new System.Drawing.Point(12, 86);
            this.lblTelDePaciente.Name = "lblTelDePaciente";
            this.lblTelDePaciente.Size = new System.Drawing.Size(72, 13);
            this.lblTelDePaciente.TabIndex = 12;
            this.lblTelDePaciente.Text = "Telefonos de:";
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(218, 413);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(69, 28);
            this.btnVolver.TabIndex = 13;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // frmTelefonos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 447);
            this.ControlBox = false;
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.lblTelDePaciente);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnPorDefecto);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.dataGridTelefonos);
            this.Controls.Add(this.lblTelefono);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmTelefonos";
            this.Text = "Telefonos";
            this.Load += new System.EventHandler(this.frmTelefonos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTelefonos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.DataGridView dataGridTelefonos;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnPorDefecto;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Label lblTelDePaciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefono;
        private System.Windows.Forms.Button btnVolver;
    }
}