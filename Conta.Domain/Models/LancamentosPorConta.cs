using Conta.Domain.Enumeradores;
using Conta.Domain.ObjetoDeValor;
using System;
using System.Collections.Generic;
using System.Text;

namespace Conta.Domain.Models
{
    public class LancamentosPorConta
    {
        public int Id { get; set; }
        public int ContaCorrenteId { get; set; }
        public double ValorOperacao { get; set; }
        public TipoLancamento TipoLancamento { get; set; }
        public ContaCorrente ContaCorrente { get; set; }
    }
}
