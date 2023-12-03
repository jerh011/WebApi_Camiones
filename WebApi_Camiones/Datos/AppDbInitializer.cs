using WebApi_Camiones.Datos.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using Api_Camiones.Datos;

namespace WebApi_Camiones.Datos
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder) 
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            { 
                var context= serviceScope.ServiceProvider.GetService<AppDbContext>();
                if (!context.camioneros.Any()) 
                {
                    context.camioneros.AddRange(
                        new Camionero() 
                        {
                            Nombres ="jesus",
                            Apellido_Paterno="xd",
                            Apellido_Materno="",
                            Numero_telefono="6441031664"

                        },
                        new Camionero() 
                        {
                            Nombres = "1",
                            Apellido_Paterno = "1",
                            Apellido_Materno = "1",
                            Numero_telefono = "1"
                        }
                        );        
                    context.SaveChanges();
                }
            }
        }

    }
}
