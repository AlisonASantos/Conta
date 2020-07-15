using Conta.API.Controllers;
using Conta.API.ViewModels;
using Conta.Domain.Interfaces;
using Conta.Domain.Models;
using Moq;
using System;
using Xunit;

namespace Conta.Teste
{
    public class TesteDebito
    {
        [Fact]
        public void TesteDebito1()
        {
            var contaCorrente = new ContaCorrente
            {
                NumeroConta = "123456",
                SaldoConta = 10000
            };

            var lancamentos = new LancamentosPorConta
            {
                Id = 1,
                ValorOperacao = 10.5,
                ContaCorrente = contaCorrente
            };

            var mock = new Mock<ILancamentosPorContaService>();
            mock.Setup(x => x.Debito(lancamentos));
        }
    }
}
