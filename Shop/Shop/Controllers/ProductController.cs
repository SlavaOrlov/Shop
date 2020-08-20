using AutoMapper;
using Shop.Api;
using Shop.Api.Model.Input;
using Shop.Api.Model.Out;
using Shop.Api.Validators;
using Shop.Data;
using Shop.Data.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Shop.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IOrderProductRepository _repo;
        private readonly IMapper _mapper;
        private delegate T DtoConverter<T, K>(K dto);
        private readonly OrderAndProductValidator _validator;
        private readonly Mapper _categoryMapper;
        public ProductController(IOrderProductRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
            _validator = new OrderAndProductValidator();
            _categoryMapper = new Mapper(_mapper);
        }
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult<ProductOutputModel> AddProduct(ProductInputModel inputModel)
        {

            var validationResult = _validator.CheckInputModel(inputModel);
            if (!string.IsNullOrWhiteSpace(validationResult)) return BadRequest(validationResult);
            var dataWrapper = _repo.ProductAdd(_mapper.Map<ProductDto>(inputModel));
            return MakeResponse(dataWrapper);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("{id}")]
        public ActionResult<ProductOutputModel> GetProductById(int id)
        {
            var dataWrapper = _repo.ProductGetById(id);
            return MakeResponse(dataWrapper);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public ActionResult<List<ProductOutputModel>> GetAllProducts()
        {
            var dataWrapper = _repo.ProductGetAll();
            return MakeResponse(dataWrapper, _mapper.Map<List<ProductOutputModel>>);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut]
        public ActionResult<ProductOutputModel> UpdateProduct(ProductInputModel inputModel)
        {
            var dataWrapper = _repo.ProductUpdate(_mapper.Map<ProductDto>(inputModel));
            return MakeResponse(dataWrapper);
        }


        private ActionResult<ProductOutputModel> MakeResponse(DataWrapper<ProductDto> dataWrapper)
        {
            if (!dataWrapper.IsOk)
            {
                return BadRequest(dataWrapper.ExceptionMessage);
            }
            return Ok(_categoryMapper.MapCategory(dataWrapper.Data));
        }

        private ActionResult<T> MakeResponse<T, K>(DataWrapper<K> dataWrapper, DtoConverter<T, K> dtoConverter)
        {
            if (!dataWrapper.IsOk)
            {
                return BadRequest(dataWrapper.ExceptionMessage);
            }
            return Ok(dtoConverter(dataWrapper.Data));
        }
    }
}
