using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using ToDo.Web.Models;
using ToDo.Web.Services.IServices;

namespace ToDo.Web.Services
{
    public class BaseService : IBaseService
    {
        public ServiceResponse responseModel { get; set; }
        private IHttpClientFactory httpClient;

        public BaseService(IHttpClientFactory httpClient)
        {
            this.responseModel = new ServiceResponse();
            this.httpClient = httpClient;
        }

        public async Task<T> SendAsync<T>(ApiRequest request)
        {
            try
            {
                //var client = httpClient.CreateClient("ToDoListAPI");
                var client = httpClient.CreateClient("UserManagementAPI");
                HttpRequestMessage message = new HttpRequestMessage();
                message.Headers.Add("Accept", "application/json");
                message.RequestUri = new Uri(request.ApiUrl);
                client.DefaultRequestHeaders.Clear();
                if (request.Data != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(request.Data),
                        Encoding.UTF8, "application/json");
                }

                if (!string.IsNullOrEmpty(request.AccessToken))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", request.AccessToken);
                }

                HttpResponseMessage response = null;
                switch(request.ApiType)
                {
                    case SD.ApiType.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case SD.ApiType.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    case SD.ApiType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                    case SD.ApiType.GET:
                        message.Method = HttpMethod.Get;
                        break;
                }
                response = await client.SendAsync(message);

                var apiContent = await response.Content.ReadAsStringAsync();
                var apiResponseDto = JsonConvert.DeserializeObject<T>(apiContent);


                return apiResponseDto;
            }
            catch (Exception ex)
            {
                var dto = new ServiceResponse
                {
                    Message = "Error",
                    ErrorMesseges = new List<string>() { ex.Message },
                    Success = false
                };
                var res = JsonConvert.SerializeObject(dto);
                var apiResponseDto = JsonConvert.DeserializeObject<T>(res);
                return apiResponseDto;
            }
        }
        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }
    }
}
