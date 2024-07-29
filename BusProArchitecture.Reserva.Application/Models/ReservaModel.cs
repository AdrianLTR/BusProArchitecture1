using BoletoBusMaMonolitica.Data.Core;
using BoletoBusMaMonolitica.Data.Entities;

namespace BoletoBusMaMonolitica.Data.Models
{
    public class ReservaModel : Reserva
    {
        public ReservaModel()
        {

        }

        internal void UpdateEntity(Reserva? reserva)
        {
            throw new NotImplementedException();
        }
        public static ReservaModel FromEntity(Reserva reserva)
        {
            return new ReservaModel
            {
                IdReserva = reserva.IdReserva,
                IdViaje = reserva.IdViaje,
                IdPasajero = reserva.IdPasajero,
                AsientosReservados = reserva.AsientosReservados,
                MontoTotal = reserva.MontoTotal,
                FechaCreacion = reserva.FechaCreacion


            };
        }
    }
}
