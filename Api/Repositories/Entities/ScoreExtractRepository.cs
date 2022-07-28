using Api.Context;
using Api.Models;
using Api.Repositories.Contracts;
using System.Linq.Expressions;

namespace Api.Repositories.Entities
{
    public class ScoreExtractRepository : RepositoryBase<ScoreExtract>, IScoreExtractRepository
    {
        public ScoreExtractRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
