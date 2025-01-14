using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using DLL.Models.User;
namespace DLL.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<MstUsers> GetAllUsers();
        MstUsers GetUserById(int id);
        void AddUser(MstUsers user);
        void UpdateUser(MstUsers user);
        void DeleteUser(int id);
    }
}
