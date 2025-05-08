using AplicationLayer.DTO_s;
using AplicationLayer.Interfaces.Repo;
using AplicationLayer.Interfaces.Service;
using AutoMapper;
using DomainLayer.Entities;
using DomainLayer.OperationResult;

namespace AplicationLayer.Service
{
    public class AuctonService :  IAuctonService
    {
        private readonly IAuctionRepository _repository;
        private readonly IMapper _mapper;
        public AuctonService(IAuctionRepository repository, IMapper mapper) 
        {
            _repository = repository;
            _mapper = mapper;


        }

        public async Task<Result> Add(SaveAuctonDto entity)
        {
            Result result = new Result();
            try
            {
                var mappedEntity = _mapper.Map<Auction>(entity);

               
                mappedEntity.AuctionEnd = DateTime.SpecifyKind(mappedEntity.AuctionEnd, DateTimeKind.Utc);
                mappedEntity.CreatedAt = DateTime.UtcNow;
                result = await _repository.Add(mappedEntity);
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
                result = await _repository.Delete(id);
            }
            catch (Exception ex)
            {
                result.IsSucceeded = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public async Task<List<AuctonDto>> GetAllAsync()
        {
            try
            {
                var entities = await _repository.GetAll();
                var data = _mapper.Map<List<AuctonDto>>(entities);
                return data;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Result> GetById(int id)
        {
            Result result = new Result();
            try
            {
                result = await _repository.GetById(id);
                var mapped = _mapper.Map<AuctonDto>(result.Data);
                result.Data = mapped;
            }
            catch (Exception ex)
            {
                result.IsSucceeded = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public async Task<Result> Update(SaveAuctonDto entity, int entityId)
        {
            Result result = new Result();
            try
            {
                var mappedEntity = _mapper.Map<Auction>(entity);
                mappedEntity.UpdatedAt = DateTime.UtcNow;
                result = await _repository.Update(mappedEntity, entityId);
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
