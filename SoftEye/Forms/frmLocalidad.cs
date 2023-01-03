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
    public partial class frmLocalidades : Form
    {
        frmPacientes formPacientes;
        NHibernateHelper nHHelper;
        ISession session;


        List<Localidad> localidadesCargadas;

        public frmLocalidades(frmPacientes fp, NHibernateHelper nHH)
        {
            InitializeComponent();
            formPacientes = fp;
            nHHelper = nHH;
        }

        private void ResetAll()
        {
            txtLocalidad.Clear();
            dataGridLocalidades.Rows.Clear();

            btnAgregar.Enabled = true;
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
        }

        private void LoadLocalidades()
        {
            dataGridLocalidades.Rows.Clear();
            session = nHHelper.GetCurrentSession();
            using (session.BeginTransaction())
            {
                try 
                {
                    localidadesCargadas = session.Query<Localidad>()
                                          .Where(o => o.activo == true)
                                          .ToList();
                }
                finally
                {
                    nHHelper.CloseSession();
                }
            }

            if (localidadesCargadas.Any())
            {
                foreach(Localidad l in localidadesCargadas)
                {
                    dataGridLocalidades.Rows.Add(l.id, l.nombre);
                }
            }
        }

        public void SetUp()
        {
            ResetAll();
            LoadLocalidades();
        }

        private Localidad EncontrarLocalidad(int id)
        {
            if (!localidadesCargadas.Any())
                return null;

            foreach (Localidad l in localidadesCargadas)
            {
                if (l.id == id)
                    return l;
            }

            return null;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtLocalidad.Text))
            {
                MessageBox.Show("El campo de localidad se encuentra en blanco.", "Localidad en blanco", MessageBoxButtons.OK);
                txtLocalidad.Focus();
                return;
            }

            bool rep = false;
            foreach (Localidad l in localidadesCargadas)
            {
                if (l.nombre == txtLocalidad.Text)
                {
                    rep = true;
                    break;
                }
            }
            if (rep)
            {
                DialogResult res;
                res = MessageBox.Show("Una localidad cargada ya tiene este nombre, ¿Desea agregarla de todas formas?",
                                      "Localidad repetida",
                                      MessageBoxButtons.YesNo);

                if (res == DialogResult.No)
                    return;
            }

            Localidad loc = new Localidad(txtLocalidad.Text);

            session = nHHelper.GetCurrentSession();
            using (session.BeginTransaction())
            {
                try
                {
                    session.Save(loc);
                    session.GetCurrentTransaction().Commit();
                }
                finally
                {
                    nHHelper.CloseSession();
                }
            }
            SetUp();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dataGridLocalidades.Rows.GetRowCount(DataGridViewElementStates.Selected) < 1)
                return;

            if (String.IsNullOrEmpty(txtLocalidad.Text))
            {
                MessageBox.Show("El campo de localidad se encuentra en blanco.", "Localidad en blanco", MessageBoxButtons.OK);
                txtLocalidad.Focus();
                return;
            }

            DialogResult res;
            res = MessageBox.Show("¿Seguro que desea editar esta localidad?",
                                  "Confirmar edicion",
                                  MessageBoxButtons.YesNo);

            if (res == DialogResult.No)
                return;

            int id = (int)dataGridLocalidades.SelectedRows[0].Cells[0].Value;
            Localidad loc = EncontrarLocalidad(id);

            if (loc == null)
                return;

            loc.nombre = txtLocalidad.Text;

            session = nHHelper.GetCurrentSession();
            using (session.BeginTransaction())
            {
                try
                {
                    session.Update(loc);
                    session.GetCurrentTransaction().Commit();
                }
                finally
                {
                    nHHelper.CloseSession();
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridLocalidades.Rows.GetRowCount(DataGridViewElementStates.Selected) < 1)
                return;

            int id = (int)dataGridLocalidades.SelectedRows[0].Cells[0].Value;
            Localidad loc = EncontrarLocalidad(id);
            if (loc == null)
                return;

            DialogResult res;
            res = MessageBox.Show("¿Seguro que desea eliminar la localidad: " + loc.nombre + "?",
                                  "¿Eliminar?",
                                  MessageBoxButtons.YesNo);

            if (res == DialogResult.No)
                return;

            loc.activo = false;

            session = nHHelper.GetCurrentSession();
            using (session.BeginTransaction())
            {
                try
                {
                    session.Update(loc);
                    session.GetCurrentTransaction().Commit();
                }
                finally
                {
                    nHHelper.CloseSession();
                }
            }
            LoadLocalidades();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            formPacientes.LoadLocalidades();
            this.Hide();
            formPacientes.Focus();
        }
    }
}
