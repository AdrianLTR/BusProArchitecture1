using BusProArchitecture.Web.Models.Base;

namespace BusProArchitecture.Web.Models.Reserva
{
    public class ReservaGetModel : ReservaModel {}
    public class ReservaListGetResult : BaseResult<List<ReservaGetModel>> { }
    public class ReservaGetResult : BaseResult<ReservaGetModel> { }
}

