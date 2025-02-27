using Application.Contracts;
using Application.DTO.Request;
using Microsoft.AspNetCore.Mvc;

namespace RV_1.Controllers;

[Route("api/v1.0/[controller]")]
[ApiController]
public class NewsController(INewsService newsService) : ControllerBase
{
    [HttpPost]
    public IActionResult Create([FromBody] NewsRequestTo request)
    {
        if (request == null)
        {
            return BadRequest("Invalid news data.");
        }

        var news = newsService.Create(request);
        return CreatedAtAction(nameof(GetById), new { id = news.Id }, news);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var news = newsService.GetById(id);
        if (news == null)
        {
            return NotFound($"News with ID {id} not found.");
        }

        return Ok(news);
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var newsList = newsService.GetAll();
        return Ok(newsList);
    }

    [HttpPut]
    public IActionResult Update([FromBody] NewsRequestTo request)
    {
        if (request == null || request.Id == 0)
        {
            return BadRequest("Invalid data.");
        }
        
        var updatedNews = newsService.Update(request.Id, request);
        if (updatedNews == null)
        {
            return NotFound($"News with id {request.Id} not found.");
        }
        return Ok(updatedNews);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var news = newsService.GetById(id);
        if (news == null)
        {
            return NotFound(); 
        }
    
        var result = newsService.Delete(id);
        if (result)
        {
            return NoContent(); 
        }

        return StatusCode(500, "Error deleting the news.");
    }
}