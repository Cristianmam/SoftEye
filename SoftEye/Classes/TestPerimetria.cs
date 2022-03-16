using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftEye.Classes
{
    public class TestPerimetria
    {
        public virtual int id { get; set; }
        public virtual int idPaciente { get; set; }
        public virtual string fecha { get; set; }
        public virtual string resIzquierdo { get; set; }
        public virtual string resDerecho { get; set; }
        public virtual string nota { get; set; }
        public virtual bool activo { get; set; }
        public virtual float[] numResIzq { get; set; }
        public virtual float[] numResDer { get; set; }

        public TestPerimetria()
        {

        }
        public TestPerimetria(int idp, float[,] res)
        {
            idPaciente = idp;
            fecha = DateTime.Today.ToString("d");
            activo = true;
            numResIzq = new float[40];
            numResDer = new float[40];
            int pos = 0;
            for (int i = 0; i < 4; i++)
            {
                for(int j = 0; j < 10; j++)
                {
                    numResIzq[pos] = res[i, j];
                    pos++;
                }
            }
            pos = 0;
            for (int i = 4; i < 8; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    numResDer[pos] = res[i, j];
                    pos++;
                }
            }
            SerializeResults();
        }

        public virtual void SerializeResults()
        {
            resIzquierdo = Math.Round(numResIzq[0], 2).ToString();
            for (int i = 1; i < 40; i++)
            {
                resIzquierdo += ";";
                resIzquierdo += resIzquierdo = Math.Round(numResIzq[i], 2).ToString();
            }
            resDerecho = Math.Round(numResDer[0], 2).ToString();
            for (int i = 1; i < 40; i++)
            {
                resDerecho += ";";
                resDerecho += Math.Round(numResDer[i], 2).ToString();
            }
        }
        public virtual void DeserializeResults()
        {
            int cur = -1;
            int next = 0;
            numResIzq = new float[40];
            numResDer = new float[40];

            if (resIzquierdo.Length == 0 || resDerecho.Length == 0)
                return;

            for(int i = 0; i < 40; i++)
            {
                for (int j = cur +1; j < resIzquierdo.Length; j++)
                {
                    if (resIzquierdo[j].Equals(';'))
                    {
                        next = j;
                        break;
                    }
                }
                if(i != 39)
                {
                    string ph = resIzquierdo.Substring(cur + 1, next - (cur + 1));
                    numResIzq[i] = float.Parse(ph);
                    cur = next;
                }
                else 
                {
                    string ph = resIzquierdo.Substring(cur + 1, resIzquierdo.Length - (cur + 1));
                    numResIzq[i] = float.Parse(ph);
                }
                
            }

            cur = -1;
            next = 0;
            for (int i = 0; i < 40; i++)
            {
                for (int j = cur + 1; j < resDerecho.Length; j++)
                {
                    if (resDerecho[j].Equals(';'))
                    {
                        next = j;
                        break;
                    }
                }
                if(i!= 39)
                {
                    string ph = resDerecho.Substring(cur + 1, next - (cur + 1));
                    numResDer[i] = float.Parse(ph);
                    cur = next;
                }
                else
                {
                    string ph = resDerecho.Substring(cur + 1, resDerecho.Length - (cur + 1));
                    numResDer[i] = float.Parse(ph);
                }
            }
        }
    }
}
