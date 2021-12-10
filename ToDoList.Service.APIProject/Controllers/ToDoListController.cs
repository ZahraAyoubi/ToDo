using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Service.APIProject.DTOs;
using ToDoList.Service.APIProject.Models;
using ToDoList.Service.APIProject.Repository;

namespace ToDoList.Service.APIProject.Controllers
{
    [Route("api/todolist")]
    public class ToDoListController : ControllerBase
    {
        private IToDoListRepository _toDoListRepository;
        protected ServiceResponse _response;
        public ToDoListController(IToDoListRepository toDoListRepository)
        {
            _toDoListRepository = toDoListRepository;
            this._response = new ServiceResponse();
        }

        [HttpGet]
        [Authorize]
        public async Task<object> Get()
        {
            try
            {
                var list = await _toDoListRepository.GetAll();
                _response.Data = list;
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.ErrorMesseges
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<object> GetById(int id)
        {
            try
            {
                var toDo = await _toDoListRepository.GetById(id);
                _response.Data = toDo;
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.ErrorMesseges
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPost]
        [Authorize]
        public async Task<object> Post([FromBody]ToDoListDto newToDo)
        {
            try
            {
                var model = await _toDoListRepository.Add(newToDo);
                _response.Data = model;
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.ErrorMesseges
                     = new List<string>() { ex.ToString() };
            }
            return _response;

        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<object> Put([FromBody] ToDoListDto newToDo)
        {
            try
            {
                var model = await _toDoListRepository.Update(newToDo);
                if (model != null)
                {
                    _response.Data = model;
                }
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.ErrorMesseges
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }
       
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<object> Delete(int id)
        {
            try
            {
                var isSuccess = await _toDoListRepository.Delete(id);
                _response.Data = isSuccess;

            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.ErrorMesseges
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }
    }
}
