using Conta.Domain.ObjetoDeValor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Conta.Infrastructure.Mappings
{
    public class LancamentosMapping : IEntityTypeConfiguration<Lancamentos>
    {
        public void Configure(EntityTypeBuilder<Lancamentos> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(40);

            builder
                .Property(x => x.Descricao)
                .IsRequired()
                .HasMaxLength(400);
        }
    }
}
