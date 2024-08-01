
using Microsoft.AspNetCore.Mvc;

using BusProArchitecture.Usuario.aplication.Interfaces;
using BusProArchitecture.Usuario.Application.Dtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BusProArchitecture.Usuario.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            this.usuarioService = usuarioService;
        }

        // GET: api/Usuario
        [HttpGet("GetUsuarios")]
        public IActionResult Get()
        {
            var result = this.usuarioService.GetUsuarios();
            if (!result.Success)
                return BadRequest(result.Message);
            else
                return Ok(result.Data);
        }

        // GET: api/Usuario/5
        [HttpGet("GetUsuario")]
        public IActionResult Get(int id)
        {
            var result = this.usuarioService.GetUsuario(id);
            if (!result.Success)
                return NotFound(result.Message);
            else
                return Ok(result.Data);
        }

        // POST: api/Usuario
        [HttpPost("SaveUsuario")]
        public IActionResult Post([FromBody] UsuarioDtoAdd dtoAdd)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = this.usuarioService.SaveUsuario(dtoAdd);
            if (!result.Success)
                return BadRequest(result.Message);

            return CreatedAtAction(nameof(Get), new { id = result.Data.Id }, result.Data);
        }

        [HttpPost("UpdateUsuario")]
        public IActionResult Post([FromBody] UsuarioDtoUpdate dtoUpdate)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = this.usuarioService.UpdateUsuario(dtoUpdate);
            if (!result.Success)
                return BadRequest(result.Message);

            return NoContent();
        }

        // DELETE: api/Usuario
        [HttpDelete("RemoveUsuario")]
        public IActionResult Delete([FromBody] UsuarioDtoRemove dtoRemove)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = this.usuarioService.RemoveUsuario(dtoRemove);
            if (!result.Success)
                return BadRequest(result.Message);

            return NoContent();
        }
    }
}
