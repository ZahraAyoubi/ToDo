using ToDo.Web.Models;

namespace ToDo.Web.Services.IServices
{
    public interface IUserManagementService : IBaseService
    {
        Task<T> GetAllAsync<T>(string token);
        Task<T> GetByIdAsync<T>(string Id, string token);
        Task<T> CreateAsync<T>(UserDto newUser, string token);
        Task<T> UpdateAsync<T>(UserDto newUser, string token);
        Task<T> DeleteAsync<T>(string id, string token);
    }
}
