namespace Model;

public class News
{
    public int Id { get; set; }
    
    public int AuthorId { get; set; }
    public Author Author { get; set; }
    
    public Comment Comment { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime Created { get; set; }
    public DateTime Modified { get; set; }
    
    public List<Comment> Comments { get; set; } = new();
    public List<Tag> Tags { get; set; } = new();
}