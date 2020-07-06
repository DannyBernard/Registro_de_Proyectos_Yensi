using Microsoft.EntityFrameworkCore;
using RegistroDeProyectos.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegistroDeProyectos.DAL
{
	public class Contexto : DbContext
	{
		public DbSet<Proyecto> Proyectos { get; set; }
		public DbSet<ProyectoDetalle> ProyectoDetalle { get; set; }
		public DbSet<Tarea> Tarea { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.EnableSensitiveDataLogging().UseSqlite(@"Data Source= DATA\SegundoParcialDB.db");
		}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			 modelBuilder.Entity<Tarea>().HasData(new Tarea
			{
				TareaId = 1,
				TipoTarea = "Analisis"
			});

        }
    }
}
