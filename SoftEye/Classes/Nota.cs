using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftEye.Classes
{
    class Nota
    {
        public virtual int id { get; set; }
        public virtual int idPaciente { get; set; }
        public virtual string texto { get; set; }
        public virtual bool activo { get; set; }
        public virtual string fecha { get; set; }

        public Nota()
        {

        }

        public Nota(int idp, String txt, string fec)
        {
            idPaciente = idp;
            texto = txt;
            fecha = fec;
            activo = true;
        }
    }

    

}
