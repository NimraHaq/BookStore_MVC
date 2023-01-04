using AutoMapper;
using EadProject.Models;
using EadProject.Data;

namespace EadProject.MappingConfigurations
{
    public class SellerProfile : Profile
    {
        public SellerProfile()
        {
            CreateMap<SellerTable, SellerModel>().ReverseMap();
        }
    }
}
