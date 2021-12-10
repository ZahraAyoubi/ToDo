using ToDo.Web.Models;

namespace ToDo.Web.Services.IServices
{
    public interface IBaseService :IDisposable
    {
        ServiceResponse responseModel { get; set; }
        Task<T> SendAsync<T>(ApiRequest request);
    }
}
