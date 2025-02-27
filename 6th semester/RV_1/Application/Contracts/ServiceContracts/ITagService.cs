using Application.DTO.Request;
using Application.DTO.Response;

namespace Application.Contracts;

public interface ITagService : IService<TagRequestTo, TagResponseTo> { }