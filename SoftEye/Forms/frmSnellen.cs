using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SoftEye.Classes;

namespace SoftEye.Forms
{
    public partial class frmSnellen : Form
    {

        int defaultSize = 361;
        int alteredSize = 361;
        int screenHeight;
        int screenWidth;

        int curPos = 0;
        int curLine = 0;

        Image[] images;
        Random rng = new Random();

        bool runningTest = false;
        bool reset = false;
        bool abort = false;
        bool controls = false;

        List<int[]> resultados;
        string alfabeto;
        int idPaciente;

        public frmAguSetup formAguSetup;
        private NHibernateHelper nHHelper;
        private frmFinalizarTestSnellen formFinalizarTestSnellen;

        public frmSnellen(frmAguSetup frm, NHibernateHelper nHH)
        {
            InitializeComponent();

            formAguSetup = frm;
            nHHelper = nHH;

            formFinalizarTestSnellen = new frmFinalizarTestSnellen(this, nHHelper);

            screenHeight = Screen.PrimaryScreen.Bounds.Height;
            screenWidth = Screen.PrimaryScreen.Bounds.Width;
        }

        private void frmSnellen_Load(object sender, EventArgs e)
        {
            backGround1.Anchor = (AnchorStyles.Top | AnchorStyles.Left);
            backGround2.Anchor = (AnchorStyles.Top | AnchorStyles.Left);

            backGround1.Height = screenHeight;
            backGround2.Height = screenHeight;

            backGround1.Width = screenWidth / 2;
            backGround2.Width = screenWidth / 2;

            backGround1.Location = new Point(0, 0);
            backGround2.Location = new Point(Screen.PrimaryScreen.Bounds.Width / 2, 0);

            picBoxMarker1.BackColor = Color.Transparent;
            picBoxMarker2.BackColor = Color.Transparent;

            picBoxMarker1.Parent = backGround1;
            picBoxMarker2.Parent = backGround2;

            picBoxMarker1.Anchor = (AnchorStyles.Top | AnchorStyles.Left);
            picBoxMarker2.Anchor = (AnchorStyles.Top | AnchorStyles.Left);

            picBoxMarker1.Image = Image.FromFile(@"Assets\Graficos\Marker.png");
            picBoxMarker2.Image = Image.FromFile(@"Assets\Graficos\Marker.png");

            picBoxA1.BackColor = Color.Transparent;
            picBoxA1.Parent = backGround1;
            picBoxA1.Anchor = (AnchorStyles.Top | AnchorStyles.Left);
            picBoxA2.BackColor = Color.Transparent;
            picBoxA2.Parent = backGround1;
            picBoxA2.Anchor = (AnchorStyles.Top | AnchorStyles.Left);
            picBoxA3.BackColor = Color.Transparent;
            picBoxA3.Parent = backGround1;
            picBoxA3.Anchor = (AnchorStyles.Top | AnchorStyles.Left);
            picBoxA4.BackColor = Color.Transparent;
            picBoxA4.Parent = backGround1;
            picBoxA4.Anchor = (AnchorStyles.Top | AnchorStyles.Left);

            picBoxB1.BackColor = Color.Transparent;
            picBoxB1.Parent = backGround2;
            picBoxB1.Anchor = (AnchorStyles.Top | AnchorStyles.Left);
            picBoxB2.BackColor = Color.Transparent;
            picBoxB2.Parent = backGround2;
            picBoxB2.Anchor = (AnchorStyles.Top | AnchorStyles.Left);
            picBoxB3.BackColor = Color.Transparent;
            picBoxB3.Parent = backGround2;
            picBoxB3.Anchor = (AnchorStyles.Top | AnchorStyles.Left);
            picBoxB4.BackColor = Color.Transparent;
            picBoxB4.Parent = backGround2;
            picBoxB4.Anchor = (AnchorStyles.Top | AnchorStyles.Left);

            lblValue.Anchor = (AnchorStyles.Top | AnchorStyles.Left);
            lblValue.Parent = backGround2;
            lblValue.BackColor = Color.Transparent;
            lblValue.Location = new Point(backGround2.Width - lblValue.Width - 60, (screenHeight - lblValue.Height) / 2);

            PrepControlLabels();
            
        }

