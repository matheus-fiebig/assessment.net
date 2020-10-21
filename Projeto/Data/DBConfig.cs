using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto.Entities;

namespace Projeto.Data
{
    public class ClienteConfig : IEntityTypeConfiguration<CLIENTE>
    {
        public void Configure(EntityTypeBuilder<CLIENTE> builder)
        {
            //builder.HasOne(p=>p.Saldo).WithOne(s=>s.Cliente).HasForeignKey<SALDO>(x=>x.ClienteId);
        }
    }

    public class SaldoConfig : IEntityTypeConfiguration<SALDO>
    {

        public void Configure(EntityTypeBuilder<SALDO> builder)
        {
            builder.HasOne(p=>p.Cliente).WithOne(s=>s.Saldo).HasForeignKey<CLIENTE>(x=>x.SaldoId);
        }
    }
}