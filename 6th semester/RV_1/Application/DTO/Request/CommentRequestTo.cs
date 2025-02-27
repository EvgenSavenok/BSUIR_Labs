namespace Application.DTO.Request;

public class CommentRequestTo
{
    public int Id { get; set; }
    public int NewsId { get; set; }
    public string Content { get; set; }
}