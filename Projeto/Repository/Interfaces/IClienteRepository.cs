using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Projeto.Entities;

namespace Projeto.Repository.Interfaces
{
    public interface IClienteRepository
    {
        Task<IEnumerable<CLIENTE>> GetCLIENTES(string id);
        Task<IdentityResult> CreateCLIENTE(CLIENTE cliente, string password);
        Task<IdentityResult> DeleteCLIENTE(string id);
        Task<IdentityResult> UpdateCLIENTE(string id,CLIENTE cliente, string currentPassword="",string newPassword="");
    }
}