using BoletoBusMaMonolitica.Data.DbObjects;
using BoletoBusMaMonolitica.Data.Entities;
using BoletoBusMaMonolitica.Data.Exceptions;

namespace BoletoBusMaMonolitica.Data.Models
{
    public class ReservaUpdateModel: ReservaBaseModel
    {



        public void UpdateEntity(Reserva reserva)
        {
            reserva.IdViaje = this.IdViaje;
           reserva.AsientosReservados = this.AsientosReservados;
            reserva.IdReserva = this.IdReserva;
            reserva.IdPasajero = this.IdPasajero;
            reserva.MontoTotal = this.MontoTotal;
            reserva.FechaCreacion = this.FechaCreacion;




            

        }










    }



    
}
