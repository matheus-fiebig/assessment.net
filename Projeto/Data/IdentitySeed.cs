using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Projeto.Entities;

namespace Projeto.Data
{
    public static class IdentitySeed
    {
        public static void SeedData(RoleManager<IdentityRole> roleManager, UserManager<CLIENTE> userManager)
        {
            SeedRole(roleManager);
            SeedUsers(userManager);
        }
        
        private static void SeedRole(RoleManager<IdentityRole> _roleManager)
        {
            _roleManager.CreateAsync(new IdentityRole{Name="Admin"}).Wait();
        }

        private static void SeedUsers(UserManager<CLIENTE> _userManager)
        {
            var adm = Task.Run(()=>_userManager.FindByIdAsync("1")).Result;   
            _userManager.AddToRoleAsync(adm,"Admin").Wait();
        }
    }
}