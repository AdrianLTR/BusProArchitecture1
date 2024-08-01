using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusProArchitecture.Reserva.Application.Dtos
{
    internal class ReservaDtoGetAll
    {

        public int IdReserva { get; set; }
        public int IdViaje { get; set; }

        public int IdPasajero { get; set; }

        public int AsientosReservados { get; set; }

        public decimal MontoTotal { get; set; }

        public DateTime FechaCreacion { get; set; }
    }
}
