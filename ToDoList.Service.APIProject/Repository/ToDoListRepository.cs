using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ToDoList.Service.APIProject.DbContexts;
using ToDoList.Service.APIProject.DTOs;
using ToDoList.Service.APIProject.Models;

namespace ToDoList.Service.APIProject.Repository
{
    public class ToDoListRepository : IToDoListRepository
    {
        private ApplicationDbContext _dbContext;
        private IMapper _mapper;

        public ToDoListRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<ToDoListDto> Add(ToDoListDto newToDo)
        {
            ToDoListModel toDoList = _mapper.Map<ToDoListDto,ToDoListModel>(newToDo);
            
            _dbContext.ToDoLists.Add(toDoList);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<ToDoListModel, ToDoListDto>(toDoList);
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var toDoList = await _dbContext.ToDoLists.FirstAsync(x => x.Id == id);

                if (toDoList == null)
                {
                    return false;
                }

                _dbContext.ToDoLists.Remove(toDoList);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch 
            {
                return false;
            }
        }

        public async Task<IEnumerable<ToDoListDto>> GetAll()
        {
            List<ToDoListModel> toDoLists = await _dbContext.ToDoLists.ToListAsync();
            return _mapper.Map<List<ToDoListDto>>(toDoLists);
        }
    
        public async Task<ToDoListDto> GetById(int id)
        {
            ToDoListModel toDoList = await _dbContext.ToDoLists.FirstOrDefaultAsync(x =>x.Id == id);
            return _mapper.Map<ToDoListDto>(toDoList);
        }

        public async Task<ToDoListDto> Update(ToDoListDto newToDo)
        {
            ToDoListModel toDoList = await _dbContext.ToDoLists.FirstOrDefaultAsync(x => x.Id == newToDo.Id);
            try
            {
                toDoList.Name = newToDo.Name;
                toDoList.Description = newToDo.Description;
                toDoList.IsCompelete = newToDo.IsCompelete;
                toDoList.Date = newToDo.Date;

                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
               var exception = ex.ToString();
            }

            return _mapper.Map<ToDoListModel,ToDoListDto>(toDoList);
        }
    }
}
