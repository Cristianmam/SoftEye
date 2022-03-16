using SoftEye.Forms;
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

namespace SoftEye
{
    public partial class frmPacientes : Form
    {
        frmMain mainForm;
        frmAgregarPaciente agregarPaciente;
        frmTestViewer formTests;
        NHibernateHelper nHHelper;
        ISession session;
        int idSeleccionado;

        List<Paciente> pacientesCargados;

        public frmPacientes(frmMain mForm, NHibernateHelper nHH)
        {
            InitializeComponent();
            mainForm = mForm;
            nHHelper = nHH;
        }

        private void ResetAll()
        {
            txtNYA.Enabled = false;
            txtNYA.Clear();
            txtDNI.Enabled = false;
            txtDNI.Clear();
            txtTelefono.Enabled = false;
            txtTelefono.Clear();
            txtEmail.Enabled = false;
            txtEmail.Clear();
            txtNacimiento.Enabled = false;
            txtNacimiento.Clear();
            txtEdad.Enabled = false;
            txtEdad.Clear();
            txtDomicilio.Enabled = false;
            txtDomicilio.Clear();
            txtHistoriaClinica.Enabled = false;
            txtHistoriaClinica.Clear();
            txtNotas.Enabled = false;
            txtNotas.Clear();



            btnNuevo.Enabled = true;
            btnEliminar.Enabled = false;
            btnEliminar.Visible = true;
            btnModificar.Enabled = false;
            btnModificar.Visible = true;
            btnCancelarNota.Visible = false;
            btnCancelarNota.Enabled = false;
            btnConfirmarNota.Visible = false;
            btnConfirmarNota.Enabled = false;
            btnModificarNota.Enabled = false;
            btnModificarNota.Visible = true;
            btnPruebas.Enabled = false;

            dataGridPacientes.Enabled = true;

            btnCancelarNota.Visible = false;
            btnCancelarNota.Enabled = false;
            btnModificarConfirmar.Enabled = false;
            btnModificarConfirmar.Visible = false;
            btnModificarCancelar.Enabled = false;
            btnModificarCancelar.Visible = false;
        }

        private void DisableAll()
        {
            txtNYA.Enabled = false;
            txtDNI.Enabled = false;
            txtTelefono.Enabled = false;
            txtEmail.Enabled = false;
            txtNacimiento.Enabled = false;
            txtEdad.Enabled = false;
            txtDomicilio.Enabled = false;
            txtHistoriaClinica.Enabled = false;
            txtNotas.Enabled = false;



            btnNuevo.Enabled = false;
            btnEliminar.Enabled = false;
            btnEliminar.Visible = false;
            btnModificar.Enabled = false;
            btnModificar.Visible = false;
            btnCancelarNota.Visible = false;
            btnCancelarNota.Enabled = false;
            btnConfirmarNota.Visible = false;
            btnConfirmarNota.Enabled = false;
            btnModificarNota.Enabled = false;
            btnModificarNota.Visible = false;
            btnPruebas.Enabled = false;

            dataGridPacientes.Enabled = false;

            btnCancelarNota.Visible = false;
            btnCancelarNota.Enabled = false;
            btnModificarConfirmar.Enabled = false;
            btnModificarConfirmar.Visible = false;
            btnModificarCancelar.Enabled = false;
            btnModificarCancelar.Visible = false;
        }

        private void frmPacientes_Load(object sender, EventArgs e)
        {
            agregarPaciente = new frmAgregarPaciente(this,nHHelper);
            formTests = new frmTestViewer(this, nHHelper);

            pacientesCargados = GetPacientes();

            RefreshDataGrid(pacientesCargados);

            if (pacientesCargados.Any())
            {
                idSeleccionado = pacientesCargados[0].id;
                MostrarDatosPaciente(pacientesCargados[0]);
                //Habilitar el boton de tests
            }
        }

