using Application.Contracts;
using Application.Contracts.RepositoryContracts;
using Application.DTO.Request;
using Application.DTO.Response;
using Application.Validation;
using AutoMapper;
using Model;

namespace Application.Services;

public class CommentService : ICommentService
{
    private readonly ICommentRepository _repository;
    private readonly IMapper _mapper;

    public CommentService(ICommentRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public CommentResponseTo Create(CommentRequestTo request)
    {
        var comment = new Comment
        {
            Content = request.Content,
            NewsId = request.NewsId,
        };

        _repository.Add(comment);
        
        return _mapper.Map<CommentResponseTo>(comment);
    }

    public CommentResponseTo GetById(int id)
    {
        var comment = _repository.GetById(id);
        if (comment == null)
        {
            throw new NotFoundException("Comment not found");
        }
        return _mapper.Map<CommentResponseTo>(comment);
    }

    public List<CommentResponseTo> GetAll()
    {
        var comments = _repository.GetAll();
        return comments.Select(comment => _mapper.Map<CommentResponseTo>(comment)).ToList();
    }

    public CommentResponseTo Update(int id, CommentRequestTo request)
    {
        var comment = _repository.GetById(id);
        if (comment == null)
        {
            throw new NotFoundException("Comment not found");
        }
        
        _mapper.Map(request, comment);
        _repository.Update(id, comment);
        
        return _mapper.Map<CommentResponseTo>(comment);
    }

    public bool Delete(int id)
    {
        return _repository.Delete(id);
    }
}