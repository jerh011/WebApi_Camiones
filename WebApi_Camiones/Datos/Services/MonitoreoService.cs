using Api_Camiones.Datos;
using System;
using System.Linq;
using WebApi_Camiones.Datos.Models;
using WebApi_Camiones.Datos.ViewModels;

namespace WebApi_Camiones.Datos.Services
{
    public class MonitoreoService
    {
        private readonly AppDbContext _context;

        public MonitoreoService(AppDbContext context)
        {
            _context = context;
        }

        public Monitoreo AddMonitoreo(MonitoreoVM monitoreo)
        {
            var nuevoMonitoreo = new Monitoreo
            {
                Hora = monitoreo.Hora,
                CamionId = monitoreo.CamionId
            };

            _context.Monitoreos.Add(nuevoMonitoreo);
            _context.SaveChanges();

            return nuevoMonitoreo;
        }

        public Monitoreo GetMonitoreoById(int id) => _context.Monitoreos.FirstOrDefault(m => m.Id == id);

        public void DeleteMonitoreoById(int id)
        {
            var monitoreo = _context.Monitoreos.FirstOrDefault(m => m.Id == id);
            if (monitoreo != null)
            {
                _context.Monitoreos.Remove(monitoreo);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception($"El monitoreo con id: {id}, no existe");
            }
        }
    }
}