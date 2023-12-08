using System;
using WebApi_Camiones.Controllers;
using WebApi_Camiones.Datos;
using WebApi_Camiones.Datos.Services;

namespace WebApi_Camiones.Datos.Exceptiones
{
    public class CamioneroNotFoundException : Exception
    {
        public CamioneroNotFoundException(string message) : base(message)
        {
        }
    }
}