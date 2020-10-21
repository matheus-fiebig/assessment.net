using System;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using Projeto.Data;
using Projeto.Entities;
using Projeto.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using AutoMapper;

namespace Projeto.Repository.Implementations
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly BancoContext _context;
        private readonly UserManager<CLIENTE> _userManager;

        public ClienteRepository(BancoContext context,UserManager<CLIENTE> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IEnumerable<CLIENTE>> GetCLIENTES(string id)
        {
            if(!String.IsNullOrEmpty(id))
                return await _userManager.Users.Include(x=>x.Saldo).Where(x=>x.Id==id).ToListAsync();
           
            return  await _userManager.Users.Include(x=>x.Saldo).ToListAsync();
        } 

        public async Task<IdentityResult> CreateCLIENTE(CLIENTE cliente, string password)
        {
            cliente.Saldo.Id = Guid.NewGuid().ToString();
            return await _userManager.CreateAsync(cliente,password);
        }

        public async Task<IdentityResult> UpdateCLIENTE(string id,CLIENTE cliente, string currentPassword="",string newPassword="")
        {
            var clienteBD = _userManager.Users.FirstOrDefault(x=>x.Id.Equals(id));
          
            clienteBD.UserName = cliente.UserName;
            clienteBD.Email = cliente.Email;

            if(!String.IsNullOrEmpty(currentPassword))
                await _userManager.ChangePasswordAsync(cliente, currentPassword,newPassword);
       
            return await _userManager.UpdateAsync(clienteBD);
        }

        public async Task<IdentityResult> DeleteCLIENTE(string id)
        {
            var cliente =  await GetCLIENTES(id);
            return await _userManager.DeleteAsync(cliente.FirstOrDefault());
        
        }
        
    }
}