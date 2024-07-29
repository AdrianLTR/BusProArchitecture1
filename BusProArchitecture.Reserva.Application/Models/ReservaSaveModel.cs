using BoletoBusMaMonolitica.Data.DbObjects;
using BoletoBusMaMonolitica.Data.Entities;

namespace BoletoBusMaMonolitica.Data.Models
{
    public class ReservaSaveModel : ReservaBaseModel
    {
        public ReservaSaveModel() { }

        public Reserva ToEntity()
        {
            return new Reserva
            {
                IdReserva = this.IdReserva,
                IdViaje = this.IdViaje,
                IdPasajero = this.IdPasajero,
                AsientosReservados = this.AsientosReservados,
                MontoTotal = this.MontoTotal,
                FechaCreacion = this.FechaCreacion


            };
        }
    }
}

