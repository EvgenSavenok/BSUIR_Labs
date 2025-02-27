using Application.DTO.Request;
using Application.DTO.Response;
using AutoMapper;
using Model;

namespace Application;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Author, AuthorResponseTo>();
        CreateMap<AuthorRequestTo, Author>();

        CreateMap<News, NewsResponseTo>();
        CreateMap<NewsRequestTo, News>();

        CreateMap<Tag, TagResponseTo>();
        CreateMap<TagRequestTo, Tag>();

        CreateMap<Comment, CommentResponseTo>();
        CreateMap<CommentRequestTo, Comment>();
    }
}