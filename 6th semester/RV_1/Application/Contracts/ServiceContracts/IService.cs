namespace Application.Contracts;

public interface IService<TRequest, TResponse>
{
    TResponse GetById(int id);
    List<TResponse> GetAll();
    TResponse Create(TRequest request);
    TResponse Update(int id, TRequest request);
    bool Delete(int id);
}