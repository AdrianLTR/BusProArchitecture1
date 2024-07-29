using BusProArchitecture.Reserva;


using BusProArchitecture.Reserva.Application.Interfaces;
namespace BusProArchitecture.Reserva.Application.Services
{
    public class ReservaService : IReservaService
    {
        private readonly IReservaDb reservaDb;
        private readonly ILogger logger;

        public ReservaService(IReservaDb reservaDb, ILogger<ReservaService> logger)
        {
            this.reservaDb = reservaDb;
            this.logger = logger;
        }

        // NOTA, METODO EXECUTE PARA MANEJAR LAS EXCEPCIONES, APLICANDO EL D.R.Y
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
        // METODO VALIDATE PARA MANEJAR Y SIMPLIFICAR LAS VALIDACIONES
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
                var result = new ServiceResult
                {
                    Data = reservaDb.GetReservas()
                };
                return result;
            }, "Hubo un error durante la obtención de las reservas.");
        }

        public ServiceResult GetReserva(int id)
        {
            return Execute(() => {
                var result = new ServiceResult
                {
                    Data = reservaDb.GetReservas(id)
                };
                return result;
            }, "Ocurrió un error obteniendo las reservas.");
        }

        public ServiceResult UpdateReserva(ReservaUpdateModel reservaUpdate)
        {
            return Execute(() => {
                var validationResult = Validate(() => reservaUpdate == null, "Los datos de la reserva no pueden ser nulos.");
                if (!validationResult.Success) return validationResult;

                validationResult = Validate(() => reservaUpdate.IdReserva <= 0, "El Id del bus es requerido.");
                if (!validationResult.Success) return validationResult;

                validationResult = Validate(() => reservaUpdate.AsientosReservados <= 0, "El número de reserva es requerido.");
                if (!validationResult.Success) return validationResult;

                this.reservaDb.UpdateReserva(reservaUpdate);
                return new ServiceResult { Success = true };
            }, "Ocurrió un error actualizando los datos.");
        }

        public ServiceResult RemoveReserva(ReservaRemoveModel reservaRemove)
        {
            return Execute(() => {
                var validationResult = Validate(() => reservaRemove == null, "Los datos de la reserva no pueden ser nulos.");
                if (!validationResult.Success) return validationResult;

                this.reservaDb.RemoveReserva(reservaRemove);
                return new ServiceResult { Success = true };
            }, "Ocurrió un error removiendo los datos.");
        }

        public ServiceResult SaveReserva(ReservaSaveModel reservaAdd)
        {
            return Execute(() => {
                var validationResult = Validate(() => reservaAdd == null, "Los datos de la reserva no pueden ser nulos.");
                if (!validationResult.Success) return validationResult;

                validationResult = Validate(() => reservaAdd.IdReserva <= 0, "El Id del bus es requerido.");
                if (!validationResult.Success) return validationResult;

                validationResult = Validate(() => reservaAdd.AsientosReservados <= 0, "El número de reserva es requerido.");
                if (!validationResult.Success) return validationResult;

                this.reservaDb.SaveReserva(reservaAdd);
                return new ServiceResult { Success = true };
            }, "Ocurrió un error grabando los datos.");
        }
    }
}
