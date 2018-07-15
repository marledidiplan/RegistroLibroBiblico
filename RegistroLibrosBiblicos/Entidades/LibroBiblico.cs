using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace RegistroLibrosBiblicos.Entidades
{
    public class LibroBiblico
    {
        [Key]
        public int LibroId { get; set; }
        public DateTime Fecha { get; set; }
        public String Descripcion { get; set; }
        public string Tipo { get; set; }
        public string Siglas { get; set; }

        public LibroBiblico()
        {
            LibroId = 0;
            Fecha = DateTime.Now;
            Descripcion = string.Empty;
        }
    }
}
