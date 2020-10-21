using System;
namespace Projeto.Entities
{
    public class SALDO
    {
        public string Id {get;set;}
        public int SaldoAtual { get; set; }
        public string ClienteId {get;set;}
        public CLIENTE Cliente {get;set;}

    }
}