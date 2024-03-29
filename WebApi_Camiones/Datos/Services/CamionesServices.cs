﻿using Api_Camiones.Datos;
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
           
                Placas=camiones.Placas,
                Modelo=camiones.Modelo
            };
            _context.camiones.Add(_camiones);
            _context.SaveChanges();
            foreach (var id in camiones.CamioneroID)
            {
                var _camiones_camionero = new Camionero_Camiones()
                {
                    CamioneroId = id,
                    CamionId = _camiones.Id
                };
                _context.camionero_Camiones.Add(_camiones_camionero);
                _context.SaveChanges();
            }
            foreach (var id in camiones.RutaID)
            {
                var _camion_ruta = new Camion_Ruta()
                {
                    IdRuta = id,
                    CamionId = _camiones.Id
                };
                _context.camion_Rutas.Add(_camion_ruta);
                _context.SaveChanges();
            }

        }

        //public List<Camiones> GetAllCamiones() => _context.camiones.ToList();
        public List<CamionesWhitCamionerosWithRutaVM> GetAllCamiones()
        {
            var _CamionesWhitCammioneros = _context.camiones
                    .Select(camiones => new CamionesWhitCamionerosWithRutaVM()
                    {
                        Id= camiones.Id,
                        Placas = camiones.Placas,
                        Modelo = camiones.Modelo,
                        camionero = camiones.Camionero_Camion
                        .Select(n => n.Camionero.Nombres).ToList(),
                        RutaName = camiones.Camion_Ruta
                        .Select(n => n.ruta.RutaName).ToList()
                    }).ToList();

            return _CamionesWhitCammioneros;
        }
        //public Camiones GetCamionesByID(int Id) => _context.camiones.FirstOrDefault(n => n.Id == Id);
        public CamionesWhitCamionerosWithRutaVM GetCamionesByID(int Id) {

            var _CamionesWhitCammioneros = _context.camiones.Where(n=>n.Id==Id)
                .Select(camiones=> new CamionesWhitCamionerosWithRutaVM()     
                {
                    Placas = camiones.Placas,
                    Modelo = camiones.Modelo,
                    camionero=camiones.Camionero_Camion
                    .Select(n=>n.Camionero.Nombres).ToList(),
                    RutaName = camiones.Camion_Ruta
                    .Select(n => n.ruta.RutaName).ToList()
                }).FirstOrDefault();

            return _CamionesWhitCammioneros;

        }

        public Camiones EditarCamiones(int Id, CamionesVM camiones)
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

        public void EliminarPorID(int Id)
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
