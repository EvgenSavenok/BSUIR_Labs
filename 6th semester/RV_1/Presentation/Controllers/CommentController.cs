using Application.Contracts;
using Application.DTO.Request;
using Microsoft.AspNetCore.Mvc;

namespace RV_1.Controllers;

[Route("api/v1.0/comments")]
[ApiController]
public class CommentController : ControllerBase
{
    private readonly ICommentService _commentService;

    public CommentController(ICommentService commentService)
    {
        _commentService = commentService;
    }

    [HttpPost]
    public IActionResult Create([FromBody] CommentRequestTo request)
    {
        if (request == null)
        {
            return BadRequest("Invalid comment data.");
        }

        var comment = _commentService.Create(request);
        return CreatedAtAction(nameof(GetById), new { id = comment.Id }, comment);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var comment = _commentService.GetById(id);
        if (comment == null)
        {
            return NotFound($"Comment with ID {id} not found.");
        }

        return Ok(comment);
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var comments = _commentService.GetAll();
        return Ok(comments);
    }

    [HttpPut]
    public IActionResult Update([FromBody] CommentRequestTo request)
    {
        if (request == null || request.Id == 0)
        {
            return BadRequest("Invalid data.");
        }
        
        var updatedComment = _commentService.Update(request.Id, request);
        if (updatedComment == null)
        {
            return NotFound($"Comment with id {request.Id} not found.");
        }
        return Ok(updatedComment);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var comment = _commentService.GetById(id);
        if (comment == null)
        {
            return NotFound(); 
        }
        
        var deleted = _commentService.Delete(id);
        if (!deleted)
        {
            return NotFound($"Comment with ID {id} not found.");
        }

        return NoContent();
    }
}
