using Application.Contracts;
using Application.DTO.Request;
using Microsoft.AspNetCore.Mvc;

namespace RV_1.Controllers;

[ApiController]
[Route("api/v1.0/authors")]
public class AuthorController(IAuthorService authorService) : ControllerBase
{
    [HttpPost]
    public IActionResult Create([FromBody] AuthorRequestTo request)
    {
        var created = authorService.Create(request);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        return Ok(authorService.GetById(id));
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(authorService.GetAll());
    }

    [HttpPut]
    public IActionResult Update([FromBody] AuthorRequestTo request)
    {
        if (request == null || request.Id == 0)
        {
            return BadRequest("Invalid data.");
        }
        
        var updatedAuthor = authorService.Update(request.Id, request);
        if (updatedAuthor == null)
        {
            return NotFound($"Author with id {request.Id} not found.");
        }
        return Ok(updatedAuthor);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var author = authorService.GetById(id);
        if (author == null)
        {
            return NotFound(); 
        }
    
        var result = authorService.Delete(id);
        if (result)
        {
            return NoContent(); 
        }

        return StatusCode(500, "Error deleting the author.");
    }
}
