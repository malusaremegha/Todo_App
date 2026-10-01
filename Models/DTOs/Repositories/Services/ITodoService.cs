using ToDo_App.DTOs;

namespace ToDo_App.Services;

public interface ITodoService
{
    List<TodoResponse> GetAll();

    TodoResponse? GetById(int id);

    TodoResponse Create(CreateTodoRequest request);

    TodoResponse? Update(int id, UpdateTodoRequest request);

    bool Delete(int id);
}