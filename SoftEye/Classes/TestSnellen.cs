using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftEye.Classes
{
    class TestSnellen
    {
        public virtual int id{ get; set; }
        public virtual int idPaciente { get; set; }
        public virtual string fecha { get; set; }
        public virtual string resultados { get; set; }
        public virtual string alfabeto { get; set; }
        public virtual string nota { get; set; }
        public virtual bool activo { get; set; }
        public virtual int[] resDeserializados { get; set; }
        public virtual string mejorRes { get; set; }



        public TestSnellen()
        {

        }

        public TestSnellen(int idP, string fe, int[] res, string alfa)
        {
            idPaciente = idP;
            fecha = fe;
            resultados = SerializeResults(res);
            nota = "";
            activo = true;
            alfabeto = alfa;
        }

        public virtual string SerializeResults(int[] res)
        {
            string ser = "";
            for (int i = 0; i < res.Length; i++)
            {
                ser += res[i].ToString();
            }
            return ser;
        }

        public virtual void DeserializeResults()
        {
            int[] res = new int[8];
            for (int i = 0; i < 8; i++)
            {
                res[i] = resultados[i] - '0';
            }
            mejorRes = FindBestResult(res);
            resDeserializados = res;
        }

        public virtual string FindBestResult(int[] arr)
        {
            string bRes = "";
            int bResIndex = -1;
            int[] bestResults = new int[8] {1,2,3,4,5,6,7,8} ;
            for(int i=0; i < 8; i++)
            {
                if (arr[i] != bestResults[i])
                {
                    bResIndex = i - 1;
                    break;
                }
            }
            if (arr[7] == bestResults[7] && arr[0] == bestResults[0] && bResIndex == -1)
            {
                bResIndex = 7;
            }

            switch (bResIndex)
            {
                case 0:
                    bRes = "20/200";
                    break;
                case 1:
                    bRes = "20/100";
                    break;
                case 2:
                    bRes = "20/70";
                    break;
                case 3:
                    bRes = "20/50";
                    break;
                case 4:
                    bRes = "20/40";
                    break;
                case 5:
                    bRes = "20/30";
                    break;
                case 6:
                    bRes = "20/25";
                    break;
                case 7:
                    bRes = "20/20";
                    break;
                default:
                    bRes = "Sin Resultado";
                    break;
            }

            return bRes;
        }

    }
}
