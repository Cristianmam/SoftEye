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
    public partial class frmTestViewer : Form
    {

        private frmPacientes pacientesForm;
        private NHibernateHelper nHHelper;
        private ISession session;

        //Paciente seleccionado
        private Paciente pacSel;
        private int idTestSeleccionado;

        //Listas para almacenar tests de un paciente
        List<TestSnellen> listaTestSnellen;
        List<TestPerimetria> listaTestPerimetria;

        frmAguSetup formSne;
        frmPeriSetup formPeri;
        frmVisualizadorPerimetria formVisuaPeri;
        frmGenReporte formReportes;

        public frmTestViewer(frmPacientes fp, NHibernateHelper nh)
        {
            InitializeComponent();
            pacientesForm = fp;
            nHHelper = nh;
        }
        private void frmTestViewer_Load(object sender, EventArgs e)
        {
            dataGridTests.AutoGenerateColumns = false;
            formSne = new frmAguSetup(this, nHHelper);
            formPeri = new frmPeriSetup(this, nHHelper);
            formVisuaPeri = new frmVisualizadorPerimetria(this);
            formReportes = new frmGenReporte(this);
        }

        public void RefreshTests()
        {
            switch (cmbTipoTest.SelectedIndex)
            {
                case 0:
                    listaTestSnellen = GetTestsSnellen(pacSel.id);
                    PrepDataSnellen();
                    LoadSnellenTests();
                    break;
                case 1:
                    listaTestPerimetria = GetTestsPerimetria(pacSel.id);
                    PrepDataPeri();
                    LoadPeriTests();
                    break;
            }
        }
        private void ResetForm()
        {
            cmbTipoTest.Enabled = true;
            dataGridTests.Enabled = true;
            btnEliminar.Enabled = false;
            grbResSnellen.Visible = false;
            grbResPerimetria.Visible = false;
            switch (cmbTipoTest.SelectedIndex)
            {
                case 0:
                    grbResSnellen.Visible = true;
                    PrepDataSnellen();
                    LoadSnellenTests();
                    break;
                case 1:
                    grbResPerimetria.Visible = true;
                    PrepDataPeri();
                    LoadPeriTests();
                    break;
            }
            btnVerResultsPeri.Enabled = false;
            txtNota.Enabled = false;
            txtNota.Clear();
            
            btnEditarNota.Enabled = false;
            btnNuevaPrueba.Visible = true;
            btnNuevaPrueba.Enabled = true;
            btnRegresar.Visible = true;
            btnRegresar.Enabled = true;
            btnConfirmarNota.Visible = false;
            btnConfirmarNota.Enabled = false;
            btnCancelarNota.Visible = false;
            btnCancelarNota.Enabled = false;

            ResetTestViewerSnellen();
        }

        private void DisableAll()
        {
            cmbTipoTest.Enabled = false;
            dataGridTests.Enabled = false;
            btnEditarNota.Enabled = false;
            btnNuevaPrueba.Enabled = false;
            btnRegresar.Enabled = false;
            btnConfirmarNota.Enabled = false;
            btnConfirmarNota.Visible = false;
            btnCancelarNota.Visible = false;
            btnCancelarNota.Enabled = false;
            txtNota.Enabled = false;
            btnEliminar.Enabled = false;
        }

        private void ResetTestViewerSnellen()
        {
            lblTestFecha.Text = "";

            lblSneRes20200.Text = "0/1";
            lblSneRes20100.Text = "0/2";
            lblSneRes2070.Text = "0/3";
            lblSneRes2050.Text = "0/4";
            lblSneRes2040.Text = "0/5";
            lblSneRes2030.Text = "0/6";
            lblSneRes2025.Text = "0/7";
            lblSneRes2020.Text = "0/8";
        }

        public void CambiarPaciente(Paciente p)
        {
            pacSel = p;
            listaTestSnellen = GetTestsSnellen(pacSel.id);
            listaTestPerimetria = GetTestsPerimetria(pacSel.id);
            ResetForm();
            ResetTestViewerSnellen();
            cmbTipoTest.SelectedIndex = 0;
            grbResSnellen.Visible = true;
            PrepDataSnellen();
            if (listaTestSnellen.Any())
            {
                LoadSnellenTests();
            }
            this.Text = p.nombre + " " + p.apellido;
        }

        private List<TestSnellen> GetTestsSnellen(int idpas)
        {
            List<TestSnellen> testsSnellen;
            session = nHHelper.GetCurrentSession();
            try
            {
                using (session.BeginTransaction())
                {
                    testsSnellen = session
                        .Query<TestSnellen>()
                        .Where(o => o.activo == true && o.idPaciente == idpas)
                        .ToList();
                }
            }
            finally
            {
                nHHelper.CloseSession();
            }

            if (testsSnellen.Any())
            {
                foreach(TestSnellen t in testsSnellen)
                {
                    t.DeserializeResults();
                }
            }
            return testsSnellen;
        }

        private List<TestPerimetria> GetTestsPerimetria(int idpas)
        {
            List<TestPerimetria> testsPerimetria;
            session = nHHelper.GetCurrentSession();
            try
            {
                using (session.BeginTransaction())
                {
                    testsPerimetria = session
                        .Query<TestPerimetria>()
                        .Where(o => o.activo == true && o.idPaciente == idpas)
                        .ToList();
                }
            }
            finally
            {
                nHHelper.CloseSession();
            }

            if (testsPerimetria.Any())
            {
                foreach (TestPerimetria t in testsPerimetria)
                {
                    t.DeserializeResults();
                }
            }
            return testsPerimetria;
        }

        private void LoadSnellenTests()
        {
            if (listaTestSnellen.Any())
            {
                foreach (TestSnellen t in listaTestSnellen)
                {
                    dataGridTests.Rows.Add(t.id, t.fecha, t.mejorRes, t.alfabeto); 
                }
                ShowTestSnellen(listaTestSnellen[0]);
            } 
        }

        private void LoadPeriTests()
        {
            if (listaTestPerimetria.Any())
            {
                foreach (TestPerimetria t in listaTestPerimetria)
                {
                    dataGridTests.Rows.Add(t.id, t.fecha);
                }
                ShowTestPerimetria(listaTestPerimetria[0]);
            }
        }

        private void PrepDataSnellen()
        { 
            dataGridTests.Columns.Clear();
            dataGridTests.Rows.Clear();

            dataGridTests.Columns.Add("Id", "Id");
            dataGridTests.Columns.Add("Fecha", "Fecha");
            dataGridTests.Columns.Add("Resultados", "Resultados");
            dataGridTests.Columns.Add("Alfabeto", "Alfabeto");

            dataGridTests.Columns["Id"].Visible = false;

            dataGridTests.Columns[0].Width = 75;
            dataGridTests.Columns[1].Width = 75;
        }

        private void PrepDataPeri()
        {
            dataGridTests.Columns.Clear();
            dataGridTests.Rows.Clear();

            dataGridTests.Columns.Add("Id", "Id");
            dataGridTests.Columns.Add("Fecha", "Fecha");

            dataGridTests.Columns["Id"].Visible = false;
        }

        private void ShowTestSnellen(TestSnellen t)
        {
            lblTestFecha.Text = t.fecha;
            
            grbResSnellen.Visible = true;

            lblSneRes20200.Text = t.resDeserializados[0].ToString() + "/1";
            lblSneRes20100.Text = t.resDeserializados[1].ToString() + "/2";
            lblSneRes2070.Text = t.resDeserializados[2].ToString() + "/3";
            lblSneRes2050.Text = t.resDeserializados[3].ToString() + "/4";
            lblSneRes2040.Text = t.resDeserializados[4].ToString() + "/5";
            lblSneRes2030.Text = t.resDeserializados[5].ToString() + "/6";
            lblSneRes2025.Text = t.resDeserializados[6].ToString() + "/7";
            lblSneRes2020.Text = t.resDeserializados[7].ToString() + "/8";

            txtNota.Text = t.nota;

            btnReporte.Visible = true;
            btnReporte.Enabled = true;
            btnEditarNota.Enabled = true;
            btnEliminar.Enabled = true;
        }

        private void ShowTestPerimetria(TestPerimetria t)
        {
            lblTestFecha.Text = t.fecha;
            txtNota.Text = t.nota;
            btnReporte.Visible = false;
            btnReporte.Enabled = false;
            btnVerResultsPeri.Enabled = true;
            btnEditarNota.Enabled = true;
            btnEliminar.Enabled = true;
        }

        private int EncontrarTestSnellen(List<TestSnellen> l, int id)
        {
            int i = 0;
            foreach (TestSnellen t in l)
            {
                if (t.id == id)
                {
                    return (i);
                }
                i++;
            }
            return (-1);
        }

        private int EncontrarTestPerimetria(List<TestPerimetria>l,int id)
        {
            int i = 0;
            foreach (TestPerimetria t in l)
            {
                if (t.id == id)
                {
                    return (i);
                }
                i++;
            }
            return (-1);
        }

        private void EliminarTestSnellen(TestSnellen t)
        {
            t.activo = false;
            session = nHHelper.GetCurrentSession();
            try
            {
                using (session.BeginTransaction())
                {
                    session.Update(t);
                    session.GetCurrentTransaction().Commit();
                }
            }
            finally
            {
                nHHelper.CloseSession();
            }
        }
        private void EliminarTestPerimetria(TestPerimetria t)
        {
            t.activo = false;
            session = nHHelper.GetCurrentSession();
            try
            {
                using (session.BeginTransaction())
                {
                    session.Update(t);
                    session.GetCurrentTransaction().Commit();
                }
            }
            finally
            {
                nHHelper.CloseSession();
            }
        }

        private void cmbTipoTest_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtNota.Clear();
            lblTestFecha.Text = "";
            btnEliminar.Enabled = false;
            btnEditarNota.Enabled = false;
            switch(cmbTipoTest.SelectedIndex)
            {
                case 0:
                    PrepDataSnellen();
                    LoadSnellenTests();
                    btnReporte.Visible = true;
                    grbResPerimetria.Visible = false;
                    btnVerResultsPeri.Enabled = false;
                    break;
                case 1:
                    PrepDataPeri();
                    LoadPeriTests();
                    btnReporte.Visible = false;
                    grbResSnellen.Visible = false;
                    grbResPerimetria.Visible = true;
                    break;
                //Add further test types here
                /*default:
                 * throw error
                 */
            }
        }

        private void dataGridTests_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int selectedId;
            int index;

            if (dataGridTests.Rows.GetRowCount(DataGridViewElementStates.Selected) > 0)
            {
                selectedId = (int)(dataGridTests.SelectedRows[0].Cells[0].Value);
                switch (cmbTipoTest.SelectedIndex)
                {
                    case 0:
                        if (listaTestSnellen.Any())
                        {
                            index = EncontrarTestSnellen(listaTestSnellen, selectedId);
                            idTestSeleccionado = selectedId;
                            ShowTestSnellen(listaTestSnellen[index]);
                        }
                        break;
                    case 1:
                        if(listaTestPerimetria.Any())
                        {
                            index = EncontrarTestPerimetria(listaTestPerimetria, selectedId);
                            idTestSeleccionado = selectedId;
                            ShowTestPerimetria(listaTestPerimetria[index]);
                        }
                        break;
                }
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            dataGridTests.Columns.Clear();
            dataGridTests.Rows.Clear();

            this.Visible = false;
            pacientesForm.Visible = true;
            pacientesForm.Focus();
        }

        private void btnNuevaPrueba_Click(object sender, EventArgs e)
        {
            switch(cmbTipoTest.SelectedIndex)
            {
                case 0:
                    formSne.CambiarPaciente(pacSel.id, pacSel.nombre);
                    formSne.Visible = true;
                    formSne.Focus();
                    this.Hide();
                    break;
                case 1:
                    formPeri.CambiarPaciente(pacSel.id, pacSel.nombre);
                    formPeri.Visible = true;
                    formSne.Focus();
                    this.Hide();
                    break;
            }
        }

        private void btnEditarNota_Click(object sender, EventArgs e)
        {
            DisableAll();

            btnRegresar.Enabled = false;
            btnRegresar.Visible = false;
            btnNuevaPrueba.Enabled = false;
            btnNuevaPrueba.Visible = false;

            btnConfirmarNota.Visible = true;
            btnConfirmarNota.Enabled = true;
            btnCancelarNota.Visible = true;
            btnCancelarNota.Enabled = true;

            txtNota.Enabled = true;
            txtNota.Focus();
        }

        private void btnConfirmarNota_Click(object sender, EventArgs e)
        {
            switch (cmbTipoTest.SelectedIndex)
            {
                case 0:
                    {
                        if (!listaTestSnellen.Any())
                            return;

                        if (dataGridTests.Rows.GetRowCount(DataGridViewElementStates.Selected) > 0)
                        {
                            int id;
                            int selectedID;
                            selectedID = (int)dataGridTests.SelectedRows[0].Cells[0].Value;

                            id = EncontrarTestSnellen(listaTestSnellen, selectedID);

                            TestSnellen t = listaTestSnellen[id];

                            t.nota = txtNota.Text;

                            session = nHHelper.GetCurrentSession();
                            try
                            {
                                using (session.BeginTransaction())
                                {
                                    session.Update(t);
                                    session.GetCurrentTransaction().Commit();
                                }
                            }
                            finally
                            {
                                nHHelper.CloseSession();
                            }
                            listaTestSnellen = GetTestsSnellen(pacSel.id);
                            PrepDataSnellen();
                            LoadSnellenTests();
                        }
                    }
                    break;
                case 1:
                    {
                        if (!listaTestPerimetria.Any())
                            return;

                        if (dataGridTests.Rows.GetRowCount(DataGridViewElementStates.Selected) > 0)
                        {
                            int id;
                            int selectedID;
                            selectedID = (int)dataGridTests.SelectedRows[0].Cells[0].Value;

                            id = EncontrarTestPerimetria(listaTestPerimetria, selectedID);

                            TestPerimetria t = listaTestPerimetria[id];

                            t.nota = txtNota.Text;

                            session = nHHelper.GetCurrentSession();
                            try
                            {
                                using (session.BeginTransaction())
                                {
                                    session.Update(t);
                                    session.GetCurrentTransaction().Commit();
                                }
                            }
                            finally
                            {
                                nHHelper.CloseSession();
                            }
                            listaTestPerimetria = GetTestsPerimetria(pacSel.id);
                            PrepDataPeri();
                            LoadPeriTests();
                        }
                    }
                    break;
            }

            ResetForm();


        }

        private void btnCancelarNota_Click(object sender, EventArgs e)
        {
            ResetForm();
            switch(cmbTipoTest.SelectedIndex)
            {
                case 0:
                    if (listaTestSnellen.Any())
                    {
                        ShowTestSnellen(listaTestSnellen[0]);
                    }
                    break;
            }
        }

        private void frmTestViewer_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnVerResultsPeri_Click(object sender, EventArgs e)
        {
            int id;
            int selectedID;
            selectedID = (int)dataGridTests.SelectedRows[0].Cells[0].Value;

            id = EncontrarTestPerimetria(listaTestPerimetria, selectedID);

            if (formVisuaPeri.IsDisposed)
                formVisuaPeri = new frmVisualizadorPerimetria(this);

            formVisuaPeri.ShowResults(listaTestPerimetria[id]);
            this.Hide();
            formVisuaPeri.Visible = true;
            formVisuaPeri.Focus();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("¿Esta seguro que desea eliminar este test?",
                                          "Eliminar test",
                                          MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                int id;
                int selectedID;
                selectedID = (int)dataGridTests.SelectedRows[0].Cells[0].Value;

                btnEditarNota.Enabled = false;
                btnEliminar.Enabled = false;

                ResetForm();
                switch(cmbTipoTest.SelectedIndex)
                {
                    case 0:
                        if (listaTestSnellen.Any())
                        {
                            TestSnellen t;
                            id = EncontrarTestSnellen(listaTestSnellen, selectedID);
                            t = listaTestSnellen[id];
                            EliminarTestSnellen(t);
                            listaTestSnellen = GetTestsSnellen(pacSel.id);
                            PrepDataSnellen();
                            LoadSnellenTests();
                        }
                        break;
                    case 1:
                        if (listaTestSnellen.Any())
                        {
                            TestPerimetria t;
                            id = EncontrarTestPerimetria(listaTestPerimetria, selectedID);
                            t = listaTestPerimetria[id];
                            EliminarTestPerimetria(t);
                            listaTestPerimetria = GetTestsPerimetria(pacSel.id);
                            PrepDataPeri();
                            LoadPeriTests();
                        }
                        break;
                } 
            }
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            formReportes.PrepararReporteSnellen(pacSel, listaTestSnellen);
            formReportes.ShowDialog();
            formReportes.Focus();
        }
    }
}