        private void SetUp20200(Image[] i)
        {
            curLine = 0;
            curPos = 0;

            ClearImgBoxes();

            int midIndex = rng.Next(i.Length);
            Size newSize = new Size(alteredSize, alteredSize);

            picBoxA1.Size = newSize;
            picBoxB1.Size = newSize;

            picBoxA1.Image = i[midIndex];
            picBoxB1.Image = i[midIndex];

            picBoxA1.Location = new Point(backGround1.Width - picBoxA1.Width / 2, (screenHeight - picBoxA1.Height) / 2);
           
            picBoxB1.Location = new Point(-(picBoxB1.Width / 2), (screenHeight - picBoxB1.Height) / 2);

            lblValue.Text = "200/20";
            SetMarker(alteredSize);
        }
        private void SetUp20100(Image[] i)
        {
            curLine = 1;
            curPos = 0;
            Size newSize = new Size(alteredSize / 2, alteredSize / 2);
            ClearImgBoxes();

            picBoxA1.Size = newSize;
            picBoxB1.Size = newSize;

            int width = picBoxA1.Width;

            picBoxA1.Image = i[rng.Next(i.Length)];
            picBoxB1.Image = i[rng.Next(i.Length)];

            int posXA1 = backGround1.Width - (int)(width * 1.5);
            picBoxA1.Location = new Point(posXA1, (screenHeight - picBoxA1.Height) / 2);

            int posXB1 =  (int)(width * 0.5);
            picBoxB1.Location = new Point(posXB1, (screenHeight - picBoxB1.Height) / 2);

            lblValue.Text = "100/20";
            SetMarker(alteredSize / 2);
        }
        private void SetUp2070(Image[] i)
        {
            curLine = 2;
            curPos = 0;
            ClearImgBoxes();

            int midIndex = rng.Next(i.Length);
            Size newSize = new Size((int)(alteredSize * 0.35), (int)(alteredSize * 0.35));

            picBoxA1.Size = newSize;
            picBoxA2.Size = newSize;
            picBoxB1.Size = newSize;
            picBoxB2.Size = newSize;

            int width = picBoxA1.Width;

            picBoxA1.Image = i[rng.Next(i.Length)];
            picBoxA2.Image = i[midIndex];
            picBoxB1.Image = i[rng.Next(i.Length)];
            picBoxB2.Image = i[midIndex];

            int posXA1 = backGround1.Width - (int)(width * 2.5);
            picBoxA1.Location = new Point(posXA1, (screenHeight - picBoxA1.Height) / 2);
            int posXA2 = backGround1.Width - width / 2;
            picBoxA2.Location = new Point(posXA2, (screenHeight - picBoxA1.Height) / 2);

            int posXB1 = (int)(width * 1.5);
            picBoxB1.Location = new Point(posXB1, (screenHeight - picBoxB1.Height) / 2);
            int posXB2 = -(width / 2);
            picBoxB2.Location = new Point(posXB2, (screenHeight - picBoxB1.Height) / 2);

            lblValue.Text = "70/20";
            SetMarker((int)(alteredSize * 0.35));
        }
        private void SetUp2050(Image[] i)
        {
            curLine = 3;
            curPos = 0;

            Size newSize = new Size((int)(alteredSize * 0.25), (int)(alteredSize * 0.25));
            
            picBoxA1.Size = newSize;
            picBoxA2.Size = newSize;
            picBoxB1.Size = newSize;
            picBoxB2.Size = newSize;
            ClearImgBoxes();

            int width = picBoxA1.Width;

            picBoxA1.Image = i[rng.Next(i.Length)];
            picBoxA2.Image = i[rng.Next(i.Length)];
            picBoxB1.Image = i[rng.Next(i.Length)];
            picBoxB2.Image = i[rng.Next(i.Length)];

            int posXA1 = backGround1.Width - (int)(width * 3.5);
            picBoxA1.Location = new Point(posXA1, (screenHeight - picBoxA1.Height) / 2);
            int posXA2 = backGround1.Width - (int)(width * 1.5);
            picBoxA2.Location = new Point(posXA2, (screenHeight - picBoxA1.Height) / 2);

            int posXB1 = (int)(width * 0.5);
            picBoxB1.Location = new Point(posXB1, (screenHeight - picBoxB1.Height) / 2);
            int posXB2 = (int)(width * 2.5);
            picBoxB2.Location = new Point(posXB2, (screenHeight - picBoxB1.Height) / 2);

            lblValue.Text = "50/20";
            SetMarker((int)(alteredSize * 0.25));

        }
        private void SetUp2040(Image[] i)
        {
            curLine = 4;
            curPos = 0;

            int midIndex = rng.Next(i.Length);
            Size newSize = new Size((int)(alteredSize * 0.20), (int)(alteredSize * 0.20));

            picBoxA1.Size = newSize;
            picBoxA2.Size = newSize;
            picBoxA3.Size = newSize;
            picBoxB1.Size = newSize;
            picBoxB2.Size = newSize;
            picBoxB3.Size = newSize;
            ClearImgBoxes();

            int width = picBoxA1.Width;

            picBoxA1.Image = i[rng.Next(i.Length)];
            picBoxA2.Image = i[rng.Next(i.Length)];
            picBoxA3.Image = i[midIndex];
            picBoxB1.Image = i[rng.Next(i.Length)];
            picBoxB2.Image = i[rng.Next(i.Length)];
            picBoxB3.Image = i[midIndex];

            int posXA1 = backGround1.Width - (int)(width * 4.5);
            picBoxA1.Location = new Point(posXA1, (screenHeight - picBoxB1.Height) / 2);
            int posXA2 = backGround1.Width - (int)(width * 2.5);
            picBoxA2.Location = new Point(posXA2, (screenHeight - picBoxB1.Height) / 2);
            int posXA3 = backGround1.Width - (int)(width * 0.5);
            picBoxA3.Location = new Point(posXA3, (screenHeight - picBoxB1.Height) / 2);

            int posXB1 = (int)(width * 1.5);
            picBoxB1.Location = new Point(posXB1, (screenHeight - picBoxB1.Height) / 2);
            int posXB2 = (int)(width * 3.5);
            picBoxB2.Location = new Point(posXB2, (screenHeight - picBoxB1.Height) / 2);
            int posXB3 = -(int)(width * 0.5);
            picBoxB3.Location = new Point(posXB3, (screenHeight - picBoxB1.Height) / 2);

            lblValue.Text = "40/20";
            SetMarker((int)(alteredSize * 0.20));

        }
        private void SetUp2030(Image[] i)
        {
            curLine = 5;
            curPos = 0;

            Size newSize = new Size((int)(alteredSize * 0.15), (int)(alteredSize * 0.15));

            picBoxA1.Size = newSize;
            picBoxA2.Size = newSize;
            picBoxA3.Size = newSize;
            picBoxB1.Size = newSize;
            picBoxB2.Size = newSize;
            picBoxB3.Size = newSize;
            ClearImgBoxes();

            int width = picBoxA1.Width;

            picBoxA1.Image = i[rng.Next(i.Length)];
            picBoxA2.Image = i[rng.Next(i.Length)];
            picBoxA3.Image = i[rng.Next(i.Length)];
            picBoxB1.Image = i[rng.Next(i.Length)];
            picBoxB2.Image = i[rng.Next(i.Length)];
            picBoxB3.Image = i[rng.Next(i.Length)];

            int posXA1 = backGround1.Width - (int)(width * 5.5);
            picBoxA1.Location = new Point(posXA1, (screenHeight - picBoxA1.Height) / 2);
            int posXA2 = backGround1.Width - (int)(width * 3.5);
            picBoxA2.Location = new Point(posXA2, (screenHeight - picBoxA1.Height) / 2);
            int posXA3 = backGround1.Width - (int)(width * 1.5);
            picBoxA3.Location = new Point(posXA3, (screenHeight - picBoxA1.Height) / 2);

            int posXB1 = (int)(width * 0.5);
            picBoxB1.Location = new Point(posXB1, (screenHeight - picBoxB1.Height) / 2);
            int posXB2 = (int)(width * 2.5);
            picBoxB2.Location = new Point(posXB2, (screenHeight - picBoxB1.Height) / 2);
            int posXB3 = (int)(width * 4.5);
            picBoxB3.Location = new Point(posXB3, (screenHeight - picBoxB1.Height) / 2);

            lblValue.Text = "30/20";
            SetMarker((int)(alteredSize * 0.15));
        }
        private void SetUp2025(Image[] i)
        {
            curLine = 6;
            curPos = 0;

            int midIndex = rng.Next(i.Length);
            Size newSize = new Size((int)(alteredSize * 0.125), (int)(alteredSize * 0.125));

            picBoxA1.Size = newSize;
            picBoxA2.Size = newSize;
            picBoxA3.Size = newSize;
            picBoxA4.Size = newSize;
            picBoxB1.Size = newSize;
            picBoxB2.Size = newSize;
            picBoxB3.Size = newSize;
            picBoxB4.Size = newSize;
            ClearImgBoxes();

            int width = picBoxA1.Width;

            picBoxA1.Image = i[rng.Next(i.Length)];
            picBoxA2.Image = i[rng.Next(i.Length)];
            picBoxA3.Image = i[rng.Next(i.Length)];
            picBoxA4.Image = i[midIndex];
            picBoxB1.Image = i[rng.Next(i.Length)];
            picBoxB2.Image = i[rng.Next(i.Length)];
            picBoxB3.Image = i[rng.Next(i.Length)];
            picBoxB4.Image = i[midIndex];

            int posXA1 = backGround1.Width - (int)(width * 6.5);
            picBoxA1.Location = new Point(posXA1, (screenHeight - picBoxB1.Height) / 2);
            int posXA2 = backGround1.Width - (int)(width * 4.5);
            picBoxA2.Location = new Point(posXA2, (screenHeight - picBoxB1.Height) / 2);
            int posXA3 = backGround1.Width - (int)(width * 2.5);
            picBoxA3.Location = new Point(posXA3, (screenHeight - picBoxB1.Height) / 2);
            int posXA4 = backGround1.Width - (int)(width * 0.5);
            picBoxA4.Location = new Point(posXA4, (screenHeight - picBoxB1.Height) / 2);

            int posXB1 = (int)(width * 1.5);
            picBoxB1.Location = new Point(posXB1, (screenHeight - picBoxB1.Height) / 2);
            int posXB2 = (int)(width * 3.5);
            picBoxB2.Location = new Point(posXB2, (screenHeight - picBoxB1.Height) / 2);
            int posXB3 = (int)(width * 5.5);
            picBoxB3.Location = new Point(posXB3, (screenHeight - picBoxB1.Height) / 2);
            int posXB4 = -(int)(width * 0.5);
            picBoxB4.Location = new Point(posXB4, (screenHeight - picBoxB1.Height) / 2);

            lblValue.Text = "25/20";
            SetMarker((int)(alteredSize * 0.125));
        }
        private void SetUp2020(Image[] i)
        {
            curLine = 7;
            curPos = 0;

            Size newSize = new Size((int)(alteredSize * 0.1), (int)(alteredSize * 0.1));

            picBoxA1.Size = newSize;
            picBoxA2.Size = newSize;
            picBoxA3.Size = newSize;
            picBoxA4.Size = newSize;
            picBoxB1.Size = newSize;
            picBoxB2.Size = newSize;
            picBoxB3.Size = newSize;
            picBoxB4.Size = newSize;
            ClearImgBoxes();

            int width = picBoxA1.Width;

            picBoxA1.Image = i[rng.Next(i.Length)];
            picBoxA2.Image = i[rng.Next(i.Length)];
            picBoxA3.Image = i[rng.Next(i.Length)];
            picBoxA4.Image = i[rng.Next(i.Length)];
            picBoxB1.Image = i[rng.Next(i.Length)];
            picBoxB2.Image = i[rng.Next(i.Length)];
            picBoxB3.Image = i[rng.Next(i.Length)];
            picBoxB4.Image = i[rng.Next(i.Length)];

            int posXA1 = backGround1.Width - (int)(width * 7.5);
            picBoxA1.Location = new Point(posXA1, (screenHeight - picBoxB1.Height) / 2);
            int posXA2 = backGround1.Width - (int)(width * 5.5);
            picBoxA2.Location = new Point(posXA2, (screenHeight - picBoxB1.Height) / 2);
            int posXA3 = backGround1.Width - (int)(width * 3.5);
            picBoxA3.Location = new Point(posXA3, (screenHeight - picBoxB1.Height) / 2);
            int posXA4 = backGround1.Width - (int)(width * 1.5);
            picBoxA4.Location = new Point(posXA4, (screenHeight - picBoxB1.Height) / 2);

            int posXB1 = (int)(width * 0.5);
            picBoxB1.Location = new Point(posXB1, (screenHeight - picBoxB1.Height) / 2);
            int posXB2 = (int)(width * 2.5);
            picBoxB2.Location = new Point(posXB2, (screenHeight - picBoxB1.Height) / 2);
            int posXB3 = (int)(width * 4.5);
            picBoxB3.Location = new Point(posXB3, (screenHeight - picBoxB1.Height) / 2);
            int posXB4 = (int)(width * 6.5);
            picBoxB4.Location = new Point(posXB4, (screenHeight - picBoxB1.Height) / 2);

            lblValue.Text = "20/20";
            SetMarker((int)(alteredSize * 0.1));
        }

