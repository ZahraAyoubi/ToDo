using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using ToDo.Web.Models;
using ToDo.Web.Services.IServices;

namespace ToDo.Web.Controllers
{
    public class ToDoListController : Controller
    {
        private readonly IToDoListService _toDoListService;

        public ToDoListController(IToDoListService toDoListService)
        {
            _toDoListService = toDoListService;
        }
        public async Task<IActionResult> ToDoListIndex()
        {
            List<ToDoListDto> toDos = new List<ToDoListDto>();
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var response = await _toDoListService.GetAllAsync<ServiceResponse>(accessToken);
            if (response != null && response.Success)
            {
                toDos = JsonConvert.DeserializeObject<List<ToDoListDto>>(Convert.ToString(response.Data));
            }

            return View(toDos);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateToDo(ToDoListDto model)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var response = await _toDoListService.CreateAsync<ServiceResponse>(model, accessToken);
            if (response != null && response.Success)
            {
                return RedirectToAction(nameof(ToDoListIndex));
            }

            return Redirect(nameof(ToDoListIndex));
        }
        public async Task<IActionResult> Edit(int id)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");

            if (accessToken != null)
            {
                var handler = new JwtSecurityTokenHandler();
                var token = handler.ReadJwtToken(accessToken);
                var playLoad = token.Payload.Select(x => (x.Key, x.Value));
                foreach (var item in playLoad)
                {
                    if (item.Value.Equals("User"))
                    {
                        return RedirectToAction("Error", "Home", new { actionName = "edit" });
                    }
                }
            }

            var response = await _toDoListService.GetByIdAsync<ServiceResponse>(id, accessToken);
            if (response != null && response.Success)
            {
                ToDoListDto model = JsonConvert.DeserializeObject<ToDoListDto>(Convert.ToString(response.Data));
                return View(model);
            }

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditToDo(ToDoListDto model)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var response = await _toDoListService.UpdateAsync<ServiceResponse>(model, accessToken);
            if (response != null && response.Success)
            {
                return RedirectToAction(nameof(ToDoListIndex));
            }

            return RedirectToAction(nameof(Edit), new { id = model.Id });
        }

        public async Task<IActionResult> Delete(int id)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");

            if (accessToken != null)
            {
                var handler = new JwtSecurityTokenHandler();
                var token = handler.ReadJwtToken(accessToken);
                var playLoad = token.Payload.Select(x => (x.Key, x.Value));
                foreach (var item in playLoad)
                {
                    if (item.Value.Equals("User"))
                    {
                        return RedirectToAction("Error", "Home", new { actionName = "delete" });
                    }
                }
            }

            var response = await _toDoListService.GetByIdAsync<ServiceResponse>(id, accessToken);
            if (response != null && response.Success)
            {
                ToDoListDto model = JsonConvert.DeserializeObject<ToDoListDto>(Convert.ToString(response.Data));
                return View(model);
            }

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteToDo(ToDoListDto model)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var response = await _toDoListService.DeleteAsync<ServiceResponse>(model.Id, accessToken);
            if (response.Success)
            {
                return RedirectToAction(nameof(ToDoListIndex));
            }

            return View(model);
        }

        public IActionResult BackToList()
        {
            return RedirectToAction(nameof(ToDoListIndex));
        }
    }
}
