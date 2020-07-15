using Conta.Domain.Interfaces;
using Conta.Domain.Models;
using Conta.Domain.Models.Validations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Conta.Domain.Services
{
    public class LancamentosPorContaService : BaseService, ILancamentosPorContaService
    {
        public readonly ILancamentoPorContaRepository _lancamentoPorContaRepository;
        private readonly IContaCorrenteRepository _contaCorrenteRepository;

        public LancamentosPorContaService(ILancamentoPorContaRepository lancamentoPorContaRepository,
            IContaCorrenteRepository contaCorrenteRepository,
            INotificador notificador) : base(notificador)
        {
            _lancamentoPorContaRepository = lancamentoPorContaRepository;
            _contaCorrenteRepository = contaCorrenteRepository;
        }

        public async Task<bool> Debito(LancamentosPorConta lancamentosPorConta)
        {
            var conta = ObterContaCorrente(lancamentosPorConta.ContaCorrente.NumeroConta);

            if (!VerificaConta(conta)) return false;

            lancamentosPorConta.ContaCorrente = conta;
            lancamentosPorConta.ContaCorrente.SaldoConta -= lancamentosPorConta.ValorOperacao;
            lancamentosPorConta.TipoLancamento = Enumeradores.TipoLancamento.Debito;

            return await Adicionar(lancamentosPorConta);
        }

        public async Task<bool> Credito(LancamentosPorConta lancamentosPorConta)
        {
            var conta = ObterContaCorrente(lancamentosPorConta.ContaCorrente.NumeroConta);

            if (!VerificaConta(conta)) return false;

            lancamentosPorConta.ContaCorrente = conta;
            lancamentosPorConta.ContaCorrente.SaldoConta += lancamentosPorConta.ValorOperacao;
            lancamentosPorConta.TipoLancamento = Enumeradores.TipoLancamento.Credito;
            
            return await Adicionar(lancamentosPorConta);
        }

        public ContaCorrente ObterContaCorrente(string numeroConta)
        {
            return _contaCorrenteRepository.ObterConta(numeroConta).Result;
        }

        public async Task<bool> Adicionar(LancamentosPorConta lancamentosPorConta)
        {
            await _contaCorrenteRepository.Atualizar(lancamentosPorConta.ContaCorrente);
            await _lancamentoPorContaRepository.Adicionar(lancamentosPorConta);

            return true;
        }


        public bool VerificaConta(ContaCorrente conta)
        {
            if (!ExecutarValidacao(new ContaCorrenteValidations(), conta)) return false;

            if (conta == null)
            {
                Notificar("Conta inexistente, por favor cadastre ou informe correta uma conta para realizar a operação.");
                return false;
            }

            return true;
        }

        public void Dispose()
        {
            _lancamentoPorContaRepository?.Dispose();
        }
    }
}
