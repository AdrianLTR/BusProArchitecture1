using BoletoBusMaMonolitica.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoletoBusMaMonolitica.Data.Models
{
    
    public class ReservaGetModel : ReservaBaseModel
    {
        
        public static ReservaGetModel FromEntity(Reserva reserva)
        {
            return new ReservaGetModel
            {
             
                IdReserva = reserva.IdReserva,
                IdViaje = reserva.IdViaje,               
                IdPasajero = reserva.IdPasajero,
                AsientosReservados = reserva.AsientosReservados,
                MontoTotal=reserva.MontoTotal,
               FechaCreacion = reserva.FechaCreacion
            };
        }
    }
}