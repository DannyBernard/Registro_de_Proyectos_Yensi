﻿using Microsoft.EntityFrameworkCore;
using RegistroDeProyectos.DAL;
using RegistroDeProyectos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace RegistroDeProyectos.BLL
{
	public class ProyectoBLL
	{
        public static bool Guardar(Proyecto proyecto)
        {
            if (!Existe(proyecto.ProyectoId))
                return Insertar(proyecto);
            else
                return Modificar(proyecto);
        }

      
        private static bool Insertar(Proyecto proyecto)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
               
                contexto.Proyectos.Add(proyecto);
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


        private static bool Modificar(Proyecto proyecto)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
   
                contexto.Database.ExecuteSqlRaw($"Delete FROM TareasDetalle Where TareaId={proyecto.ProyectoId}");

                foreach (var item in proyecto.Detalle)
                {
                    contexto.Entry(item).State = EntityState.Added;
                }

               
                contexto.Entry(proyecto).State = EntityState.Modified;
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
              
                var tarea = ProyectoBLL.Buscar(id);

                if (tarea != null)
                {
                    contexto.Proyectos.Remove(tarea); 
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

        public static Proyecto Buscar(int id)
        {
            Proyecto proyecto = new Proyecto();
            Contexto contexto = new Contexto();

            try
            {
                proyecto = contexto.Proyectos.Include(x => x.Detalle)
                    .Where(x => x.ProyectoId == id)
                    .SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return proyecto;
        }

        public static List<Proyecto> GetList(Expression<Func<Proyecto, bool>> criterio)
        {
            List<Proyecto> Lista = new List<Proyecto>();
            Contexto contexto = new Contexto();

            try
            {
               
                Lista = contexto.Proyectos.Where(criterio).ToList();
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
                encontrado = contexto.Proyectos.Any(e => e.ProyectoId == id);
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
