namespace Application.Contracts.RepositoryContracts;

public interface IRepositoryBase<T>
{
    T GetById(int id);
    List<T> GetAll();
    void Add(T entity);
    void Update(int id, T entity);
    bool Delete(int id);
}
