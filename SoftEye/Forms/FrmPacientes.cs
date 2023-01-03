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
    //Confirmar/cabcelar notas
    //Agregar UI para localidades
    //Agregar UI para telefonos
    //Agregar una entrada para el telefono cuando se cree un paciente si se ingreso telefono
    //Agregar UI para localidad a la interfaz de crear paciente
    //Funciones para interpretar la combobox a id en la BD
    public partial class frmPacientes : Form
    {
        frmMain mainForm;
        frmAgregarPaciente agregarPaciente;
        frmTestViewer formTests;
        frmTelefonos formTelefonos;
        frmLocalidades formLocalidades;
        NHibernateHelper nHHelper;
        ISession session;
        int idSeleccionado;

        List<Paciente> pacientesCargados;
        List<Nota> notasPacienteSel;
        List<Localidad> localidadesCargadas;

        public frmPacientes(frmMain mForm, NHibernateHelper nHH)
        {
            InitializeComponent();
            mainForm = mForm;
            nHHelper = nHH;
        }

        private void ResetAll()
        {
            txtNombre.Enabled = false;
            txtNombre.Clear();
            txtApellido.Enabled = false;
            txtApellido.Clear();
            txtDNI.Enabled = false;
            txtDNI.Clear();
            txtTelefono.Enabled = false;
            txtTelefono.Clear();
            btnTelefonos.Enabled = false;
            txtEmail.Enabled = false;
            txtEmail.Clear();
            dtpFdn.Enabled = false;
            dtpFdn.Value = DateTime.Now;
            txtEdad.Enabled = false;
            txtEdad.Clear();
            txtDomicilio.Enabled = false;
            txtDomicilio.Clear();
            txtHistoriaClinica.Enabled = false;
            txtHistoriaClinica.Clear();
            cmbLocalidad.Enabled = false;

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
            btnNuevaNota.Enabled = false;
            btnNuevaNota.Visible = true;
            btnEliminarNota.Enabled = false;
            btnEliminarNota.Visible = true;
            btnPruebas.Enabled = false;

            dataGridPacientes.Enabled = true;
            dataGridNotas.Enabled = false;
            dataGridNotas.Rows.Clear();

            btnCancelarNota.Visible = false;
            btnCancelarNota.Enabled = false;
            btnModificarConfirmar.Enabled = false;
            btnModificarConfirmar.Visible = false;
            btnModificarCancelar.Enabled = false;
            btnModificarCancelar.Visible = false;
        }

        private void DisableAll()
        {
            txtNombre.Enabled = false;
            txtApellido.Enabled = false;
            txtDNI.Enabled = false;
            txtTelefono.Enabled = false;
            btnTelefonos.Enabled = false;
            txtEmail.Enabled = false;
            dtpFdn.Enabled = false;
            txtEdad.Enabled = false;
            txtDomicilio.Enabled = false;
            txtHistoriaClinica.Enabled = false;
            txtNotas.Enabled = false;
            cmbLocalidad.Enabled = false;



            btnNuevo.Enabled = false;
            btnEliminar.Enabled = false;
            btnEliminar.Visible = false;
            btnModificar.Enabled = false;
            btnModificar.Visible = false;
            btnCancelarNota.Visible = false;
            btnCancelarNota.Enabled = false;
            btnConfirmarNota.Visible = false;
            btnConfirmarNota.Enabled = false;
            btnNuevaNota.Enabled = false;
            btnEliminar.Enabled = false;
            btnPruebas.Enabled = false;

            dataGridPacientes.Enabled = false;
            dataGridNotas.Enabled = false;

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
            formTelefonos = new frmTelefonos(this, nHHelper);
            formLocalidades = new frmLocalidades(this, nHHelper);

            LoadLocalidades();
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
            if (!String.IsNullOrEmpty(paciente.telefono))
            {
                List<Paciente> p;
                session = nHHelper.GetCurrentSession();
                try
                {
                    using (session.BeginTransaction())
                    {
                        p = session.Query<Paciente>()
                                   .Where(o => o.nombre == paciente.nombre && o.dni == paciente.dni)
                                   .OrderByDescending(o => o.id)
                                   .ToList();
                    }
                }
                finally
                {
                    nHHelper.CloseSession();
                }
                if (p.Any())
                {
                    Telefono tel = new Telefono(p[0].id, paciente.telefono);
                    session = nHHelper.GetCurrentSession();
                    try
                    {
                        using (session.BeginTransaction())
                        {
                            session.Save(tel);
                            session.GetCurrentTransaction().Commit();
                        }
                    }
                    finally
                    {
                        nHHelper.CloseSession();
                    }
                }
            }

            pacientesCargados = GetPacientes();

            RefreshDataGrid(pacientesCargados);
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
            RefreshDataGrid(pacientesCargados);
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

        public void LoadLocalidades()
        {
            session = nHHelper.GetCurrentSession();
            try
            {
                using (session.BeginTransaction())
                {
                    localidadesCargadas = session
                                          .Query<Localidad>()
                                          .Where(o => o.activo == true)
                                          .OrderBy(o => o.nombre)
                                          .ToList();
                }
            }
            finally
            {
                nHHelper.CloseSession();
            }

            localidadesCargadas = localidadesCargadas.OrderBy(o => o.nombre).ToList();
        }

        public void LoadCmbx()
        {
            LoadLocalidades();

            if (!localidadesCargadas.Any())
            {
                cmbLocalidad.DataSource = null;
                return;
            }
            else
            {
                cmbLocalidad.DataSource = null;
                cmbLocalidad.DataSource = localidadesCargadas;
                cmbLocalidad.DisplayMember = "nombre";
                cmbLocalidad.ValueMember = "id";
                cmbLocalidad.SelectedIndex = -1;
            }
        }

        public void LimpiarLocalidad (Localidad l)
        {
            foreach (Paciente p in pacientesCargados)
            {
                if (p.localidad == l.id)
                {
                    p.localidad = null;
                    session = nHHelper.GetCurrentSession();
                    try
                    {
                        using (session.BeginTransaction())
                        {
                            session.Update(p);
                            session.GetCurrentTransaction().Commit();
                        }
                    }
                    finally
                    {
                        nHHelper.CloseSession();
                    }
                }
            }
            pacientesCargados = GetPacientes();
            RefreshDataGrid(pacientesCargados);
        }

        public String InterpretLocalidad(int? index)
        {
            if (index < 0 || index == null)
                return "";

            return (localidadesCargadas.Find(o=>o.id == index).nombre);
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

        private void AddNota(String texto, Paciente p)
        {
            if (String.IsNullOrEmpty(texto))
                return;

            if (p == null)
                return;

            session = nHHelper.GetCurrentSession();
            Nota nota = new Nota(p.id, texto, DateTime.Today.ToString("d"));
            try
            {
                using (session.BeginTransaction())
                {
                    session.Save(nota);
                    session.GetCurrentTransaction().Commit();
                }
            }
            finally
            {
                nHHelper.CloseSession();
            }
        }
        private void DeleteNota(Nota n)
        {
            if (n == null)
                return;

            n.activo = false;
            session = nHHelper.GetCurrentSession();
            try
            {
                using (session.BeginTransaction())
                {
                    session.Update(n);
                    session.GetCurrentTransaction().Commit();
                }
            }
            finally
            {
                nHHelper.CloseSession();
            }
        }
        private List<Nota> GetNotas(Paciente p)
        {
            if (p == null)
                return null;

            List<Nota> notas;
            session = nHHelper.GetCurrentSession();
            try
            {
                using (session.BeginTransaction())
                {
                    notas = session
                            .Query<Nota>()
                            .Where(o => o.idPaciente == p.id && o.activo == true)
                            .OrderByDescending(o => o.id)
                            .ToList();
                }
            }
            finally
            {
                nHHelper.CloseSession();
            }
            return notas;
        }
        private Nota FindNota(List<Nota> l, int id)
        {
            if (!l.Any())
                return null;

            foreach (Nota n in l)
            {
                if (n.id == id)
                {
                    return n;
                }
            }
            return null;
        }
        private void ClearNotas()
        {
            txtNotas.Text = "";
            dataGridNotas.Rows.Clear();
        }
        private void LoadNotas(List<Nota> l)
        {
            if (!l.Any())
                return;

            foreach (Nota n in l)
            {
                dataGridNotas.Rows.Add(n.fecha, n.id);
            }
        }
        private void MostrarNotasDatagrid(Paciente p)
        {
            notasPacienteSel = GetNotas(p);
            dataGridNotas.Rows.Clear();
            dataGridNotas.Enabled = false;
            if (!notasPacienteSel.Any())
                return;

            LoadNotas(notasPacienteSel);
            dataGridNotas.Rows[0].Selected = true;
            MostrarNota(FindNota(notasPacienteSel, (int)dataGridNotas.Rows[0].Cells[1].Value));
            dataGridNotas.Enabled = true;
            btnEliminar.Enabled = true;
        }
        private void MostrarNota(Nota n)
        {
            txtNotas.Text = n.texto;
        }

        private void RefreshDataGrid(List<Paciente> pac)
        {
            pacientesCargados = GetPacientes();
            ResetAll();
            dataGridPacientes.Rows.Clear();
            string loc;
            if (pac.Any())
            {
                foreach (Paciente p in pac)
                {
                    loc = InterpretLocalidad(p.localidad);
                    string displayName = p.nombre + " " + p.apellido;
                    dataGridPacientes.Rows.Add(p.id, displayName, p.dni, loc);
                }
                idSeleccionado = pac[0].id;
                MostrarDatosPaciente(pac[0]);
            }
        }
        
        private void MostrarDatosPaciente(Paciente p)
        {
            p.CalcEdad();
            txtNombre.Text = p.nombre;
            txtApellido.Text = p.apellido;
            txtDNI.Text = p.dni;
            txtTelefono.Text = p.telefono;
            txtEmail.Text = p.email;
            dtpFdn.Value = Convert.ToDateTime(p.fdn);
            txtEdad.Text = p.edad.ToString();
            txtDomicilio.Text = p.domicilio;
            txtHistoriaClinica.Text = p.hClinica;

            LoadCmbx();
            cmbLocalidad.Text = InterpretLocalidad(p.localidad);

            MostrarNotasDatagrid(p);

            btnTelefonos.Enabled = true;
            btnPruebas.Enabled = true;
            btnModificar.Enabled = true;
            btnEliminar.Enabled = true;
            btnNuevaNota.Enabled = true;
        }

        public void RefrescarDatosPaciente()
        {
            Paciente p = pacientesCargados[EncontrarPaciente(pacientesCargados, idSeleccionado)];

            p.CalcEdad();
            txtNombre.Text = p.nombre;
            txtDNI.Text = p.dni;
            txtTelefono.Text = p.telefono;
            txtEmail.Text = p.email;
            dtpFdn.Value = Convert.ToDateTime(p.fdn);
            txtEdad.Text = p.edad.ToString();
            txtDomicilio.Text = p.domicilio;
            txtHistoriaClinica.Text = p.hClinica;

            LoadCmbx();
            cmbLocalidad.Text = InterpretLocalidad(p.localidad);

            MostrarNotasDatagrid(p);

            btnPruebas.Enabled = true;
            btnModificar.Enabled = true;
            btnEliminar.Enabled = true;
            btnNuevaNota.Enabled = true;
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

        public bool ValidarMail(string mail)
        {
            if (string.IsNullOrEmpty(mail))
                return true;

            bool res = false;

            for (int i = 0; i < mail.Length; i++)
            {
                if(mail[i] == '@')
                {
                    for (int j = i + 1; j < mail.Length; j++)
                    {
                        if(mail[j] == '.')
                        {
                            res = true;
                            break;
                        }
                    }
                    break;
                }
            }

            return res;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            agregarPaciente.LimpiarCampos(localidadesCargadas);
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

        private void dataGridNotas_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridNotas.Rows.GetRowCount(DataGridViewElementStates.Selected) > 0)
            {
                if (notasPacienteSel.Any())
                {
                    int idNota = (int) dataGridNotas.SelectedRows[0].Cells[1].Value;
                    Nota n = FindNota(notasPacienteSel, idNota);
                    if(n != null)
                    {
                        txtNotas.Text = n.texto;
                        btnEliminarNota.Enabled = true;
                    }                       
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            DisableAll();

            txtNombre.Enabled = true;
            txtApellido.Enabled = true;
            txtDNI.Enabled = true;
            txtEmail.Enabled = true;
            dtpFdn.Enabled = true;
            txtDomicilio.Enabled = true;
            txtHistoriaClinica.Enabled = true;
            cmbLocalidad.Enabled = true;

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
            if (!String.IsNullOrEmpty(txtEmail.Text))
            {
                if (!ValidarMail(txtEmail.Text))
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
                        .Where(o => o.dni == txtDNI.Text && o.activo == true && o.id != idSeleccionado)
                        .ToList();
                }
            }
            finally
            {
                nHHelper.CloseSession();
            }
            if (pac.Any())
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
                            .Where(o => o.hClinica == txtHistoriaClinica.Text && o.activo == true && o.id != idSeleccionado)
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
            {
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
                    loc = (int)cmbLocalidad.SelectedValue;
                Paciente p = new Paciente(nom,
                                          ape,
                                          nacimiento,
                                          dni,
                                          telefono,
                                          domicilio,
                                          eMail,
                                          hClinica,
                                          loc);
                p.id = idSeleccionado;
                //Llamada a modificar
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
        private void btnNuevaNota_Click(object sender, EventArgs e)
        {
            DisableAll();
            txtNotas.Enabled = true;
            txtNotas.Clear();
            txtNotas.Focus();

            btnNuevaNota.Enabled = false;
            btnNuevaNota.Visible = false;
            btnEliminarNota.Enabled = false;
            btnEliminarNota.Visible = false;

            btnConfirmarNota.Enabled = true;
            btnConfirmarNota.Visible = true;
            btnCancelarNota.Enabled = true;
            btnCancelarNota.Visible = true;
        }
        private void btnEliminarNota_Click(object sender, EventArgs e)
        {
            if (dataGridNotas.Rows.GetRowCount(DataGridViewElementStates.Selected)<1)
            {
                return;
            }

            DialogResult res = MessageBox.Show("¿Esta seguro que desea eliminar esta nota?",
                                          "Eliminar nota",
                                          MessageBoxButtons.YesNo);

            if (res == DialogResult.Yes)
            {
                txtNotas.Clear();
                int selectedID;
                selectedID = (int)dataGridNotas.SelectedRows[0].Cells[1].Value;
                Nota nota;
                if (notasPacienteSel.Any())
                {
                    nota = FindNota(notasPacienteSel, selectedID);
                    DeleteNota(nota);
                    MostrarNotasDatagrid(pacientesCargados[EncontrarPaciente(pacientesCargados,idSeleccionado)]);
                }
            }
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
                //See whos selected, bring those notes up
                int id;
                int selectedID;
                selectedID = (int)dataGridPacientes.SelectedRows[0].Cells[0].Value;

                id = EncontrarPaciente(pacientesCargados, selectedID);

                Paciente p = pacientesCargados[id];

                AddNota(txtNotas.Text, p);

                MostrarNotasDatagrid(p);
            }

            txtNotas.Enabled = false;

            btnCancelarNota.Enabled = false;
            btnCancelarNota.Visible = false;
            btnConfirmarNota.Enabled = false;
            btnConfirmarNota.Visible = false;

            btnNuevaNota.Enabled = true;
            btnNuevaNota.Visible = true;
            btnEliminarNota.Enabled = true;
            btnEliminarNota.Visible = true;

            btnPruebas.Enabled = true;
            btnNuevo.Enabled = true;
            btnModificar.Visible = true;
            btnModificar.Enabled = true;
            btnEliminar.Visible = true;
            btnEliminar.Enabled = true;
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

                txtNotas.Clear();
                cmbLocalidad.Text = null;

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

        private void btnTelefonos_Click(object sender, EventArgs e)
        {
            Paciente p = pacientesCargados[EncontrarPaciente(pacientesCargados, idSeleccionado)];
            formTelefonos.CargarFormulario(p);
            formTelefonos.ShowDialog();
            formTelefonos.Focus();
        }

        private void btnLocalidad_Click(object sender, EventArgs e)
        {
            formLocalidades.SetUp();
            formLocalidades.ShowDialog();
            formLocalidades.Focus();
        }


        public List<Localidad> LocalidadesCargadas => localidadesCargadas;

        private void txtDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            int ttTime = 5000;
            ToolTip tt = new ToolTip();

            if (e.KeyChar != (char)Keys.Back && !char.IsDigit(e.KeyChar))
            {
                tt.Show("Solo se admiten caracteres numericos.", tb, 0, -20, ttTime);
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
    }
}
