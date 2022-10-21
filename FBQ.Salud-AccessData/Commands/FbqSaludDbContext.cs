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
                Fecha = DateTime.Now
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
