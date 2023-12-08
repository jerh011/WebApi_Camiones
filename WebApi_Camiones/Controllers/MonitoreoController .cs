using Microsoft.AspNetCore.Mvc;
using System;
using WebApi_Camiones.Datos.Models;
using WebApi_Camiones.Datos.Services;
using WebApi_Camiones.Datos.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi_Camiones.Datos.Services;
using WebApi_Camiones.Datos.ViewModels;


namespace WebApi_Camiones.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonitoreoController : ControllerBase
    {
        private readonly MonitoreoService _monitoreoService;

        public MonitoreoController(MonitoreoService monitoreoService)
        {
            _monitoreoService = monitoreoService;
        }

        [HttpPost("add-monitoreo")]
        public IActionResult AddMonitoreo([FromBody] MonitoreoVM monitoreo)
        {
            try
            {
                var newMonitoreo = _monitoreoService.AddMonitoreo(monitoreo);
                return Created(nameof(AddMonitoreo), newMonitoreo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-monitoreo-by-id/{id}")]
        public IActionResult GetMonitoreoById(int id)
        {
            var response = _monitoreoService.GetMonitoreoById(id);
            if (response != null)
            {
                return Ok(response);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("delete-monitoreo-by-id/{id}")]
        public IActionResult DeleteMonitoreoById(int id)
        {
            try
            {
                _monitoreoService.DeleteMonitoreoById(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}