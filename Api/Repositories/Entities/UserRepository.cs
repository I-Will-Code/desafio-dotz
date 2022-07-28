using Api.Context;
using Api.Models;
using Api.Repositories.Contracts;

namespace Api.Repositories.Entities
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(RepositoryContext repositoryContext)
           : base(repositoryContext)
        {
        }
    }
}
