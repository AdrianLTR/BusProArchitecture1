using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusProArchitecture.Reserva.Application.Dtos
{
    internal class DtoBaseReserva:DtoBase
    {

        public string? Title { get; set; }
        public int Credits { get; set; }
        public int IdReserva { get; set; }
    }
}
