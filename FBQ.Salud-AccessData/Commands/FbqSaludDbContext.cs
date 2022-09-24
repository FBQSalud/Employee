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

        
    }
}
