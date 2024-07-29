
using BusProArchitecture.common.Data.Repository;

using BusProArchitecture.Reserva.Persistence.Exceptions;
using BusProArchitecture.Reserva.Domain.Interfaces;
using BusProArchitecture.Reserva.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace BusProArchitecture.Reserva.Persistence.Repositories

{
  using BusProArchitecture.Reserva.Domain.Entities;
    public class ReservaRepository : IReservaRepository
    {
        private readonly BoletoBusContext context;

        public ReservaRepository(BoletoBusContext context)
        {
            this.context = context;
        }

        public Reserva GetEntityby(int Id)
        {
            var reserva = context.Reservas.Find(Id);
            ReservaException.VerifyExistence(reserva, Id);
            return reserva;
        }

        public bool Exist(Expression<Func<Reserva, bool>> filter)
        {
            return context.Reservas.Any(filter);
        }




        public List<Reserva> GetAll()
        {
            return context.Reservas.ToList();
        }

        public List<Reserva> GetReservasByIdUsuario(int IdReserva)
        {
            return context.Reservas.Where(a => a.IdReserva == IdReserva).ToList();
        }

      

        public void Remove(Reserva entity)
        {
            context.Reservas.Remove(entity);
            context.SaveChanges();
        }

        public void Save(Reserva entity)
        {
            context.Reservas.Add(entity);
            context.SaveChanges();
        }

        public void Update(Reserva entity)
        {
            var existingReserva = context.Reservas.Find(entity.Id);
            ReservaException.VerifyExistence(existingReserva, entity.Id);

            existingReserva.Id = entity.Id;
            existingReserva.IdViaje = entity.IdViaje;
            existingReserva.IdReserva = entity.IdReserva;
            existingReserva.AsientosReservados = entity.AsientosReservados;
            existingReserva.MontoTotal = entity.MontoTotal;

            context.Reservas.Update(existingReserva);
            context.SaveChanges();
        }

       
    }
}
