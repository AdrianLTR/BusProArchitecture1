
using BusProArchitecture.Reserva.Application.Base;

using BusProArchitecture.Reserva.Application.Dtos;

namespace BusProArchitecture.Reserva.Application.Interfaces

{
   public interface IReservaService
    {

        ServiceResult GetReservas();
        ServiceResult GetReserva(int id);
        ServiceResult UpdateReserva(ReservaDtoUpdate reservaUpdate);
        ServiceResult RemoveReserva(ReservaDtoRemove reservaRemove);
        ServiceResult SaveReserva(ReservaDtoAdd reservaAdd);
    }

}

