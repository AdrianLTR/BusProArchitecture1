using BusProArchitecture.Reserva.Application.Services;
using BusProArchitecture.Reserva.Domain.Interfaces;
using BusProArchitecture.Reserva.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;
using BusProArchitecture.Reserva.Application.Interfaces;
using BusProArchitecture.common.Data.Repository;
using BusProArchitecture.Usuario.Domain.Interfaces;
using BusProArchitecture.Usuario.Persistence.Repositories;
using BusProArchitecture.Usuario.aplication.Interfaces;
using BusProArchitecture.Usuario.aplication.Services;


namespace BusProArchitecture.IOC.Dependencies
{
   public static class ReservaDependency
    {

        public static void AddReservaDependecy (this IServiceCollection service )
        {

            service.AddScoped<IReservaRepository, ReservaRepository>();
            service.AddScoped<IUsuarioRepository, UsuarioRepository>();

            service.AddTransient<IReservaService, ReservaService>();
            service.AddTransient<IUsuarioService, UsuarioService>();
        }

    }
}
