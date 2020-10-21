using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Projeto.Entities;

namespace Projeto.Data
{
    public class BancoContext : IdentityDbContext
    {
        public DbSet<SALDO> SALDO {get;set;}
        public DbSet<USUARIOS_LOGADOS> USUARIOS_LOGADOS{get;set;}

        public BancoContext(DbContextOptions<BancoContext> opt):base(opt)
        {          
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //ADMIN
            builder.Entity<CLIENTE>().HasData(
                new CLIENTE()
                {
                    Id = "1",
                    UserName="Teste1",
                    Email = "teste1@teste.com",
                    SaldoId="1"

                });
            builder.Entity<SALDO>().HasData(
                new SALDO()
                {
                    Id="1",
                    SaldoAtual=100
                }
            );
            builder.Entity<CLIENTE>().HasData(
                new CLIENTE()
                {
                    Id = "2",
                    UserName="Teste2",
                    Email = "teste1@teste.com",
                    SaldoId="2"

                });
            builder.Entity<SALDO>().HasData(
                new SALDO()
                {
                    Id="2",
                    SaldoAtual=10
                }
            );

            builder.Entity<USUARIOS_LOGADOS>().HasData(
                new USUARIOS_LOGADOS(){
                    Id=1,
                    NumeroLogados=0,
                }
            );
            
            base.OnModelCreating(builder);
            builder.ApplyConfiguration<CLIENTE>(new ClienteConfig());  
            builder.ApplyConfiguration<SALDO>(new SaldoConfig());  
        }

    }
}