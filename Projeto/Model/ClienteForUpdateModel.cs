using Projeto.Entities;

namespace Projeto.Model
{
    public class ClienteForUpdateModel
    {
        public string UserName {get;set;}
        public string Email { get; set; }
        public string NewPassword {get;set;} = "";
        public string CurrentPassword{get;set;}="";
    }
}