using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Natural_Age.Models
{
    public class Tratamiento
    {

        public int TratamientoID  { get; set; }

        public int CitaID { get; set; }


        public string Tipo { get; set; }

        public string Descripcion { get; set; }

        public virtual Cita Cita { get; set; }

        public virtual ICollection<Receta> Receta { get; set; }

    }
}