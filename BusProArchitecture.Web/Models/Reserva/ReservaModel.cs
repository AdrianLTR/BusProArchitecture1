﻿using BusProArchitecture.Web.Models.Base;

namespace BusProArchitecture.Web.Models.Reserva
{
    public class ReservaModel : EntityModel
    {
        
        public int IdReserva { get; set; }
        public int IdViaje { get; set; }

        public int IdPasajero { get; set; }

        public int AsientosReservados { get; set; }

        public decimal MontoTotal { get; set; }

        public DateTime FechaCreacion { get; set; }
    }
}
