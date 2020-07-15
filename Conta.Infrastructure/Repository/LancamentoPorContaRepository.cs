using Conta.Domain.Interfaces;
using Conta.Domain.Models;
using Conta.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Conta.Infrastructure.Repository
{
    public class LancamentoPorContaRepository : BaseRepository<LancamentosPorConta>, ILancamentoPorContaRepository
    {
        public LancamentoPorContaRepository(MeuDbContext meuDbContext) : base(meuDbContext)
        {
        }
    }
}

