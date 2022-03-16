using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NHibernate;
using NHibernate.Cfg;
using SoftEye.Classes;

namespace SoftEye.Forms
{ 
    public partial class frmFinalizarTestSnellen : Form
    {
        ISession session;
        public frmSnellen formSnellen;
        private NHibernateHelper nHHelper;

        private TestSnellen test = null;

        public frmFinalizarTestSnellen(frmSnellen frm,NHibernateHelper nHH)
        {
            InitializeComponent();
            formSnellen = frm;
            nHHelper = nHH;
        }

        public void PrepararTest(int idp, List<int[]> res, string alf)
        {
            int[] results = new int[res.Count()];
            int j = 0;
            
            foreach (int[] r in res)
            {
                for (int i = 0; i < r.Length; i++)
                {
                    results[j] += r[i];
                }
                j++;
            }

            test = new TestSnellen(idp, DateTime.Today.ToString("d"), results, alf);

            lblSneRes20200.Text = results[0] + "/1";
            lblSneRes20100.Text = results[1] + "/2";
            lblSneRes2070.Text = results[2] + "/3";
            lblSneRes2050.Text = results[3] + "/4";
            lblSneRes2040.Text = results[4] + "/5";
            lblSneRes2030.Text = results[5] + "/6";
            lblSneRes2025.Text = results[6] + "/7";
            lblSneRes2020.Text = results[7] + "/8";
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            test.nota = txtNota.Text;

            session = nHHelper.GetCurrentSession();
            try
            {
                using (session.BeginTransaction())
                {
                    session.Save(test);

                    session.GetCurrentTransaction().Commit();
                }
            }
            finally
            {
                nHHelper.CloseSession();
            }

            formSnellen.formAguSetup.formTV.RefreshTests();
            this.Hide();
            formSnellen.formAguSetup.formTV.Visible = true;
            formSnellen.formAguSetup.formTV.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            formSnellen.formAguSetup.Visible = true;
            formSnellen.formAguSetup.Focus();
        }
    }
}
