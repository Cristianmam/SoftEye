
namespace SoftEye.Forms
{
    partial class frmGenReporte
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
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblFechaIni = new System.Windows.Forms.Label();
            this.dtpInicioRep = new System.Windows.Forms.DateTimePicker();
            this.dtpFinRep = new System.Windows.Forms.DateTimePicker();
            this.lblFechaFin = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(13, 59);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(85, 30);
            this.btnAceptar.TabIndex = 1;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(240, 59);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(85, 30);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblFechaIni
            // 
            this.lblFechaIni.AutoSize = true;
            this.lblFechaIni.Location = new System.Drawing.Point(9, 9);
            this.lblFechaIni.Name = "lblFechaIni";
            this.lblFechaIni.Size = new System.Drawing.Size(152, 13);
            this.lblFechaIni.TabIndex = 3;
            this.lblFechaIni.Text = "Fecha para el inicio del reporte";
            // 
            // dtpInicioRep
            // 
            this.dtpInicioRep.Location = new System.Drawing.Point(13, 26);
            this.dtpInicioRep.Name = "dtpInicioRep";
            this.dtpInicioRep.Size = new System.Drawing.Size(130, 20);
            this.dtpInicioRep.TabIndex = 4;
            // 
            // dtpFinRep
            // 
            this.dtpFinRep.Location = new System.Drawing.Point(171, 26);
            this.dtpFinRep.Name = "dtpFinRep";
            this.dtpFinRep.Size = new System.Drawing.Size(130, 20);
            this.dtpFinRep.TabIndex = 6;
            // 
            // lblFechaFin
            // 
            this.lblFechaFin.AutoSize = true;
            this.lblFechaFin.Location = new System.Drawing.Point(167, 9);
            this.lblFechaFin.Name = "lblFechaFin";
            this.lblFechaFin.Size = new System.Drawing.Size(152, 13);
            this.lblFechaFin.TabIndex = 5;
            this.lblFechaFin.Text = "Fecha para el inicio del reporte";
            // 
            // frmGenReporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 101);
            this.Controls.Add(this.dtpFinRep);
            this.Controls.Add(this.lblFechaFin);
            this.Controls.Add(this.dtpInicioRep);
            this.Controls.Add(this.lblFechaIni);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Name = "frmGenReporte";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblFechaIni;
        private System.Windows.Forms.DateTimePicker dtpInicioRep;
        private System.Windows.Forms.DateTimePicker dtpFinRep;
        private System.Windows.Forms.Label lblFechaFin;
    }
}