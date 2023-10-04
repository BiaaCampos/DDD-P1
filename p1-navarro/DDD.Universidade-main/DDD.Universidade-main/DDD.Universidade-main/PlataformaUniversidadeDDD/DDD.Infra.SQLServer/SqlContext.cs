using DDD.Domain.GeralContext;
using DDD.Domain.UserManagementContext;
using Microsoft.EntityFrameworkCore;

namespace DDD.Infra.SQLServer
{
    public class SqlContext : DbContext
    {

        //https://balta.io/blog/ef-crud
        //https://jasonwatmore.com/post/2022/03/18/net-6-connect-to-sql-server-with-entity-framework-core

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=UniversidadeDb");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Eventos>()
                .HasMany(e => e.Compradores)
                .WithMany(e => e.Eventos)
                .UsingEntity<Venda>();


            modelBuilder.Entity<User>().UseTpcMappingStrategy();
            modelBuilder.Entity<Eventos>().ToTable("Eventos");
            //https://learn.microsoft.com/pt-br/ef/core/modeling/inheritance
        }

        public DbSet<Eventos> Eventos { get; set; }
        public DbSet<Comprador> Comprador { get; set; }
        public DbSet<Venda> Venda { get; set; }
        public DbSet<User> Users { get; set; }
    }
}