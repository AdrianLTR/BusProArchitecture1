
using System;
using BusProArchitecture.Reserva.Domain.Entities;

using Microsoft.EntityFrameworkCore;

namespace BusProArchitecture.Reserva.Persistence.Context
{
    public class BoletoBusContext : DbContext
    {

        #region"Constructor"
        public BoletoBusContext(DbContextOptions<BoletoBusContext> options) : base(options)

        {

        }

        #endregion

        #region "Db Sets"
        public DbSet<Domain.Entities.Reserva> Reservas { get; set; }

        #endregion





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Domain.Entities.Reserva>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();  // Configura que el valor es generado al agregar
            });


            


        }

      
      


    }
}
