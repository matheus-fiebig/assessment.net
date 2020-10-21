using AutoMapper;
using Projeto.Entities;
using Projeto.Model;

namespace Projeto.Profiles
{
    public class AllProfiles: Profile
    {
        public AllProfiles()
        {
            CreateMap<CLIENTE, ClienteModel>().ReverseMap();
            CreateMap<CLIENTE, ClienteForCreationModel>().ReverseMap();
            CreateMap<CLIENTE, ClienteForUpdateModel>().ReverseMap();
            CreateMap<SALDO,SaldoModel>().ReverseMap();
        }
    }
}