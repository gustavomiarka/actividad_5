using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ServicioLibrary.Services;
using ServicioLibrary.Models;

namespace ServicioApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicioController : ControllerBase
    {
        private readonly IServicioService _servicioService;

        public ServicioController(IServicioService servicioService)
        {
            _servicioService = servicioService;
        }

        [HttpGet("servicios-activos")]
        public IActionResult GetAll()
        {
            if (_servicioService.GetAll() != null)
            {
                return Ok(_servicioService.GetAll());
            }
            else
            {
                return BadRequest("Error en la carga de datos");
            }
        }

        [HttpGet("servicios-inactivos")]
        public IActionResult GetAllInactivos(int id) 
        {
            if (_servicioService.GetAllInactivos != null)
            {
                return Ok(_servicioService.GetAllInactivos());
            }
            else
            {
                return BadRequest("Error en la carga de datos");
            }
        }


        [HttpDelete("delete/{id}")]
        public IActionResult Delete( int id) 
        {
            if (_servicioService.Delete(id))
            {
                return Ok(_servicioService.Delete(id));
            }
            else
            {
                return StatusCode(500, "Error al eliminar el elemento");
            }
        }

        [HttpPost("new")]
        public IActionResult Save(TServicio servicio) 
        {
            if (_servicioService.Add(servicio))
            {
                return Ok(_servicioService.Add(servicio));
            }
            else
            {
                return StatusCode(500, "Error al cargar nuevo elemento");
            }
        }

        [HttpPut("edit")]
        public IActionResult Update(TServicio servicio) 
        {
            if (_servicioService.Update(servicio))
            {
                return Ok(_servicioService.Update(servicio));
            }
            else
            {
                return BadRequest("Error al actualizar");
            }

        }     

    }
}