        private void frmPacientes_Closed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        public bool ValidarPaciente(Paciente paciente)
        {
            string fe = FormatearFecha(paciente.fdn);
            if (fe != "")
                paciente.fdn = fe;
            /*else
                //error*/

            return true;
        }

        public void AgregarPaciente(Paciente paciente)
        {
            session = nHHelper.GetCurrentSession();
            try
            {
                using (session.BeginTransaction())
                {
                    session.Save(paciente);

                    session.GetCurrentTransaction().Commit();
                }
            }
            finally
            {
                nHHelper.CloseSession();
            }

            pacientesCargados = GetPacientes();

            RefreshDataGrid(pacientesCargados);
            //Checkear por pacientes cargados, setear el 0 como seleccionado y habilitar test
        }

        public void ModificarPaciente(Paciente paciente)
        {
            session = nHHelper.GetCurrentSession();
            try
            {
                using (session.BeginTransaction())
                {
                    session.Update(paciente);
                    session.GetCurrentTransaction().Commit();
                }
            }
            finally
            {
                nHHelper.CloseSession();
            }
            pacientesCargados = GetPacientes();
        }

        public int ToInt(char c)
        {
            if(c == '0' ||
               c == '1' ||
               c == '2' ||
               c == '3' ||
               c == '4' ||
               c == '5' ||
               c == '6' ||
               c == '7' ||
               c == '8' ||
               c == '9' )
            {
                int i;
                i = int.Parse((c.ToString()));
                return i;
            }
            else
            {
                return -1;
            }
            
        }

        private List<Paciente> GetPacientes()
        {
            List<Paciente> pas;
            session = nHHelper.GetCurrentSession();
            try
            {
                using (session.BeginTransaction())
                {
                    pas = session
                        .Query<Paciente>()
                        .Where(o => o.activo == true)
                        .ToList();
                }
            }
            finally
            {
                nHHelper.CloseSession();
            }
            return pas;
        }

        private void RefreshDataGrid(List<Paciente> pac)
        {
            ResetAll();
            dataGridPacientes.Rows.Clear();
            if (pac.Any())
            {
                foreach (Paciente p in pac)
                {
                    dataGridPacientes.Rows.Add(p.id, p.nombre, p.dni);
                }
                MostrarDatosPaciente(pac[0]);
            }
        }
        
        private void MostrarDatosPaciente(Paciente p)
        {
            p.CalcEdad();
            txtNYA.Text = p.nombre;
            txtDNI.Text = p.dni;
            txtTelefono.Text = p.telefono;
            txtEmail.Text = p.email;
            txtNacimiento.Text = p.fdn;
            txtEdad.Text = p.edad.ToString();
            txtDomicilio.Text = p.domicilio;
            txtHistoriaClinica.Text = p.hClinica;
            txtNotas.Text = p.nota;

            btnPruebas.Enabled = true;
            btnModificar.Enabled = true;
            btnEliminar.Enabled = true;
            btnModificarNota.Enabled = true;
        }

        private int EncontrarPaciente(List<Paciente> l, int id)
        {
            int i = 0;
            foreach(Paciente p in l)
            {
                if(p.id == id)
                {
                    return (i);
                }
                i++;
            }
            return (-1);
        }

