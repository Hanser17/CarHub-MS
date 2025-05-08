using DomainLayer.Entities;
using DomainLayer.OperationResult;


namespace AplicationLayer.Interfaces.Repo
{
    public interface IAuctionRepository 
    {
        Task<Result> GetById(int id);
        Task<IQueryable<Auction>> GetAll();
        Task<Result> Add(Auction entity);
        Task<Result> Update(Auction entity, int entityId);
        Task<Result> Delete(int id);

    }
}
