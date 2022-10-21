using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FBQ.Salud_AccessData.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    EmpleadoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoEmpleadoId = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DNI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    Foto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Usuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Clave = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    HorarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.EmpleadoId);
                });

            migrationBuilder.CreateTable(
                name: "Enfermeras",
                columns: table => new
                {
                    EnfermeraId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpleadoId = table.Column<int>(type: "int", nullable: false),
                    TipoEnfermera = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    HorarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enfermeras", x => x.EnfermeraId);
                });

            migrationBuilder.CreateTable(
                name: "Especialidades",
                columns: table => new
                {
                    EspecilalidadId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialidades", x => x.EspecilalidadId);
                });

            migrationBuilder.CreateTable(
                name: "Habitaciones",
                columns: table => new
                {
                    HabitacionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    EnfermeraId = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    Piso = table.Column<int>(type: "int", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habitaciones", x => x.HabitacionId);
                });

            migrationBuilder.CreateTable(
                name: "HorariosTrabajo",
                columns: table => new
                {
                    HorarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoraInicio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HoraFin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fecha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiaSemana = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HorariosTrabajo", x => x.HorarioId);
                });

            migrationBuilder.CreateTable(
                name: "Medicos",
                columns: table => new
                {
                    MedicoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpeleadoId = table.Column<int>(type: "int", nullable: false),
                    EspecialidadId = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    HorarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicos", x => x.MedicoId);
                });

            migrationBuilder.CreateTable(
                name: "TipoEmpleados",
                columns: table => new
                {
                    TipoEmpleadoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoEmpleados", x => x.TipoEmpleadoId);
                });

            migrationBuilder.InsertData(
                table: "Habitaciones",
                columns: new[] { "HabitacionId", "EnfermeraId", "Estado", "Fecha", "Numero", "PacienteId", "Piso" },
                values: new object[,]
                {
                    { 1, 1, true, new DateTime(2022, 10, 19, 2, 9, 24, 864, DateTimeKind.Local).AddTicks(5747), 204, 1, 1 },
                    { 2, 1, true, new DateTime(2022, 10, 19, 2, 9, 24, 864, DateTimeKind.Local).AddTicks(5757), 205, 2, 1 },
                    { 3, 1, true, new DateTime(2022, 10, 19, 2, 9, 24, 864, DateTimeKind.Local).AddTicks(5759), 206, 3, 1 },
                    { 4, 1, true, new DateTime(2022, 10, 19, 2, 9, 24, 864, DateTimeKind.Local).AddTicks(5760), 207, 4, 1 },
                    { 5, 2, true, new DateTime(2022, 10, 19, 2, 9, 24, 864, DateTimeKind.Local).AddTicks(5761), 208, 5, 1 },
                    { 6, 2, true, new DateTime(2022, 10, 19, 2, 9, 24, 864, DateTimeKind.Local).AddTicks(5762), 209, 6, 1 },
                    { 7, 3, true, new DateTime(2022, 10, 19, 2, 9, 24, 864, DateTimeKind.Local).AddTicks(5763), 210, 7, 1 },
                    { 8, 3, true, new DateTime(2022, 10, 19, 2, 9, 24, 864, DateTimeKind.Local).AddTicks(5764), 211, 8, 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropTable(
                name: "Enfermeras");

            migrationBuilder.DropTable(
                name: "Especialidades");

            migrationBuilder.DropTable(
                name: "Habitaciones");

            migrationBuilder.DropTable(
                name: "HorariosTrabajo");

            migrationBuilder.DropTable(
                name: "Medicos");

            migrationBuilder.DropTable(
                name: "TipoEmpleados");
        }
    }
}
