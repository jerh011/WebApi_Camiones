using System;

namespace WebApi_Camiones.Datos.Models
{
    public class Monitoreo
    {
        public int Id { get; set; }
        public DateTime Hora { get; set; }

        // Relación con Camiones
        public int CamionId { get; set; }
        public Camiones Camion { get; set; }
    }

}