        public string FormatearFecha(string vString)
        {
            string nString;
            int largo = vString.Length;

            if (string.IsNullOrEmpty(vString))
            {
                return vString;
            }
            //Checkear que el largo sea de al menos 6
            if (largo < 6)
            {
                MessageBox.Show("La fecha ingresada no tiene almenos 6 números. Por favor, incluya ceros",
                                     "Error en la fecha",
                                     MessageBoxButtons.OK);
                nString = "";
            }
            else
            {
                //Checkear que al menos haya 6 numeros
                int numCont = 0;

                for (int i = 0; i < largo; i++)
                {
                    if (ToInt(vString[i]) >= 0 && ToInt(vString[i]) <= 9)
                    {
                        numCont++;
                    }
                }

                if (numCont < 6)
                {
                    nString = "";
                    MessageBox.Show("La fecha ingresada no tiene almenos 6 números. Por favor, incluya ceros",
                                     "Error en la fecha",
                                     MessageBoxButtons.OK);
                }
                else
                {
                    nString = "";
                    int vStringPos = 0;
                    if(numCont < 8)
                    {
                        do
                        {
                            if (ToInt(vString[vStringPos]) >= 0 && ToInt(vString[vStringPos]) <= 9)
                            {
                                if (nString.Length == 2 || nString.Length == 5)
                                    nString += "/";
                                nString += vString[vStringPos];
                            }
                            vStringPos++;
                        } while (nString.Length <= 8 && vStringPos < vString.Length);
                    }
                    else
                    {
                        
                        do
                        {
                            if (ToInt(vString[vStringPos]) >= 0 && ToInt(vString[vStringPos]) <= 9)
                            {
                                if (nString.Length == 2 || nString.Length == 5)
                                    nString += "/";
                                nString += vString[vStringPos];
                            }
                            vStringPos++;
                        } while (nString.Length<=10 && vStringPos < vString.Length);
                    }

                    DateTime minFecha = new DateTime(1940,01,01);
                    DateTime maxFecha = DateTime.Now;
                    DateTime inputFecha = Convert.ToDateTime(nString);

                    if (DateTime.Compare(inputFecha, minFecha) < 0)
                        inputFecha = minFecha;
                    if (DateTime.Compare(inputFecha, maxFecha) > 0)
                        inputFecha = maxFecha;

                    nString = inputFecha.ToString("d");
                }
            }
            

            return nString;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            agregarPaciente.LimpiarCampos();
            agregarPaciente.ShowDialog();
            agregarPaciente.Focus();
        }

        private void dataGridPacientes_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int selectedID;
            int id;

            if (dataGridPacientes.Rows.GetRowCount(DataGridViewElementStates.Selected) > 0)
            {
                selectedID = (int)dataGridPacientes.SelectedRows[0].Cells[0].Value;
                if (pacientesCargados.Any())
                {
                    id = EncontrarPaciente(pacientesCargados, selectedID);
                    idSeleccionado = selectedID;
                    MostrarDatosPaciente(pacientesCargados[id]);
                }
            }
        }


        private void btnModificar_Click(object sender, EventArgs e)
        {
            DisableAll();

            txtNYA.Enabled = true;
            txtDNI.Enabled = true;
            txtTelefono.Enabled = true;
            txtEmail.Enabled = true;
            txtNacimiento.Enabled = true;
            txtDomicilio.Enabled = true;
            txtHistoriaClinica.Enabled = true;

            btnModificarConfirmar.Enabled = true;
            btnModificarConfirmar.Visible = true;
            btnModificarCancelar.Enabled = true;
            btnModificarCancelar.Visible = true;
        }

        private void btnModificarCancelar_Click(object sender, EventArgs e)
        {
            ResetAll();

            if (dataGridPacientes.Rows.GetRowCount(DataGridViewElementStates.Selected) > 0)
            {
                int id;
                int selectedID;
                selectedID = (int)dataGridPacientes.SelectedRows[0].Cells[0].Value;

                if (pacientesCargados.Any())
                {
                    id = EncontrarPaciente(pacientesCargados, selectedID);
                    MostrarDatosPaciente(pacientesCargados[id]);
                }
            }
            else
            {
                if (pacientesCargados.Any())
                {
                    MostrarDatosPaciente(pacientesCargados[0]);
                }
            }
        }

        private void btnModificarConfirmar_Click(object sender, EventArgs e)
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


