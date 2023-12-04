using Microsoft.EntityFrameworkCore;
using WebApi_Camiones.Datos.Models;

namespace Api_Camiones.Datos
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {


        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Camionero_Camiones>()
                .HasOne(b => b.Camionero)
                .WithMany(ba => ba.Camionero_Camion)
                .HasForeignKey(bi=>bi.CamioneroId);
            modelBuilder.Entity<Camionero_Camiones>()
                .HasOne(b => b.Camion)
                .WithMany(ba => ba.Camionero_Camion)
                .HasForeignKey(bi => bi.CamionId);

        }
        public DbSet<Camionero> camioneros {get; set;}
        public DbSet<Camiones> camiones { get; set;}
        public DbSet<Camionero_Camiones> camionero_Camiones { get; set;}
    }
}
