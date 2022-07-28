namespace Api.Repositories.Contracts
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }
        IAddressRepository Address { get; }
        IScoreRepository Score { get; }
        IScoreExtractRepository ScoreExtract { get; }
        IProductRepository Product { get; }
        IUserProductRepository UserProduct { get; }
        IOrderRepository Order { get; }
    }
}
