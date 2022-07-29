using Api.Models;
using Api.Repositories.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private IRepositoryWrapper _repository;

        public ProductsController([FromServices] IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _repository.Product.FindAll();
        }

        [HttpPost]
        public ActionResult<Product> Post([FromBody] Product product)
        {
            try
            {
                _repository.Product.Create(product);
                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public ActionResult<Product> Put([FromBody] Product product)
        {
            try
            {
                _repository.Product.Update(product);
                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("rescue/{userId}/{productId}")]
        public ActionResult<String> Rescue(long userId, long productId)
        {
            _repository.UserProduct.Create(new UserProduct()
            {
                UserId = userId,
                ProductId = productId
            });

            return Ok("Product was rescued!!");
        }
    }
}
