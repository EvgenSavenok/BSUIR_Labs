using Application.Contracts;
using Application.Contracts.RepositoryContracts;
using AutoMapper;

namespace Application.Services;

public class BaseService<TModel, TRequest, TResponse> : IService<TRequest, TResponse>
    where TModel : class
{
    protected readonly IRepositoryBase<TModel> _repository;
    protected readonly IMapper _mapper;

    public BaseService(IRepositoryBase<TModel> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public TResponse GetById(int id)
    {
        var entity = _repository.GetById(id);
        if (entity == null) throw new Exception($"Entity with ID {id} not found.");
        return _mapper.Map<TResponse>(entity);
    }

    public List<TResponse> GetAll()
    {
        var entities = _repository.GetAll();
        return entities.Select(entity => _mapper.Map<TResponse>(entity)).ToList();
    }

    public TResponse Create(TRequest request)
    {
        var entity = _mapper.Map<TModel>(request);
        _repository.Add(entity);
        return _mapper.Map<TResponse>(entity);
    }

    public TResponse Update(int id, TRequest request)
    {
        var entity = _repository.GetById(id);
        if (entity == null) throw new Exception($"Entity with ID {id} not found.");

        _mapper.Map(request, entity);
        _repository.Update(id, entity);
        return _mapper.Map<TResponse>(entity);
    }

    public bool Delete(int id)
    {
        return _repository.Delete(id);
    }
}