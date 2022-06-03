using Domain.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Context
{
    public class BasicCrudAPIDbContext : DbContext
    {
        public BasicCrudAPIDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<BaseEntity>();

            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedDate = DateTime.UtcNow,
                    EntityState.Modified => data.Entity.UpdatedDate = DateTime.UtcNow,

                    _ => DateTime.UtcNow
                };
            }


            return base.SaveChangesAsync(cancellationToken);
        }

    }
}
