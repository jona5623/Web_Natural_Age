using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Natural_Age.Models
{
    public class Cita
    {

        public int CitaID { get; set; }

        public int PacienteID { get; set; }

        public int EspecialistaID { get; set; }

        public DateTime Fecha { get; set; }

        public virtual Paciente Paciente { get; set; }


        public virtual Especialista Especialista { get; set; }

       
        public virtual ICollection<Tratamiento> Tratamiento { get; set; }


    }
}