

using BusProArchitecture.common.Data.Repository;

namespace BusProArchitecture.Reserva.Domain.Interfaces

{

using BusProArchitecture.Reserva.Domain.Entities;


    public interface IReservaRepository  : IBaseRepository<Reserva,int>
    {
       

        List<Reserva> GetReservasById(int IdReserva);


    }
}