            //Carga de objeto
            {
                string nya = txtNYA.Text;
                string nacimiento = String.IsNullOrEmpty(txtNacimiento.Text) ? "" : txtNacimiento.Text;
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
                p.id = idSeleccionado;
                p.nota = pacientesCargados[EncontrarPaciente(pacientesCargados, idSeleccionado)].nota;
                //Llamada a modificar
                if (ValidarPaciente(p))
                    ModificarPaciente(p);
            }

            ResetAll();

            if (dataGridPacientes.Rows.GetRowCount(DataGridViewElementStates.Selected) > 0)
            {
                int id;
                int selectedID;
                selectedID = (int)dataGridPacientes.SelectedRows[0].Cells[0].Value;

                if (pacientesCargados.Any())
                {
                    id = EncontrarPaciente(pacientesCargados, selectedID);
                    MostrarDatosPaciente(pacientesCargados[id]);
                }
            }
            else
            {
                if (pacientesCargados.Any())
                {
                    MostrarDatosPaciente(pacientesCargados[0]);
                }
            }
        }

        private void btnModificarNota_Click(object sender, EventArgs e)
        {
            DisableAll();
            txtNotas.Enabled = true;
            txtNotas.Focus();

            btnConfirmarNota.Enabled = true;
            btnConfirmarNota.Visible = true;
            btnCancelarNota.Enabled = true;
            btnCancelarNota.Visible = true;
        }
        private void btnCancelarNota_Click(object sender, EventArgs e)
        {

            ResetAll();

            if (!pacientesCargados.Any())
                return;

            if (dataGridPacientes.Rows.GetRowCount(DataGridViewElementStates.Selected) > 0)
            {
                int id;
                int selectedID;
                selectedID = (int)dataGridPacientes.SelectedRows[0].Cells[0].Value;

                if (pacientesCargados.Any())
                {
                    id = EncontrarPaciente(pacientesCargados, selectedID);
                    MostrarDatosPaciente(pacientesCargados[id]);
                }
            }
            else
            {
                if (pacientesCargados.Any())
                {
                    MostrarDatosPaciente(pacientesCargados[0]);
                }
            }
        }

        private void btnConfirmarNota_Click(object sender, EventArgs e)
        {

            if (!pacientesCargados.Any())
                return;

            if (dataGridPacientes.Rows.GetRowCount(DataGridViewElementStates.Selected) > 0)
            {
                int id;
                int selectedID;
                selectedID = (int)dataGridPacientes.SelectedRows[0].Cells[0].Value;

                id = EncontrarPaciente(pacientesCargados, selectedID);

                Paciente p = pacientesCargados[id];

                p.nota = txtNotas.Text;

                ModificarPaciente(p);
                ResetAll();
                MostrarDatosPaciente(p);
            }
       

        }

        private void btnPruebas_Click(object sender, EventArgs e)
        {
            if (dataGridPacientes.Rows.GetRowCount(DataGridViewElementStates.Selected) > 0)
            {
                int id;
                int selectedID;
                selectedID = (int)dataGridPacientes.SelectedRows[0].Cells[0].Value;

                if (pacientesCargados.Any())
                {
                    id = EncontrarPaciente(pacientesCargados, selectedID);
                }
                else
                {
                    return;
                }
                this.Visible = false;
                formTests.Visible = true;
                formTests.CambiarPaciente(pacientesCargados[id]);
            }
                
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("¿Esta seguro que desea eliminar este paciente?",
                                          "Eliminar paciente",
                                          MessageBoxButtons.YesNo);
            if(res == DialogResult.Yes)
            {
                int id;
                int selectedID;
                selectedID = (int)dataGridPacientes.SelectedRows[0].Cells[0].Value;
                Paciente p;

                if (pacientesCargados.Any())
                {
                    id = EncontrarPaciente(pacientesCargados, selectedID);
                    p = pacientesCargados[id];
                    p.activo = false;
                    ModificarPaciente(p);
                    pacientesCargados = GetPacientes();
                    RefreshDataGrid(pacientesCargados);
                }
            }  
        }
    }
}
