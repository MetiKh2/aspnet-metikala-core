using MetiKala.Application.Interfaces;
using MetiKala.Domain.Entities.Permission;
using MetiKala.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetiKala.Application.Services
{
    public class PermissionService : IPermissionService
    {
        private readonly IDatabaseContext _context;
        private readonly IUserService _userService;
        public PermissionService(IDatabaseContext context,IUserService userService)
        {
            _userService = userService;
            _context = context;
        }

        public int AddRole(Role role)
        {
            _context.Roles.Add(role);
            _context.SaveChanges();
            return role.RoleID;
        }

        public void AddRolePermissions(int roleId, List<int> selectedPermissions)
        {
            foreach (var item in selectedPermissions)
            {
                _context.RolePermissions.Add(new RolePermission {
                RoleID=roleId,
                PermissionID=item
                });
            }
            _context.SaveChanges();
        }

        public void AddUserRoles(int userId, List<int> selectedRoles)
        {
            foreach (var item in selectedRoles)
            {
                _context.UserRoles.Add(new UserRole { UserID=userId,RoleID=item});
            }
            _context.SaveChanges();
        }

        public bool CheckExistsRoleTitle(string title)
        {
            return _context.Roles.Any(p=>p.RoleTitle==title);
        }

        public bool CheckPermission(string username, int permissionId)
        {
            var userId = _userService.GetUserIDByUserName(username);

            var userRoles = _context.UserRoles.Where(p => p.UserID == userId).Select(p => p.RoleID).ToList();
            if (!userRoles.Any())
            {
                return false;
            }
            var rolePermssions= _context.RolePermissions.Where(p => p.PermissionID == permissionId).Select(p => p.RoleID).ToList();

            return rolePermssions.Any(p => userRoles.Contains(p));
        }

        public void DeleteRole(Role role)
        {
            role.IsRemoved = true;
            _context.SaveChanges();
        }

        public void EditRole(Role role)
        {
            _context.Roles.Update(role);
            _context.SaveChanges();
        }

        public void EditRolePermissions(int roleId, List<int> selectedPermissions)
        {
            var lastRolePermissions = _context.RolePermissions.Where(p => p.RoleID == roleId).ToList();
            foreach (var item in lastRolePermissions)
            {
                _context.RolePermissions.Remove(item);
            }
            AddRolePermissions(roleId,  selectedPermissions);
        }

        public void EditUserRoles(int userId, List<int> selectedRoles)
        {
            var userRoles = _context.UserRoles.Where(p => p.UserID == userId).ToList();
            foreach (var item in userRoles)
            {
                _context.UserRoles.Remove(item);
            }
            AddUserRoles(userId,selectedRoles);
        }

        public List<Permission> GetPermissions()
        {
            return _context.Permissions.ToList();
        }

        public Role GetRoleByID(int id)
        {
            return _context.Roles.Find(id);
        }

        public List<int> GetRolePermissionsByRoleID(int roleId)
        {
            return _context.RolePermissions.Where(p => p.RoleID == roleId).Select(p => p.PermissionID).ToList();
        }

        public IEnumerable<Role> GetRoles(string filter = "")
        {
            IQueryable<Role> roles = _context.Roles;
            if (!string.IsNullOrEmpty(filter))
            {
                roles = roles.Where(p => p.RoleTitle.Contains(filter));
            }
            return roles.ToList();
        }

        public List<int> GetUserRolesByUserID(int userId)
        {
            return _context.UserRoles.Where(p => p.UserID == userId).Select(p => p.RoleID).ToList();
        }
    }
}
