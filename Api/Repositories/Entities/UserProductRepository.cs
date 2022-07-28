using Api.Context;
using Api.Models;
using Api.Repositories.Contracts;

namespace Api.Repositories.Entities
{
    public class UserProductRepository : RepositoryBase<UserProduct>, IUserProductRepository
    {
        public UserProductRepository(RepositoryContext repositoryContext)
           : base(repositoryContext)
        {
        }
    }
}
