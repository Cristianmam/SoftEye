using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using SoftEye.Classes;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

namespace SoftEye.Forms
{
    public partial class frmGenReporte : Form
    {

        frmTestViewer formTestViever;

        FolderBrowserDialog buscadorCarpetas;

        string folderPath;

        Paciente pac;
        List<TestSnellen> testSnellen;

        public frmGenReporte(frmTestViewer tv)
        {
            formTestViever = tv;
            InitializeComponent();

            buscadorCarpetas = new FolderBrowserDialog();
            buscadorCarpetas.Description = "Seleccionar carpeta para guardar el informe";
        }

        public void PrepararReporteSnellen(Paciente p, List<TestSnellen> testSne)
        {
            pac = p;
            testSnellen = testSne;

            dtpInicioRep.Value = DateTime.Now;
            dtpFinRep.Value = DateTime.Now;

            this.Text = "Reportes para " + pac.nombre + " " + pac.apellido;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            List<TestSnellen> tS = new List<TestSnellen>();
            foreach (TestSnellen t in testSnellen)
            {
                DateTime date = Convert.ToDateTime(t.fecha);
                if (DateTime.Compare(date, dtpInicioRep.Value) >= 0 && DateTime.Compare(date, dtpFinRep.Value) <= 0)
                {
                    tS.Add(t);
                }
            }
            if (!tS.Any())
            {
                MessageBox.Show("No se han encontrado tests en el rango de fechas ingresadas.", "Sin tests");
                return;
            }
            DialogResult res = buscadorCarpetas.ShowDialog();
            if (res == DialogResult.OK)
            {
                folderPath = buscadorCarpetas.SelectedPath;

                PdfDocument doc = new PdfDocument();
                doc.Info.Title = "Reporte de " + pac.nombre + " " + pac.apellido;

                PdfPage pag = doc.AddPage();

                XGraphics gfx = XGraphics.FromPdfPage(pag);

                XFont fue = new XFont("Arial", 16);

                XRect rec = new XRect(0,0,pag.Width,20);

                string texto = "Tests del paciente " + pac.nombre + " " + pac.apellido; 

                gfx.DrawString(texto, fue, XBrushes.Black, rec, XStringFormats.TopCenter);

                texto = "Realizados entre el " + dtpInicioRep.Value.ToString("d") + " y el " + dtpFinRep.Value.ToString("d");

                rec = new XRect(0, 20, pag.Width, 20);

                gfx.DrawString(texto, fue, XBrushes.Black, rec, XStringFormats.TopCenter);

                XPen lineaNegra = new XPen(XColors.Black, 3);
                XPoint p1 = new XPoint(20, 40);
                XPoint p2 = new XPoint(pag.Width - 20, 40);
                gfx.DrawLine(lineaNegra, p1, p2);

                int margen = 60;
                int spacing = 100;

                rec = new XRect(0, margen, 50, 20);
                gfx.DrawString("Fecha", fue, XBrushes.Black, rec, XStringFormats.TopCenter);
                rec = new XRect(spacing, margen, 50, 20);
                gfx.DrawString("Resultado", fue, XBrushes.Black, rec, XStringFormats.TopCenter);
                rec = new XRect(spacing * 2, margen, 50, 20);
                gfx.DrawString("Alfabeto", fue, XBrushes.Black, rec, XStringFormats.TopCenter);

                int intervalo = 20;
                margen += intervalo * 2;

                foreach (TestSnellen t in tS)
                {
                    rec = new XRect(0, margen, 50, 20);
                    gfx.DrawString(t.fecha, fue, XBrushes.Black, rec, XStringFormats.TopLeft);
                    rec = new XRect(spacing, margen, 50, 20);
                    gfx.DrawString(t.mejorRes, fue, XBrushes.Black, rec, XStringFormats.TopCenter);
                    rec = new XRect(spacing * 2, margen, 50, 20);
                    gfx.DrawString(t.alfabeto, fue, XBrushes.Black, rec, XStringFormats.TopCenter);
                    margen += intervalo;
                }

                string filename = folderPath + "\\" + "Reporte " + pac.nombre + " " + pac.apellido + ".pdf";

                doc.Save(filename);

                Process.Start(filename);
            }
            else
            {
                return;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            formTestViever.Focus();
        }
    }
}
