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
    public partial class frmAgregarPaciente : Form
    {
        frmPacientes pacientesForm;
        NHibernateHelper nHHelper;

        public frmAgregarPaciente(frmPacientes pForm, NHibernateHelper nHH)
        {
            InitializeComponent();
            pacientesForm = pForm;
            nHHelper = nHH;
        }

        private void frmAgregarPaciente_Load(object sender, EventArgs e)
        {
            
        }

        public void LimpiarCampos()
        {
            txtNYA.Clear();
            txtNacimiento.Clear();
            txtDNI.Clear();
            txtTelefono.Clear();
            txtDomicilio.Clear();
            txtEmail.Clear();
            txtHistoriaClinica.Clear();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //Nombre en blanco
            if (String.IsNullOrEmpty(txtNYA.Text))
            {
                MessageBox.Show("El campo de nombre esta vacio, por favor, ingrese un nombre.",
                    "Nombre en blanco",
                    MessageBoxButtons.OK);
                txtNYA.Focus();
                return;
            }
            //DNI en blanco
            if (String.IsNullOrEmpty(txtDNI.Text))
            {
                MessageBox.Show("El campo del DNI esta vacio, por favor, ingrese un DNI.",
                    "DNI en blanco",
                    MessageBoxButtons.OK);
                txtDNI.Focus();
                return;
                
            }
            //DNI repetido
            List<Paciente> pac;
            ISession session = nHHelper.GetCurrentSession();
            try
            {
                using (session.BeginTransaction())
                {
                    pac = session
                        .Query<Paciente>()
                        .Where(o => o.dni == txtDNI.Text && o.activo == true)
                        .ToList();
                }
            }
            finally
            {
                nHHelper.CloseSession();
            }
            if(pac.Any())
            {
                 DialogResult res = MessageBox.Show("Ya se encuentra un DNI igual a este en la base de datos. ¿Desea agreagar " +
                 "este paciente de todas formas?",
                 "DNI repetido",
                 MessageBoxButtons.OKCancel);

                if (res == DialogResult.Cancel)
                    return;
            }


            //Carga de objeto
            string nya = txtNYA.Text;
            string nacimiento = String.IsNullOrEmpty(txtNacimiento.Text)?"":txtNacimiento.Text;
            string dni = txtDNI.Text;
            string telefono = String.IsNullOrEmpty(txtTelefono.Text) ? "" : txtTelefono.Text;
            string domicilio = String.IsNullOrEmpty(txtDomicilio.Text) ? "" : txtDomicilio.Text;
            string eMail = String.IsNullOrEmpty(txtEmail.Text) ? "" : txtEmail.Text;
            string hClinica = String.IsNullOrEmpty(txtHistoriaClinica.Text) ? "" : txtHistoriaClinica.Text;
            Paciente p = new Paciente(nya,
                                      nacimiento,
                                      dni,
                                      telefono,
                                      domicilio,
                                      eMail,
                                      hClinica);

            if (pacientesForm.ValidarPaciente(p))
                pacientesForm.AgregarPaciente(p);

            LimpiarCampos();
            this.Hide();
            pacientesForm.Focus();

        }
    }
}
