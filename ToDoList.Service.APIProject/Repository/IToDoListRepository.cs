using ToDoList.Service.APIProject.DTOs;
using ToDoList.Service.APIProject.Models;
namespace ToDoList.Service.APIProject.Repository
{
    public interface IToDoListRepository
    {
        Task<IEnumerable<ToDoListDto>> GetAll();
        Task<ToDoListDto> GetById(int id);
        Task<ToDoListDto> Add(ToDoListDto newToDo);
        Task<ToDoListDto> Update(ToDoListDto newToDo);
        Task<bool> Delete(int id);
    }
}
