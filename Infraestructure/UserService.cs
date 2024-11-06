using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UserService.data;

namespace UserService.Infraestructure
{
    public class Startup
    {
         public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DbContextI>(options =>
                options.UseSqlServer("YourConnectionString")); // Cambia por tu cadena de conexión
            services.AddControllers();
            services.AddMediatR(typeof(Program).Assembly);
        }
    }
}