using AutoMapper;
using UserManagement.Service.APIProject.DTOs;
using UserManagement.Service.APIProject.Models;

namespace UserManagement.Service.APIProject
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserDto, User>();
            CreateMap<User, UserDto>();
        }
    }
}
