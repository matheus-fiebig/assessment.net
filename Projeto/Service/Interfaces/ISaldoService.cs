using System.Collections.Generic;
using Projeto.Model;

namespace Projeto.Service
{
    public interface ISaldoService
    {
        int VerSaldo(string id);
        SaldoModel MudarSaldo(SaldoModel model);
        List<int> SacarSaldo(SaldoModel model);
        
    }
}