


namespace BusProArchitecture.Reserva.Persistence.Exceptions
{
using BusProArchitecture.Reserva.Domain.Entities;


    public class ReservaException : Exception
    {
        public ReservaException(string message) : base(message)
        {
        }

        public static void VerifyExistence(Reserva reserva, int idReserva)
        {
            if (reserva == null)
            {
                throw new ReservaException($"El asiento con la id {idReserva} no está registrado.");
            }
        }


    }

}
