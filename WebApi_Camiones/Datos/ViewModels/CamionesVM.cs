using System.Collections.Generic;
using WebApi_Camiones.Datos.Models;

namespace WebApi_Camiones.Datos.ViewModels
{
    public class CamionesVM
    {
     
        public string Placas { get; set; }
        public string Modelo { get; set; }
        //
        public List<int> RutaID { get; set; }
        public List<int> CamioneroID{ get; set; }
    }
    public class CamionesWhitCamionerosWithRutaVM
    {
        public int Id { get; set; }
        public string Placas { get; set; }
        public string Modelo { get; set; }
        public List<string> camionero { get; set; }
        public List<string> RutaName { get; set; }
    }
}
