using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SoftEye.Classes;
using SoftEye.Forms;

namespace SoftEye
{
    public partial class frmPeriSetup : Form
    {
        public frmTestViewer formTV;
        NHibernateHelper nHHelper;
        frmPerimetria formPeri;

        bool[] cuadrantesArr;
        int idPaciente;

        public frmPeriSetup(frmTestViewer ftv, NHibernateHelper nhh)
        {
            InitializeComponent();
            formTV = ftv;
            nHHelper = nhh;
            cuadrantesArr = new bool[8];
        }

        private void frmPeriSetup_Load(object sender, EventArgs e)
        {
            formPeri = new frmPerimetria(this, nHHelper);
        }

        public void CambiarPaciente(int idp, string np)
        {
            idPaciente = idp;
            ResetForm();
            this.Text = "Test de perimetria para " + np;
            for (int i = 0; i < 8; i++)
            {
                cuadrantesArr[i] = false;
            }
        }


        private void ResetForm()
        {
            rbtCompleto.Checked = true;
            rbtPersonalizado.Checked = false;
            DisableChkBoxes();
        }

        private void DisableChkBoxes()
        {
            chkDer1.Enabled = false;
            chkDer2.Enabled = false;
            chkDer3.Enabled = false;
            chkDer4.Enabled = false;

            chkIzq1.Enabled = false;
            chkIzq2.Enabled = false;
            chkIzq3.Enabled = false;
            chkIzq4.Enabled = false;

            chkDer1.Checked = false;
            chkDer2.Checked = false;
            chkDer3.Checked = false;
            chkDer4.Checked = false;

            chkIzq1.Checked = false;
            chkIzq2.Checked = false;
            chkIzq3.Checked = false;
            chkIzq4.Checked = false;
        }
        private void EnableChkBoxes()
        {
            chkDer1.Enabled = true;
            chkDer2.Enabled = true;
            chkDer3.Enabled = true;
            chkDer4.Enabled = true;
                              
            chkIzq1.Enabled = true;
            chkIzq2.Enabled = true;
            chkIzq3.Enabled = true;
            chkIzq4.Enabled = true;
        }

        private void rbtCompleto_Click(object sender, EventArgs e)
        {
            rbtCompleto.Checked = true;
            rbtPersonalizado.Checked = false;
            DisableChkBoxes();
        }

        private void rbtPersonalizado_Click(object sender, EventArgs e)
        {
            rbtPersonalizado.Checked = true;
            rbtCompleto.Checked = false;
            EnableChkBoxes();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            bool anyTrue = false;
            if (formPeri.IsDisposed)
                formPeri = new frmPerimetria(this, nHHelper);

            if (rbtCompleto.Checked)
            {
                for (int i = 0; i < 8; i++)
                {
                    cuadrantesArr[i] = true;
                }
                anyTrue = true;
            }
            else
            {
                cuadrantesArr[0] = chkIzq1.Checked;
                cuadrantesArr[1] = chkIzq2.Checked;
                cuadrantesArr[2] = chkIzq3.Checked;
                cuadrantesArr[3] = chkIzq4.Checked;
                cuadrantesArr[4] = chkDer1.Checked;
                cuadrantesArr[5] = chkDer2.Checked;
                cuadrantesArr[6] = chkDer3.Checked;
                cuadrantesArr[7] = chkDer4.Checked;
                anyTrue = false;
                for (int i = 0; i < 8; i++)
                {
                    if (cuadrantesArr[i])
                    {
                        anyTrue = true;
                        break;
                    }
                }
            }
            

            if (anyTrue)
            {
                this.Hide();
                formPeri.Visible = true;
                formPeri.Focus();
                formPeri.TestThis(cuadrantesArr, idPaciente);
            }
            else
            {

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ResetForm();
            this.Hide();
            formTV.Visible = true;
            formTV.Focus();
        }
    }
}
