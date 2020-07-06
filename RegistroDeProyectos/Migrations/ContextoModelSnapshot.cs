﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RegistroDeProyectos.DAL;

namespace RegistroDeProyectos.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5");

            modelBuilder.Entity("RegistroDeProyectos.Entidades.Proyecto", b =>
                {
                    b.Property<int>("ProyectoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.HasKey("ProyectoId");

                    b.ToTable("Proyectos");
                });

            modelBuilder.Entity("RegistroDeProyectos.Entidades.ProyectoDetalle", b =>
                {
                    b.Property<int>("ProyectoDetalleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ProyectoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Requerimento")
                        .HasColumnType("TEXT");

                    b.Property<int>("TareaID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Tiempo")
                        .HasColumnType("INTEGER");

                    b.HasKey("ProyectoDetalleId");

                    b.HasIndex("ProyectoId");

                    b.ToTable("ProyectoDetalle");
                });

            modelBuilder.Entity("RegistroDeProyectos.Entidades.Tarea", b =>
                {
                    b.Property<int>("TareaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("TipoTarea")
                        .HasColumnType("TEXT");

                    b.HasKey("TareaId");

                    b.ToTable("Tarea");

                    b.HasData(
                        new
                        {
                            TareaId = 1,
                            TipoTarea = "Analisis"
                        });
                });

            modelBuilder.Entity("RegistroDeProyectos.Entidades.ProyectoDetalle", b =>
                {
                    b.HasOne("RegistroDeProyectos.Entidades.Proyecto", null)
                        .WithMany("Detalle")
                        .HasForeignKey("ProyectoId");
                });
#pragma warning restore 612, 618
        }
    }
}