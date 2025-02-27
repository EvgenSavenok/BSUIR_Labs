namespace Model;

public class Comment
{
    public int Id { get; set; }
    
    public int NewsId { get; set; }
    public News News { get; set; }
    
    public string Content { get; set; }
}