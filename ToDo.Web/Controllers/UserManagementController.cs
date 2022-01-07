using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ToDo.Web.Models;
using ToDo.Web.Services.IServices;

namespace ToDo.Web.Controllers
{
    public class UserManagementController : Controller
    {
        private readonly IUserManagementService _userManagementService;

        public UserManagementController(IUserManagementService userManagementService)
        {
            _userManagementService = userManagementService;
        }
        public async Task<IActionResult>  Index()
        {
            List<UserDto> users= new List<UserDto>();
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var response = await _userManagementService.GetAllAsync<ServiceResponse>(accessToken);
            if (response != null && response.Success)
            {
                users = JsonConvert.DeserializeObject<List<UserDto>>(Convert.ToString(response.Data));
            }

            return View(users);
        }
    }
}
