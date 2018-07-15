using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using RegistroLibrosBiblicos.Entidades;

namespace RegistroLibrosBiblicos.DAL
{
   public class Contexto : DbContext
    {
        public DbSet<LibroBiblico> librosBiblico { get; set; }

        public Contexto() : base("ConStr")
        {
                    
        }
    }
}
