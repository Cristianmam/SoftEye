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

namespace SoftEye.Forms
{
    public partial class frmVisualizadorPerimetria : Form
    {
        List<Label> labelList;
        frmTestViewer formTV;

        public frmVisualizadorPerimetria(frmTestViewer ftv)
        {
            InitializeComponent();
            formTV = ftv;
            labelList = LoadList();
        }

        private void frmVisualizadorPerimetria_Load(object sender, EventArgs e)
        {
            
        }

        private List<Label> LoadList()
        {
            List<Label> l = new List<Label>();

            l.Add(lblPoint1);
            l.Add(lblPoint2);
            l.Add(lblPoint3);
            l.Add(lblPoint4);
            l.Add(lblPoint5);
            l.Add(lblPoint6);
            l.Add(lblPoint7);
            l.Add(lblPoint8);
            l.Add(lblPoint9);

            l.Add(lblPoint10);
            l.Add(lblPoint11);
            l.Add(lblPoint12);
            l.Add(lblPoint13);
            l.Add(lblPoint14);
            l.Add(lblPoint15);
            l.Add(lblPoint16);
            l.Add(lblPoint17);
            l.Add(lblPoint18);
            l.Add(lblPoint19);

            l.Add(lblPoint20);
            l.Add(lblPoint21);
            l.Add(lblPoint22);
            l.Add(lblPoint23);
            l.Add(lblPoint24);
            l.Add(lblPoint25);
            l.Add(lblPoint26);
            l.Add(lblPoint27);
            l.Add(lblPoint28);
            l.Add(lblPoint29);

            l.Add(lblPoint30);
            l.Add(lblPoint31);
            l.Add(lblPoint32);
            l.Add(lblPoint33);
            l.Add(lblPoint34);
            l.Add(lblPoint35);
            l.Add(lblPoint36);
            l.Add(lblPoint37);
            l.Add(lblPoint38);
            l.Add(lblPoint39);

            l.Add(lblPoint40);
            l.Add(lblPoint41);
            l.Add(lblPoint42);
            l.Add(lblPoint43);
            l.Add(lblPoint44);
            l.Add(lblPoint45);
            l.Add(lblPoint46);
            l.Add(lblPoint47);
            l.Add(lblPoint48);
            l.Add(lblPoint49);

            l.Add(lblPoint50);
            l.Add(lblPoint51);
            l.Add(lblPoint52);
            l.Add(lblPoint53);
            l.Add(lblPoint54);
            l.Add(lblPoint55);
            l.Add(lblPoint56);
            l.Add(lblPoint57);
            l.Add(lblPoint58);
            l.Add(lblPoint59);

            l.Add(lblPoint60);
            l.Add(lblPoint61);
            l.Add(lblPoint62);
            l.Add(lblPoint63);
            l.Add(lblPoint64);
            l.Add(lblPoint65);
            l.Add(lblPoint66);
            l.Add(lblPoint67);
            l.Add(lblPoint68);
            l.Add(lblPoint69);

            l.Add(lblPoint70);
            l.Add(lblPoint71);
            l.Add(lblPoint72);
            l.Add(lblPoint73);
            l.Add(lblPoint74);
            l.Add(lblPoint75);
            l.Add(lblPoint76);
            l.Add(lblPoint77);
            l.Add(lblPoint78);
            l.Add(lblPoint79);

            l.Add(lblPoint80);

            return l;
        }

        public void ShowResults(TestPerimetria test)
        {
            test.DeserializeResults();
            int cont = 0;
            foreach (Label l in labelList)
            {
                if(cont < 40)
                {
                    Console.WriteLine(test.numResIzq[cont]);
                    if (test.numResIzq[cont] >= 0)
                        l.Text = test.numResIzq[cont].ToString();
                    else
                        l.Text = "N/A";
                }
                else
                {
                    if (test.numResDer[cont - 40] >= 0)
                        l.Text = test.numResDer[cont-40].ToString();
                    else
                        l.Text = "N/A";
                }
                cont++;
            }
        }

        private void frmVisualizadorPerimetria_FormClosed(object sender, FormClosedEventArgs e)
        {
            formTV.Visible = true;
            formTV.Focus();
        }
    }
}
