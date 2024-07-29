using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusProArchitecture.Reserva.Application.Base;
namespace BusProArchitecture.Reserva.Application.Interfaces
{
   public interface IReservaService
    {

        ServiceResult GetReservas();
        ServiceResult GetReserva(int id);
        ServiceResult UpdateReserva(ReservaUpdateModel reservaUpdate);
        ServiceResult RemoveReserva(ReservaRemoveModel reservaRemove);
        ServiceResult SaveReserva(ReservaSaveModel reservaAdd);
    }

}

