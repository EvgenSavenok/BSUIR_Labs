using Application.Contracts.RepositoryContracts;
using Model;

namespace Infrastructure.Repositories;

public class TagRepository : IRepositoryBase<Tag>, ITagRepository
{
    private static readonly Dictionary<int, Tag> Storage = new();
    private static int _nextId = 1;

    public Tag GetById(int id)
    {
        return Storage.ContainsKey(id) ? Storage[id] : null!;
    }

    public List<Tag> GetAll()
    {
        return Storage.Values.ToList();
    }

    public void Add(Tag entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));

        entity.Id = _nextId;
        Storage[_nextId] = entity;
        _nextId++;
    }

    public void Update(int id, Tag entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));

        if (Storage.ContainsKey(id))
        {
            Storage[id] = entity;
        }
        else
        {
            throw new Exception($"Entity with ID {id} not found.");
        }
    }

    public bool Delete(int id)
    {
        if (Storage.ContainsKey(id))
        {
            return Storage.Remove(id);
        }
        return false;
    }
}