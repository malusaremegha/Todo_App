using ToDo_App.Models;

namespace ToDo_App.Repositories;

public class TodoRepository : ITodoRepository
{
    private readonly List<ToDo> _todos = new();

    public List<ToDo> GetAll()
    {
        Console.WriteLine($"Retrieving all todos. Current count: {_todos.Count}");
        Console.WriteLine("Current todos:");
        foreach (var todo in _todos)
        {
            Console.WriteLine($"Id: {todo.Id}, Title: {todo.Title}, IsCompleted: {todo.IsCompleted}");
        }
        return _todos;
    }

    public ToDo? GetById(int id)
    {
        return _todos.FirstOrDefault(x => x.Id == id);
    }

    public ToDo Add(ToDo todo)
    {
        todo.Id = _todos.Count == 0
            ? 1
            : _todos.Max(x => x.Id) + 1;

        _todos.Add(todo);

        Console.WriteLine($"Added new todo. Current count: {_todos.Count}");
        Console.WriteLine("Current todos:");
        foreach (var t in _todos)
        {
            Console.WriteLine($"Id: {t.Id}, Title: {t.Title}, IsCompleted: {t.IsCompleted}");
        }

        return todo;
    }

    public void Update(ToDo todo)
    {
        var existingTodo = GetById(todo.Id);

        if (existingTodo == null)
        {
            return;
        }

        existingTodo.Title = todo.Title;
        existingTodo.IsCompleted = todo.IsCompleted;
    }

    public void Delete(ToDo todo)
    {
        _todos.Remove(todo);
    }
}