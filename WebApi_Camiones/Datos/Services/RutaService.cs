﻿using Api_Camiones.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApi_Camiones.Datos.Models;
using WebApi_Camiones.Datos.ViewModels;

namespace WebApi_Camiones.Datos.Services
{
    public class RutaService
    {

        private AppDbContext _context;
        public RutaService(AppDbContext context)
        {
            _context = context;
        }

        public void AgregarRuta(RutaVM ruta)
        {
            var _ruta = new Ruta()
            {
                RutaName = ruta.RutaName,
                Hora_llegada=DateTime.Now,
                Hora_salida = DateTime.Now,
                Cantidad_maxima = ruta.Cantidad_maxima,
                Cantidad_estimada = ruta.Cantidad_estimada,
            };
            _context.rutas.Add(_ruta);
            _context.SaveChanges();
        }

        //public List<Ruta> GetAllRutas() => _context.rutas.ToList();

        public List<RutaWithCamionVM> GetAllRutas()
        {
            var ruta = _context.rutas
                .Select(ruta => new RutaWithCamionVM()
                {
                    RutaName = ruta.RutaName,
                    Hora_llegada = ruta.Hora_llegada,
                    Hora_salida = ruta.Hora_salida,
                    Cantidad_maxima = ruta.Cantidad_maxima,
                    Cantidad_estimada = ruta.Cantidad_estimada,
                   
                    Numerocamion = ruta.Camion_Ruta
                        .Select(n => n.Camion.Id).ToList(),
                    
                }).ToList();

            return ruta;
        }
        public Ruta GetRutasById(int Id) => _context.rutas.FirstOrDefault(n => n.Id == Id);

        public Ruta EditarRuta(int Id, RutaVM ruta)
        {
            var _ruta = _context.rutas.FirstOrDefault(n => n.Id == Id);

            if (_ruta != null)
            {
                _ruta.RutaName = ruta.RutaName;
                _ruta.Hora_llegada = ruta.Hora_llegada;
                _ruta.Hora_salida=ruta.Hora_salida;
                _ruta.Cantidad_maxima = ruta.Cantidad_maxima;
                _ruta.Cantidad_estimada = ruta.Cantidad_estimada;
          

                _context.SaveChanges();//importante no olvidar nunca
            }
            return _ruta;
        }

        public void EliminarPorID(int Id)
        {
            var _ruta = _context.rutas.FirstOrDefault(n => n.Id == Id);

            if (_ruta != null)
            {
                _context.rutas.Remove(_ruta);
                _context.SaveChanges();//importante no olvidar nunca
            }
        }

        public RutaWithCamionVM GetRutaWithCamiones(int _IdRuta)
        {
            var _ruta = _context.rutas.Where(n => n.Id == _IdRuta).Select(n => new RutaWithCamionVM()
            {
                RutaName=n.RutaName,
                Hora_llegada = n.Hora_llegada,
                Hora_salida = n.Hora_salida,
                Cantidad_maxima=n.Cantidad_maxima,
                Cantidad_estimada=n.Cantidad_estimada,
                Numerocamion=n.Camion_Ruta.Select(n => n.Camion.Id).ToList(),

                

            }).FirstOrDefault();

            return _ruta;
        }

    }
}
