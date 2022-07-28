using Api.Models;
using System.Linq.Expressions;

namespace Api.Repositories.Contracts
{
    public interface IScoreRepository : IRepositoryBase<Score>
    {
        long ExistingId(Expression<Func<Score, bool>> expression);
        Score CreateScore(Score score, IRepositoryWrapper repository);
        Score UpdateScore(Score score, IRepositoryWrapper repository);
    }
}