        private void ClearImgBoxes()
        {
            picBoxA1.Image = null;
            picBoxA2.Image = null;
            picBoxA3.Image = null;
            picBoxA4.Image = null;

            picBoxB1.Image = null;
            picBoxB2.Image = null;
            picBoxB3.Image = null;
            picBoxB4.Image = null;
        }

        private void SetMarker (int wid)
        {
            picBoxMarker1.Size = new Size(wid, (int) wid / 2);
            picBoxMarker2.Size = new Size(wid, (int) wid / 2);

            picBoxMarker1.Location = picBoxA1.Location;
            picBoxMarker1.Top -= 20 + picBoxMarker1.Height;
            picBoxMarker2.Location = picBoxMarker1.Location;
            picBoxMarker2.Left -= backGround2.Width;

            
            
        }
        private void MoveMarker()
        {
            picBoxMarker1.Left += picBoxA1.Width * 2;
            picBoxMarker2.Left += picBoxA1.Width * 2;
        }
        private void MoveBack()
        {
            if (curPos == 0)
            {
                if (curLine == 0)
                    return;
                else
                {
                    curLine--;
                    picBoxA1.Location = new Point(-1000, -1000);
                    picBoxA2.Location = picBoxA1.Location;
                    picBoxA3.Location = picBoxA1.Location;
                    picBoxA4.Location = picBoxA1.Location;

                    picBoxB1.Location = picBoxA1.Location;
                    picBoxB2.Location = picBoxA1.Location;
                    picBoxB3.Location = picBoxA1.Location;
                    picBoxB4.Location = picBoxA1.Location;
                    switch (curLine)
                    {
                        case 0:
                            SetUp20200(images);
                            break;
                        case 1:
                            SetUp20100(images);
                            break;
                        case 2:
                            SetUp2070(images);
                            break;
                        case 3:
                            SetUp2050(images);
                            break;
                        case 4:
                            SetUp2040(images);
                            break;
                        case 5:
                            SetUp2030(images);
                            break;
                        case 6:
                            SetUp2025(images);
                            break;
                        case 7:
                            SetUp2020(images);
                            break;
                    }
                }
            }
            else
            {
                curPos--;
                picBoxMarker1.Left -= picBoxA1.Width * 2;
                picBoxMarker2.Left -= picBoxA1.Width * 2;
            }
        }

