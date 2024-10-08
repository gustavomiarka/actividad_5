using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicioLibrary.Services;
using ServicioLibrary.Models;

namespace ServicioApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurnoController : ControllerBase
    {
        private readonly ITurnoService _turnoService;

        public TurnoController(ITurnoService turnoService)
        {
            _turnoService = turnoService;
        }


        [HttpGet("turnos-activos")]
        public async Task<IActionResult> GetAll()
        {
            if ( await _turnoService.GetAll() != null)
            {
                return Ok(await _turnoService.GetAll());
            }
            else
            {
                return BadRequest("Error en la carga de turnos");
            }
        }

        [HttpGet("turnos-cancelados")]
        public IActionResult GetAllCancelados(int id)
        {

            try
            {
                if (_turnoService.GetAllCancelados().Count > 0)
                {
                    return Ok(_turnoService.GetAllCancelados());
                }
                else
                {
                    return BadRequest("Lista de turnos cancelados vacia");
                }
            }
            catch (Exception)
            {

                throw new Exception("Error en la carga de turnos");
            }
            
        }


        [HttpDelete("delete/{id}")]
        public IActionResult Delete([FromQuery]int id, [FromBody]DateTime fecha, [FromBody]string motivo)
        {
            if (_turnoService.Delete(id, fecha, motivo))
            {
                return Ok(_turnoService.Delete(id, fecha, motivo));
            }
            else
            {
                return StatusCode(500, "Error al eliminar el turno");
            }
        }

        [HttpPost("new")]
        public IActionResult Save([FromBody]TTurno turno)
        {
            if ( _turnoService.Add(turno))
            {
                return Ok( _turnoService.Add(turno));
            }
            else
            {
                return StatusCode(500, "Error al cargar nuevo turno");
            }
        }

        [HttpPut("edit")]
        public IActionResult Update(TTurno turno)
        {
            try
            {
                if (_turnoService.Update(turno))
                {
                    return Ok(_turnoService.Update(turno));
                }
                else
                {
                    return BadRequest("Error al actualizar turno");
                }
            }
            catch (Exception)
            {

                throw new Exception("Error inesperado, intente nuevamente");
            }
            

        }


    }
}
