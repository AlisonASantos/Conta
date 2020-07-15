using Conta.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Conta.Domain.Interfaces
{
    public interface ILancamentosPorContaService : IDisposable
    {
        Task<bool> Debito(LancamentosPorConta lancamentosPorConta);
        Task<bool> Credito(LancamentosPorConta lancamentosPorConta);
    }
}
