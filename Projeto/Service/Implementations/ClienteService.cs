using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Projeto.Entities;
using Projeto.Model;
using Projeto.Repository.Interfaces;

namespace Projeto.Service
{
    public class ClienteService : IClienteService
    {
        private readonly IMapper _mapper;
        private readonly IClienteRepository _repository;

        public ClienteService(IMapper mapper,
                              IClienteRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public IEnumerable<ClienteModel> GetCliente(string id)
        {
            var res = Task.Run(()=>_repository.GetCLIENTES(id)).Result;
            var map = _mapper.Map<IEnumerable<ClienteModel>>(res);
          
            return map;
        }

        public async Task CreateCliente(ClienteForCreationModel model)
        {

            if(model==null){
                throw new Exception("Erro");
            }   

            var cliente = _mapper.Map<CLIENTE>(model);
            var res = await _repository.CreateCLIENTE(cliente,model.Password); 
            
            if(res.Succeeded)
                return; 

            throw new Exception("Erro");
        }

        public async Task UpdateCliente(ClienteForUpdateModel model, string id)
        {
                
            if(model==null){
                throw new System.Exception("Erro");
            }   
            
            var cliente = _mapper.Map<CLIENTE>(model);
            var res = await _repository.UpdateCLIENTE(id,cliente,model.CurrentPassword,model.NewPassword); 
            
            if(res.Succeeded)
                return; 

            throw new Exception("Erro");
        }

        public async Task DeleteCliente(string id)
        {
            if(String.IsNullOrEmpty(id)){
                throw new System.Exception("Erro");
            }   
            
            var res = await _repository.DeleteCLIENTE(id);
            
            if(res.Succeeded)
                return; 
            
            throw new Exception("Erro");
        }  

        

    }
}