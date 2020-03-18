using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project4BHWII.Models.Database
{
    interface IRepUser
    {
        void Open();
        void Close();
        bool Insert(User user);
        bool Delete(int id);
        bool UpdateUserData(int id, User newUserData);
        List<User> GetAllUser();
        User GetUser(int id);
        User Login(UserLogin user);
        bool PWReset(int id, string newPW);
        User GetUserByUsername(string username);
    }
}
