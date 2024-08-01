
using BusProArchitecture.Web.Models.Reserva;

namespace BusProArchitecture.Web.Controllers

{
    public class ReservaController : BaseController<ReservaGetModel, ReservaSaveModel, ReservaUpdateModel>
    {
        public ReservaController() : base("http://localhost:5110/api/Reserva") { }

        protected override string GetAllUrl => "/GetReservas";
        protected override string GetByIdUrl => "/GetReserva";
        protected override string CreateUrl => "/SaveReserva";
        protected override string UpdateUrl => "/UpdateReserva";
    }
}
