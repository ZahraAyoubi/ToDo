using AutoMapper;
using ToDoList.Service.APIProject.DTOs;
using ToDoList.Service.APIProject.Models;

namespace ToDoList.Service.APIProject
{
    public class AutoMapperPrpfile : Profile
    {
        public AutoMapperPrpfile ()
        {
            CreateMap<ToDoListModel, ToDoListDto>();
            CreateMap<ToDoListDto, ToDoListModel>();
        }
    }
}