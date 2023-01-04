using AutoMapper;
using EadProject.Models;
using EadProject.Data;

namespace EadProject.MappingConfigurations
{
    public class BuyerProfile : Profile
    {
        public BuyerProfile()
        {
            CreateMap<BuyerTable, BuyerModel>().ReverseMap();
        }
    }
}
