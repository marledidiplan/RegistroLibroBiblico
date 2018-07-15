using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Data.Entity;
using RegistroLibrosBiblicos.Entidades;
using RegistroLibrosBiblicos.DAL;

namespace RegistroLibrosBiblicos.BLL
{
    public class LibroBiblicoBLL
    {
        public static bool Guardar(LibroBiblico libroB)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                if (contexto.librosBiblico.Add(libroB) != null)
                {
                    contexto.SaveChanges();
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }

        public static bool Modificar(LibroBiblico libroB)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                contexto.Entry(libroB).State = EntityState.Modified;
                if(contexto.SaveChanges() >0)
                {
                    paso = true;
                }
                contexto.Dispose();
            }
            catch(Exception)
            {
                throw;
            }
            return paso;
          
        }
        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                LibroBiblico libroB = contexto.librosBiblico.Find(id);
                contexto.librosBiblico.Remove(libroB);
                if (contexto.SaveChanges() > 0)
                {

                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }

        public static LibroBiblico Buscar(int id)
        {

            Contexto contexto = new Contexto();
            LibroBiblico libroB = new LibroBiblico();

            try
            {
                libroB = contexto.librosBiblico.Find(id);
                contexto.Dispose();

            }
            catch (Exception)
            {
                throw;
            }

            return libroB;


        }
        public static List<LibroBiblico> GetList(Expression<Func<LibroBiblico, bool>> expression)
        {
            List<LibroBiblico> libroB = new List<LibroBiblico>();
            Contexto contexto = new Contexto();

            try
            {
                libroB = contexto.librosBiblico.Where(expression).ToList();
                contexto.Dispose();
            }
            catch(Exception)
            {
                throw;
            }
            return libroB;
        }

    }
}
