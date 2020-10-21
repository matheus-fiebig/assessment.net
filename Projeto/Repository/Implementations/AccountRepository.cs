using System.Collections;
using System.Collections.Generic;
using Projeto.Data;
using System.Linq;
using Projeto.Repository.Interfaces;
using Projeto.Entities;

namespace Projeto.Repository.Implementations
{
    public class AccountRepository : IAccountRepository
    {
        private readonly BancoContext _context;

        public AccountRepository(BancoContext context)
        {
            _context = context;
        }

        public USUARIOS_LOGADOS GetNumeroLogados(){
            return _context.USUARIOS_LOGADOS.FirstOrDefault(x=>x.Id==1);
        }

        public void AlteraLogados(Enums.Enums.Operacao op){
            var logados = GetNumeroLogados();
            if(op==Enums.Enums.Operacao.Adiciona)
                logados.NumeroLogados+=1;
            else
                logados.NumeroLogados-=1;

            _context.SaveChanges();
        }
    }
}