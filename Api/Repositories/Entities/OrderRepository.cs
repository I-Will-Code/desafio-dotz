using Api.Context;
using Api.Models;
using Api.Repositories.Contracts;

namespace Api.Repositories.Entities
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(RepositoryContext repositoryContext)
           : base(repositoryContext)
        {
        }
    }
}
