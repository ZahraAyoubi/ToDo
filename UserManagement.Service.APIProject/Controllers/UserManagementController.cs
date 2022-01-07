using IdentityModel;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using UserManagement.Service.APIProject.DTOs;
using UserManagement.Service.APIProject.Models;
using UserManagement.Service.APIProject.Repository;

namespace UserManagement.Service.APIProject.Controllers
{
    [Route("api/users")]
    //[Authorize(Roles = "Admin")]
    public class UserManagementController : ControllerBase
    {
        private IUserManagementRepository _repository;
        protected ServiceResponse _serviceResponse;

        //private readonly UserManager<User> _userManager;
        ////private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        //private readonly IIdentityServerInteractionService _interaction;
        //private readonly IEventService _events;

        public UserManagementController(IUserManagementRepository repository)
        {
            _repository = repository;
            this._serviceResponse = new ServiceResponse();
            //_userManager = userManager;
            ////_signInManager = signInManager;
            //_roleManager = roleManager;
            //_interaction = interaction;
            //_events = events;

        }
        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                var list = await _repository.GetAll();
                _serviceResponse.Data = list;
            }
            catch (Exception ex)
            {
                _serviceResponse.Success = false;
                _serviceResponse.ErrorMesseges
                     = new List<string>() { ex.ToString() };
            }
            return _serviceResponse;
        }

        [HttpGet("{id}")]
        public async Task<object> GetById(string id)
        {
            try
            {
                var toDo = await _repository.GetById(id);
                _serviceResponse.Data = toDo;
            }
            catch (Exception ex)
            {
                _serviceResponse.Success = false;
                _serviceResponse.ErrorMesseges
                     = new List<string>() { ex.ToString() };
            }
            return _serviceResponse;
        }

        [HttpPost]
        //public async Task<object> Post([FromBody] UserDto newUser)
        //{
        //    try
        //    {
        //        User user = new User ();
        //        var result = await _userManager.CreateAsync(user, newUser.Password);

        //        if (result.Succeeded)
        //        {
        //            if (!_roleManager.RoleExistsAsync(newUser.RoleName).GetAwaiter().GetResult())
        //            {
        //                var userRole = new IdentityRole
        //                {
        //                    Name = newUser.RoleName,
        //                    NormalizedName = newUser.RoleName,

        //                };
        //                await _roleManager.CreateAsync(userRole);
        //            }

        //            await _userManager.AddToRoleAsync(user, newUser.RoleName);

        //            //await _userManager.AddClaimsAsync(user, new Claim[]{
        //            //        new Claim(JwtClaimTypes.Name, newUser.UserName),
        //            //        new Claim(JwtClaimTypes.Email, newUser.Email),
        //            //        new Claim(JwtClaimTypes.FamilyName, newUser.FisrtName),
        //            //        new Claim(JwtClaimTypes.GivenName, newUser.LastName),
        //            //        new Claim(JwtClaimTypes.WebSite, "http://"+newUser.UserName+".com"),
        //            //        new Claim(JwtClaimTypes.Role, newUser.RoleName) });
        //        }
        //            var model = await _repository.Add(newUser);
        //        _serviceResponse.Data = model;
        //    }
        //    catch (Exception ex)
        //    {
        //        _serviceResponse.Success = false;
        //        _serviceResponse.ErrorMesseges
        //             = new List<string>() { ex.ToString() };
        //    }
        //    return _serviceResponse;

        //}

        [HttpPut]
        public async Task<object> Put([FromBody] UserDto newUser)
        {
            try
            {
                var model = await _repository.Update(newUser);
                if (model != null)
                {
                    _serviceResponse.Data = model;
                }
            }
            catch (Exception ex)
            {
                _serviceResponse.Success = false;
                _serviceResponse.ErrorMesseges
                     = new List<string>() { ex.ToString() };
            }
            return _serviceResponse;
        }

        [HttpDelete("{id}")]
        public async Task<object> Delete(string id)
        {
            try
            {
                var isSuccess = await _repository.Delete(id);
                _serviceResponse.Data = isSuccess;

            }
            catch (Exception ex)
            {
                _serviceResponse.Success = false;
                _serviceResponse.ErrorMesseges
                     = new List<string>() { ex.ToString() };
            }
            return _serviceResponse;
        }
    }
}
