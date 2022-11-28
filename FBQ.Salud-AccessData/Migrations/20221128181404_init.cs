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
                name: "Especialidades",
                columns: table => new
                {
                    EspecilalidadId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialidades", x => x.EspecilalidadId);
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
                    table.ForeignKey(
                        name: "FK_Empleados_HorariosTrabajo_HorarioId",
                        column: x => x.HorarioId,
                        principalTable: "HorariosTrabajo",
                        principalColumn: "HorarioId",
                        onDelete: ReferentialAction.Cascade);
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
                    table.ForeignKey(
                        name: "FK_Enfermeras_Empleados_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalTable: "Empleados",
                        principalColumn: "EmpleadoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Medicos",
                columns: table => new
                {
                    MedicoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpleadoId = table.Column<int>(type: "int", nullable: false),
                    EspecialidadId = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    HorarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicos", x => x.MedicoId);
                    table.ForeignKey(
                        name: "FK_Medicos_Empleados_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalTable: "Empleados",
                        principalColumn: "EmpleadoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Medicos_Especialidades_EspecialidadId",
                        column: x => x.EspecialidadId,
                        principalTable: "Especialidades",
                        principalColumn: "EspecilalidadId",
                        onDelete: ReferentialAction.Cascade);
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
                    table.ForeignKey(
                        name: "FK_Habitaciones_Enfermeras_EnfermeraId",
                        column: x => x.EnfermeraId,
                        principalTable: "Enfermeras",
                        principalColumn: "EnfermeraId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "HorariosTrabajo",
                columns: new[] { "HorarioId", "DiaSemana", "Estado", "Fecha", "HoraFin", "HoraInicio" },
                values: new object[,]
                {
                    { 1, "Lunes", true, "24/10/22", "18:00", "07:00" },
                    { 2, "Lunes", true, "24/10/22", "07:00", "18:00" },
                    { 3, "Martes", true, "25/10/22", "18:00", "07:00" }
                });

            migrationBuilder.InsertData(
                table: "TipoEmpleados",
                columns: new[] { "TipoEmpleadoId", "Descripcion", "Estado" },
                values: new object[] { 1, "Enfermera", true });

            migrationBuilder.InsertData(
                table: "Empleados",
                columns: new[] { "EmpleadoId", "Apellido", "Clave", "DNI", "Estado", "Foto", "HorarioId", "Nombre", "TipoEmpleadoId", "Usuario" },
                values: new object[] { 1, "Mcree", "42205969Messi", "201412521", true, "foto.jpg", 1, "Mauricio", 1, "alamenda204" });

            migrationBuilder.InsertData(
                table: "Empleados",
                columns: new[] { "EmpleadoId", "Apellido", "Clave", "DNI", "Estado", "Foto", "HorarioId", "Nombre", "TipoEmpleadoId", "Usuario" },
                values: new object[] { 2, "Magno", "42205969Messi", "201412522", true, "foto.jpg", 2, "Alejandro", 1, "alamenda209" });

            migrationBuilder.InsertData(
                table: "Empleados",
                columns: new[] { "EmpleadoId", "Apellido", "Clave", "DNI", "Estado", "Foto", "HorarioId", "Nombre", "TipoEmpleadoId", "Usuario" },
                values: new object[] { 3, "Tentaculos", "42205969Messi", "201412526", true, "foto.jpg", 3, "Calamardo", 1, "Calamenda609" });

            migrationBuilder.InsertData(
                table: "Enfermeras",
                columns: new[] { "EnfermeraId", "EmpleadoId", "Estado", "HorarioId", "TipoEnfermera" },
                values: new object[] { 1, 1, true, 1, "MultiFuncion" });

            migrationBuilder.InsertData(
                table: "Enfermeras",
                columns: new[] { "EnfermeraId", "EmpleadoId", "Estado", "HorarioId", "TipoEnfermera" },
                values: new object[] { 2, 2, true, 2, "Limpiador" });

            migrationBuilder.InsertData(
                table: "Enfermeras",
                columns: new[] { "EnfermeraId", "EmpleadoId", "Estado", "HorarioId", "TipoEnfermera" },
                values: new object[] { 3, 3, true, 3, "MultiFuncion" });

            migrationBuilder.InsertData(
                table: "Habitaciones",
                columns: new[] { "HabitacionId", "EnfermeraId", "Estado", "Fecha", "Numero", "PacienteId", "Piso" },
                values: new object[,]
                {
                    { 1, 1, true, new DateTime(2022, 11, 28, 15, 14, 4, 347, DateTimeKind.Local).AddTicks(5469), 204, 1, 1 },
                    { 2, 1, true, new DateTime(2022, 11, 28, 15, 14, 4, 347, DateTimeKind.Local).AddTicks(5525), 205, 2, 1 },
                    { 3, 1, true, new DateTime(2022, 11, 28, 15, 14, 4, 347, DateTimeKind.Local).AddTicks(5527), 206, 3, 1 },
                    { 4, 1, true, new DateTime(2022, 11, 28, 15, 14, 4, 347, DateTimeKind.Local).AddTicks(5528), 207, 4, 1 },
                    { 5, 2, true, new DateTime(2022, 11, 28, 15, 14, 4, 347, DateTimeKind.Local).AddTicks(5529), 208, 5, 1 },
                    { 6, 2, true, new DateTime(2022, 11, 28, 15, 14, 4, 347, DateTimeKind.Local).AddTicks(5530), 209, 6, 1 },
                    { 7, 3, true, new DateTime(2022, 11, 28, 15, 14, 4, 347, DateTimeKind.Local).AddTicks(5531), 210, 7, 1 },
                    { 8, 3, true, new DateTime(2022, 11, 28, 15, 14, 4, 347, DateTimeKind.Local).AddTicks(5532), 211, 8, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_HorarioId",
                table: "Empleados",
                column: "HorarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Enfermeras_EmpleadoId",
                table: "Enfermeras",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Habitaciones_EnfermeraId",
                table: "Habitaciones",
                column: "EnfermeraId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicos_EmpleadoId",
                table: "Medicos",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicos_EspecialidadId",
                table: "Medicos",
                column: "EspecialidadId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Habitaciones");

            migrationBuilder.DropTable(
                name: "Medicos");

            migrationBuilder.DropTable(
                name: "TipoEmpleados");

            migrationBuilder.DropTable(
                name: "Enfermeras");

            migrationBuilder.DropTable(
                name: "Especialidades");

            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropTable(
                name: "HorariosTrabajo");
        }
    }
}
