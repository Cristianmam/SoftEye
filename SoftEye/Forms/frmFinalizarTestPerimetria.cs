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
using SoftEye.Classes;

namespace SoftEye.Forms
{
    public partial class frmFinalizarTestPerimetria : Form
    {
        frmPerimetria formPerimetria;
        NHibernateHelper nHHelper;
        ISession session;
        TestPerimetria test;

        public frmFinalizarTestPerimetria(frmPerimetria fp, NHibernateHelper nhh)
        {
            formPerimetria = fp;
            nHHelper = nhh;
            InitializeComponent();
        }

        public void PrepararTest(int idp, float[,] res)
        {
            test = new TestPerimetria(idp, res);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
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

            this.Hide();
            formPerimetria.formPeriSetup.formTV.Visible = true;
            formPerimetria.formPeriSetup.formTV.Focus();
            formPerimetria.formPeriSetup.formTV.RefreshTests();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            formPerimetria.formPeriSetup.Visible = true;
            formPerimetria.formPeriSetup.Focus();
        }
    }
}
