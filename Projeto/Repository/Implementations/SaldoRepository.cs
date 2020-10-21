using Microsoft.EntityFrameworkCore;
using Projeto.Data;
using Projeto.Entities;
using Projeto.Repository.Implementations;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Repository
{
    public class SaldoRepository :ISaldoRepository
    {
        private readonly BancoContext _context;

        public SaldoRepository(BancoContext context)
        {
            _context = context;
        }

        public async Task<SALDO> EditSaldo(string id, int qnt)
        {
            var saldo = await GetSaldo(id);
            saldo.SaldoAtual += qnt;
            await _context.SaveChangesAsync();
            return saldo;
        }

        public async Task<SALDO> GetSaldo(string id)
        {
            return await _context.SALDO.Include(x=>x.Cliente)
                                        .Where(x=>x.Cliente.Id.Equals(id))
                                        .FirstOrDefaultAsync();
        }
        
    }
}