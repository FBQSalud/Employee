using FBQ.Salud_Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FBQ.Salud_AccessData.Commands
{
    public class FbqSaludDbContext : DbContext
    {
        public FbqSaludDbContext() { }

        public FbqSaludDbContext(DbContextOptions<FbqSaludDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=DbEmployeeApi;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
      
            modelBuilder.Entity<TipoEmpleado>().HasData
          (
              new TipoEmpleado
              {
                  Estado = true,
                  Descripcion = "Enfermera",
                  TipoEmpleadoId = 1,
                  
              }
          );

            modelBuilder.Entity<HorarioTrabajo>().HasData
        (
           new HorarioTrabajo
           {
               Estado = true,
               DiaSemana = "Lunes",
               Fecha = "24/10/22",
               HoraFin = "18:00",
               HoraInicio = "07:00",
               HorarioId = 1,
           },
           new HorarioTrabajo
           {
               Estado = true,
               DiaSemana = "Lunes",
               Fecha = "24/10/22",
               HoraFin = "07:00",
               HoraInicio = "18:00",
               HorarioId = 2,
           },
           new HorarioTrabajo
           {
               Estado = true,
               DiaSemana = "Martes",
               Fecha = "25/10/22",
               HoraFin = "18:00",
               HoraInicio = "07:00",
               HorarioId =3,
           }
        );
            modelBuilder.Entity<Empleado>().HasData(
                   new Empleado{
                        Nombre = "Mauricio",
                        Apellido = "Mcree",
                         Clave = "42205969Messi",
                         DNI = "201412521",
                         EmpleadoId = 1,
                         Estado = true,
                          Foto = "foto.jpg",
                         HorarioId = 1,
                         TipoEmpleadoId=1,     
                         Usuario = "alamenda204",
                   },
                   new Empleado
                   {
                       Nombre = "Alejandro",
                       Apellido = "Magno",
                       Clave = "42205969Messi",
                       DNI = "201412522",
                       EmpleadoId = 2,
                       Estado = true,
                       Foto = "foto.jpg",
                       HorarioId = 2,
                       TipoEmpleadoId = 1,
                       Usuario = "alamenda209",

                   },
                   new Empleado
                   {
                       Nombre = "Calamardo",
                       Apellido = "Tentaculos",
                       Clave = "42205969Messi",
                       DNI = "201412526",
                       EmpleadoId = 3,
                       Estado = true,
                       Foto = "foto.jpg",
                       HorarioId = 3,
                       TipoEmpleadoId = 1,
                       Usuario = "Calamenda609",

                   }
                   );
            modelBuilder.Entity<Habitacion>().HasData(
 new Habitacion
 {
     HabitacionId = 1,
     PacienteId = 1,
     EnfermeraId = 1,
     Estado = true,
     Piso = 1,
     Numero = 204,
     Fecha = DateTime.Now
 },
new Habitacion
{
HabitacionId = 2,
PacienteId = 2,
EnfermeraId = 1,
Estado = true,
Piso = 1,
Numero = 205,
Fecha = DateTime.Now
},
new Habitacion
{
HabitacionId = 3,
PacienteId = 3,
EnfermeraId = 1,
Estado = true,
Piso = 1,
Numero = 206,
Fecha = DateTime.Now,

},
new Habitacion
{
HabitacionId = 4,
PacienteId = 4,
EnfermeraId = 1,
Estado = true,
Piso = 1,
Numero = 207,
Fecha = DateTime.Now
},
new Habitacion
{
HabitacionId = 5,
PacienteId = 5,
EnfermeraId = 2,
Estado = true,
Piso = 1,
Numero = 208,
Fecha = DateTime.Now
},
new Habitacion
{
HabitacionId = 6,
PacienteId = 6,
EnfermeraId = 2,
Estado = true,
Piso = 1,
Numero = 209,
Fecha = DateTime.Now
},
new Habitacion
{
 HabitacionId = 7,
 PacienteId = 7,
 EnfermeraId = 3,
 Estado = true,
 Piso = 1,
 Numero = 210,
 Fecha = DateTime.Now
},
new Habitacion
{
HabitacionId = 8,
PacienteId = 8,
EnfermeraId = 3,
Estado = true,
Piso = 1,
Numero = 211,
Fecha = DateTime.Now
});

            modelBuilder.Entity<Enfermera>().HasData
        (
            new Enfermera
            {
                Estado = true,
                EmpleadoId = 1,
                EnfermeraId = 1,
                HorarioId = 1,
                TipoEnfermera ="MultiFuncion"

            },
              new Enfermera
              {
                  Estado = true,
                  EmpleadoId = 2,
                  EnfermeraId = 2,
                  HorarioId = 2,
                  TipoEnfermera = "Limpiador"

              },
                new Enfermera
                {
                    Estado = true,
                    EmpleadoId = 3,
                    EnfermeraId = 3,
                    HorarioId = 3,
                    TipoEnfermera = "MultiFuncion"
                    

                }
        );



        }

        public virtual DbSet<Medico> Medicos { get; set;  }
        public virtual DbSet<Enfermera> Enfermeras { get; set; }
        public virtual DbSet<Empleado> Empleados { get; set; }
        public virtual DbSet<TipoEmpleado> TipoEmpleados { get; set; }  
        public virtual DbSet<HorarioTrabajo> HorariosTrabajo { get; set; }
        public virtual DbSet<Especialidad> Especialidades { get; set; }
        public virtual DbSet<Habitacion> Habitaciones { get; set; }

        
    }
   
}
