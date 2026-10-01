using Microsoft.AspNetCore.Mvc;
using ToDo_App.DTOs;
using ToDo_App.Services;

namespace ToDo_App.Controllers;

[ApiController]
[Route("api/todo")]
public class TodoController : ControllerBase
{
    private readonly ITodoService _todoService;

    public TodoController(ITodoService todoService)
    {
        _todoService = todoService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var todos = _todoService.GetAll();

        return Ok(todos);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var todo = _todoService.GetById(id);

        if (todo == null)
        {
            return NotFound();
        }

        return Ok(todo);
    }

    [HttpPost]
    public IActionResult Create(CreateTodoRequest request)
    {
        var todo = _todoService.Create(request);

        return CreatedAtAction(
            nameof(GetById),
            new { id = todo.Id },
            todo);
    }

    [HttpPut("{id}")]
    public IActionResult Update(
        int id,
        UpdateTodoRequest request)
    {
        var todo = _todoService.Update(id, request);

        if (todo == null)
        {
            return NotFound();
        }

        return Ok(todo);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var deleted = _todoService.Delete(id);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}