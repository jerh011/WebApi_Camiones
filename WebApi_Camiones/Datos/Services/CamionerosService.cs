using WebApi_Camiones.Datos.Models;
using WebApi_Camiones.Datos.ViewModels;

using System;
using Api_Camiones.Datos;

namespace WebApi_Camiones.Datos.Services
{
    public class CamionerosService
    {
        private AppDbContext _context;
        public CamionerosService(AppDbContext context)
        {
            _context = context;
        }
        public void AgregarCamionero(CamionerosVM camionero)
        {
            var _camionero =  new Camionero()
            { 
               Id = camionero.Id,
               Nombres = camionero.Nombres,
               Apellido_Paterno=camionero.Apellido_Paterno,
               Apellido_Materno=camionero.Apellido_Materno,
               Numero_telefono=camionero.Numero_telefono
            };
            _context.camioneros.Add(_camionero);
            _context.SaveChanges();
        
        }
     
    }
}
