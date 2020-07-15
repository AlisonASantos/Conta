using Conta.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Conta.Infrastructure.Mappings
{
    public class LancamentosPorContaMapping : IEntityTypeConfiguration<LancamentosPorConta>
    {
        public void Configure(EntityTypeBuilder<LancamentosPorConta> builder)
        {
            builder.HasKey(x => x.Id);

            builder
            .Property(x => x.ContaCorrenteId)
            .IsRequired();

            builder
           .Property(x => x.ValorOperacao)
           .IsRequired();

            builder.HasOne(x => x.ContaCorrente);

        }
    }
}
