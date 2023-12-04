namespace WebApi_Camiones.Datos.Models
{
    public class Camionero_Camiones
    {
        public int Id { get; set; }
        public string CamionId { get; set; }
        public Camiones Camion { get; set; }
        public int CamioneroId { get; set; }
        public Camionero Camionero { get; set; }
    }
}
