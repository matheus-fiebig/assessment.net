using Projeto.Entities;

namespace Projeto.Model
{
    public class ClienteModel
    {
        public string Id { get; set; }
        public string UserName {get;set;}
        public string Email { get; set; }
        public SaldoModel Saldo { get; set; }
    }
}