        private void PrepControlLabels()
        {
            int lblHeight = lblControlesF1.Height;
            int spacing = 20;

            lblControlesF1.Anchor = (AnchorStyles.Top | AnchorStyles.Left);
            lblControlesF1.Parent = backGround1;
            lblControlesF1.BackColor = Color.Transparent;
            lblControlesF1.Location = new Point(20, screenHeight - lblHeight - 20);
            lblControlesF1.Visible = true;
            lblControlesF1.Text = "H: Controles";

            lblControlesA.Anchor = (AnchorStyles.Top | AnchorStyles.Left);
            lblControlesA.Parent = backGround1;
            lblControlesA.BackColor = Color.Transparent;
            lblControlesA.Location = new Point(20, screenHeight - lblHeight * 2 - spacing * 2);
            lblControlesA.Visible = false;

            lblControlesF.Anchor = (AnchorStyles.Top | AnchorStyles.Left);
            lblControlesF.Parent = backGround1;
            lblControlesF.BackColor = Color.Transparent;
            lblControlesF.Location = new Point(20, screenHeight - lblHeight * 3 - spacing * 3);
            lblControlesF.Visible = false;

            lblControlesJ.Anchor = (AnchorStyles.Top | AnchorStyles.Left);
            lblControlesJ.Parent = backGround1;
            lblControlesJ.BackColor = Color.Transparent;
            lblControlesJ.Location = new Point(20, screenHeight - lblHeight * 4 - spacing * 4);
            lblControlesJ.Visible = false;

            lblControlesR.Anchor = (AnchorStyles.Top | AnchorStyles.Left);
            lblControlesR.Parent = backGround1;
            lblControlesR.BackColor = Color.Transparent;
            lblControlesR.Location = new Point(20, screenHeight - lblHeight * 5 - spacing * 5);
            lblControlesR.Visible = false;

            lblControlesEsc.Anchor = (AnchorStyles.Top | AnchorStyles.Left);
            lblControlesEsc.Parent = backGround1;
            lblControlesEsc.BackColor = Color.Transparent;
            lblControlesEsc.Location = new Point(20, screenHeight - lblHeight * 6 - spacing * 6);
            lblControlesEsc.Visible = false;
        }

