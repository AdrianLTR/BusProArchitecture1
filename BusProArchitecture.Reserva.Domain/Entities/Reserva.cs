
using BusProArchitecture.common.Data.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusProArchitecture.Reserva.Domain.Entities
{
   public class Reserva : AuditEntity<int>
    {

        [Column("IdReserva")]
        public override int Id { get; set; }

        public int IdReserva { get; set; }
        public int IdViaje { get; set; }

        public int IdPasajero { get; set; }

        public int AsientosReservados { get; set; }

        public decimal MontoTotal { get; set; }

        public DateTime FechaCreacion { get; set; }
    }
}
