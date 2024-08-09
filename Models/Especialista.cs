using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Natural_Age.Models
{
    public class Especialista
    {

        public int EspecialistaID { get; set; }

        public string Nombre_Especialista { get; set; }

        public string Apellido_Especialista { get; set; }

        public string Cedula { get; set; }

        public string Telefono { get; set; }

        public string Especialidad { get; set; }

        public virtual ICollection<Cita> Cita { get; set; }


    }
}