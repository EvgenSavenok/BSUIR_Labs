using Application.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace RV_1.Controllers;

[ApiController]
[Route("api/v1.0/[controller]")]
public abstract class BaseController<TRequest, TResponse> : ControllerBase
{
    protected readonly IService<TRequest, TResponse> _service;

    protected BaseController(IService<TRequest, TResponse> service)
    {
        _service = service;
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var item = _service.GetById(id);
        return item != null ? Ok(item) : NotFound();
    }

    [HttpGet]
    public IActionResult GetAll() => Ok(_service.GetAll());

    [HttpPost]
    public IActionResult Create([FromBody] TRequest request)
    {
        var created = _service.Create(request); 
        
        var idProperty = typeof(TResponse).GetProperty("Id");
        if (idProperty == null)
        {
            return BadRequest("Created entity does not have an Id property.");
        }

        var id = idProperty.GetValue(created);
        return CreatedAtAction(nameof(GetById), new { id }, created);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] TRequest request)
    {
        var updated = _service.Update(id, request);
        return updated != null ? Ok(updated) : NotFound();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var deleted = _service.Delete(id);
        return deleted ? NoContent() : NotFound();
    }
}
