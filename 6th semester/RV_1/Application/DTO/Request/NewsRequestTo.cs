﻿namespace Application.DTO.Request;

public class NewsRequestTo
{
    public int Id { get; set; }
    public int AuthorId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
}