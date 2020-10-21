using System.Threading.Tasks;
using Projeto.Model;

namespace Projeto.Service
{
    public interface IAccountService
    {
        Task<ClienteModel> Login(LoginModel model);
        Task Logout();
    }
}