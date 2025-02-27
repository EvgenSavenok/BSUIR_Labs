namespace Application.Contracts.RepositoryContracts;

public interface IRepositoryManager
{
    IAuthorRepository AuthorRepository { get; }
    INewsRepository NewsRepository { get; }
    ICommentRepository CommentRepository { get; }
    ITagRepository TagRepository { get; }
    Task SaveAsync();
}
