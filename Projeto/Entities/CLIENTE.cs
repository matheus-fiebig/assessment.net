using System;
using Microsoft.AspNetCore.Identity;

namespace Projeto.Entities
{
    public class CLIENTE : IdentityUser
    {

        public string SaldoId {get;set;}
        public SALDO Saldo{get;set;}
    }
}