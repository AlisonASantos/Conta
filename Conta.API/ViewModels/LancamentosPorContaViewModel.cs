using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Conta.API.ViewModels
{
    public class LancamentosPorContaViewModel
    {
        [Key]
        public int Id { get; set; }
        public int ContaCorrenteId { get; set; }
        public double ValorOperacao { get; set; }
        public ContaCorrenteViewModel ContaCorrente { get; set; }
    }
}
