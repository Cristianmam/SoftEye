using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SoftEye.Classes;


namespace SoftEye.Forms
{
    public partial class frmPerimetria : Form
    {
        public frmPeriSetup formPeriSetup;
        frmFinalizarTestPerimetria formFinalizarTestPerimetria;
        NHibernateHelper nHHelper;

        List<PictureBox> picBoxesL;
        List<PictureBox> picBoxesLS;
        Queue<PictureBox> picBoxesQ;
        bool[] cuadrantesArr;
        int idPaciente;
        int currentCuadrant;
        float[,] results;
        bool esperar;
        bool rotating;
        bool masCuadrantes;
        bool abort = false;

        bool runningTest = false;
        DateTime startTime;
        float[,] resultsCuadrante;
        int currentlyEvaluated;
        int increment = 1;
        int interval = 25;
        int screenWidth;
        int screenHeight;
        int innerRad;
        int midRad;
        int outerRad;

        public frmPerimetria()
        {
            InitializeComponent();
        }

        public frmPerimetria(frmPeriSetup fPS, NHibernateHelper nhh)
        {
            InitializeComponent();

            formPeriSetup = fPS;
            nHHelper = nhh;
        }


        private void frmPerimetria_Load(object sender, EventArgs e)
        {
            formFinalizarTestPerimetria = new frmFinalizarTestPerimetria(this, nHHelper);
            picBoxesQ = new Queue<PictureBox>();
            resultsCuadrante = new float[10,3];
            results = new float[8, 10];
            picBoxesL = FillList();
            picBoxesLS = FillList();
            screenHeight = Screen.PrimaryScreen.Bounds.Height;
            screenWidth = Screen.PrimaryScreen.Bounds.Width;

            innerRad = (int)((screenHeight - 60) / 3);
            midRad = (int)((screenHeight - 60) / 3) * 2;
            outerRad = (int)(screenHeight - 60);
        }

        public void TestThis(bool[] arr, int idp)
        {
            cuadrantesArr = arr;
            idPaciente = idp;
            currentCuadrant = 0;

            pibMarker1.BackColor = Color.Black;
            pibMarker2.BackColor = Color.Black;
            pibMarker3.BackColor = Color.Black;
            pibMarker4.BackColor = Color.Black;
            pibMarker5.BackColor = Color.Black;
            pibMarker6.BackColor = Color.Black;
            pibMarker7.BackColor = Color.Black;
            pibMarker8.BackColor = Color.Black;
            pibMarker9.BackColor = Color.Black;
            pibMarker10.BackColor = Color.Black;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    results[i, j] = -1;
                }
            }

