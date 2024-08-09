using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Natural_Age.Models
{
    public class Paciente
    {

        public int PacienteID { get; set; }

        public string Nombre_Paciente { get; set; }

        public string Apellido_Paciente { get; set; }

        public string Cedula { get; set; }

        public string Telefono { get; set; }

        public string Ocupacion { get; set; }

        public string Direccion { get; set; }

        public virtual ICollection<Cita> Cita { get; set; }


    }
}