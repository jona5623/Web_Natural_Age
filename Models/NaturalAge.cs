using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Natural_Age.Models
{
    public class NaturalAge : DbContext
    {

        public DbSet<Paciente> Paciente { get; set; }

        public DbSet<Especialista> Especialista { get; set; }

        public DbSet<Cita> Cita { get; set; }

        public DbSet<Tratamiento> Tratamiento { get; set; }

        public DbSet<Receta> Receta { get; set; }


    }
}