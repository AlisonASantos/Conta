using Conta.Domain.Enumeradores;
using Conta.Domain.Models;
using Conta.Domain.ObjetoDeValor;
using System;
using System.Collections.Generic;
using System.Text;

namespace Conta.Domain.Models
{
    public class ContaCorrente
    {
        public int Id { get; set; }
        public string NumeroConta { get; set; }
        public string TitularConta { get; set; }
        public double SaldoConta { get; set; }
        public List<LancamentosPorConta> LancamentosPorContas { get; set; }
    }
}
