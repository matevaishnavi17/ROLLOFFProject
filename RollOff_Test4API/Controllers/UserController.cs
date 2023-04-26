using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RollOff_Test4API.Data;
using RollOff_Test4API.Models.Domain;
using RollOff_Test4API.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace RollOff_Test4API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserService _userService;
        private readonly IConfiguration _config;
        public readonly RollOff4DbContext _context;
        public UserController(UserService service, IConfiguration config, RollOff4DbContext context)
        {
            _config = config;
            _userService = service;
            _context = context;
        }

        [AllowAnonymous]// allow access by non-authenticated users to individual actions. 
        [HttpPost("CreateUser")]

        //method for creating user
        public async Task<IActionResult> Create(User reg)
        {
            var u = await _userService.AddUser(reg);
            try
            {
                if (reg == null)
                {
                    return Ok("Already Exist");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Something went wrong");
            }
            return Ok("User created");
        }

        //method for login user
        [HttpPost("LoginUser")]
        public IActionResult Login(Login user)
        {
            var userAvailable = _context.Users.Where(u => u.Email == user.Email && u.Password == user.Password).FirstOrDefault(); 
           
            {
                try
                {
                    if (userAvailable == null)
                    {
                        return Ok("Failure");

                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine("User not found");
                }
                return Ok(new JwtService(_config).GenerateToken(
                   userAvailable.Firstname,
                   userAvailable.Lastname,
                   userAvailable.Email,
                   userAvailable.Role
                   ));
                
                // return Ok("Success");

            }
        }
    }
}
