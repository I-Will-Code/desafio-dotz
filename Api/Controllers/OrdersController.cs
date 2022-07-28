using Api.Models;
using Api.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private IRepositoryWrapper _repository;

        public OrdersController([FromServices] IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        [HttpGet("{userId}")]
        public ActionResult<ICollection<Order>> Get(long userId)
        {
            var orders = _repository.Order.FindByCondition(cond => cond.UserId == userId).ToList();

            if (orders.Count == 0)
            {
                return NotFound();
            }

            return Ok(orders);
        }

        [HttpPost]
        public ActionResult<Order> Post([FromBody] Order order)
        {
            try
            {
                _repository.Order.Create(order);
                return Ok(order);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public ActionResult<Order> Put([FromBody] Order order)
        {
            try
            {
                _repository.Order.Update(order);
                return Ok(order);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
