using AutoMapper;
using Shop.Api.Model.Out;
using Shop.Core;
using Shop.Data.DTO;

namespace Shop.Api
{
    public class Mapper
    {
        private readonly IMapper _mapper;

        public Mapper(IMapper mapper)
        {
            _mapper = mapper;
        }
        public dynamic MapCategory(ProductDto productDto)
        {
            if (productDto.CategoryId == (int)Category.Microwaves) return _mapper.Map<MicrowaveOutputModel>(productDto);
            if (productDto.CategoryId == (int)Category.VacuumCleanrs) return _mapper.Map<VacuumCleanerOutputModel>(productDto);
            if (productDto.CategoryId == (int)Category.ElectricKettles) return _mapper.Map<ElectricKettlesOutputModel>(productDto);
            return -1;
        }
    }
}
