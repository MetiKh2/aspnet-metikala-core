using MetiKala.Application.DTOs.User;
using MetiKala.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetiKala.Application.Interfaces
{
    public interface IUserService
    {
        bool CheckExistsUserName(string username);
        bool CheckExistsEmail(string email);
        User GetUserByActiveCode(string code);
        string GetActivateCodeByEmail(string email);
        User GetUserByID(int id);
        IEnumerable<User> GetUsers(string filterName = "", string filterEmail = "");
        void EditUser(int userId,EditUserViewModel user);
        int GetUserIDByUserName(string username);
        void DeleteUser(int id);
        #region Register&Login
        int AddUser(User user);
        User LoginUser(string password,string emailOrUserName);
        void ActiveUser(User user);
        #endregion
        #region ResetPassword
        void ResetPassword(int userId,string password);
        #endregion
    }
}
