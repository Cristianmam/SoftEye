
namespace SoftEye.Forms
{
    partial class frmAgregarPaciente
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
            this.grbDatos = new System.Windows.Forms.GroupBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtHistoriaClinica = new System.Windows.Forms.TextBox();
            this.lblHistoriaClinica = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtDomicilio = new System.Windows.Forms.TextBox();
            this.lblDomicilio = new System.Windows.Forms.Label();
            this.txtNacimiento = new System.Windows.Forms.TextBox();
            this.lblNacimiento = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtDNI = new System.Windows.Forms.TextBox();
            this.lblDNI = new System.Windows.Forms.Label();
            this.txtNYA = new System.Windows.Forms.TextBox();
            this.lblNYA = new System.Windows.Forms.Label();
            this.grbDatos.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbDatos
            // 
            this.grbDatos.Controls.Add(this.btnAceptar);
            this.grbDatos.Controls.Add(this.btnCancelar);
            this.grbDatos.Controls.Add(this.txtHistoriaClinica);
            this.grbDatos.Controls.Add(this.lblHistoriaClinica);
            this.grbDatos.Controls.Add(this.txtEmail);
            this.grbDatos.Controls.Add(this.lblEmail);
            this.grbDatos.Controls.Add(this.txtDomicilio);
            this.grbDatos.Controls.Add(this.lblDomicilio);
            this.grbDatos.Controls.Add(this.txtNacimiento);
            this.grbDatos.Controls.Add(this.lblNacimiento);
            this.grbDatos.Controls.Add(this.txtTelefono);
            this.grbDatos.Controls.Add(this.lblTelefono);
            this.grbDatos.Controls.Add(this.txtDNI);
            this.grbDatos.Controls.Add(this.lblDNI);
            this.grbDatos.Controls.Add(this.txtNYA);
            this.grbDatos.Controls.Add(this.lblNYA);
            this.grbDatos.Location = new System.Drawing.Point(11, 11);
            this.grbDatos.Margin = new System.Windows.Forms.Padding(2);
            this.grbDatos.Name = "grbDatos";
            this.grbDatos.Padding = new System.Windows.Forms.Padding(2);
            this.grbDatos.Size = new System.Drawing.Size(380, 205);
            this.grbDatos.TabIndex = 3;
            this.grbDatos.TabStop = false;
            this.grbDatos.Text = "Datos:";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(200, 175);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(2);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(80, 26);
            this.btnAceptar.TabIndex = 17;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(284, 175);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(80, 26);
            this.btnCancelar.TabIndex = 16;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtHistoriaClinica
            // 
            this.txtHistoriaClinica.Location = new System.Drawing.Point(200, 114);
            this.txtHistoriaClinica.Margin = new System.Windows.Forms.Padding(2);
            this.txtHistoriaClinica.Name = "txtHistoriaClinica";
            this.txtHistoriaClinica.Size = new System.Drawing.Size(168, 20);
            this.txtHistoriaClinica.TabIndex = 15;
            // 
            // lblHistoriaClinica
            // 
            this.lblHistoriaClinica.AutoSize = true;
            this.lblHistoriaClinica.Location = new System.Drawing.Point(200, 99);
            this.lblHistoriaClinica.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHistoriaClinica.Name = "lblHistoriaClinica";
            this.lblHistoriaClinica.Size = new System.Drawing.Size(106, 13);
            this.lblHistoriaClinica.TabIndex = 14;
            this.lblHistoriaClinica.Text = "N° de historia clinica:";
            // 
            // txtEmail
            // 
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
            this.txtDomicilio.Location = new System.Drawing.Point(200, 77);
            this.txtDomicilio.Margin = new System.Windows.Forms.Padding(2);
            this.txtDomicilio.Name = "txtDomicilio";
            this.txtDomicilio.Size = new System.Drawing.Size(168, 20);
            this.txtDomicilio.TabIndex = 11;
            // 
            // lblDomicilio
            // 
            this.lblDomicilio.AutoSize = true;
            this.lblDomicilio.Location = new System.Drawing.Point(200, 60);
            this.lblDomicilio.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDomicilio.Name = "lblDomicilio";
            this.lblDomicilio.Size = new System.Drawing.Size(52, 13);
            this.lblDomicilio.TabIndex = 10;
            this.lblDomicilio.Text = "Domicilio:";
            // 
            // txtNacimiento
            // 
            this.txtNacimiento.Location = new System.Drawing.Point(200, 38);
            this.txtNacimiento.Margin = new System.Windows.Forms.Padding(2);
            this.txtNacimiento.Name = "txtNacimiento";
            this.txtNacimiento.Size = new System.Drawing.Size(168, 20);
            this.txtNacimiento.TabIndex = 7;
            // 
            // lblNacimiento
            // 
            this.lblNacimiento.AutoSize = true;
            this.lblNacimiento.Location = new System.Drawing.Point(200, 23);
            this.lblNacimiento.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNacimiento.Name = "lblNacimiento";
            this.lblNacimiento.Size = new System.Drawing.Size(109, 13);
            this.lblNacimiento.TabIndex = 6;
            this.lblNacimiento.Text = "Fecha de nacimiento:";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(13, 114);
            this.txtTelefono.Margin = new System.Windows.Forms.Padding(2);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(168, 20);
            this.txtTelefono.TabIndex = 5;
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Location = new System.Drawing.Point(13, 97);
            this.lblTelefono.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(52, 13);
            this.lblTelefono.TabIndex = 4;
            this.lblTelefono.Text = "Teléfono:";
            // 
            // txtDNI
            // 
            this.txtDNI.Location = new System.Drawing.Point(13, 75);
            this.txtDNI.Margin = new System.Windows.Forms.Padding(2);
            this.txtDNI.Name = "txtDNI";
            this.txtDNI.Size = new System.Drawing.Size(168, 20);
            this.txtDNI.TabIndex = 3;
            // 
            // lblDNI
            // 
            this.lblDNI.AutoSize = true;
            this.lblDNI.Location = new System.Drawing.Point(13, 60);
            this.lblDNI.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDNI.Name = "lblDNI";
            this.lblDNI.Size = new System.Drawing.Size(29, 13);
            this.lblDNI.TabIndex = 2;
            this.lblDNI.Text = "DNI:";
            // 
            // txtNYA
            // 
            this.txtNYA.Location = new System.Drawing.Point(13, 38);
            this.txtNYA.Margin = new System.Windows.Forms.Padding(2);
            this.txtNYA.Name = "txtNYA";
            this.txtNYA.Size = new System.Drawing.Size(168, 20);
            this.txtNYA.TabIndex = 1;
            // 
            // lblNYA
            // 
            this.lblNYA.AutoSize = true;
            this.lblNYA.Location = new System.Drawing.Point(13, 23);
            this.lblNYA.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNYA.Name = "lblNYA";
            this.lblNYA.Size = new System.Drawing.Size(94, 13);
            this.lblNYA.TabIndex = 0;
            this.lblNYA.Text = "Nombre y apellido:";
            // 
            // frmAgregarPaciente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 220);
            this.ControlBox = false;
            this.Controls.Add(this.grbDatos);
            this.MaximizeBox = false;
            this.Name = "frmAgregarPaciente";
            this.Text = "Agregar Paciente";
            this.Load += new System.EventHandler(this.frmAgregarPaciente_Load);
            this.grbDatos.ResumeLayout(false);
            this.grbDatos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbDatos;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtHistoriaClinica;
        private System.Windows.Forms.Label lblHistoriaClinica;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtDomicilio;
        private System.Windows.Forms.Label lblDomicilio;
        private System.Windows.Forms.TextBox txtNacimiento;
        private System.Windows.Forms.Label lblNacimiento;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.TextBox txtDNI;
        private System.Windows.Forms.Label lblDNI;
        private System.Windows.Forms.TextBox txtNYA;
        private System.Windows.Forms.Label lblNYA;
    }
}