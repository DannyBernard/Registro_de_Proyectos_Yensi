using Microsoft.EntityFrameworkCore;
using RegistroDeProyectos.DAL;
using RegistroDeProyectos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace RegistroDeProyectos.BLL
{
	class TareaBLL
	{
        public static bool Guardar(Tarea tarea)
        {
            if (!Existe(tarea.TareaId))
                return Insertar(tarea);
            else
                return Modificar(tarea);
        }

        
        private static bool Insertar(Tarea tarea)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
              
                contexto.Tarea.Add(tarea);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }


        private static bool Modificar(Tarea tarea)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                
                contexto.Entry(tarea).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

       
        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
               
                var adicionales = TareaBLL.Buscar(id);

                if (adicionales != null)
                {
                    contexto.Tarea.Remove(adicionales); 
                    paso = contexto.SaveChanges() > 0;
                }

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

   
        public static Tarea Buscar(int id)
        {
            Tarea adicionales = new Tarea();
            Contexto contexto = new Contexto();

            try
            {
                adicionales = contexto.Tarea.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return adicionales;
        }

       
        public static List<Tarea> GetList(Expression<Func<Tarea, bool>> criterio)
        {
            List<Tarea> Lista = new List<Tarea>();
            Contexto contexto = new Contexto();

            try
            {
              
                Lista = contexto.Tarea.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return Lista;
        }

      
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Tarea.Any(e => e.TareaId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return encontrado;
        }
    }
}
