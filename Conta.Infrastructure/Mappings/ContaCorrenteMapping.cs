using Conta.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Conta.Infrastructure.Mappings
{
    public class ContaCorrenteMapping : IEntityTypeConfiguration<ContaCorrente>
    {
        public void Configure(EntityTypeBuilder<ContaCorrente> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(p => p.NumeroConta)
             .IsRequired();

            builder.Property(p => p.TitularConta)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(p => p.SaldoConta)
                .IsRequired();

            builder.HasMany(f => f.LancamentosPorContas)
            .WithOne(p => p.ContaCorrente)
            .HasForeignKey(p => p.ContaCorrenteId);

        }
    }
}
