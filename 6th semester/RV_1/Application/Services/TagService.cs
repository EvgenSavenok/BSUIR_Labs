using Application.Contracts;
using Application.Contracts.RepositoryContracts;
using Application.DTO.Request;
using Application.DTO.Response;
using Application.Validation;
using AutoMapper;
using Model;

namespace Application.Services;

public class TagService : ITagService
{
    private readonly ITagRepository _repository;
    private readonly IMapper _mapper;

    public TagService(ITagRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public TagResponseTo Create(TagRequestTo request)
    {
        var tag = _mapper.Map<Tag>(request);
        _repository.Add(tag);
        return _mapper.Map<TagResponseTo>(tag);
    }

    public TagResponseTo GetById(int id)
    {
        var tag = _repository.GetById(id);
        if (tag == null)
        {
            throw new NotFoundException("Tag not found");
        }
        return _mapper.Map<TagResponseTo>(tag);
    }

    public List<TagResponseTo> GetAll()
    {
        var tags = _repository.GetAll();
        return tags.Select(tag => _mapper.Map<TagResponseTo>(tag)).ToList();
    }

    public TagResponseTo Update(int id, TagRequestTo request)
    {
        var tag = _repository.GetById(id);
        if (tag == null)
        {
            throw new NotFoundException("Tag not found");
        }
        
        _mapper.Map(request, tag);
        _repository.Update(id, tag);
        
        return _mapper.Map<TagResponseTo>(tag);
    }

    public bool Delete(int id)
    {
        return _repository.Delete(id);
    }
}