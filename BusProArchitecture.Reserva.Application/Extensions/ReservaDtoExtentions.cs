
using BusProArchitecture.Reserva.Application.Dtos;


namespace BusProArchitecture.Reserva.Application.Extensions
{
    using BusProArchitecture.Reserva.Domain.Entities;

    public static class ReservaDtoExtentions
    {


        public static Reserva ToEntity(this ReservaDtoAdd reservaDto)
        {
            return new Reserva
            {
                IdReserva = reservaDto.IdReserva,
                IdViaje = reservaDto.IdViaje,
                AsientosReservados = reservaDto.AsientosReservados
            };
        }

        public static void UpdateEntity(this ReservaDtoUpdate reservaDto, Reserva reserva)
        {
            reserva.IdReserva = reservaDto.IdReserva;
            reserva.IdViaje = reservaDto.IdViaje;
            reserva.AsientosReservados = reservaDto.AsientosReservados;



        }
    }
}