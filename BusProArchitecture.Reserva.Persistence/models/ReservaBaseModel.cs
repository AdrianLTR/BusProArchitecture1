using System.ComponentModel.DataAnnotations;

namespace BoletoBusMaMonolitica.Data.Models
{
    public class ReservaBaseModel 
    {
       [Key] public int IdReserva { get; set; }

        public int IdViaje { get; set; }

        public int IdPasajero { get; set; }

        public int AsientosReservados { get; set; }

        public decimal MontoTotal { get; set; }

        public DateTime FechaCreacion { get; set; }
    }
}