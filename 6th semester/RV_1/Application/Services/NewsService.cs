using Application.Contracts;
using Application.Contracts.RepositoryContracts;
using Application.DTO.Request;
using Application.DTO.Response;
using Application.Validation;
using Application.Validation.CustomExceptions;
using AutoMapper;
using Model;

namespace Application.Services;

public class NewsService : INewsService
{
    private readonly INewsRepository _repository;
    private readonly IMapper _mapper;

    public NewsService(INewsRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public NewsResponseTo Create(NewsRequestTo request)
    {
        var news = new News
        {
            Title = request.Title,
            Content = request.Content,
            AuthorId = request.AuthorId,
        };

        _repository.Add(news);

        return new NewsResponseTo
        {
            Id = news.Id,
            Title = news.Title,
            Content = news.Content,
            AuthorId = news.AuthorId,
        };
    }

    public NewsResponseTo GetById(int id)
    {
        var news = _repository.GetById(id);
        if (news == null)
        {
            throw new NotFoundException("News not found");
        }

        return _mapper.Map<NewsResponseTo>(news);
    }

    public List<NewsResponseTo> GetAll()
    {
        var newsList = _repository.GetAll();
        var responseList = new List<NewsResponseTo>();

        foreach (var news in newsList)
        {
            responseList.Add(_mapper.Map<NewsResponseTo>(news));
        }

        return responseList;
    }

    public NewsResponseTo Update(int id, NewsRequestTo request)
    {
        var news = _repository.GetById(id);
        if (news == null)
        {
            throw new BadRequestException("News not found");
        }

        _mapper.Map(request, news);
        _repository.Update(id, news);

        return _mapper.Map<NewsResponseTo>(news);
    }

    public bool Delete(int id)
    {
        return _repository.Delete(id);
    }
}
