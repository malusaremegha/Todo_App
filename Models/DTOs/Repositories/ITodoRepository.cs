using ToDo_App.Models;

namespace ToDo_App.Repositories;

public interface ITodoRepository
{
    List<ToDo> GetAll();

    ToDo? GetById(int id);

    ToDo Add(ToDo todo);

    void Update(ToDo todo);

    void Delete(ToDo todo);
}