using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLL.Models.User;

namespace BAL.Interfaces
{
    public interface IUserService
    {
        IEnumerable<MstUsers> GetAllUsers();
        MstUsers GetUserById(int id);
        void CreateUser(MstUsers user);
        void UpdateUser(MstUsers user);
        void RemoveUser(int id);
        MstUsers ValidateUser(string Username, string Password);




    }
}
