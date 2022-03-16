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
using SoftEye.Forms;

namespace SoftEye
{
    
    public partial class frmMain : Form
    {
        private NHibernateHelper nHHelper = new NHibernateHelper();
        /*private Configuration myConfiguration;
        private ISessionFactory mySessionFactory;
        private ISession mySession;*/


        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            frmPacientes pacientesForm = new frmPacientes(this,nHHelper);
            pacientesForm.Visible = true;


        }

        private void frmMain_Shown(Object sender, EventArgs e)
        {
            this.Hide();
        }

    }
}
