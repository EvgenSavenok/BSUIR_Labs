using Application.Contracts;
using Application.Contracts.RepositoryContracts;
using Application.DTO.Request;
using Application.DTO.Response;
using Application.Validation;
using AutoMapper;
using Model;

namespace Application.Services;

public class AuthorService : IAuthorService
{
    private readonly IAuthorRepository _repository;
    private readonly IMapper _mapper;

    public AuthorService(IAuthorRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public AuthorResponseTo Create(AuthorRequestTo request)
    {
        var author = new Author
        {
            Login = request.Login,
            Password = request.Password,
            Firstname = request.Firstname,
            Lastname = request.Lastname
        };

        _repository.Add(author);

        return new AuthorResponseTo
        {
            Id = author.Id,
            Login = author.Login,
            Firstname = author.Firstname,
            Lastname = author.Lastname
        };
    }

    public AuthorResponseTo GetById(int id)
    {
        var author = _repository.GetById(id);
        return _mapper.Map<AuthorResponseTo>(author);
    }

    public List<AuthorResponseTo> GetAll()
    {
        var authors = _repository.GetAll();
        var responseList = new List<AuthorResponseTo>();

        foreach (var author in authors)
        {
            responseList.Add(_mapper.Map<AuthorResponseTo>(author));
        }

        return responseList;
    }

    public AuthorResponseTo Update(int id, AuthorRequestTo request)
    {
        var author = _repository.GetById(id);
        if (author == null)
        {
            throw new NotFoundException("Author not found");
        }

        _mapper.Map(request, author);
        _repository.Update(id, author);

        return _mapper.Map<AuthorResponseTo>(author);
    }

    public bool Delete(int id)
    {
        return _repository.Delete(id);
    }
}