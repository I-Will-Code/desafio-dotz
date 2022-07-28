using Api.Context;
using Api.Models;
using Api.Repositories.Contracts;

namespace Api.Repositories.Entities
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(RepositoryContext repositoryContext)
           : base(repositoryContext)
        {
        }
    }
}
