using Api.Models;
using Api.Repositories.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AddressesController : ControllerBase
    {
        private IRepositoryWrapper _repository;

        public AddressesController([FromServices] IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<Address> Get()
        {
            return _repository.Address.FindAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Address> Get(long id)
        {
            var address = _repository.Address.FindById(id);

            if (address == null)
            {
                return NotFound();
            }

            return Ok(address);
        }

        [HttpPost]
        public ActionResult<Address> Post([FromBody] Address address)
        {
            try 
            {
                return Ok(_repository.Address.Create(address));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public ActionResult<Address> Put([FromBody] Address address)
        {
            try
            {
                return Ok(_repository.Address.Update(address));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(long id)
        {
            var addressToRemove = _repository.Address.FindById(id);

            if (addressToRemove == null)
            {
                return NotFound();
            }

            return Ok(_repository.Address.Delete(addressToRemove));
        }
    }
}