        private void ShowControls()
        {
            controls = true;
            lblControlesF1.Text = "H: Esconder controles";
            lblControlesA.Visible = true;
            lblControlesF.Visible = true;
            lblControlesR.Visible = true;
            lblControlesJ.Visible = true;
            lblControlesEsc.Visible = true;
        }
        private void HideControls()
        {
            controls = false;
            lblControlesF1.Text = "H: Controles";
            lblControlesA.Visible = false;
            lblControlesF.Visible = false;
            lblControlesR.Visible = false;
            lblControlesJ.Visible = false;
            lblControlesEsc.Visible = false;
        }

        private void ReturnToSetUp()
        {
            runningTest = false;
            reset = false;
            abort = false;
            controls = false;
            HideControls();
            this.Hide();
            formAguSetup.Visible = true;
            formAguSetup.Focus();
        }

        private void ClearResultados()
        {
            if (resultados != null)
                resultados.Clear();
            else
                resultados = new List<int[]>();
        }
        private void PrepResultados()
        {
            for (int i = 1; i<=8; i++)
            {
                resultados.Add(new int[i]);
            }
        }

        private void PrepNextLine()
        {
            switch (curLine)
            {
                case 0:
                    SetUp20100(images);
                    break;
                case 1:
                    SetUp2070(images);
                    break;
                case 2:
                    SetUp2050(images);
                    break;
                case 3:
                    SetUp2040(images);
                    break;
                case 4:
                    SetUp2030(images);
                    break;
                case 5:
                    SetUp2025(images);
                    break;
                case 6:
                    SetUp2020(images);
                    break;
                case 7:
                    this.Hide();
                    formFinalizarTestSnellen.Visible = true;
                    formFinalizarTestSnellen.Focus();

                    formFinalizarTestSnellen.PrepararTest(idPaciente, resultados, alfabeto);

                    runningTest = false;
                    break;
            }
        }
        private void RetryLine()
        {
            switch (curLine)
            {
                case 0:
                    SetUp20200(images);
                    break;
                case 1:
                    SetUp20100(images);
                    break;
                case 2:
                    SetUp2070(images);
                    break;
                case 3:
                    SetUp2050(images);
                    break;
                case 4:
                    SetUp2040(images);
                    break;
                case 5:
                    SetUp2030(images);
                    break;
                case 6:
                    SetUp2025(images);
                    break;
                case 7:
                    SetUp2020(images);
                    break;
            }
        }
        private void CorrectHit()
        {
            resultados[curLine][curPos] = 1;
            if (curPos == curLine)
            {
                PrepNextLine();
            }
            else
            {
                MoveMarker();
                curPos++;
            }
        }
        private void WrongHit()
        {
            resultados[curLine][curPos] = 0;
            if (curPos == curLine)
            {
                PrepNextLine();
            }
            else
            {
                MoveMarker();
                curPos++;
            }
        }

