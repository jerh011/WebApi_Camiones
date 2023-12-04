using WebApi_Camiones.Datos.Models;
using WebApi_Camiones.Datos.ViewModels;

using System;
using Api_Camiones.Datos;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace WebApi_Camiones.Datos.Services
{
    public class CamionerosService
    {
        private AppDbContext _context;
        public CamionerosService(AppDbContext context)
        {
            _context = context;
        }
        public void AgregarCamionero(CamioneroVM camionero)
        {
            var _camionero =  new Camionero()
            { 
               Nombres = camionero.Nombres,
               Apellido_Paterno=camionero.Apellido_Paterno,
               Apellido_Materno=camionero.Apellido_Materno,
               Numero_telefono=camionero.Numero_telefono
            };
            _context.camioneros.Add(_camionero);
            _context.SaveChanges();
        }
       
        public List<Camionero> GetAllCamioneros()=>_context.camioneros.ToList();
       
        public Camionero GetCamionerosByID(int Id) => _context.camioneros.FirstOrDefault(n => n.Id == Id);

        public Camionero EditarCamionero(int Id, CamioneroVM camionero)
        {
           var _camionero= _context.camioneros.FirstOrDefault(n => n.Id == Id);

            if (_camionero != null)
            {
                _camionero.Nombres = camionero.Nombres;
                _camionero.Apellido_Paterno = camionero.Apellido_Paterno;
                _camionero.Apellido_Materno = camionero.Apellido_Materno;
                _camionero.Numero_telefono = camionero.Numero_telefono;
                _context.SaveChanges();//importante no olvidar nunca
            }
            return _camionero;
        }

        public void EliminarPorID(int Id)
        {
            var _camionero = _context.camioneros.FirstOrDefault(n => n.Id == Id);

            if (_camionero != null)
            {
                _context.camioneros.Remove(_camionero);
                _context.SaveChanges();//importante no olvidar nunca
            }
        }




    }
}
