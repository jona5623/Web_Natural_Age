using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Natural_Age.Models
{
    public class Receta
    {

        public int RecetaID { get; set; }

        public int TratamientoID { get; set; }

        public string descripcion { get; set; }

        public virtual Tratamiento Tratamiento { get; set; }


    }
}