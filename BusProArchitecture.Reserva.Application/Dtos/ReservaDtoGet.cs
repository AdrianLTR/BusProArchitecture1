using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusProArchitecture.Reserva.Application.Dtos
{
    public record ReservaDtoGet(


     int IdReserva,
     int IdViaje ,
     int IdPasajero, 
     int AsientosReservados,
     decimal MontoTotal,
     DateTime FechaCreacion


        
        
     );
    
}
