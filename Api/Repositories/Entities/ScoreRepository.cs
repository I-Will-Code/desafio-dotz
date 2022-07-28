using Api.Context;
using Api.Models;
using Api.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace Api.Repositories.Entities
{
    public class ScoreRepository : RepositoryBase<Score>, IScoreRepository
    {
        public ScoreRepository(RepositoryContext repositoryContext)
           : base(repositoryContext)
        {
        }

        public Score CreateScore(Score score, IRepositoryWrapper repository)
        {
            base.Create(score);

            repository.ScoreExtract.Create(new ScoreExtract()
            {
                ScoreId = score.Id,
                CreatedAt = DateTime.Now,
                Description = $"Saldo: {score.Total}"
            });

            return score;
        }

        public Score UpdateScore(Score score, IRepositoryWrapper repository)
        {
            base.Update(score);

            repository.ScoreExtract.Create(new ScoreExtract()
            {
                ScoreId = score.Id,
                CreatedAt = DateTime.Now,
                Description = $"Saldo: {score.Total}"
            });

            return score;
        }

        public long ExistingId(Expression<Func<Score, bool>> expression)
        {
            var result = RepositoryContext.Set<Score>().Where(expression).FirstOrDefault();
            return result == null ? 0 : result.Id;
        }
    }
}
