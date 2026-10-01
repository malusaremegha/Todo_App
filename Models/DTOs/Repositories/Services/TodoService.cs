using ToDo_App.DTOs;
using ToDo_App.Models;
using ToDo_App.Repositories;

namespace ToDo_App.Services;

public class TodoService : ITodoService
{
    private readonly ITodoRepository _repository;

    public TodoService(ITodoRepository repository)
    {
        _repository = repository;
    }

    public List<TodoResponse> GetAll()
    {
        var todos = _repository.GetAll();

        Console.WriteLine($"Retrieved {todos.Count} todos from the repository.");

        return todos.Select(MapToResponse).ToList();
    }

    public TodoResponse? GetById(int id)
    {
        var todo = _repository.GetById(id);

        if (todo == null)
        {
            return null;
        }

        return MapToResponse(todo);
    }

    public TodoResponse Create(CreateTodoRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Title))
        {
            throw new ArgumentException("Todo title is required.");
        }

        var todo = new ToDo
        {
            Title = request.Title,
            IsCompleted = false
        };

        var createdTodo = _repository.Add(todo);

        return MapToResponse(createdTodo);
    }

    public TodoResponse? Update(int id, UpdateTodoRequest request)
    {
        var todo = _repository.GetById(id);

        if (todo == null)
        {
            return null;
        }

        if (string.IsNullOrWhiteSpace(request.Title))
        {
            throw new ArgumentException("Todo title is required.");
        }

        todo.Title = request.Title;
        todo.IsCompleted = request.IsCompleted;

        _repository.Update(todo);

        return MapToResponse(todo);
    }

    public bool Delete(int id)
    {
        var todo = _repository.GetById(id);

        if (todo == null)
        {
            return false;
        }

        _repository.Delete(todo);

        return true;
    }

    private static TodoResponse MapToResponse(ToDo todo)
    {
        return new TodoResponse
        {
            Id = todo.Id,
            Title = todo.Title,
            IsCompleted = todo.IsCompleted
        };
    }
}