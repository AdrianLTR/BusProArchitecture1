

using BusProArchitecture.common.Data.Repository;

namespace BusProArchitecture.Reserva.Domain.Interfaces
{
    public interface IReservaRepository  : IBaseRepository<Reserva.Domain.Entities.Reserva,int>
    {
        List<Reserva.Domain.Entities.Reserva> GetReservasByIdUsuario( int IdUsuario);




    }
}
