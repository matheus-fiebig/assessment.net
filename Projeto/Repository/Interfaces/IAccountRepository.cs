using Projeto.Entities;

namespace Projeto.Repository.Interfaces
{
    public interface IAccountRepository
    {
        USUARIOS_LOGADOS GetNumeroLogados();
        void AlteraLogados(Enums.Enums.Operacao op);
    }
}