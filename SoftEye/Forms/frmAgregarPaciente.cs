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

        public void LimpiarCampos(List<Localidad> localidades)
        {
            txtNombre.Clear();
            txtApellido.Clear();
            dtpFdn.Value = DateTime.Now;
            txtDNI.Clear();
            txtTelefono.Clear();
            txtDomicilio.Clear();
            txtEmail.Clear();
            txtHistoriaClinica.Clear();

            cmbLocalidad.DataSource = null;
            if (localidades != null)
            {
                cmbLocalidad.DataSource = localidades;
                cmbLocalidad.DisplayMember = "nombre";
                cmbLocalidad.ValueMember = "id";

                cmbLocalidad.SelectedIndex = -1;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //Nombre en blanco
            if (String.IsNullOrEmpty(txtNombre.Text) || String.IsNullOrEmpty(txtApellido.Text))
            {
                MessageBox.Show("Los campos de nombre o apellido estan vacios. Por favor completelos.",
                    "Nombre o apellido en blanco",
                    MessageBoxButtons.OK);
                txtNombre.Focus();
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
            //HClinica en blanco
            if (String.IsNullOrEmpty(txtHistoriaClinica.Text))
            {
                DialogResult res = MessageBox.Show("El campo de historia clinica esta vacio. ¿Continuar de todas formas?.",
                    "Historia Clinica en blanco",
                    MessageBoxButtons.YesNo);

                if (res == DialogResult.No)
                {
                    txtHistoriaClinica.Focus();
                    return;
                }
            }
            //Validar formato DNI
            if (txtDNI.Text.Length < 8)
            {
                MessageBox.Show("El DNI ingresado es demaciado corto (requiere al menos 8 numeros). Por favor " +
                    "valide que sea correcto.",
                    "DNI repetido",
                    MessageBoxButtons.OK);
                txtDNI.Focus();

                return;
            }

            //Validar formato mail
            if(!String.IsNullOrEmpty(txtEmail.Text))
            {
                if (!pacientesForm.ValidarMail(txtEmail.Text))
                {
                    MessageBox.Show("El Email ingresado parece tener un formato incorrecto. Por favor " +
                    "valide que sea correcto.",
                    "Formato Email",
                    MessageBoxButtons.OK);
                    txtEmail.Focus();

                    return;
                }
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
                MessageBox.Show("Ya se encuentra un DNI igual a este en la base de datos. Por favor " +
                    "ingrese uno nuevo.",
                    "DNI repetido",
                    MessageBoxButtons.OK);
                txtDNI.Focus();

                return;
            }
            //HClinica Repetida
            if (!string.IsNullOrEmpty(txtHistoriaClinica.Text))
            {
                session = nHHelper.GetCurrentSession();
                try
                {
                    using (session.BeginTransaction())
                    {
                        pac = session
                            .Query<Paciente>()
                            .Where(o => o.hClinica == txtHistoriaClinica.Text && o.activo == true)
                            .ToList();
                    }
                }
                finally
                {
                    nHHelper.CloseSession();
                }
                if (pac.Any())
                {
                    DialogResult res = MessageBox.Show("Ya se encuentra una historia clinica igual a esta en la base de datos. Por favor " +
                    "ingrese una nueva.",
                    "Historia clinica repetida",
                    MessageBoxButtons.OK);
                    txtHistoriaClinica.Focus();

                    return;
                }
            }

            //Carga de objeto
            string nom = txtNombre.Text;
            string ape = txtApellido.Text;
            string nacimiento = dtpFdn.Value.ToString("d");
            string dni = txtDNI.Text;
            string telefono = String.IsNullOrEmpty(txtTelefono.Text) ? "" : txtTelefono.Text;
            string domicilio = String.IsNullOrEmpty(txtDomicilio.Text) ? "" : txtDomicilio.Text;
            string eMail = String.IsNullOrEmpty(txtEmail.Text) ? "" : txtEmail.Text;
            string hClinica = String.IsNullOrEmpty(txtHistoriaClinica.Text) ? "" : txtHistoriaClinica.Text;
            int? loc;

            if (String.IsNullOrEmpty(cmbLocalidad.Text) || cmbLocalidad.SelectedIndex == -1)
                loc = null;
            else
            {
                loc = (int)cmbLocalidad.SelectedValue;
            }

            Paciente p = new Paciente(nom,
                                      ape,
                                      nacimiento,
                                      dni,
                                      telefono,
                                      domicilio,
                                      eMail,
                                      hClinica,
                                      loc);


            pacientesForm.AgregarPaciente(p);

            LimpiarCampos(null);
            this.Hide();
            pacientesForm.Focus();

        }

        private void txtDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            int ttTime = 5000;
            ToolTip tt = new ToolTip();

            if (e.KeyChar != (char)Keys.Back && !char.IsDigit(e.KeyChar))
            {
                tt.Show("Solo se admiten caracters numericos.", tb, 0, -20, ttTime);
                e.Handled = true;
            }

            if (tb.Text.Length >= 10 && e.KeyChar != (char)Keys.Back)
            {
                tt.Show("No se admiten DNIs mayores a 10 numeros.", tb, 0, -20, ttTime);
                e.Handled = true;
            }
        }

        private void txtHistoriaClinica_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            int ttTime = 5000;
            ToolTip tt = new ToolTip();

            if (e.KeyChar != (char)Keys.Back && !char.IsDigit(e.KeyChar))
            {
                tt.Show("Solo se admiten caracteres numericos.", tb, 0, -20, ttTime);
                e.Handled = true;
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            int ttTime = 5000;
            ToolTip tt = new ToolTip();

            if (e.KeyChar != (char)Keys.Back && !char.IsDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) &&
                !(e.KeyChar == 43 || e.KeyChar == 45 || e.KeyChar == 40 || e.KeyChar == 41))
            {
                tt.Show("Solo se admiten caracteres numericos, '+', '-', '(' y ')'", tb, 0, -20, ttTime);
                e.Handled = true;
            }
        }
    }
}
