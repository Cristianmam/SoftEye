
namespace SoftEye.Forms
{
    partial class frmTestViewer
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
            this.dataGridTests = new System.Windows.Forms.DataGridView();
            this.grbPreview = new System.Windows.Forms.GroupBox();
            this.grbResPerimetria = new System.Windows.Forms.GroupBox();
            this.btnVerResultsPeri = new System.Windows.Forms.Button();
            this.txtNota = new System.Windows.Forms.RichTextBox();
            this.btnEditarNota = new System.Windows.Forms.Button();
            this.lblTextNotas = new System.Windows.Forms.Label();
            this.grbResSnellen = new System.Windows.Forms.GroupBox();
            this.lblSneRes2040 = new System.Windows.Forms.Label();
            this.lblTSne2040 = new System.Windows.Forms.Label();
            this.lblSneRes2020 = new System.Windows.Forms.Label();
            this.lblSneRes2025 = new System.Windows.Forms.Label();
            this.lblSneRes2030 = new System.Windows.Forms.Label();
            this.lblSneRes2050 = new System.Windows.Forms.Label();
            this.lblSneRes2070 = new System.Windows.Forms.Label();
            this.lblSneRes20100 = new System.Windows.Forms.Label();
            this.lblSneRes20200 = new System.Windows.Forms.Label();
            this.lblTSne2020 = new System.Windows.Forms.Label();
            this.lblTSne2025 = new System.Windows.Forms.Label();
            this.lblTSne2030 = new System.Windows.Forms.Label();
            this.lblTSne2050 = new System.Windows.Forms.Label();
            this.lblTSne2070 = new System.Windows.Forms.Label();
            this.lblTSne20100 = new System.Windows.Forms.Label();
            this.lblTSne20200 = new System.Windows.Forms.Label();
            this.lblTSnellenAciertos = new System.Windows.Forms.Label();
            this.lblTestFecha = new System.Windows.Forms.Label();
            this.lblTextFecha = new System.Windows.Forms.Label();
            this.grbTipoTest = new System.Windows.Forms.GroupBox();
            this.cmbTipoTest = new System.Windows.Forms.ComboBox();
            this.btnNuevaPrueba = new System.Windows.Forms.Button();
            this.btnRegresar = new System.Windows.Forms.Button();
            this.btnConfirmarNota = new System.Windows.Forms.Button();
            this.btnCancelarNota = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTests)).BeginInit();
            this.grbPreview.SuspendLayout();
            this.grbResPerimetria.SuspendLayout();
            this.grbResSnellen.SuspendLayout();
            this.grbTipoTest.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridTests
            // 
            this.dataGridTests.AllowUserToAddRows = false;
            this.dataGridTests.AllowUserToDeleteRows = false;
            this.dataGridTests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridTests.Location = new System.Drawing.Point(12, 66);
            this.dataGridTests.MultiSelect = false;
            this.dataGridTests.Name = "dataGridTests";
            this.dataGridTests.ReadOnly = true;
            this.dataGridTests.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridTests.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridTests.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridTests.Size = new System.Drawing.Size(257, 383);
            this.dataGridTests.TabIndex = 0;
            this.dataGridTests.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridTests_RowEnter);
            this.dataGridTests.MouseEnter += new System.EventHandler(this.cmbTipoTest_SelectedIndexChanged);
            // 
            // grbPreview
            // 
            this.grbPreview.Controls.Add(this.btnEliminar);
            this.grbPreview.Controls.Add(this.grbResPerimetria);
            this.grbPreview.Controls.Add(this.txtNota);
            this.grbPreview.Controls.Add(this.btnEditarNota);
            this.grbPreview.Controls.Add(this.lblTextNotas);
            this.grbPreview.Controls.Add(this.grbResSnellen);
            this.grbPreview.Controls.Add(this.lblTestFecha);
            this.grbPreview.Controls.Add(this.lblTextFecha);
            this.grbPreview.Location = new System.Drawing.Point(288, 12);
            this.grbPreview.Name = "grbPreview";
            this.grbPreview.Size = new System.Drawing.Size(184, 406);
            this.grbPreview.TabIndex = 1;
            this.grbPreview.TabStop = false;
            this.grbPreview.Text = "Info:";
            // 
            // grbResPerimetria
            // 
            this.grbResPerimetria.Controls.Add(this.btnVerResultsPeri);
            this.grbResPerimetria.Location = new System.Drawing.Point(34, 48);
            this.grbResPerimetria.Name = "grbResPerimetria";
            this.grbResPerimetria.Size = new System.Drawing.Size(120, 53);
            this.grbResPerimetria.TabIndex = 23;
            this.grbResPerimetria.TabStop = false;
            this.grbResPerimetria.Text = "Test de perimetria:";
            this.grbResPerimetria.Visible = false;
            // 
            // btnVerResultsPeri
            // 
            this.btnVerResultsPeri.Enabled = false;
            this.btnVerResultsPeri.Location = new System.Drawing.Point(20, 18);
            this.btnVerResultsPeri.Margin = new System.Windows.Forms.Padding(2);
            this.btnVerResultsPeri.Name = "btnVerResultsPeri";
            this.btnVerResultsPeri.Size = new System.Drawing.Size(80, 26);
            this.btnVerResultsPeri.TabIndex = 24;
            this.btnVerResultsPeri.Text = "Ver Test";
            this.btnVerResultsPeri.UseVisualStyleBackColor = true;
            this.btnVerResultsPeri.Click += new System.EventHandler(this.btnVerResultsPeri_Click);
            // 
            // txtNota
            // 
            this.txtNota.Enabled = false;
            this.txtNota.Location = new System.Drawing.Point(6, 303);
            this.txtNota.Name = "txtNota";
            this.txtNota.Size = new System.Drawing.Size(172, 95);
            this.txtNota.TabIndex = 22;
            this.txtNota.Text = "";
            // 
            // btnEditarNota
            // 
            this.btnEditarNota.Enabled = false;
            this.btnEditarNota.Location = new System.Drawing.Point(88, 272);
            this.btnEditarNota.Margin = new System.Windows.Forms.Padding(2);
            this.btnEditarNota.Name = "btnEditarNota";
            this.btnEditarNota.Size = new System.Drawing.Size(80, 26);
            this.btnEditarNota.TabIndex = 21;
            this.btnEditarNota.Text = "Editar Nota";
            this.btnEditarNota.UseVisualStyleBackColor = true;
            this.btnEditarNota.Click += new System.EventHandler(this.btnEditarNota_Click);
            // 
            // lblTextNotas
            // 
            this.lblTextNotas.AutoSize = true;
            this.lblTextNotas.Location = new System.Drawing.Point(17, 279);
            this.lblTextNotas.Name = "lblTextNotas";
            this.lblTextNotas.Size = new System.Drawing.Size(38, 13);
            this.lblTextNotas.TabIndex = 4;
            this.lblTextNotas.Text = "Notas:";
            // 
            // grbResSnellen
            // 
            this.grbResSnellen.Controls.Add(this.lblSneRes2040);
            this.grbResSnellen.Controls.Add(this.lblTSne2040);
            this.grbResSnellen.Controls.Add(this.lblSneRes2020);
            this.grbResSnellen.Controls.Add(this.lblSneRes2025);
            this.grbResSnellen.Controls.Add(this.lblSneRes2030);
            this.grbResSnellen.Controls.Add(this.lblSneRes2050);
            this.grbResSnellen.Controls.Add(this.lblSneRes2070);
            this.grbResSnellen.Controls.Add(this.lblSneRes20100);
            this.grbResSnellen.Controls.Add(this.lblSneRes20200);
            this.grbResSnellen.Controls.Add(this.lblTSne2020);
            this.grbResSnellen.Controls.Add(this.lblTSne2025);
            this.grbResSnellen.Controls.Add(this.lblTSne2030);
            this.grbResSnellen.Controls.Add(this.lblTSne2050);
            this.grbResSnellen.Controls.Add(this.lblTSne2070);
            this.grbResSnellen.Controls.Add(this.lblTSne20100);
            this.grbResSnellen.Controls.Add(this.lblTSne20200);
            this.grbResSnellen.Controls.Add(this.lblTSnellenAciertos);
            this.grbResSnellen.Location = new System.Drawing.Point(18, 47);
            this.grbResSnellen.Name = "grbResSnellen";
            this.grbResSnellen.Size = new System.Drawing.Size(150, 193);
            this.grbResSnellen.TabIndex = 3;
            this.grbResSnellen.TabStop = false;
            this.grbResSnellen.Text = "Resultados:";
            this.grbResSnellen.Visible = false;
            // 
            // lblSneRes2040
            // 
            this.lblSneRes2040.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSneRes2040.AutoSize = true;
            this.lblSneRes2040.Location = new System.Drawing.Point(100, 110);
            this.lblSneRes2040.Name = "lblSneRes2040";
            this.lblSneRes2040.Size = new System.Drawing.Size(24, 13);
            this.lblSneRes2040.TabIndex = 16;
            this.lblSneRes2040.Text = "0/5";
            // 
            // lblTSne2040
            // 
            this.lblTSne2040.AutoSize = true;
            this.lblTSne2040.Location = new System.Drawing.Point(10, 110);
            this.lblTSne2040.Name = "lblTSne2040";
            this.lblTSne2040.Size = new System.Drawing.Size(39, 13);
            this.lblTSne2040.TabIndex = 15;
            this.lblTSne2040.Text = "20/40:";
            // 
            // lblSneRes2020
            // 
            this.lblSneRes2020.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSneRes2020.AutoSize = true;
            this.lblSneRes2020.Location = new System.Drawing.Point(100, 170);
            this.lblSneRes2020.Name = "lblSneRes2020";
            this.lblSneRes2020.Size = new System.Drawing.Size(24, 13);
            this.lblSneRes2020.TabIndex = 14;
            this.lblSneRes2020.Text = "0/8";
            // 
            // lblSneRes2025
            // 
            this.lblSneRes2025.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSneRes2025.AutoSize = true;
            this.lblSneRes2025.Location = new System.Drawing.Point(100, 150);
            this.lblSneRes2025.Name = "lblSneRes2025";
            this.lblSneRes2025.Size = new System.Drawing.Size(24, 13);
            this.lblSneRes2025.TabIndex = 13;
            this.lblSneRes2025.Text = "0/7";
            // 
            // lblSneRes2030
            // 
            this.lblSneRes2030.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSneRes2030.AutoSize = true;
            this.lblSneRes2030.Location = new System.Drawing.Point(100, 130);
            this.lblSneRes2030.Name = "lblSneRes2030";
            this.lblSneRes2030.Size = new System.Drawing.Size(24, 13);
            this.lblSneRes2030.TabIndex = 12;
            this.lblSneRes2030.Text = "0/6";
            // 
            // lblSneRes2050
            // 
            this.lblSneRes2050.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSneRes2050.AutoSize = true;
            this.lblSneRes2050.Location = new System.Drawing.Point(100, 90);
            this.lblSneRes2050.Name = "lblSneRes2050";
            this.lblSneRes2050.Size = new System.Drawing.Size(24, 13);
            this.lblSneRes2050.TabIndex = 11;
            this.lblSneRes2050.Text = "0/4";
            // 
            // lblSneRes2070
            // 
            this.lblSneRes2070.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSneRes2070.AutoSize = true;
            this.lblSneRes2070.Location = new System.Drawing.Point(100, 70);
            this.lblSneRes2070.Name = "lblSneRes2070";
            this.lblSneRes2070.Size = new System.Drawing.Size(24, 13);
            this.lblSneRes2070.TabIndex = 10;
            this.lblSneRes2070.Text = "0/3";
            // 
            // lblSneRes20100
            // 
            this.lblSneRes20100.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSneRes20100.AutoSize = true;
            this.lblSneRes20100.Location = new System.Drawing.Point(100, 50);
            this.lblSneRes20100.Name = "lblSneRes20100";
            this.lblSneRes20100.Size = new System.Drawing.Size(24, 13);
            this.lblSneRes20100.TabIndex = 9;
            this.lblSneRes20100.Text = "0/2";
            // 
            // lblSneRes20200
            // 
            this.lblSneRes20200.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSneRes20200.AutoSize = true;
            this.lblSneRes20200.Location = new System.Drawing.Point(100, 30);
            this.lblSneRes20200.Name = "lblSneRes20200";
            this.lblSneRes20200.Size = new System.Drawing.Size(24, 13);
            this.lblSneRes20200.TabIndex = 8;
            this.lblSneRes20200.Text = "0/1";
            // 
            // lblTSne2020
            // 
            this.lblTSne2020.AutoSize = true;
            this.lblTSne2020.Location = new System.Drawing.Point(10, 170);
            this.lblTSne2020.Name = "lblTSne2020";
            this.lblTSne2020.Size = new System.Drawing.Size(39, 13);
            this.lblTSne2020.TabIndex = 7;
            this.lblTSne2020.Text = "20/20:";
            // 
            // lblTSne2025
            // 
            this.lblTSne2025.AutoSize = true;
            this.lblTSne2025.Location = new System.Drawing.Point(10, 150);
            this.lblTSne2025.Name = "lblTSne2025";
            this.lblTSne2025.Size = new System.Drawing.Size(39, 13);
            this.lblTSne2025.TabIndex = 6;
            this.lblTSne2025.Text = "20/25:";
            // 
            // lblTSne2030
            // 
            this.lblTSne2030.AutoSize = true;
            this.lblTSne2030.Location = new System.Drawing.Point(10, 130);
            this.lblTSne2030.Name = "lblTSne2030";
            this.lblTSne2030.Size = new System.Drawing.Size(39, 13);
            this.lblTSne2030.TabIndex = 5;
            this.lblTSne2030.Text = "20/30:";
            // 
            // lblTSne2050
            // 
            this.lblTSne2050.AutoSize = true;
            this.lblTSne2050.Location = new System.Drawing.Point(10, 90);
            this.lblTSne2050.Name = "lblTSne2050";
            this.lblTSne2050.Size = new System.Drawing.Size(39, 13);
            this.lblTSne2050.TabIndex = 4;
            this.lblTSne2050.Text = "20/50:";
            // 
            // lblTSne2070
            // 
            this.lblTSne2070.AutoSize = true;
            this.lblTSne2070.Location = new System.Drawing.Point(10, 70);
            this.lblTSne2070.Name = "lblTSne2070";
            this.lblTSne2070.Size = new System.Drawing.Size(39, 13);
            this.lblTSne2070.TabIndex = 3;
            this.lblTSne2070.Text = "20/70:";
            // 
            // lblTSne20100
            // 
            this.lblTSne20100.AutoSize = true;
            this.lblTSne20100.Location = new System.Drawing.Point(10, 50);
            this.lblTSne20100.Name = "lblTSne20100";
            this.lblTSne20100.Size = new System.Drawing.Size(45, 13);
            this.lblTSne20100.TabIndex = 2;
            this.lblTSne20100.Text = "20/100:";
            // 
            // lblTSne20200
            // 
            this.lblTSne20200.AutoSize = true;
            this.lblTSne20200.Location = new System.Drawing.Point(10, 30);
            this.lblTSne20200.Name = "lblTSne20200";
            this.lblTSne20200.Size = new System.Drawing.Size(45, 13);
            this.lblTSne20200.TabIndex = 1;
            this.lblTSne20200.Text = "20/200:";
            // 
            // lblTSnellenAciertos
            // 
            this.lblTSnellenAciertos.AutoSize = true;
            this.lblTSnellenAciertos.Location = new System.Drawing.Point(6, 16);
            this.lblTSnellenAciertos.Name = "lblTSnellenAciertos";
            this.lblTSnellenAciertos.Size = new System.Drawing.Size(48, 13);
            this.lblTSnellenAciertos.TabIndex = 0;
            this.lblTSnellenAciertos.Text = "Aciertos:";
            // 
            // lblTestFecha
            // 
            this.lblTestFecha.AutoSize = true;
            this.lblTestFecha.Location = new System.Drawing.Point(73, 24);
            this.lblTestFecha.Name = "lblTestFecha";
            this.lblTestFecha.Size = new System.Drawing.Size(0, 13);
            this.lblTestFecha.TabIndex = 2;
            // 
            // lblTextFecha
            // 
            this.lblTextFecha.AutoSize = true;
            this.lblTextFecha.Location = new System.Drawing.Point(15, 24);
            this.lblTextFecha.Name = "lblTextFecha";
            this.lblTextFecha.Size = new System.Drawing.Size(40, 13);
            this.lblTextFecha.TabIndex = 0;
            this.lblTextFecha.Text = "Fecha:";
            // 
            // grbTipoTest
            // 
            this.grbTipoTest.Controls.Add(this.cmbTipoTest);
            this.grbTipoTest.Location = new System.Drawing.Point(12, 12);
            this.grbTipoTest.Name = "grbTipoTest";
            this.grbTipoTest.Size = new System.Drawing.Size(257, 48);
            this.grbTipoTest.TabIndex = 2;
            this.grbTipoTest.TabStop = false;
            this.grbTipoTest.Text = "Test:";
            // 
            // cmbTipoTest
            // 
            this.cmbTipoTest.FormattingEnabled = true;
            this.cmbTipoTest.Items.AddRange(new object[] {
            "Agudeza",
            "Perimetria"});
            this.cmbTipoTest.Location = new System.Drawing.Point(15, 15);
            this.cmbTipoTest.Name = "cmbTipoTest";
            this.cmbTipoTest.Size = new System.Drawing.Size(225, 21);
            this.cmbTipoTest.TabIndex = 0;
            this.cmbTipoTest.SelectedIndexChanged += new System.EventHandler(this.cmbTipoTest_SelectedIndexChanged);
            // 
            // btnNuevaPrueba
            // 
            this.btnNuevaPrueba.Location = new System.Drawing.Point(288, 423);
            this.btnNuevaPrueba.Margin = new System.Windows.Forms.Padding(2);
            this.btnNuevaPrueba.Name = "btnNuevaPrueba";
            this.btnNuevaPrueba.Size = new System.Drawing.Size(80, 26);
            this.btnNuevaPrueba.TabIndex = 19;
            this.btnNuevaPrueba.Text = "Nuevo Test";
            this.btnNuevaPrueba.UseVisualStyleBackColor = true;
            this.btnNuevaPrueba.Click += new System.EventHandler(this.btnNuevaPrueba_Click);
            // 
            // btnRegresar
            // 
            this.btnRegresar.Location = new System.Drawing.Point(393, 423);
            this.btnRegresar.Margin = new System.Windows.Forms.Padding(2);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(80, 26);
            this.btnRegresar.TabIndex = 20;
            this.btnRegresar.Text = "Regresar";
            this.btnRegresar.UseVisualStyleBackColor = true;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // btnConfirmarNota
            // 
            this.btnConfirmarNota.Enabled = false;
            this.btnConfirmarNota.Location = new System.Drawing.Point(288, 424);
            this.btnConfirmarNota.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirmarNota.Name = "btnConfirmarNota";
            this.btnConfirmarNota.Size = new System.Drawing.Size(80, 26);
            this.btnConfirmarNota.TabIndex = 21;
            this.btnConfirmarNota.Text = "Confirmar";
            this.btnConfirmarNota.UseVisualStyleBackColor = true;
            this.btnConfirmarNota.Visible = false;
            this.btnConfirmarNota.Click += new System.EventHandler(this.btnConfirmarNota_Click);
            // 
            // btnCancelarNota
            // 
            this.btnCancelarNota.Enabled = false;
            this.btnCancelarNota.Location = new System.Drawing.Point(393, 424);
            this.btnCancelarNota.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelarNota.Name = "btnCancelarNota";
            this.btnCancelarNota.Size = new System.Drawing.Size(80, 26);
            this.btnCancelarNota.TabIndex = 22;
            this.btnCancelarNota.Text = "Cancelar";
            this.btnCancelarNota.UseVisualStyleBackColor = true;
            this.btnCancelarNota.Visible = false;
            this.btnCancelarNota.Click += new System.EventHandler(this.btnCancelarNota_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Enabled = false;
            this.btnEliminar.Location = new System.Drawing.Point(88, 242);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(2);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(80, 26);
            this.btnEliminar.TabIndex = 23;
            this.btnEliminar.Text = "Eliminar Test";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // frmTestViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.Controls.Add(this.btnCancelarNota);
            this.Controls.Add(this.btnConfirmarNota);
            this.Controls.Add(this.btnRegresar);
            this.Controls.Add(this.btnNuevaPrueba);
            this.Controls.Add(this.grbTipoTest);
            this.Controls.Add(this.grbPreview);
            this.Controls.Add(this.dataGridTests);
            this.MaximizeBox = false;
            this.Name = "frmTestViewer";
            this.Text = "Tests";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmTestViewer_FormClosed);
            this.Load += new System.EventHandler(this.frmTestViewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTests)).EndInit();
            this.grbPreview.ResumeLayout(false);
            this.grbPreview.PerformLayout();
            this.grbResPerimetria.ResumeLayout(false);
            this.grbResSnellen.ResumeLayout(false);
            this.grbResSnellen.PerformLayout();
            this.grbTipoTest.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridTests;
        private System.Windows.Forms.GroupBox grbPreview;
        private System.Windows.Forms.Label lblTestFecha;
        private System.Windows.Forms.Label lblTextFecha;
        private System.Windows.Forms.GroupBox grbTipoTest;
        private System.Windows.Forms.Button btnNuevaPrueba;
        private System.Windows.Forms.Button btnRegresar;
        private System.Windows.Forms.GroupBox grbResSnellen;
        private System.Windows.Forms.Label lblTSne2050;
        private System.Windows.Forms.Label lblTSne2070;
        private System.Windows.Forms.Label lblTSne20100;
        private System.Windows.Forms.Label lblTSne20200;
        private System.Windows.Forms.Label lblTSnellenAciertos;
        private System.Windows.Forms.Label lblSneRes2020;
        private System.Windows.Forms.Label lblSneRes2025;
        private System.Windows.Forms.Label lblSneRes2030;
        private System.Windows.Forms.Label lblSneRes2050;
        private System.Windows.Forms.Label lblSneRes2070;
        private System.Windows.Forms.Label lblSneRes20100;
        private System.Windows.Forms.Label lblSneRes20200;
        private System.Windows.Forms.Label lblTSne2020;
        private System.Windows.Forms.Label lblTSne2025;
        private System.Windows.Forms.Label lblTSne2030;
        private System.Windows.Forms.RichTextBox txtNota;
        private System.Windows.Forms.Button btnEditarNota;
        private System.Windows.Forms.Label lblTextNotas;
        private System.Windows.Forms.ComboBox cmbTipoTest;
        private System.Windows.Forms.Label lblSneRes2040;
        private System.Windows.Forms.Label lblTSne2040;
        private System.Windows.Forms.Button btnConfirmarNota;
        private System.Windows.Forms.Button btnCancelarNota;
        private System.Windows.Forms.GroupBox grbResPerimetria;
        private System.Windows.Forms.Button btnVerResultsPeri;
        private System.Windows.Forms.Button btnEliminar;
    }
}