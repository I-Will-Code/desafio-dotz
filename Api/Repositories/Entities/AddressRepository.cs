using Api.Context;
using Api.Models;
using Api.Repositories.Contracts;

namespace Api.Repositories.Entities
{
    public class AddressRepository : RepositoryBase<Address>, IAddressRepository
    {
        public AddressRepository(RepositoryContext repositoryContext)
           : base(repositoryContext)
        {
        }
    }
}
