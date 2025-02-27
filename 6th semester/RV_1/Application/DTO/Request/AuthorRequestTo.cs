namespace Application.DTO.Request;

public class AuthorRequestTo
{
    public int Id { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
}