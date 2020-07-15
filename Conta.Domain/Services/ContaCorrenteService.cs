using Conta.Domain.Interfaces;
using Conta.Domain.Models;
using Conta.Domain.Models.Validations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Conta.Domain.Services
{
    public class ContaCorrenteService : BaseService, IContaCorrenteService
    {
        private readonly IContaCorrenteRepository _contaCorrenteRepository;

        public ContaCorrenteService(IContaCorrenteRepository contaCorrenteRepository,
            INotificador notificador) : base(notificador)
        {
            _contaCorrenteRepository = contaCorrenteRepository;
        }

        public async Task<bool> Adicionar(ContaCorrente contaCorrente)
        {
            if (!ExecutarValidacao(new ContaCorrenteValidations(), contaCorrente)) return false;
            var conta = _contaCorrenteRepository.ObterConta(contaCorrente.NumeroConta).Result;
            if (conta != null)
            {
                Notificar("Já existe uma conta com este número informado.");
                return false;
            }

            await _contaCorrenteRepository.Adicionar(contaCorrente);
            return true;
        }

        public void Dispose()
        {
            _contaCorrenteRepository?.Dispose();
        }
    }
}
