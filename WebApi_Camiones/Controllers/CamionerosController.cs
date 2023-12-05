using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi_Camiones.Datos.Services;
using WebApi_Camiones.Datos.ViewModels;

namespace WebApi_Camiones.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CamionerosController : ControllerBase
    {
        public CamionerosService _camionerosService;
        public CamionerosController(CamionerosService camionerosService)
        {
            _camionerosService = camionerosService;
        }

        [HttpGet("Listar_camioneros")]
        public IActionResult GetAllCamioneros()
        {
            var allBooks = _camionerosService.GetAllCamioneros();
            return Ok(allBooks);
        }

        [HttpGet("Obtener_camioneros_por_id/{id}")]
        public IActionResult GetCamionerosById(int id)
        {

            var camionero = _camionerosService.GetCamionerosByID(id);
            return Ok(camionero);
        }

        [HttpPost("Agregar-Camionero")]
        public IActionResult AgregarCamionero([FromBody]CamioneroVM camionero)
        {
            _camionerosService.AgregarCamionero(camionero);
            return Ok();
        }

        [HttpPut("actualizar_camioneros_por_id/{id}")]
        public IActionResult EditarCamionero(int id, [FromBody] CamioneroVM camionero)
        {
            _camionerosService.EditarCamionero(id,camionero);
            return Ok();
        }

        [HttpDelete("Eliminar-camion-por-Id/{id}")]
        public IActionResult EliminarCamionero(int id)
        {
            _camionerosService.EliminarPorID(id);
            return Ok();
        }

        [HttpGet("Obtener_camioneros-con-camiones_por_id/{id}")]
        public IActionResult GetCamnioneroWithcamiones(int id)
        {

            var camionero = _camionerosService.GetCamioneroWithCamiones(id);
            return Ok(camionero);
        }
    }
}
