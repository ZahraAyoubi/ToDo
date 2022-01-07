using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UserManagement.Service.APIProject.DbContexts;
using UserManagement.Service.APIProject.DTOs;
using UserManagement.Service.APIProject.Models;

namespace UserManagement.Service.APIProject.Repository
{
    public class UserManagementRepository : IUserManagementRepository
    {
        private IMapper _mapper;
        private ApplicationDbContext _dbContext;
        public UserManagementRepository(ApplicationDbContext dbContext ,IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<UserDto> Add(UserDto newUser)
        {
            User user = _mapper.Map<UserDto, User>(newUser);

            _dbContext.AspNetUsers.Add(user);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<User, UserDto>(user); ;
        }

        public async Task<bool> Delete(string id)
        {
            try
            {
                User user = await _dbContext.AspNetUsers.FirstAsync(x => x.Id.Equals(id));

                if (user == null)
                {
                    return false;
                }

                _dbContext.AspNetUsers.Remove(user);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async  Task<IEnumerable<UserDto>> GetAll()
        {
            List<User> users = await _dbContext.AspNetUsers.ToListAsync();
            return _mapper.Map<List<UserDto>>(users);
        }

        public async Task<UserDto> GetById(string id)
        {
            User user = await _dbContext.AspNetUsers.FirstAsync(x =>x.Id.Equals(id));
            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> Update(UserDto newUser)
        {
            User user = await _dbContext.AspNetUsers.FirstOrDefaultAsync(x => x.Id.Equals(newUser.Id));
            try
            {
                user.FisrtName = newUser.FisrtName;
                user.LastName = newUser.LastName;
                user.Email = newUser.Email;
                user.UserName = newUser.UserName;
                user.PhoneNumber = newUser.PhoneNumber;    

                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                var exception = ex.ToString();
            }

            return _mapper.Map<User, UserDto>(user);
        }
    }
}
