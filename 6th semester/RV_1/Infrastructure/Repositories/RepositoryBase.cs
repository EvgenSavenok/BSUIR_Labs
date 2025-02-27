using Application.Contracts;
using Application.Contracts.RepositoryContracts;

namespace Infrastructure.Repositories;

public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    private readonly Dictionary<int, T> _storage = new();
    private int _nextId = 1;  

    public T GetById(int id)
    {
        return _storage.ContainsKey(id) ? _storage[id] : null!;
    }

    public List<T> GetAll()
    {
        return _storage.Values.ToList();
    }

    public void Add(T entity)
    {
        var idProperty = entity.GetType().GetProperty("Id");
        if (idProperty != null)
        {
            idProperty.SetValue(entity, _nextId);
        }
        _storage[_nextId] = entity;
        _nextId++;
    }

    public void Update(int id, T entity)
    {
        if (_storage.ContainsKey(id))
        {
            _storage[id] = entity;
        }
        else
        {
            throw new Exception($"Entity with ID {id} not found.");
        }
    }

    public bool Delete(int id)
    {
        return _storage.Remove(id);
    }
}