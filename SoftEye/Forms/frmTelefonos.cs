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
using NHibernate;
using NHibernate.Cfg;

namespace SoftEye.Forms
{
    public partial class frmTelefonos : Form
    {
        ISession session;
        NHibernateHelper nHHelper;
        frmPacientes formPacientes;
        Paciente pac;

        List<Telefono> listaTelefonos;

        public frmTelefonos(frmPacientes formP, NHibernateHelper nHH)
        {
            InitializeComponent();
            formPacientes = formP;
            nHHelper = nHH;
        }

        private void frmTelefonos_Load(object sender, EventArgs e)
        {

        }

        private void ResetAll()
        {
            txtTelefono.Enabled = true;
            dataGridTelefonos.Enabled = true;
            btnAgregar.Enabled = true;
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
            btnPorDefecto.Enabled = false;

            txtTelefono.Clear();
            dataGridTelefonos.Rows.Clear();
        }

        public void ShowTelefonos(Paciente p)
        {
            ResetAll();

            if (p.id < 0)
                return;

            session = nHHelper.GetCurrentSession();
            using (session.BeginTransaction())
            {
                try
                {
                    listaTelefonos = session
                                     .Query<Telefono>()
                                     .Where(o => o.idPaciente == p.id && o.activo == true)
                                     .ToList();
                }
                finally
                {
                    nHHelper.CloseSession();
                }
            }

            if (!listaTelefonos.Any())
                return;

            foreach (Telefono tel in listaTelefonos)
            {
                dataGridTelefonos.Rows.Add(tel.id, tel.numero);
            }

            dataGridTelefonos.Rows[0].Selected = true;
            txtTelefono.Text = dataGridTelefonos.Rows[0].Cells[1].Value.ToString();

            btnEliminar.Enabled = true;
            btnModificar.Enabled = true;
            btnPorDefecto.Enabled = true;
        }

        public void CargarFormulario(Paciente p)
        {
            pac = p;
            lblTelDePaciente.Text = "Telefonos de " + p.nombre + " " + p.apellido +":";
            ShowTelefonos(p);
        }

        private Telefono EncontrarTelefono(int id)
        {
            if (!listaTelefonos.Any())
                return null;

            foreach (Telefono t in listaTelefonos)
            {
                if (id == t.id)
                    return t;
            }

            return null;
        }

        private void dataGridTelefonos_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridTelefonos.Rows.GetRowCount(DataGridViewElementStates.Selected) > 0)
            {
                txtTelefono.Text = dataGridTelefonos.SelectedRows[0].Cells[1].Value.ToString();
                btnEliminar.Enabled = true;
                btnModificar.Enabled = true;
                btnPorDefecto.Enabled = true;
            }
        }

        private void btnPorDefecto_Click(object sender, EventArgs e)
        {
            if (!(dataGridTelefonos.Rows.GetRowCount(DataGridViewElementStates.Selected) > 0))
                return;

            pac.telefono = dataGridTelefonos.SelectedRows[0].Cells[1].Value.ToString();
            session = nHHelper.GetCurrentSession();
            using (session.BeginTransaction())
            {
                try
                {
                    session.Update(pac);
                    session.GetCurrentTransaction().Commit();
                }
                finally
                {
                    nHHelper.CloseSession();
                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtTelefono.Text))
            {
                MessageBox.Show("El campo de telefono se encuentra en blanco.", "Telefono en blanco", MessageBoxButtons.OK);
                txtTelefono.Focus();
                return;
            }

            bool rep = false;
            foreach (Telefono t in listaTelefonos)
            {
                if (t.numero == txtTelefono.Text)
                {
                    rep = true;
                    break;
                }
            }
            if (rep)
            {
                DialogResult res;
                res = MessageBox.Show("El paciente ya tiene cargado este numero de telefono, ¿Desea agregarlo de todas formas?",
                                      "Telefono repetido",
                                      MessageBoxButtons.YesNo);

                if (res == DialogResult.No)
                    return;
            }

            Telefono tel = new Telefono(pac.id, txtTelefono.Text);
            session = nHHelper.GetCurrentSession();
            using (session.BeginTransaction())
            {
                try
                {
                    session.Save(tel);
                    session.GetCurrentTransaction().Commit();
                }
                finally
                {
                    nHHelper.CloseSession();
                }
            }

            ResetAll();
            ShowTelefonos(pac);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dataGridTelefonos.Rows.GetRowCount(DataGridViewElementStates.Selected) < 1)
                return;

            if (String.IsNullOrEmpty(txtTelefono.Text))
            {
                MessageBox.Show("El campo de telefono se encuentra en blanco.", "Telefono en blanco", MessageBoxButtons.OK);
                txtTelefono.Focus();
                return;
            }

            DialogResult res;
            res = MessageBox.Show("¿Seguro que desea editar este telefono?",
                                  "Confirmar edicion",
                                  MessageBoxButtons.YesNo);

            if (res == DialogResult.No)
                return;

            int id = (int)dataGridTelefonos.SelectedRows[0].Cells[0].Value;
            Telefono tel = EncontrarTelefono(id);

            if (tel == null)
                return;

            tel.numero = txtTelefono.Text;

            session = nHHelper.GetCurrentSession();
            using (session.BeginTransaction())
            {
                try
                {
                    session.Update(tel);
                    session.GetCurrentTransaction().Commit();
                }
                finally
                {
                    nHHelper.CloseSession();
                }
            }

            ResetAll();
            ShowTelefonos(pac);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridTelefonos.Rows.GetRowCount(DataGridViewElementStates.Selected) < 1)
                return;

            int id = (int)dataGridTelefonos.SelectedRows[0].Cells[0].Value;
            Telefono tel = EncontrarTelefono(id);
            if (tel == null)
                return;

            DialogResult res;
            res = MessageBox.Show("¿Seguro que desea eliminar el telefono: " + tel.numero + "?",
                                  "¿Eliminar?",
                                  MessageBoxButtons.YesNo);

            if (res == DialogResult.No)
                return;

            if(pac.telefono == tel.numero)
            {
                pac.telefono = "";
            }
            session = nHHelper.GetCurrentSession();
            using (session.BeginTransaction())
            {
                try
                {
                    session.Update(pac);
                    session.GetCurrentTransaction().Commit();
                }
                finally
                {
                    nHHelper.CloseSession();
                }
            }

            tel.activo = false;
            
            session = nHHelper.GetCurrentSession();
            using (session.BeginTransaction())
            {
                try
                {
                    session.Update(tel);
                    session.GetCurrentTransaction().Commit();
                }
                finally
                {
                    nHHelper.CloseSession();
                }
            }
            ShowTelefonos(pac);
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            formPacientes.RefrescarDatosPaciente();
            this.Hide();
            formPacientes.Focus();
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            int ttTime = 5000;
            ToolTip tt = new ToolTip();

            if (e.KeyChar != (char)Keys.Back && !char.IsDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && 
                !(e.KeyChar == 43 || e.KeyChar == 45 || e.KeyChar == 40  || e.KeyChar == 41))
            {
                tt.Show("Solo se admiten caracters numericos, '+', '-', '(' y ')'", tb, 0, -20, ttTime);
                e.Handled = true;
            }
        }
    }
}