            for (int i = 0; i < 8; i++)
            {
                if (cuadrantesArr[i])
                {
                    currentCuadrant = i;
                    CheckCuadrant(currentCuadrant);
                    break;
                }
            }
            StartTest();
        }

        private List<PictureBox> FillList()
        {
            List<PictureBox> l = new List<PictureBox>();
            l.Add(pibMarker1);
            l.Add(pibMarker2);
            l.Add(pibMarker3);
            l.Add(pibMarker4);
            l.Add(pibMarker5);
            l.Add(pibMarker6);
            l.Add(pibMarker7);
            l.Add(pibMarker8);
            l.Add(pibMarker9);
            l.Add(pibMarker10);
            return l;
        }

        private void CheckCuadrant(int q)
        {
            switch (q)
            {
                case 0:
                case 4:
                    PrepQ1();
                    break;
                case 1:
                case 5:
                    PrepQ2();
                    break;
                case 2:
                case 6:
                    PrepQ3();
                    break;
                case 3:
                case 7:
                    PrepQ4();
                    break;
            }
        }

        public void StartTest()
        {           
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    resultsCuadrante[i, j] = -1;
                }
            }

            for (int i = 0; i < 3; i++)
            {
                picBoxesLS.Shuffle();
                foreach (PictureBox pb in picBoxesLS)
                {
                    picBoxesQ.Enqueue(pb);
                }
            }

            esperar = true;
            bgw.RunWorkerAsync();
            bgwRotator.RunWorkerAsync();
        }

        public double DegreesToRadians(double n)
        {
            return n * Math.PI / 180;
        }

        private Image RotateImage(Image img, float rotationAngle)
        {
            //create an empty Bitmap image
            Bitmap bmp = new Bitmap(img.Width, img.Height);
            bmp.SetResolution(img.HorizontalResolution, img.VerticalResolution);

            //turn the Bitmap into a Graphics object
            Graphics gfx = Graphics.FromImage(bmp);

            //now we set the rotation point to the center of our image
            gfx.TranslateTransform((float)bmp.Width / 2, (float)bmp.Height / 2);

            //now rotate the image
            gfx.RotateTransform(rotationAngle);

            gfx.TranslateTransform(-(float)bmp.Width / 2, -(float)bmp.Height / 2);

            //set the InterpolationMode to HighQualityBicubic so to ensure a high
            //quality image once it is transformed to the specified size
            gfx.InterpolationMode = InterpolationMode.HighQualityBicubic;

            //now draw our new image onto the graphics object
            gfx.DrawImage(img, new Point(0, 0));

            //dispose of our Graphics object
            gfx.Dispose();

            //return the image
            return bmp;
        }

        private void PrepQ1()
        {
            int i = 0;
            int x, y;
            picBoxFocus.Location = new Point(20, screenHeight - 60);
            picBoxFocus.Visible = true;
            foreach (PictureBox pb in picBoxesL)
            {
                
                switch (i)
                {
                    case 0:
                    case 1:
                    case 2:
                        x = (int)(innerRad * Math.Cos(DegreesToRadians(45 * i)) + 40);
                        y = (int)(innerRad * Math.Sin(DegreesToRadians(45 * i)) + 40);
                        pb.Location = new Point(x, screenHeight - y);
                        break;
                    case 3:
                    case 4:
                    case 5:
                        x = (int)(midRad * Math.Cos(DegreesToRadians(45 * (i - 3))) + 40);
                        y = (int)(midRad * Math.Sin(DegreesToRadians(45 * (i - 3))) + 40);
                        pb.Location = new Point(x, screenHeight - y);
                        break;
                    case 6:
                    case 7:
                    case 8:
                    case 9:
                        x = (int)(outerRad * Math.Cos(DegreesToRadians(30 * (i - 6))) + 40);
                        y = (int)(outerRad * Math.Sin(DegreesToRadians(30 * (i - 6))) + 40);
                        pb.Location = new Point(x, screenHeight - y);
                        break;
                }
                i++;
            }
        }

        private void PrepQ2()
        {
            int i = 0;
            int x, y;
            picBoxFocus.Location = new Point(screenWidth - 60, screenHeight - 60);
            picBoxFocus.Visible = true;
            foreach (PictureBox pb in picBoxesL)
            {

                switch (i)
                {
                    case 0:
                    case 1:
                    case 2:
                        x = (int)(innerRad * Math.Cos(DegreesToRadians(45 * i)) + 40);
                        y = (int)(innerRad * Math.Sin(DegreesToRadians(45 * i)) + 40);
                        pb.Location = new Point(screenWidth - x, screenHeight - y);
                        break;
                    case 3:
                    case 4:
                    case 5:
                        x = (int)(midRad * Math.Cos(DegreesToRadians(45 * (i - 3))) + 40);
                        y = (int)(midRad * Math.Sin(DegreesToRadians(45 * (i - 3))) + 40);
                        pb.Location = new Point(screenWidth - x, screenHeight - y);
                        break;
                    case 6:
                    case 7:
                    case 8:
                    case 9:
                        x = (int)(outerRad * Math.Cos(DegreesToRadians(30 * (i - 6))) + 40);
                        y = (int)(outerRad * Math.Sin(DegreesToRadians(30 * (i - 6))) + 40);
                        pb.Location = new Point(screenWidth - x, screenHeight - y);
                        break;
                }
                i++;
            }
        }

        private void PrepQ3()
        {
            int i = 0;
            int x, y;
            picBoxFocus.Location = new Point(screenWidth - 60, 20);
            picBoxFocus.Visible = true;
            foreach (PictureBox pb in picBoxesL)
            {

                switch (i)
                {
                    case 0:
                    case 1:
                    case 2:
                        x = (int)(innerRad * Math.Cos(DegreesToRadians(45 * i)) + 40);
                        y = (int)(innerRad * Math.Sin(DegreesToRadians(45 * i)) + 40);
                        pb.Location = new Point(screenWidth - x, y);
                        break;
                    case 3:
                    case 4:
                    case 5:
                        x = (int)(midRad * Math.Cos(DegreesToRadians(45 * (i - 3))) + 40);
                        y = (int)(midRad * Math.Sin(DegreesToRadians(45 * (i - 3))) + 40);
                        pb.Location = new Point(screenWidth - x, y);
                        break;
                    case 6:
                    case 7:
                    case 8:
                    case 9:
                        x = (int)(outerRad * Math.Cos(DegreesToRadians(30 * (i - 6))) + 40);
                        y = (int)(outerRad * Math.Sin(DegreesToRadians(30 * (i - 6))) + 40);
                        pb.Location = new Point(screenWidth - x, y);
                        break;
                }
                i++;
            }
        }

        private void PrepQ4()
        {
            int i = 0;
            int x, y;
            picBoxFocus.Location = new Point(20, 20);
            picBoxFocus.Visible = true;
            foreach (PictureBox pb in picBoxesL)
            {

                switch (i)
                {
                    case 0:
                    case 1:
                    case 2:
                        x = (int)(innerRad * Math.Cos(DegreesToRadians(45 * i)) + 40);
                        y = (int)(innerRad * Math.Sin(DegreesToRadians(45 * i)) + 40);
                        pb.Location = new Point(x, y);
                        break;
                    case 3:
                    case 4:
                    case 5:
                        x = (int)(midRad * Math.Cos(DegreesToRadians(45 * (i - 3))) + 40);
                        y = (int)(midRad * Math.Sin(DegreesToRadians(45 * (i - 3))) + 40);
                        pb.Location = new Point(x, y);
                        break;
                    case 6:
                    case 7:
                    case 8:
                    case 9:
                        x = (int)(outerRad * Math.Cos(DegreesToRadians(30 * (i - 6))) + 40);
                        y = (int)(outerRad * Math.Sin(DegreesToRadians(30 * (i - 6))) + 40);
                        pb.Location = new Point(x, y);
                        break;
                }
                i++;
            }
        }

        private void FinalizarTest()
        {
            formFinalizarTestPerimetria.PrepararTest(idPaciente, results);
            this.Hide();
            formFinalizarTestPerimetria.Visible = true;
            formFinalizarTestPerimetria.Focus();
        }

        private void bgw_DoWork(object sender, DoWorkEventArgs e)
        {   
            runningTest = true;
            if (esperar)
            {
                System.Threading.Thread.Sleep(3000);
                esperar = false;
            }
            int opacity = 0;
            PictureBox pb = picBoxesQ.Dequeue();
            string name = pb.Name.Remove(0,9);
            currentlyEvaluated = int.Parse(name);
            startTime = DateTime.UtcNow;
            while (true)
            {
                if (bgw.CancellationPending)
                    break;
                
                if (opacity < 255)
                {
                    pb.BackColor = Color.FromArgb(opacity, opacity, opacity);
                    opacity += increment;
                    System.Threading.Thread.Sleep(interval);
                }
                if ((DateTime.UtcNow - startTime).TotalSeconds > 10)
                {
                    abort = false;
                    break;
                }
            }
        }

        private void bgwRotator_DoWork(object sender, DoWorkEventArgs e)
        {
            int angle = 0;
            int increment = 3;
            rotating = true;
            Image image = picBoxFocus.Image;
            while (true)
            {
                if (bgwRotator.CancellationPending)
                    break;

                angle += increment;
                picBoxFocus.Image = RotateImage(image, angle);
                System.Threading.Thread.Sleep(interval);
            }
        }

        private void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            runningTest = false;

            if (abort)
                return;

            picBoxesL[currentlyEvaluated-1].BackColor = Color.Black;
            for (int i = 0; i < 3; i++)
            {
                if(resultsCuadrante[currentlyEvaluated-1,i] == -1)
                {
                    resultsCuadrante[currentlyEvaluated-1, i] = (DateTime.UtcNow - startTime).Seconds;
                }
            }
            if (picBoxesQ.Any())
            {
                bgw.RunWorkerAsync();
            }
            else
            {
                bgwRotator.CancelAsync();
                masCuadrantes = false;

                float acum;
                for (int i = 0; i < 10; i++)
                {
                    acum = 0;
                    for (int j = 0; j < 3; j++)
                    {
                        acum += resultsCuadrante[i, j];
                    }
                    acum = acum / 3;
                    results[currentCuadrant, i] = acum;
                }
                if(currentCuadrant + 1 == cuadrantesArr.Length)
                {
                    FinalizarTest();
                }
                else
                {
                    currentCuadrant++;
                    for(int i = currentCuadrant; i < cuadrantesArr.Length; i++)
                    {
                        if (cuadrantesArr[i])
                        {
                            masCuadrantes = true;
                            currentCuadrant = i;
                            break;
                        }
                    }
                    if (!masCuadrantes)
                    {
                        FinalizarTest();
                    }
                }
            }
        }

        private void bgwRotator_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            rotating = false;
            picBoxFocus.Visible = false;
            if (abort)
                return;
            if (masCuadrantes)
            {
                CheckCuadrant(currentCuadrant);
                StartTest();
            }
            
        }

        private void ReturnToSetup()
        {
            bgw.CancelAsync();
            bgwRotator.CancelAsync();
            runningTest = false;
            abort = false;
            this.Hide();
            this.Close();
            formPeriSetup.Visible = true;
            formPeriSetup.Focus();
        }

        private void frmPerimetria_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 32 && runningTest == true)
            {
                abort = false;
                bgw.CancelAsync();
            }
            if(e.KeyChar == 27)
            {
                if (abort)
                {
                    ReturnToSetup();
                }
                else
                {
                    abort = true;
                }
            }
        }

        
    }
}
