using Application.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistance.Context;
using Persistance.Repositories.ProductRepositories;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance
{
    public static class ServiceRegistiration
    {
        public static void AddPersistanceServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<BasicCrudAPIDbContext>(options => options.UseNpgsql(connectionString:configuration.GetConnectionString("PostgreSQL")));
            services.AddScoped<IProductReadRepository,ProductReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();

        }
    }
}
