using Application.DTO.Request;
using Application.DTO.Response;
using Model;

namespace Application.Contracts;

public interface IAuthorService : IService<AuthorRequestTo, AuthorResponseTo> { }