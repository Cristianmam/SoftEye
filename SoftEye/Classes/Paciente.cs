using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftEye.Classes
{
    public class Paciente
    {
        public virtual int id { get; set; }
        public virtual string nombre { get; set; }
        public virtual string apellido { get; set; }
        public virtual string fdn { get; set; }
        public virtual string dni { get; set; }
        public virtual int? localidad { get; set; }
        public virtual int edad { get; set; }
        public virtual string domicilio { get; set; }
        public virtual string email { get; set; }
        public virtual string hClinica { get; set; }
        public virtual string telefono { get; set; }
        public virtual bool activo { get; set; }
        





        public Paciente()
        {

        }
        public Paciente(string nom, string ape, string fecha, string doc, string tel, string dom, string mail, string hc, int? loc)
        {
            nombre = nom;
            apellido = ape;
            fdn = fecha;
            dni = doc;
            telefono = tel;
            domicilio = dom;
            email = mail;
            hClinica = hc;
            localidad = loc;
            activo = true;
        }
        public virtual void CalcEdad()
        {
            if (String.IsNullOrEmpty(fdn))
            {
                edad = 0;
                return;
            }

            DateTime fechadn = Convert.ToDateTime(fdn);
            edad = (int)Math.Truncate((DateTime.Now - fechadn).TotalDays / 365);
        }
    }
}
