


using Microsoft.EntityFrameworkCore;

namespace BusProArchitecture.Usuario.Persistence.Context
{


using BusProArchitecture.Usuario.Domain.Entities;

    public class BoletoBusContext : DbContext
    {

        #region"Constructor"
        public BoletoBusContext(DbContextOptions<BoletoBusContext> options) : base(options)

        {

        }

        #endregion

        #region "Db Sets"


        public DbSet<Domain.Entities.Usuario> Usuarios { get; set; }
        #endregion



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
          
            modelBuilder.Entity<Usuario>().ToTable("Usuario");
        }

    }
}
