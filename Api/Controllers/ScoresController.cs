using Api.Models;
using Api.Repositories.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoresController : ControllerBase
    {
        private IRepositoryWrapper _repository;

        public ScoresController([FromServices] IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        [HttpGet("{userid}")]
        public ActionResult<Score> Get(long userid)
        {
            return Ok(_repository.Score.FindByCondition(cond => cond.User.Id == userid).FirstOrDefault());
        }

        [HttpPost]
        public ActionResult<Score> Post([FromBody] Score score)
        {
            try
            {
                _repository.Score.CreateScore(score, _repository);
                return Ok(score);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public ActionResult<Score> Put([FromBody] Score score)
        {
            try
            {
                _repository.Score.UpdateScore(score, _repository);
                return Ok(score);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("balance/{userid}")]
        [Authorize]
        public ActionResult<Score> GetScoreBalance(long userid)
        {
            return Ok(_repository.Score.FindByCondition(cond => cond.User.Id == userid).FirstOrDefault());
        }

        [HttpGet("extract/{userid}")]
        [Authorize]
        public ActionResult<ScoreExtract> GetScoreExtract(long userid)
        {
            return Ok();
        }
    }}
