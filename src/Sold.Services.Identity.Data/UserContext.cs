using Microsoft.EntityFrameworkCore;
using Sold.Services.Core.Data;
using Sold.Services.Identity.Domain.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Sold.Services.Identity.Data
{
    public class UserContext : DbContext, IUnitOfWork
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder model)
        {
            foreach (var property in model.Model.GetEntityTypes().SelectMany(
                e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            model.ApplyConfigurationsFromAssembly(typeof(UserContext).Assembly);
        }
        public async Task<bool> Commit()
        {
            return await base.SaveChangesAsync() > 0;
        }
    }
}