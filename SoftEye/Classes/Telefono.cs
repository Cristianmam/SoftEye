using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftEye.Classes
{
    public class Telefono
    {
        public virtual int id { get; set; }
        public virtual int idPaciente { get; set; }
        public virtual string numero { get; set; }
        public virtual bool activo { get; set; }

        public Telefono()
        {

        }

        public Telefono (int idP, String num)
        {
            idPaciente = idP;
            numero = num;
            activo = true;
        }
    }

    
}
