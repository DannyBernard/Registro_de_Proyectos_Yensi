using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RegistroDeProyectos.Migrations
{
    public partial class MigracionInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Proyectos",
                columns: table => new
                {
                    ProyectoId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(nullable: true),
                    Fecha = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proyectos", x => x.ProyectoId);
                });

            migrationBuilder.CreateTable(
                name: "Tarea",
                columns: table => new
                {
                    TareaId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TipoTarea = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarea", x => x.TareaId);
                });

            migrationBuilder.CreateTable(
                name: "ProyectoDetalle",
                columns: table => new
                {
                    ProyectoDetalleId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Requerimento = table.Column<string>(nullable: true),
                    Tiempo = table.Column<int>(nullable: false),
                    TareaID = table.Column<int>(nullable: false),
                    ProyectoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProyectoDetalle", x => x.ProyectoDetalleId);
                    table.ForeignKey(
                        name: "FK_ProyectoDetalle_Proyectos_ProyectoId",
                        column: x => x.ProyectoId,
                        principalTable: "Proyectos",
                        principalColumn: "ProyectoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaId", "TipoTarea" },
                values: new object[] { 1, "Analisis" });

            migrationBuilder.CreateIndex(
                name: "IX_ProyectoDetalle_ProyectoId",
                table: "ProyectoDetalle",
                column: "ProyectoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProyectoDetalle");

            migrationBuilder.DropTable(
                name: "Tarea");

            migrationBuilder.DropTable(
                name: "Proyectos");
        }
    }
}
