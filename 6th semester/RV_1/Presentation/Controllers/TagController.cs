using Application.Contracts;
using Application.DTO.Request;
using Microsoft.AspNetCore.Mvc;

namespace RV_1.Controllers;

[Route("api/v1.0/tags")]
[ApiController]
public class TagController : ControllerBase
{
    private readonly ITagService _tagService;

    public TagController(ITagService tagService)
    {
        _tagService = tagService;
    }

    [HttpPost]
    public IActionResult Create([FromBody] TagRequestTo request)
    {
        if (request == null)
        {
            return BadRequest("Invalid tag data.");
        }

        var tag = _tagService.Create(request);
        return CreatedAtAction(nameof(GetById), new { id = tag.Id }, tag);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var tag = _tagService.GetById(id);
        if (tag == null)
        {
            return NotFound($"Tag with ID {id} not found.");
        }

        return Ok(tag);
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var tags = _tagService.GetAll();
        return Ok(tags);
    }

    [HttpPut]
    public IActionResult Update([FromBody] TagRequestTo request)
    {
        if (request == null || request.Id == 0)
        {
            return BadRequest("Invalid data.");
        }
        
        var updatedTag = _tagService.Update(request.Id, request);
        if (updatedTag == null)
        {
            return NotFound($"Tag with id {request.Id} not found.");
        }
        return Ok(updatedTag);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var tag = _tagService.GetById(id);
        if (tag == null)
        {
            return NotFound(); 
        }
        
        var deleted = _tagService.Delete(id);
        if (!deleted)
        {
            return NotFound($"Tag with ID {id} not found.");
        }

        return NoContent();
    }
}