using BookManagement.Entities;
using BookManagement.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagement.Controllers
{
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly BookManagementContext _context;

        public LoginController(BookManagementContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("api/login")]
        public ActionResult Login(LoginViewModel model)
        {
            var result = _context.Managers
                .Where(m => m.ManagerUsername.Equals(model.Username))
                .Where(m => m.Password.Equals(model.Password));

            if (!result.Any())
                return NotFound("Invalid username or password !");

            return Ok(result.Select(m => new
            {
                ManagerUsername = m.ManagerUsername,
                Fullname = m.Fullname
            }).FirstOrDefault());
        }

    }
}
