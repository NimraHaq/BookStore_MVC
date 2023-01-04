using AutoMapper;
using EadProject.Models;
using EadProject.Data;

namespace EadProject.MappingConfigurations
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<BookTable, BookModel>().ReverseMap();
        }
    }
}
