using ToDo.Web.Models;

namespace ToDo.Web.Services.IServices
{
    public interface IToDoListService : IBaseService
    {
        Task<T> GetAllAsync<T>(string token);
        Task<T> GetByIdAsync<T>(int Id, string token);
        Task<T> CreateAsync<T>(ToDoListDto newToDo,string token);
        Task<T> UpdateAsync<T>(ToDoListDto newToDo, string token);
        Task<T> DeleteAsync<T>(int id, string token);
    }
}
