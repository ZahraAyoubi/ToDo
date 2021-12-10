using ToDo.Web.Models;
using ToDo.Web.Services.IServices;

namespace ToDo.Web.Services
{
    public class ToDoListService : BaseService, IToDoListService
    {
        private readonly IHttpClientFactory _httpClient;

        public ToDoListService(IHttpClientFactory httpClient):base(httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<T> CreateAsync<T>(ToDoListDto newToDo,string token)
        {
            return await this.SendAsync<T>(new ApiRequest
            {
                ApiType = SD.ApiType.POST,
                Data = newToDo,
                ApiUrl = SD.ToDoAPIListBase + "api/todolist",
                AccessToken = token
            });
        }

        public async Task<T> DeleteAsync<T>(int id, string token)
        {
            return await this.SendAsync<T>(new ApiRequest
            {
                ApiType = SD.ApiType.DELETE,
                ApiUrl = SD.ToDoAPIListBase + "api/todolist/" + id,
                AccessToken = token
            });
        }

        public async Task<T> GetAllAsync<T>(string token)
        {
            return await this.SendAsync<T>(new ApiRequest
            {
                ApiType = SD.ApiType.GET,
                ApiUrl = SD.ToDoAPIListBase + "api/todolist",
                AccessToken = token
            }); 
        }
        public async Task<T> GetByIdAsync<T>(int id, string token)
        {
            return await this.SendAsync<T>(new ApiRequest
            {
                ApiType = SD.ApiType.GET,
                ApiUrl = SD.ToDoAPIListBase + "api/todolist/" + id,
                AccessToken = token
            });
        }

        public async Task<T> UpdateAsync<T>(ToDoListDto newToDo, string token)
        {
            return await this.SendAsync<T>(new ApiRequest
            {
                ApiType = SD.ApiType.PUT,
                Data = newToDo,
                ApiUrl = SD.ToDoAPIListBase + "api/todolist",
                AccessToken = token
            });
        }
    }
}
