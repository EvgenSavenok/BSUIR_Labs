using Application.Contracts.RepositoryContracts;
using Model;

namespace Infrastructure.Repositories;

public class CommentRepository : IRepositoryBase<Comment>, ICommentRepository
{
    private static readonly Dictionary<int, Comment> Storage = new();
    private static int _nextId = 1;

    public Comment GetById(int id)
    {
        return Storage.ContainsKey(id) ? Storage[id] : null!;
    }

    public List<Comment> GetAll()
    {
        return Storage.Values.ToList();
    }

    public void Add(Comment entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));

        entity.Id = _nextId;
        Storage[_nextId] = entity;
        _nextId++;
    }

    public void Update(int id, Comment entity)
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