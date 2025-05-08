using AplicationLayer.Interfaces.Repo;
using DomainLayer.Entities;
using DomainLayer.OperationResult;
using Microsoft.EntityFrameworkCore;

namespace PersistanceLayer.Repository
{
    public class AuctionRepository :  IAuctionRepository
    {
        private readonly Context _context;
        private readonly DbSet<Auction> _entity;
        public AuctionRepository(Context context) 
        {
            _context = context;
            _entity = context.Set<Auction>();
        }

        public async Task<Result> Add(Auction entity)
        {
            Result result = new Result();
            try
            {
                await _entity.AddAsync(entity);
                await _context.SaveChangesAsync();
                result.IsSucceeded = true;
                result.Message = "Entity added successfully";
            }
            catch (Exception ex)
            {
                result.IsSucceeded = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public async Task<Result> Delete(int id)
        {
            Result result = new Result();
            try
            {
                var entity = await _entity.FindAsync(id);
                if (entity == null)
                {
                    result.IsSucceeded = false;
                    result.Message = "Entity not found";
                }
                else
                {
                    _entity.Remove(entity);
                    await _context.SaveChangesAsync();
                    result.IsSucceeded = true;
                    result.Message = "Entity deleted successfully";
                }
            }
            catch (Exception ex)
            {
                result.IsSucceeded = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public  Task<IQueryable<Auction>> GetAll()
        {
            try
            {
                return Task.FromResult(_entity.Include(x => x.Item).AsNoTracking().AsQueryable());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public  async Task<Result> GetById(int id)
        {
            Result result = new Result();
            try
            {
                var entity = await _entity.Include(a => a.Item).FirstOrDefaultAsync(a => a.id == id);
                if (entity == null)
                {
                    result.IsSucceeded = true;
                    result.Message = "Entity not found";
                }
                else
                {
                    result.IsSucceeded = true;
                    result.Data = entity;
                }
            }
            catch (Exception ex)
            {
                result.IsSucceeded = false;
                result.Message = ex.Message;
            }
            return result;


        }

        public async Task<Result> Update(Auction entity, int entityId)
        {
            var result = new Result();

            try
            {
                var entityToUpdate = await _entity.FindAsync(entityId);

                if (entityToUpdate == null)
                {
                    result.IsSucceeded = false;
                    result.Message = "Entity not found";
                    return result;
                }
                entity.id = entityToUpdate.id;
                entity.CreatedAt = entityToUpdate.CreatedAt;
                _context.Entry(entityToUpdate).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();

                result.IsSucceeded = true;
                result.Message = "Entity updated successfully";
            }
            catch (Exception ex)
            {
                result.IsSucceeded = false;
                result.Message = ex.Message;
            }

            return result;
        }
    }
    
}
