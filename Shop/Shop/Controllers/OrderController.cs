using AutoMapper;
using Shop.Api.Model.Input;
using Shop.Api.Model.Out;
using Shop.Api.Validators;
using Shop.Data;
using Shop.Data.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Shop.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IOrderProductRepository _repo;
        private readonly IMapper _mapper;
        private delegate T DtoConverter<T, K>(K dto);
        private readonly OrderAndProductValidator _validator;
        public OrderController(IOrderProductRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
            _validator = new OrderAndProductValidator();
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("{id}")]
        public ActionResult<OrderOutputModel> GetOrderById(int id)
        {
            var dataWrapper = _repo.OrderGetById(id);
            return MakeResponse(dataWrapper, _mapper.Map<OrderOutputModel>);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult<OrderOutputModel> CreateOrder(OrderInputModel inputModel)
        {
            var validationResult = _validator.CheckInputModel(inputModel);
            if (!string.IsNullOrWhiteSpace(validationResult)) return BadRequest(validationResult);
            var dataWrapper = _repo.CreateFullOrder(_mapper.Map<OrderDto>(inputModel));
            return MakeResponse(dataWrapper, _mapper.Map<OrderOutputModel>);
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
