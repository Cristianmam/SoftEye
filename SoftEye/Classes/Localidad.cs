using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftEye.Classes
{
    public class Localidad
    {
        public virtual int id { get; set; }
        public virtual string nombre { get; set; }
        public virtual bool activo { get; set; }

        public Localidad ()
        {

        }

        public Localidad (string nom)
        {
            nombre = nom;
            activo = true;
        }
    }
}
