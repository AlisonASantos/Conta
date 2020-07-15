using Conta.Domain.Models;
using Conta.Domain.ObjetoDeValor;
using Conta.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Conta.Infrastructure.Context
{
    public class MeuDbContext : DbContext
    {
        public DbSet<ContaCorrente> ContaCorrentes { get; set; }
        public DbSet<Lancamentos> Lancamentos { get; set; }

        public MeuDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                       .SelectMany(e => e.GetProperties()
                           .Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MeuDbContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            modelBuilder.Entity<Lancamentos>().HasData(
            new Lancamentos()
            {
                Id = 1,
                Nome = "Débito",
                Descricao = "Débito em conta"
            },
            new Lancamentos()
            {
                Id = 2,
                Nome = "Crédito",
                Descricao = "Crédito em conta"
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
