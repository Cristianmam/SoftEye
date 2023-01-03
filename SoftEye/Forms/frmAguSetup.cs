using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using SoftEye.Classes;
using SoftEye.Forms;

namespace SoftEye
{
    public partial class frmAguSetup : Form
    {
        private NHibernateHelper nHHelper;
        public frmTestViewer formTV;
        private frmSnellen formSne;
        private int largoRuta = 17;

        private Color color1, color2;

        private String[] rutaAlfabetos;

        private int idPaciente;

        private void frmAguSetup_Load(object sender, EventArgs e)
        {
            formSne = new frmSnellen(this, nHHelper);
            color1 = Color.White;
            color2 = Color.White;

            CargarAlfabetos();
        }

        public frmAguSetup(frmTestViewer ftv,NHibernateHelper nh)
        {
            InitializeComponent();
            formTV = ftv;
            nHHelper = nh;    
        }

        public void CambiarPaciente (int id, string name)
        {
            idPaciente = id;
            lblPaciente.Text = name;
            ResetForm();
        }

        private void ResetForm()
        {
            cmbEscala.SelectedIndex = 0;
            rbtSinColor.Checked = true;
            rbtColor.Checked = false;
            chkColor1.Enabled = false;
            chkColor1.Checked = false;
            picBoxSample1.BackColor = Color.White;
            color1 = Color.White;
            chkColor2.Enabled = false;
            chkColor2.Checked = false;
            picBoxSample2.BackColor = Color.White;
            color2 = Color.White;
        }

        private void CargarAlfabetos()
        {
            cmbBoxAlfabeto.Items.Clear();
            rutaAlfabetos = Directory.GetDirectories(@"Assets\Alfabetos");
            if (rutaAlfabetos.Length == 0)
            {
                if (MessageBox.Show("No se encontro ningun alfabeto cargado. ¿Quiere abrir la carpeta de alfabetos?",
                    "Sin alfabetos", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Process.Start("explorer.exe", @"Assets\Alfabetos");
                }
            }
            else
            {
                int def = 0;
                for (int i = 0; i < rutaAlfabetos.Length; i++)
                {
                    cmbBoxAlfabeto.Items.Add(rutaAlfabetos[i].Remove(0,largoRuta));
                    if (rutaAlfabetos[i].Remove(0, largoRuta) == "Latino")
                        def = i;
                }
                cmbBoxAlfabeto.SelectedIndex = def;
            }
        }

        private void rbtSinColor_Click(object sender, EventArgs e)
        {
            rbtSinColor.Checked = true;
            rbtColor.Checked = false;
            ResetForm();
        }

        private void rbtColor_Click(object sender, EventArgs e)
        {
            rbtSinColor.Checked = false;
            rbtColor.Checked = true;
            chkColor1.Enabled = true;
            btnEdit1.Enabled = true;
            chkColor2.Enabled = true;
            btnEdit2.Enabled = true;
        }

        private void btnEdit1_Click(object sender, EventArgs e)
        {
            colDiag.Color = color1;
            if(colDiag.ShowDialog() == DialogResult.OK)
            {
                color1 = colDiag.Color;
                picBoxSample1.BackColor = colDiag.Color;
            }
        }
        private void btnEdit2_Click(object sender, EventArgs e)
        {
            colDiag.Color = color2;
            if (colDiag.ShowDialog() == DialogResult.OK)
            {
                color2 = colDiag.Color;
                picBoxSample2.BackColor = colDiag.Color;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            CargarAlfabetos();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            formTV.Visible = true;
            formTV.Focus();
        }

        private void frmAguSetup_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", @"Assets\Alfabetos");
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            List<String> dirPng = null;
            try
            {
                dirPng = Directory.GetFiles(@"Assets\Alfabetos\" + rutaAlfabetos[cmbBoxAlfabeto.SelectedIndex].Remove(0, largoRuta), "*.png").ToList();
            }
            catch(DirectoryNotFoundException)
            {
                MessageBox.Show("El alfabeto no fue encontrado", "Alfabeto no encontrado", MessageBoxButtons.OK);
                CargarAlfabetos();
                return;
            }
            
            Image[] images;
            string alfabeto = rutaAlfabetos[cmbBoxAlfabeto.SelectedIndex].Remove(0, largoRuta);
            float escala = 1;
            if (dirPng.Any())
            {
                images = new Image[dirPng.Count()];
                int i = 0;
                foreach (String d in dirPng)
                {
                    images[i] = Image.FromFile(d);
                    i++;
                }
            }
            else
            {
                MessageBox.Show("El alfabeto no tiene simbolos","Sin Simbolos",MessageBoxButtons.OK);
                return;
            }

            formSne.Visible = true;
            formSne.Focus();
            this.Hide();

            
            switch (cmbEscala.SelectedIndex)
            {
                case 0:
                    escala = 1;
                    break;
                case 1:
                    escala = 0.9f;
                    break;
                case 2:
                    escala = 0.8f;
                    break;
                case 3:
                    escala = 0.7f;
                    break;
                case 4:
                    escala = 0.6f;
                    break;
                case 5:
                    escala = 0.5f;
                    break;
            }

            if (rbtSinColor.Checked)
            {
                formSne.SetUpTest(images, Color.FromArgb(255, 255, 255), Color.FromArgb(255, 255, 255), idPaciente, alfabeto, escala);
            }
            else
            {
                if (chkColor1.Checked ^ chkColor2.Checked)
                {
                    if (chkColor1.Checked)
                    {
                        formSne.SetUpTest(images, color1, color1, idPaciente, alfabeto, escala);
                    }
                    else
                    {
                        formSne.SetUpTest(images, color2, color2, idPaciente, alfabeto, escala);
                    }
                }
                else
                {
                    if(chkColor1.Checked && chkColor2.Checked)
                    {
                        formSne.SetUpTest(images, color1, color2, idPaciente, alfabeto, escala);
                    }
                    else
                    {
                        formSne.SetUpTest(images, Color.FromArgb(255, 255, 255), Color.FromArgb(255, 255, 255), idPaciente, alfabeto, escala);
                    }
                }
            }
        }


    }
}
