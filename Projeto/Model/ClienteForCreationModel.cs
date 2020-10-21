using Projeto.Entities;

namespace Projeto.Model
{
    public class ClienteForCreationModel
    {
        public string UserName {get;set;}
        public string Email { get; set; }
        public string Password {get;set;}
        public SaldoModel Saldo { get; set; }
    }
}