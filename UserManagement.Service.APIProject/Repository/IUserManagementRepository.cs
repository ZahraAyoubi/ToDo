using UserManagement.Service.APIProject.DTOs;

namespace UserManagement.Service.APIProject.Repository
{
    public interface IUserManagementRepository
    {
        Task<IEnumerable<UserDto>> GetAll();
        Task<UserDto> GetById(string id);
        Task<UserDto> Add(UserDto newUser);
        Task<UserDto> Update(UserDto newUser);
        Task<bool> Delete(string id);
    }
}
