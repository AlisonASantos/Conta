using Conta.Domain.Notificacoes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Conta.Domain.Interfaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}
