using System.Collections.Generic;
using WebApi_Camiones.Datos.Models;

namespace WebApi_Camiones.Datos.ViewModels
{
    public class CamionesVM
    {
     
        public string Placas { get; set; }
        public string Modelo { get; set; }
        //
        public List<int> CamioneroID{ get; set; }
    }
    public class CamionesWhitCammionerosVM
    {

        public string Placas { get; set; }
        public string Modelo { get; set; }
        //
        public List<Camionero> Camionero { get; set; }
        
    }
}
