using BAL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DLL.Models.User;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Users : ControllerBase
    {
        private readonly IUserService _userService;

        public Users(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetAllUsers")]

        public List<MstUsers> GetAllUsers()
        {
            List<MstUsers> lst = (List<MstUsers>)_userService.GetAllUsers();
            return lst;
        }
    }
}
