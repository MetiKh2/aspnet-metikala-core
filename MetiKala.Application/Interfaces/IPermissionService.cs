using MetiKala.Domain.Entities.Permission;
using MetiKala.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetiKala.Application.Interfaces
{
   public interface IPermissionService
    {
        #region Role
        int AddRole(Role role);
        IEnumerable<Role> GetRoles(string filter="");
        Role GetRoleByID(int id);
        bool CheckExistsRoleTitle(string title);
        void DeleteRole(Role role);
        void EditRole(Role role);
        void AddUserRoles(int userId,List<int> selectedRoles);
        void EditUserRoles(int userId, List<int> selectedRoles);
        List<int> GetUserRolesByUserID(int userId);
        #endregion
        #region Permission
        List<Permission> GetPermissions();
        void AddRolePermissions(int roleId,List<int> selectedPermissions);
        List<int> GetRolePermissionsByRoleID(int roleId);
        void EditRolePermissions(int roleId,List<int> selectedPermissions);
        bool CheckPermission(string username,int permissionId);
        #endregion
    }
}
