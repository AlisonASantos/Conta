using Conta.Domain.Interfaces;
using Conta.Domain.Models;
using Conta.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Conta.Infrastructure.Repository
{
    public class ContaCorrenteRepository : BaseRepository<ContaCorrente>, IContaCorrenteRepository
    {
        public ContaCorrenteRepository(MeuDbContext meuDbContext) : base(meuDbContext)
        {
        }

        public virtual async Task<ContaCorrente> ObterConta(string conta)
        {
            return await Db.ContaCorrentes.AsNoTracking().FirstOrDefaultAsync(p => p.NumeroConta == conta);
        }
    }
}
