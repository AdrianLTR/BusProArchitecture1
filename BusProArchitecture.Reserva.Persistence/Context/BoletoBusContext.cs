

using Microsoft.EntityFrameworkCore;

namespace BusProArchitecture.Reserva.Persistence.Context
{
   using BusProArchitecture.Reserva.Domain.Entities;

    public class BoletoBusContext : DbContext
    {

        #region"Constructor"
        public BoletoBusContext(DbContextOptions<BoletoBusContext> options) : base(options)

        {

        }

        #endregion

        #region "Db Sets"
        public DbSet<Reserva> Reservas { get; set; }

        #endregion





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Reserva>().ToTable("Reserva");
            
        }





    }
}
