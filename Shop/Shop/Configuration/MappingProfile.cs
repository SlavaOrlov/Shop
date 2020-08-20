using AutoMapper;
using Shop.Api.Model.Input;
using Shop.Api.Model.Out;
using Shop.Core;
using Shop.Data;
using Shop.Data.DTO;
using System;

namespace Shop.Api.Configuration
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductDto, MicrowaveOutputModel>()
                .ForMember(dest => dest.Category, o => o.MapFrom(src => Enum.GetName(typeof(Category), src.CategoryId)));
            CreateMap<ProductDto, VacuumCleanerOutputModel>()
                .ForMember(dest => dest.Category, o => o.MapFrom(src => Enum.GetName(typeof(Category), src.CategoryId)));
            CreateMap<ProductDto, ElectricKettlesOutputModel>()
                .ForMember(dest => dest.Category, o => o.MapFrom(src => Enum.GetName(typeof(Category), src.CategoryId)));
            
            CreateMap<ProductInputModel, ProductDto>();
            
            CreateMap<OrderInputModel, OrderDto>()
                .ForPath(dest => dest.ProductDto, o => o.MapFrom(src => src.ProductDto));

            CreateMap<OrderDto, OrderOutputModel>()
                .ForPath(dest => dest.ProductDto, o => o.MapFrom(src => src.ProductDto));
        }
    }
}
