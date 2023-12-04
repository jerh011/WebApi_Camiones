using Api_Camiones.Datos;
using System.Collections.Generic;
using System.Linq;
using WebApi_Camiones.Datos.Models;
using WebApi_Camiones.Datos.ViewModels;

namespace WebApi_Camiones.Datos.Services
{
    public class CamionesServices
    {
        private AppDbContext _context;
        public CamionesServices(AppDbContext context)
        {
            _context = context;
        }
        public void AgregarCamiones(CamionesVM camiones)
        {
            var _camiones = new Camiones()
            {
                Id = camiones.Id,
                Placas=camiones.Placas,
                Modelo=camiones.Modelo
            };
            _context.camiones.Add(_camiones);
            _context.SaveChanges();
        }

        public List<Camiones> GetAllCamiones() => _context.camiones.ToList();

        public Camiones GetCamionesByID(string Id) => _context.camiones.FirstOrDefault(n => n.Id == Id);

        public Camiones EditarCamiones(string Id, CamionesVM camiones)
        {
            var _camiones = _context.camiones.FirstOrDefault(n => n.Id == Id);

            if (_camiones != null)
            {
                _camiones.Placas = camiones.Placas;
                _camiones.Modelo = camiones.Modelo;
                
                _context.SaveChanges();//importante no olvidar nunca
            }
            return _camiones;
        }

        public void EliminarPorID(string Id)
        {
            var _camiones = _context.camiones.FirstOrDefault(n => n.Id == Id);

            if (_camiones != null)
            {
                _context.camiones.Remove(_camiones);
                _context.SaveChanges();//importante no olvidar nunca
            }

        }

    }


}
