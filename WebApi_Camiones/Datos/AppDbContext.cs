using Microsoft.EntityFrameworkCore;
using WebApi_Camiones.Datos.Models;

namespace Api_Camiones.Datos
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {


        }
        public DbSet<Camionero> camioneros {get; set;}
    }
}
