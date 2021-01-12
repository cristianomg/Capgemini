using Com.Capgemini.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Com.Capgemini.Infra.Context
{
    public sealed class CapgeminiContext : DbContext
    {
        public CapgeminiContext(DbContextOptions<CapgeminiContext> options) : base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
            this.Database.Migrate();
        }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
