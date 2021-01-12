using Com.Capgemini.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Linq;
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