        public void SetUpTest(Image[] img, Color color1, Color color2, int idp, string alfa, float escala)
        {
            images = img;

            backGround1.BackColor = color1;
            backGround2.BackColor = color2;
            alfabeto = alfa;
            idPaciente = idp;
            alteredSize = (int)(defaultSize * escala);

            runningTest = true;
            ClearResultados();
            PrepResultados();

            SetUp20200(images);
        }
        


        private void frmSnellen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (runningTest)
            {
                if (e.KeyChar == 'H' || e.KeyChar == 'h')
                {
                    if (controls)
                    {
                        HideControls();
                    }
                    else
                    {
                        ShowControls();
                    }
                    abort = false;
                    reset = false;
                    return;
                }

                if (e.KeyChar == 27)
                {
                    if (abort)
                    {
                        ReturnToSetUp();
                    }
                    else
                    {
                        abort = true;
                    }
                    reset = false;
                    return;
                }

                if(e.KeyChar == 'R' || e.KeyChar == 'r')
                {
                    if (reset)
                    {
                        RetryLine();
                        reset = false;
                    }    
                    else
                    {
                        reset = true;
                    }
                    abort = false;
                    return;   
                }

                reset = false;
                abort = false;
                switch (e.KeyChar)
                {
                    case 'A':
                    case 'a':
                        CorrectHit();
                        break;
                    case 'F':
                    case 'f':
                        WrongHit();
                        break;
                    case 'J':
                    case 'j':
                        MoveBack();
                        break;
                }
            }
        }
    }
}
