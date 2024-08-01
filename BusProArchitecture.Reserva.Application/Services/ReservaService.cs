using Microsoft.Extensions.Logging;
using BusProArchitecture.Reserva.Application.Dtos;
using BusProArchitecture.Reserva.Application.Base;
using BusProArchitecture.Reserva.Application.Interfaces;
using BusProArchitecture.Reserva.Domain.Interfaces;

using BusProArchitecture.Reserva.Application.Extensions;

namespace BusProArchitecture.Reserva.Application.Services
{
    
   using BusProArchitecture.Reserva.Domain.Entities;
  
   public class ReservaService : IReservaService
    {
      

        private readonly IReservaRepository reservaRepository;
        private readonly ILogger logger;


        public ReservaService(IReservaRepository reservaRepository,ILogger<ReservaService> logger)
                             
                             
        {
            this.reservaRepository = reservaRepository;
          
            this.logger = logger;
        }

        private ServiceResult Execute(Func<ServiceResult> action, string errorMessage)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result = action();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = errorMessage;
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        private ServiceResult Validate(Func<bool> condition, string errorMessage)
        {
            ServiceResult result = new ServiceResult();
            if (condition())
            {
                result.Success = false;
                result.Message = errorMessage;
                return result;
            }
            result.Success = true;
            return result;
        }

        public ServiceResult GetReservas()
        {
            return Execute(() => {
                var reservas = reservaRepository.GetAll();
                var result = new ServiceResult
                {
                    Data = reservas.Select(reserva => new ReservaDtoGet(
                        reserva.Id,
                        reserva.IdReserva,
                        reserva.IdViaje,
                        reserva.IdPasajero,
                        reserva.AsientosReservados,
                        reserva.FechaCreacion
                    )).ToList()
                };
                return result;
            }, "Hubo un error durante la obtención de las reservas.");
        }

        public ServiceResult GetReserva(int id)
        {
            return Execute(() => {
                var reserva = reservaRepository.GetEntityby(id);
                if (reserva == null)
                {
                    return new ServiceResult
                    {
                        Success = false,
                        Message = "Reserva no encontrada."
                    };
                }
                var result = new ServiceResult
                {
                    Data = new ReservaDtoGet(
                         reserva.Id,
                        reserva.IdReserva,
                        reserva.IdViaje,
                        reserva.IdPasajero,
                        reserva.AsientosReservados,
                        reserva.FechaCreacion
                    )
                };
                return result;
            }, "Ocurrió un error obteniendo la reserva.");
        }

        public ServiceResult UpdateReserva(ReservaDtoUpdate reservaUpdate)
        {
            return Execute(() => {
                var validationResult = Validate(() => reservaUpdate == null, "Los datos de la reserva no pueden ser nulos.");
                if (!validationResult.Success) return validationResult;

                validationResult = Validate(() => reservaUpdate.IdReserva <= 0, "El Id de Reserva es requerido.");
                if (!validationResult.Success) return validationResult;

                validationResult = Validate(() => reservaUpdate.AsientosReservados <= 0, "El número de asiento es requerido.");
                if (!validationResult.Success) return validationResult;

                var reserva = reservaRepository.GetEntityby(reservaUpdate.IdReserva);
                if (reserva == null)
                {
                    return new ServiceResult
                    {
                        Success = false,
                        Message = "reserva no encontrada."
                    };
                }
                reservaUpdate.UpdateEntity(reserva);

                reservaRepository.Update(reserva);
                return new ServiceResult { Success = true };
            }, "Ocurrió un error actualizando los datos.");
        }

        public ServiceResult RemoveReserva(ReservaDtoRemove reservaRemove)
        {
            return Execute(() => {
                var validationResult = Validate(() => reservaRemove == null, "Los datos de la reserva no pueden ser nulos.");
                if (!validationResult.Success) return validationResult;

                var reserva = reservaRepository.GetEntityby(reservaRemove.IdReserva);
                if (reserva == null)
                {
                    return new ServiceResult
                    {
                        Success = false,
                        Message = "Reserva no encontrada."
                    };
                }
                reservaRepository.Remove(reserva);
                return new ServiceResult { Success = true };
            }, "Ocurrió un error removiendo los datos.");
        }

        public ServiceResult SaveReserva(ReservaDtoAdd reservaAdd)
        {
            return Execute(() => {
                var validationResult = Validate(() => reservaAdd == null, "Los datos del reserva no pueden ser nulos.");
                if (!validationResult.Success) return validationResult;

                validationResult = Validate(() => reservaAdd.IdReserva <= 0, "El Id de la reserva es requerido.");
                if (!validationResult.Success) return validationResult;

                validationResult = Validate(() => reservaAdd.AsientosReservados <= 0, "El número de AsientosReservados es requerido.");
                if (!validationResult.Success) return validationResult;

                var reservaEntity = new Reserva
                {
                    IdReserva = reservaAdd.IdReserva,
                    IdViaje = reservaAdd.IdViaje,
                    IdPasajero = reservaAdd.IdPasajero,
                    AsientosReservados=reservaAdd.AsientosReservados,
                    FechaCreacion = DateTime.Now


                   
                };

                reservaRepository.Save(reservaEntity);
                return new ServiceResult { Success = true, Data = reservaEntity };
            }, "Ocurrió un error grabando los datos.");
        }








   }

}

    

