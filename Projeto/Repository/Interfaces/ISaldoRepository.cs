using System.Threading.Tasks;
using Projeto.Entities;
using Projeto.Repository.Interfaces;

namespace Projeto.Repository
{
    public interface ISaldoRepository
    {
        public Task<SALDO> GetSaldo(string id);
        public Task<SALDO> EditSaldo(string id, int qnt);

    }
}