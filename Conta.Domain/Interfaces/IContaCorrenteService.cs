using Conta.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Conta.Domain.Interfaces
{
    public interface IContaCorrenteService : IDisposable
    {
        Task<bool> Adicionar(ContaCorrente contaCorrente);
    }
}
