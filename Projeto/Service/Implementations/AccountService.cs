using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Primitives;
using Projeto.Entities;
using Projeto.Model;
using Projeto.Repository.Interfaces;

namespace Projeto.Service
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<CLIENTE> _userManager;
        private readonly SignInManager<CLIENTE> _signInManager;
        private readonly IAccountRepository _repository;
        private readonly IMapper _mapper;

        public AccountService(UserManager<CLIENTE> userManager,SignInManager<CLIENTE> signInManager, IAccountRepository repository, IMapper mapper )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ClienteModel> Login(LoginModel model){
            
            if (model == null){
                throw new System.Exception("Null model");
            }

            var user = await _userManager.FindByNameAsync(model.UserName);
            if(user.Id=="1" || user.Id=="2")
                await _userManager.AddPasswordAsync(user,"Asd123!@#");

            if(IsMaxLogados()){
                throw new System.Exception("Max Logados");
            }

            var res = await _signInManager.PasswordSignInAsync(model.UserName,model.Password,false,false);
            
            if (!res.Succeeded){
                throw new System.Exception("Error login");
            }
            _repository.AlteraLogados(Enums.Enums.Operacao.Adiciona);
            
            return _mapper.Map<ClienteModel>(user);
        }

        public async Task Logout(){
            await this._signInManager.SignOutAsync();
            _repository.AlteraLogados(Enums.Enums.Operacao.Remove);
            return;
        }

        private bool IsMaxLogados(){
            var usuariosLogados = _repository.GetNumeroLogados();
            if(usuariosLogados.NumeroLogados==5){
                return true;
            }
            return false;
        }
    }
}