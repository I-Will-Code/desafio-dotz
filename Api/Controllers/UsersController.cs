using Api.Models;
using Api.Repositories.Contracts;
using Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IRepositoryWrapper _repository;

        public UsersController([FromServices] IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Authorize]
        public IQueryable<User> GetAll()
        {
            return _repository.User.FindAll();
        }

        [HttpGet("{userid}")]
        [Authorize]
        public ActionResult<User> GetUser(long userid)
        {
            var user = _repository.User.FindByCondition(c => c.Id == userid);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public ActionResult<User> PostUser([FromBody] User user)
        {
            try
            {
                _repository.User.Create(user);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Authorize]
        public ActionResult<User> PutUser([FromBody] User user)
        {
            try
            {
                _repository.User.Update(user);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{userid}")]
        [Authorize]
        public ActionResult<User> Delete(long userid)
        {
            var userToRemove = _repository.User.FindById(userid);

            if(userToRemove == null)
            {
                return NotFound();
            }

            return Ok(_repository.User.Delete(userToRemove));
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public ActionResult<dynamic> Authenticate([FromBody] User user)
        {
            var returnedUser = _repository.User.FindByCondition(cond => cond.Email == user.Email && cond.Password == user.Password).FirstOrDefault();

            if (returnedUser == null)
                return NotFound(new { message = "Incorrect username or password" });

            var token = TokenService.GenerateToken(returnedUser);
            returnedUser.Password = "";
            return Ok(new
            {
                user = user,
                token = token
            });
        }
    }
}
