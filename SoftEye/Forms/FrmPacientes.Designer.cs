namespace SoftEye
{
    partial class frmPacientes
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.grbDatos = new System.Windows.Forms.GroupBox();
            this.lblApellido = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.btnTelefonos = new System.Windows.Forms.Button();
            this.btnLocalidad = new System.Windows.Forms.Button();
            this.cmbLocalidad = new System.Windows.Forms.ComboBox();
            this.lblLocalidad = new System.Windows.Forms.Label();
            this.btnModificarCancelar = new System.Windows.Forms.Button();
            this.btnPruebas = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnModificarConfirmar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.txtHistoriaClinica = new System.Windows.Forms.TextBox();
            this.lblHistoriaClinica = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtDomicilio = new System.Windows.Forms.TextBox();
            this.lblDomicilio = new System.Windows.Forms.Label();
            this.txtEdad = new System.Windows.Forms.TextBox();
            this.lblEdad = new System.Windows.Forms.Label();
            this.lblNacimiento = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtDNI = new System.Windows.Forms.TextBox();
            this.lblDNI = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNotas = new System.Windows.Forms.TextBox();
            this.lblNota = new System.Windows.Forms.Label();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnConfirmarNota = new System.Windows.Forms.Button();
            this.dataGridPacientes = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NYA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DNI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Localidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCancelarNota = new System.Windows.Forms.Button();
            this.dataGridNotas = new System.Windows.Forms.DataGridView();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idNota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblGridNotas = new System.Windows.Forms.Label();
            this.btnNuevaNota = new System.Windows.Forms.Button();
            this.btnEliminarNota = new System.Windows.Forms.Button();
            this.dtpFdn = new System.Windows.Forms.DateTimePicker();
            this.grbDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPacientes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridNotas)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(8, 9);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(105, 13);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Pacientes Anotados:";
            // 
            // grbDatos
            // 
            this.grbDatos.Controls.Add(this.dtpFdn);
            this.grbDatos.Controls.Add(this.lblApellido);
            this.grbDatos.Controls.Add(this.txtApellido);
            this.grbDatos.Controls.Add(this.btnTelefonos);
            this.grbDatos.Controls.Add(this.btnLocalidad);
            this.grbDatos.Controls.Add(this.cmbLocalidad);
            this.grbDatos.Controls.Add(this.lblLocalidad);
            this.grbDatos.Controls.Add(this.btnModificarCancelar);
            this.grbDatos.Controls.Add(this.btnPruebas);
            this.grbDatos.Controls.Add(this.btnModificar);
            this.grbDatos.Controls.Add(this.btnModificarConfirmar);
            this.grbDatos.Controls.Add(this.btnEliminar);
            this.grbDatos.Controls.Add(this.txtHistoriaClinica);
            this.grbDatos.Controls.Add(this.lblHistoriaClinica);
            this.grbDatos.Controls.Add(this.txtEmail);
            this.grbDatos.Controls.Add(this.lblEmail);
            this.grbDatos.Controls.Add(this.txtDomicilio);
            this.grbDatos.Controls.Add(this.lblDomicilio);
            this.grbDatos.Controls.Add(this.txtEdad);
            this.grbDatos.Controls.Add(this.lblEdad);
            this.grbDatos.Controls.Add(this.lblNacimiento);
            this.grbDatos.Controls.Add(this.txtTelefono);
            this.grbDatos.Controls.Add(this.lblTelefono);
            this.grbDatos.Controls.Add(this.txtDNI);
            this.grbDatos.Controls.Add(this.lblDNI);
            this.grbDatos.Controls.Add(this.txtNombre);
            this.grbDatos.Controls.Add(this.lblNombre);
            this.grbDatos.Location = new System.Drawing.Point(339, 9);
            this.grbDatos.Margin = new System.Windows.Forms.Padding(2);
            this.grbDatos.Name = "grbDatos";
            this.grbDatos.Padding = new System.Windows.Forms.Padding(2);
            this.grbDatos.Size = new System.Drawing.Size(380, 205);
            this.grbDatos.TabIndex = 2;
            this.grbDatos.TabStop = false;
            this.grbDatos.Text = "Datos:";
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new System.Drawing.Point(98, 23);
            this.lblApellido.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(47, 13);
            this.lblApellido.TabIndex = 26;
            this.lblApellido.Text = "Apellido:";
            // 
            // txtApellido
            // 
            this.txtApellido.Enabled = false;
            this.txtApellido.Location = new System.Drawing.Point(101, 38);
            this.txtApellido.Margin = new System.Windows.Forms.Padding(2);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(80, 20);
            this.txtApellido.TabIndex = 25;
            // 
            // btnTelefonos
            // 
            this.btnTelefonos.Enabled = false;
            this.btnTelefonos.Location = new System.Drawing.Point(343, 150);
            this.btnTelefonos.Name = "btnTelefonos";
            this.btnTelefonos.Size = new System.Drawing.Size(25, 21);
            this.btnTelefonos.TabIndex = 24;
            this.btnTelefonos.Text = "...";
            this.btnTelefonos.UseVisualStyleBackColor = true;
            this.btnTelefonos.Click += new System.EventHandler(this.btnTelefonos_Click);
            // 
            // btnLocalidad
            // 
            this.btnLocalidad.Location = new System.Drawing.Point(343, 114);
            this.btnLocalidad.Name = "btnLocalidad";
            this.btnLocalidad.Size = new System.Drawing.Size(25, 21);
            this.btnLocalidad.TabIndex = 23;
            this.btnLocalidad.Text = "...";
            this.btnLocalidad.UseVisualStyleBackColor = true;
            this.btnLocalidad.Click += new System.EventHandler(this.btnLocalidad_Click);
            // 
            // cmbLocalidad
            // 
            this.cmbLocalidad.Enabled = false;
            this.cmbLocalidad.FormattingEnabled = true;
            this.cmbLocalidad.Location = new System.Drawing.Point(200, 114);
            this.cmbLocalidad.Name = "cmbLocalidad";
            this.cmbLocalidad.Size = new System.Drawing.Size(137, 21);
            this.cmbLocalidad.TabIndex = 22;
            // 
            // lblLocalidad
            // 
            this.lblLocalidad.AutoSize = true;
            this.lblLocalidad.Location = new System.Drawing.Point(200, 97);
            this.lblLocalidad.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLocalidad.Name = "lblLocalidad";
            this.lblLocalidad.Size = new System.Drawing.Size(56, 13);
            this.lblLocalidad.TabIndex = 21;
            this.lblLocalidad.Text = "Localidad:";
            // 
            // btnModificarCancelar
            // 
            this.btnModificarCancelar.Enabled = false;
            this.btnModificarCancelar.Location = new System.Drawing.Point(284, 175);
            this.btnModificarCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnModificarCancelar.Name = "btnModificarCancelar";
            this.btnModificarCancelar.Size = new System.Drawing.Size(80, 26);
            this.btnModificarCancelar.TabIndex = 20;
            this.btnModificarCancelar.Text = "Cancelar";
            this.btnModificarCancelar.UseVisualStyleBackColor = true;
            this.btnModificarCancelar.Visible = false;
            this.btnModificarCancelar.Click += new System.EventHandler(this.btnModificarCancelar_Click);
            // 
            // btnPruebas
            // 
            this.btnPruebas.Enabled = false;
            this.btnPruebas.Location = new System.Drawing.Point(13, 175);
            this.btnPruebas.Margin = new System.Windows.Forms.Padding(2);
            this.btnPruebas.Name = "btnPruebas";
            this.btnPruebas.Size = new System.Drawing.Size(80, 26);
            this.btnPruebas.TabIndex = 18;
            this.btnPruebas.Text = "Tests";
            this.btnPruebas.UseVisualStyleBackColor = true;
            this.btnPruebas.Click += new System.EventHandler(this.btnPruebas_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Enabled = false;
            this.btnModificar.Location = new System.Drawing.Point(200, 175);
            this.btnModificar.Margin = new System.Windows.Forms.Padding(2);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(80, 26);
            this.btnModificar.TabIndex = 17;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnModificarConfirmar
            // 
            this.btnModificarConfirmar.Enabled = false;
            this.btnModificarConfirmar.Location = new System.Drawing.Point(200, 175);
            this.btnModificarConfirmar.Margin = new System.Windows.Forms.Padding(2);
            this.btnModificarConfirmar.Name = "btnModificarConfirmar";
            this.btnModificarConfirmar.Size = new System.Drawing.Size(80, 26);
            this.btnModificarConfirmar.TabIndex = 19;
            this.btnModificarConfirmar.Text = "Confirmar";
            this.btnModificarConfirmar.UseVisualStyleBackColor = true;
            this.btnModificarConfirmar.Visible = false;
            this.btnModificarConfirmar.Click += new System.EventHandler(this.btnModificarConfirmar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Enabled = false;
            this.btnEliminar.Location = new System.Drawing.Point(284, 175);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(2);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(80, 26);
            this.btnEliminar.TabIndex = 16;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // txtHistoriaClinica
            // 
            this.txtHistoriaClinica.Enabled = false;
            this.txtHistoriaClinica.Location = new System.Drawing.Point(200, 75);
            this.txtHistoriaClinica.Margin = new System.Windows.Forms.Padding(2);
            this.txtHistoriaClinica.Name = "txtHistoriaClinica";
            this.txtHistoriaClinica.Size = new System.Drawing.Size(168, 20);
            this.txtHistoriaClinica.TabIndex = 15;
            this.txtHistoriaClinica.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHistoriaClinica_KeyPress);
            // 
            // lblHistoriaClinica
            // 
            this.lblHistoriaClinica.AutoSize = true;
            this.lblHistoriaClinica.Location = new System.Drawing.Point(200, 60);
            this.lblHistoriaClinica.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHistoriaClinica.Name = "lblHistoriaClinica";
            this.lblHistoriaClinica.Size = new System.Drawing.Size(106, 13);
            this.lblHistoriaClinica.TabIndex = 14;
            this.lblHistoriaClinica.Text = "N° de historia clinica:";
            // 
            // txtEmail
            // 
            this.txtEmail.Enabled = false;
            this.txtEmail.Location = new System.Drawing.Point(13, 151);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(2);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(168, 20);
            this.txtEmail.TabIndex = 13;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(13, 136);
            this.lblEmail.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(38, 13);
            this.lblEmail.TabIndex = 12;
            this.lblEmail.Text = "E-mail:";
            // 
            // txtDomicilio
            // 
            this.txtDomicilio.Enabled = false;
            this.txtDomicilio.Location = new System.Drawing.Point(13, 114);
            this.txtDomicilio.Margin = new System.Windows.Forms.Padding(2);
            this.txtDomicilio.Name = "txtDomicilio";
            this.txtDomicilio.Size = new System.Drawing.Size(168, 20);
            this.txtDomicilio.TabIndex = 11;
            // 
            // lblDomicilio
            // 
            this.lblDomicilio.AutoSize = true;
            this.lblDomicilio.Location = new System.Drawing.Point(13, 97);
            this.lblDomicilio.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDomicilio.Name = "lblDomicilio";
            this.lblDomicilio.Size = new System.Drawing.Size(52, 13);
            this.lblDomicilio.TabIndex = 10;
            this.lblDomicilio.Text = "Domicilio:";
            // 
            // txtEdad
            // 
            this.txtEdad.Enabled = false;
            this.txtEdad.Location = new System.Drawing.Point(146, 75);
            this.txtEdad.Margin = new System.Windows.Forms.Padding(2);
            this.txtEdad.Name = "txtEdad";
            this.txtEdad.Size = new System.Drawing.Size(35, 20);
            this.txtEdad.TabIndex = 9;
            // 
            // lblEdad
            // 
            this.lblEdad.AutoSize = true;
            this.lblEdad.Location = new System.Drawing.Point(146, 60);
            this.lblEdad.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEdad.Name = "lblEdad";
            this.lblEdad.Size = new System.Drawing.Size(35, 13);
            this.lblEdad.TabIndex = 8;
            this.lblEdad.Text = "Edad:";
            // 
            // lblNacimiento
            // 
            this.lblNacimiento.AutoSize = true;
            this.lblNacimiento.Location = new System.Drawing.Point(10, 60);
            this.lblNacimiento.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNacimiento.Name = "lblNacimiento";
            this.lblNacimiento.Size = new System.Drawing.Size(109, 13);
            this.lblNacimiento.TabIndex = 6;
            this.lblNacimiento.Text = "Fecha de nacimiento:";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Enabled = false;
            this.txtTelefono.Location = new System.Drawing.Point(200, 151);
            this.txtTelefono.Margin = new System.Windows.Forms.Padding(2);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(137, 20);
            this.txtTelefono.TabIndex = 5;
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Location = new System.Drawing.Point(200, 136);
            this.lblTelefono.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(52, 13);
            this.lblTelefono.TabIndex = 4;
            this.lblTelefono.Text = "Teléfono:";
            // 
            // txtDNI
            // 
            this.txtDNI.Enabled = false;
            this.txtDNI.Location = new System.Drawing.Point(200, 38);
            this.txtDNI.Margin = new System.Windows.Forms.Padding(2);
            this.txtDNI.Name = "txtDNI";
            this.txtDNI.Size = new System.Drawing.Size(168, 20);
            this.txtDNI.TabIndex = 3;
            this.txtDNI.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDNI_KeyPress);
            // 
            // lblDNI
            // 
            this.lblDNI.AutoSize = true;
            this.lblDNI.Location = new System.Drawing.Point(200, 23);
            this.lblDNI.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDNI.Name = "lblDNI";
            this.lblDNI.Size = new System.Drawing.Size(29, 13);
            this.lblDNI.TabIndex = 2;
            this.lblDNI.Text = "DNI:";
            // 
            // txtNombre
            // 
            this.txtNombre.Enabled = false;
            this.txtNombre.Location = new System.Drawing.Point(13, 38);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(2);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(80, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(13, 23);
            this.lblNombre.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(47, 13);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre:";
            // 
            // txtNotas
            // 
            this.txtNotas.Enabled = false;
            this.txtNotas.Location = new System.Drawing.Point(465, 232);
            this.txtNotas.Margin = new System.Windows.Forms.Padding(2);
            this.txtNotas.Multiline = true;
            this.txtNotas.Name = "txtNotas";
            this.txtNotas.Size = new System.Drawing.Size(254, 131);
            this.txtNotas.TabIndex = 3;
            // 
            // lblNota
            // 
            this.lblNota.AutoSize = true;
            this.lblNota.Location = new System.Drawing.Point(462, 216);
            this.lblNota.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNota.Name = "lblNota";
            this.lblNota.Size = new System.Drawing.Size(33, 13);
            this.lblNota.TabIndex = 4;
            this.lblNota.Text = "Nota:";
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(240, 3);
            this.btnNuevo.Margin = new System.Windows.Forms.Padding(2);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(80, 26);
            this.btnNuevo.TabIndex = 18;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnConfirmarNota
            // 
            this.btnConfirmarNota.Enabled = false;
            this.btnConfirmarNota.Location = new System.Drawing.Point(542, 366);
            this.btnConfirmarNota.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirmarNota.Name = "btnConfirmarNota";
            this.btnConfirmarNota.Size = new System.Drawing.Size(80, 26);
            this.btnConfirmarNota.TabIndex = 20;
            this.btnConfirmarNota.Text = "Confirmar";
            this.btnConfirmarNota.UseVisualStyleBackColor = true;
            this.btnConfirmarNota.Visible = false;
            this.btnConfirmarNota.Click += new System.EventHandler(this.btnConfirmarNota_Click);
            // 
            // dataGridPacientes
            // 
            this.dataGridPacientes.AllowUserToAddRows = false;
            this.dataGridPacientes.AllowUserToDeleteRows = false;
            this.dataGridPacientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridPacientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.NYA,
            this.DNI,
            this.Localidad});
            this.dataGridPacientes.Location = new System.Drawing.Point(11, 34);
            this.dataGridPacientes.MultiSelect = false;
            this.dataGridPacientes.Name = "dataGridPacientes";
            this.dataGridPacientes.ReadOnly = true;
            this.dataGridPacientes.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridPacientes.RowHeadersVisible = false;
            this.dataGridPacientes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridPacientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridPacientes.Size = new System.Drawing.Size(317, 358);
            this.dataGridPacientes.TabIndex = 21;
            this.dataGridPacientes.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridPacientes_RowEnter);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            this.ID.Width = 25;
            // 
            // NYA
            // 
            this.NYA.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NYA.HeaderText = "Nombre";
            this.NYA.Name = "NYA";
            this.NYA.ReadOnly = true;
            // 
            // DNI
            // 
            this.DNI.HeaderText = "DNI";
            this.DNI.Name = "DNI";
            this.DNI.ReadOnly = true;
            // 
            // Localidad
            // 
            this.Localidad.HeaderText = "Localidad";
            this.Localidad.Name = "Localidad";
            this.Localidad.ReadOnly = true;
            // 
            // btnCancelarNota
            // 
            this.btnCancelarNota.Enabled = false;
            this.btnCancelarNota.Location = new System.Drawing.Point(623, 366);
            this.btnCancelarNota.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelarNota.Name = "btnCancelarNota";
            this.btnCancelarNota.Size = new System.Drawing.Size(80, 26);
            this.btnCancelarNota.TabIndex = 22;
            this.btnCancelarNota.Text = "Cancelar";
            this.btnCancelarNota.UseVisualStyleBackColor = true;
            this.btnCancelarNota.Visible = false;
            this.btnCancelarNota.Click += new System.EventHandler(this.btnCancelarNota_Click);
            // 
            // dataGridNotas
            // 
            this.dataGridNotas.AllowUserToAddRows = false;
            this.dataGridNotas.AllowUserToDeleteRows = false;
            this.dataGridNotas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridNotas.ColumnHeadersVisible = false;
            this.dataGridNotas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Fecha,
            this.idNota});
            this.dataGridNotas.Enabled = false;
            this.dataGridNotas.Location = new System.Drawing.Point(339, 232);
            this.dataGridNotas.Name = "dataGridNotas";
            this.dataGridNotas.ReadOnly = true;
            this.dataGridNotas.RowHeadersVisible = false;
            this.dataGridNotas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridNotas.Size = new System.Drawing.Size(119, 160);
            this.dataGridNotas.TabIndex = 23;
            this.dataGridNotas.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridNotas_RowEnter);
            // 
            // Fecha
            // 
            this.Fecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Fecha.HeaderText = "Fecha Nota";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            // 
            // idNota
            // 
            this.idNota.HeaderText = "idNota";
            this.idNota.Name = "idNota";
            this.idNota.ReadOnly = true;
            this.idNota.Visible = false;
            // 
            // lblGridNotas
            // 
            this.lblGridNotas.AutoSize = true;
            this.lblGridNotas.Location = new System.Drawing.Point(336, 216);
            this.lblGridNotas.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGridNotas.Name = "lblGridNotas";
            this.lblGridNotas.Size = new System.Drawing.Size(99, 13);
            this.lblGridNotas.TabIndex = 24;
            this.lblGridNotas.Text = "Notas del paciente:";
            // 
            // btnNuevaNota
            // 
            this.btnNuevaNota.Location = new System.Drawing.Point(542, 367);
            this.btnNuevaNota.Margin = new System.Windows.Forms.Padding(2);
            this.btnNuevaNota.Name = "btnNuevaNota";
            this.btnNuevaNota.Size = new System.Drawing.Size(80, 26);
            this.btnNuevaNota.TabIndex = 25;
            this.btnNuevaNota.Text = "Nueva Nota";
            this.btnNuevaNota.UseVisualStyleBackColor = true;
            this.btnNuevaNota.Visible = false;
            this.btnNuevaNota.Click += new System.EventHandler(this.btnNuevaNota_Click);
            // 
            // btnEliminarNota
            // 
            this.btnEliminarNota.Enabled = false;
            this.btnEliminarNota.Location = new System.Drawing.Point(623, 366);
            this.btnEliminarNota.Margin = new System.Windows.Forms.Padding(2);
            this.btnEliminarNota.Name = "btnEliminarNota";
            this.btnEliminarNota.Size = new System.Drawing.Size(80, 26);
            this.btnEliminarNota.TabIndex = 26;
            this.btnEliminarNota.Text = "Eliminar Nota";
            this.btnEliminarNota.UseVisualStyleBackColor = true;
            this.btnEliminarNota.Visible = false;
            this.btnEliminarNota.Click += new System.EventHandler(this.btnEliminarNota_Click);
            // 
            // dtpFdn
            // 
            this.dtpFdn.Enabled = false;
            this.dtpFdn.Location = new System.Drawing.Point(13, 74);
            this.dtpFdn.Name = "dtpFdn";
            this.dtpFdn.Size = new System.Drawing.Size(125, 20);
            this.dtpFdn.TabIndex = 27;
            // 
            // frmPacientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 396);
            this.Controls.Add(this.btnEliminarNota);
            this.Controls.Add(this.btnNuevaNota);
            this.Controls.Add(this.lblGridNotas);
            this.Controls.Add(this.dataGridNotas);
            this.Controls.Add(this.btnCancelarNota);
            this.Controls.Add(this.dataGridPacientes);
            this.Controls.Add(this.btnConfirmarNota);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.lblNota);
            this.Controls.Add(this.txtNotas);
            this.Controls.Add(this.grbDatos);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "frmPacientes";
            this.Text = "Pacientes";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPacientes_Closed);
            this.Load += new System.EventHandler(this.frmPacientes_Load);
            this.grbDatos.ResumeLayout(false);
            this.grbDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPacientes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridNotas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.GroupBox grbDatos;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.TextBox txtHistoriaClinica;
        private System.Windows.Forms.Label lblHistoriaClinica;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtDomicilio;
        private System.Windows.Forms.Label lblDomicilio;
        private System.Windows.Forms.TextBox txtEdad;
        private System.Windows.Forms.Label lblEdad;
        private System.Windows.Forms.Label lblNacimiento;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.TextBox txtDNI;
        private System.Windows.Forms.Label lblDNI;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNotas;
        private System.Windows.Forms.Label lblNota;
        private System.Windows.Forms.Button btnPruebas;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnConfirmarNota;
        private System.Windows.Forms.DataGridView dataGridPacientes;
        private System.Windows.Forms.Button btnModificarConfirmar;
        private System.Windows.Forms.Button btnModificarCancelar;
        private System.Windows.Forms.Button btnCancelarNota;
        private System.Windows.Forms.Label lblLocalidad;
        private System.Windows.Forms.Button btnTelefonos;
        private System.Windows.Forms.Button btnLocalidad;
        private System.Windows.Forms.ComboBox cmbLocalidad;
        private System.Windows.Forms.DataGridView dataGridNotas;
        private System.Windows.Forms.Label lblGridNotas;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NYA;
        private System.Windows.Forms.DataGridViewTextBoxColumn DNI;
        private System.Windows.Forms.DataGridViewTextBoxColumn Localidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn idNota;
        private System.Windows.Forms.Button btnNuevaNota;
        private System.Windows.Forms.Button btnEliminarNota;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.DateTimePicker dtpFdn;
    }
}