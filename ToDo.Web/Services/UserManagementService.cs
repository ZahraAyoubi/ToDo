using ToDo.Web.Models;
using ToDo.Web.Services.IServices;

namespace ToDo.Web.Services
{
    public class UserManagementService : BaseService, IUserManagementService
    {
        private readonly IHttpClientFactory _httpClient;
        public UserManagementService(IHttpClientFactory httpClient) : base(httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<T> CreateAsync<T>(UserDto newUser, string token)
        {
            return await this.SendAsync<T>(new ApiRequest
            {
                ApiType = SD.ApiType.POST,
                Data = newUser,
                ApiUrl = SD.UserManagementAPIBase + "api/users",
                AccessToken = token
            });
        }

        public async Task<T> DeleteAsync<T>(string id, string token)
        {
            return await this.SendAsync<T>(new ApiRequest
            {
                ApiType = SD.ApiType.DELETE,
                ApiUrl = SD.UserManagementAPIBase + "api/users" + id,
                AccessToken = token
            });
        }

        public async Task<T> GetAllAsync<T>(string token)
        {
            return await this.SendAsync<T>(new ApiRequest
            {
                ApiType = SD.ApiType.GET,
                ApiUrl = SD.UserManagementAPIBase + "api/users",
                AccessToken = token
            });
        }

        public async Task<T> GetByIdAsync<T>(string Id, string token)
        {
            return await this.SendAsync<T>(new ApiRequest
            {
                ApiType = SD.ApiType.GET,
                ApiUrl = SD.UserManagementAPIBase + "api/users" +Id,
                AccessToken = token
            });
        }

        public async Task<T> UpdateAsync<T>(UserDto newUser, string token)
        {
            return await this.SendAsync<T>(new ApiRequest
            {
                ApiType = SD.ApiType.PUT,
                Data = newUser,
                ApiUrl = SD.UserManagementAPIBase + "api/users",
                AccessToken = token
            });
        }
    }
}
