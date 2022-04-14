using MetiKala.Application.DTOs.User;
using MetiKala.Application.Interfaces;
using MetiKala.Common.Convertors;
using MetiKala.Common.Security;
using MetiKala.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetiKala.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IDatabaseContext _context;
        public UserService(IDatabaseContext context)
        {
            _context = context;
        }

        public void ActiveUser(User user)
        {
            user.IsActive = true;
            user.ActivationCode = GeneratCode.GenerateUniqCode();
           
            _context.SaveChanges();
        }

        public int AddUser(User user)
        {
            _context.User.Add(user);
            _context.SaveChanges();
            return user.UserID;
        }

        public bool CheckExistsEmail(string email)
        {
            return _context.User.Any(p=>p.Email== FixText.FixEmail(email));
        }

        public bool CheckExistsUserName(string username)
        {
            return _context.User.Any(p => p.UserName == username);
        }

        public void DeleteUser(int id)
        {
            var user = GetUserByID(id);
            user.IsRemoved = true;
            user.RemovedDate = DateTime.Now;
            _context.SaveChanges();
        }

        public void EditUser(int userId, EditUserViewModel edit)
        {
            var user = GetUserByID(userId);
            user.UserName = edit.UserName;
            user.Email = edit.Email;
            user.IsActive = edit.IsActive;
            if (edit.Password!=null)
            {
                var hashPassword = MyPasswordHasher.EncodePasswordMd5(edit.Password);
                user.Password = hashPassword;
            }
            _context.SaveChanges();
        }

        public string GetActivateCodeByEmail(string email)
        {
            return _context.User.Where(p => p.Email == FixText.FixEmail(email)).Select(p => p.ActivationCode).SingleOrDefault();
        }

        public User GetUserByActiveCode(string code)
        {
            return _context.User.SingleOrDefault(p => p.ActivationCode == code);
        }

        public User GetUserByID(int id)
        {
            return _context.User.Find(id);
        }

        public int GetUserIDByUserName(string username)
        {
            return _context.User.Where(p => p.UserName == username).Select(p=>p.UserID).SingleOrDefault();
        }

        public IEnumerable<User> GetUsers(string filterName="",string filterEmail="")
        {
            IQueryable<User> Users = _context.User;
            if (!string.IsNullOrEmpty(filterName))
            {
                Users = Users.Where(p=>p.UserName.Contains(filterName));
            }
            if (!string.IsNullOrEmpty(filterEmail))
            {
                Users = Users.Where(p => p.Email.Contains(filterEmail));
            }
            return Users.ToList();
        }

        public User LoginUser(string password, string emailOrUserName)
        {
            var hashPassword = MyPasswordHasher.EncodePasswordMd5(password);
            var email = FixText.FixEmail(emailOrUserName);
            return _context.User.Where(p=>(p.Password == hashPassword&&p.Email==email)||(p.Password==hashPassword&&p.UserName==emailOrUserName)).SingleOrDefault();
        }

        public void ResetPassword(int userId,string password)
        {
            var hashPassword = MyPasswordHasher.EncodePasswordMd5(password);
            var user = GetUserByID(userId);
            user.Password = hashPassword;
            _context.SaveChanges();

        }
    }
}
