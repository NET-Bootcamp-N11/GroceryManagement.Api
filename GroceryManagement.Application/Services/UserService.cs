using GroceryManagement.Application.Abstractions.IRepositories;
using GroceryManagement.Application.IServices;
using GroceryManagement.Domain.Entities.DTOs;
using GroceryManagement.Domain.Entities.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace GroceryManagement.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IConfiguration _config;
    
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _config = configuration;
        }

        public string SendEmail(UserDTO userDTO, int code)
        {
            IConfigurationSection? emailSettings = _config.GetSection("EmailSettings");
            MailMessage? mailMessage = new MailMessage
            {
                From = new MailAddress(emailSettings["Sender"]!, emailSettings["SenderName"]),
                Subject = "Emailingizni tasdiqlang",
                Body = $"Kod: {code}",
                IsBodyHtml = true,

            };
            mailMessage.To.Add(userDTO.Email);

            using var smtpClient = new SmtpClient(emailSettings["MailServer"], int.Parse(emailSettings["MailPort"]!))
            {
                Port = Convert.ToInt32(emailSettings["MailPort"]),
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(emailSettings["Sender"], emailSettings["Password"]),
                EnableSsl = true,
            };


            //smtpClient.UseDefaultCredentials = true;
            smtpClient.SendMailAsync(mailMessage).GetAwaiter().GetResult();
            return "Code Emailingizga jonatildi uni verify Email qismida tasdiqlang";

        }
        public string Create(UserDTO userDTO)
        {
            User user = new User()
            {
                UserName = userDTO.UserName,
                Password = userDTO.Password,
                Email = userDTO.Email,
                Role = userDTO.Role,
               
            };
            return _userRepository.Create(user);
        }

        public string Delete(int id)
        {
            return _userRepository.Delete(x => x.Id == id);
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public User GetByName(string name)
        {
            return _userRepository.GetByAny(x => x.UserName == name);
        }

        public string Update(int id, UserDTO userDTO)
        {
            User model = _userRepository.GetByAny(x => x.Id == id);
            model.UserName = userDTO.UserName;
            model.Email = userDTO.Email;
            return _userRepository.Update(model);
        }
    }
}
