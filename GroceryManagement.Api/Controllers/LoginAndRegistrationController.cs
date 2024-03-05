using GroceryManagement.Application.IServices;
using GroceryManagement.Application.Services;
using GroceryManagement.Application.Services.AuthServices;
using GroceryManagement.Domain.Entities.DTOs;
using GroceryManagement.Domain.Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Security.AccessControl;

namespace GroceryManagement.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginAndRegistrationController : ControllerBase
    {
      
        private readonly IAuthService _authService;
        private readonly IUserService _userService;
        private readonly IWebHostEnvironment _webHostEnv;

        public LoginAndRegistrationController(IAuthService authService, IUserService userService,IWebHostEnvironment webHostEnv)
        {
            _authService = authService;
            _userService = userService;
            _webHostEnv = webHostEnv;
        }
        [HttpPost]
        public string Registration(UserDTO userDTO)
        {
            Random rnd = new Random();
            _userService.Create(userDTO);
            int code = rnd.Next(100000, 999999);
            string path = Path.Combine(_webHostEnv.WebRootPath, "images/", "code.txt");

            System.IO.File.WriteAllText(path, code.ToString());
            return _userService.SendEmail(userDTO, code);
            
        }

        [HttpGet]
        public string VerifyEmail(string code)
        {
            string path = Path.Combine(_webHostEnv.WebRootPath, "images/", "code.txt");
            string verificationCode =System.IO.File.ReadAllText(path);
            if(verificationCode !=code)
            {
                List<User> users = new List<User>(_userService.GetAll());
                int id = users[^1].Id;
                _userService.Delete(id);
                System.IO.File.WriteAllText(path, "");

                return "Aldashga urunmang\nCode notogri!\nEndi Code yaroqsiz";
            }
            return "Muvafaqiyatli Registratsiyadan otdingiz\nLogin Orqali Token oling!";
        }

        [HttpGet]
        public string Login(string userName,string password)
        {
            User user=_userService.GetByName(userName);
            if (user == null || password != user.Password)
                return "Aldashga urunmang!\nUser yoki Password hato";
            UserDTO userDTO = new UserDTO()
            {
                UserName = user.UserName,
                Password = user.Password,
                Email = user.Email,
                Role = user.Role,
            };
            return _authService.GenerateToken(userDTO);
        }
    }
}
