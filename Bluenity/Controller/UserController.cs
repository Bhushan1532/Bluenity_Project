using BAL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DLL.Models.User;

namespace Bluenity.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("GetAllUsers")]
        public  List<MstUsers> GetAllUsers()
        {
            List<MstUsers> lst = (List<MstUsers>)_userService.GetAllUsers();
            return lst;
        }
    }
}
