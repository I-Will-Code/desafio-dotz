using Api.Context;
using Api.Repositories.Contracts;
using Api.Repositories.Entities;

namespace Api.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repositoryContext;
        private IUserRepository? _user;
        private IAddressRepository? _address;
        private IScoreRepository? _score;
        private IScoreExtractRepository? _scoreExtract;
        private IProductRepository? _product;
        private IOrderRepository? _order;
        private IUserProductRepository? _userProduct;



        public IUserRepository User
        {
            get
            {
                if (_user == null)
                    _user = new UserRepository(_repositoryContext);
                
                return _user;
            }
        }
        
        public IAddressRepository Address
        {
            get
            {
                if (_address == null)
                    _address = new AddressRepository(_repositoryContext);
                
                return _address;
            }
        }

        public IScoreRepository Score
        {
            get
            {
                if (_score == null)
                    _score = new ScoreRepository(_repositoryContext);

                return _score;
            }
        }

        public IScoreExtractRepository ScoreExtract
        {
            get
            {
                if (_scoreExtract == null)
                    _scoreExtract = new ScoreExtractRepository(_repositoryContext);

                return _scoreExtract;
            }
        }

        public IProductRepository Product
        {
            get
            {
                if (_product == null)
                    _product = new ProductRepository(_repositoryContext);

                return _product;
            }
        }

        public IOrderRepository Order
        {
            get
            {
                if (_order == null)
                    _order = new OrderRepository(_repositoryContext);

                return _order;
            }
        }

        public IUserProductRepository UserProduct
        {
            get
            {
                if (_userProduct == null)
                    _userProduct = new UserProductRepository(_repositoryContext);

                return _userProduct;
            }
        }

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }
    }
}
