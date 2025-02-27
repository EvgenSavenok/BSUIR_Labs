using Application.Contracts.RepositoryContracts;
using Model;

namespace Infrastructure.Repositories;

public class AuthorRepository : IRepositoryBase<Author>, IAuthorRepository
{
    private static readonly Dictionary<int, Author> Storage = new();
    private static int _nextId = 1;

    public Author GetById(int id)
    {
        return Storage.ContainsKey(id) ? Storage[id] : null!;
    }

    public List<Author> GetAll()
    {
        return Storage.Values.ToList();
    }

    public void Add(Author entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));

        entity.Id = _nextId;
        Storage[_nextId] = entity;
        _nextId++;
    }

    public void Update(int id, Author entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));

        if (Storage.ContainsKey(id))
        {
            Storage[id] = entity;
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