

using AplicationLayer.DTO_s;
using AutoMapper;
using DomainLayer.Entities;

namespace AplicationLayer.Mapping
{
    public class MappingProfile : Profile 
    {
        public MappingProfile() 
        {
            CreateMap<Item, ItemDto>()
                .ReverseMap();
            CreateMap<Item, SaveItemDto>()
                .ReverseMap();

            CreateMap<Auction, AuctonDto>()
                .ReverseMap();

            CreateMap<Auction, SaveAuctonDto>()
               .ReverseMap();
        }
    }
}
