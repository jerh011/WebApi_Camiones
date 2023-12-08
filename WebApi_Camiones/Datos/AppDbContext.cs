using Microsoft.EntityFrameworkCore;
using WebApi_Camiones.Datos.Models;
using WebApi_Camiones.Controllers;
using WebApi_Camiones.Datos.Services;

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
            modelBuilder.Entity<Monitoreo>()
        .HasOne(m => m.Camion)
        .WithMany(c => c.Monitoreos)
        .HasForeignKey(m => m.CamionId);


        }
        public DbSet<Monitoreo> Monitoreos { get; set; }

        public DbSet<Camionero> camioneros {get; set;}
        public DbSet<Camiones> camiones { get; set;}
        public DbSet<Camionero_Camiones> camionero_Camiones { get; set;}
    }
}
