using System.Collections.Generic;
using System.Threading.Tasks;
using Projeto.Entities;
using Projeto.Model;

namespace Projeto.Service
{
    public interface IClienteService
    {
        IEnumerable<ClienteModel> GetCliente(string id);
        Task CreateCliente(ClienteForCreationModel model);
        Task DeleteCliente(string id);
        Task UpdateCliente(ClienteForUpdateModel model, string id);
    }
}