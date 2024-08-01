
using BusProArchitecture.Reserva.Application.Dtos;
using BusProArchitecture.Reserva.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BusProArchitecture.Reserva.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController : ControllerBase
    {
        private readonly IReservaService reservaService;

        public ReservaController(IReservaService reservaService)
        {
            this.reservaService = reservaService;
        }

        // GET: api/Reserva
        [HttpGet("GetReservas")]
        public IActionResult Get()
        {
            var result = this.reservaService.GetReservas();
            if (!result.Success)
                return BadRequest(result.Message);
            else
                return Ok(result.Data);
        }

        // GET: api/Reserva/5
        [HttpGet("GetReserva")]
        public IActionResult Get(int id)
        {
            var result = this.reservaService.GetReserva(id);
            if (!result.Success)
                return NotFound(result.Message);
            else
                return Ok(result.Data);
        }

        // POST: api/Reserva
        [HttpPost("SaveReserva")]
        public IActionResult Post([FromBody] ReservaDtoAdd dtoAdd)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = this.reservaService.SaveReserva(dtoAdd);
            if (!result.Success)
                return BadRequest(result.Message);

            return CreatedAtAction(nameof(Get), new { id = result.Data.Id }, result.Data);
        }

        [HttpPost("UpdateReserva")]
        public IActionResult Post([FromBody] ReservaDtoUpdate dtoUpdate)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = this.reservaService.UpdateReserva(dtoUpdate);
            if (!result.Success)
                return BadRequest(result.Message);

            return NoContent();
        }

        // DELETE: api/Reserva
        [HttpDelete("RemoveReserva")]
        public IActionResult Delete([FromBody] ReservaDtoRemove dtoRemove)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = this.reservaService.RemoveReserva(dtoRemove);
            if (!result.Success)
                return BadRequest(result.Message);

            return NoContent();
        }
    }
}
