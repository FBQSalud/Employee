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

        public virtual DbSet<Medico> Medicos { get; set;  }
        public virtual DbSet<Enfermera> Enfermeras { get; set; }
        public virtual DbSet<Empleado> Empleados { get; set; }
        public virtual DbSet<TipoEmpleado> TipoEmpleados { get; set; }  
        public virtual DbSet<HorarioTrabajo> HorariosTrabajo { get; set; }
        public virtual DbSet<Especialidad> Especialidades { get; set; }
        public virtual DbSet<Habitacion> Habitaciones { get; set; }
    }
}
