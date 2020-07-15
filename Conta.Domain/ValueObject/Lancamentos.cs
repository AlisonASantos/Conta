using Conta.Domain.Enumeradores;
using Conta.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Conta.Domain.ObjetoDeValor
{
    public class Lancamentos
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public ContaCorrente ContaCorrente { get; set; }

        public bool Debito
        {
            get { return Id == (int)TipoLancamento.Debito; }
        }

        public bool Credito
        {
            get { return Id == (int)TipoLancamento.Credito; }
        }
    }
}
