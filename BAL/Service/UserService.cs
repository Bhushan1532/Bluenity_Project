using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL.Interfaces;
using DLL.Models.User;
using DLL.Repositories;

namespace BAL.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public void CreateUser(MstUsers user)
        {
             _userRepository.AddUser(user);
        }

        public IEnumerable<MstUsers> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        public MstUsers GetUserById(int id)
        {
            return _userRepository.GetUserById(id);
        }

        public void RemoveUser(int id)
        {
            _userRepository.DeleteUser(id);
        }

        public void UpdateUser(MstUsers user)
        {
            _userRepository.UpdateUser(user);
        }
    }
}
