using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MetiKala.Domain.Entities.User;
using MetiKala.Persistance.Context;
using MetiKala.Application.Interfaces;
using MetiKala.Application.DTOs.Role;
using MetiKala.Application.Security;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RolesController : Controller
    {
        private readonly IPermissionService _permissionService;

        public RolesController(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        // GET: Admin/Roles
        [PermissionChecker(6)]
        public IActionResult Index(string filter="")
        {
            return View(_permissionService.GetRoles(filter));
        }

        // GET: Admin/Roles/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var role = _permissionService.GetRoleByID(id.Value);
            if (role == null)
            {
                return NotFound();
            }

            return View(role);
        }

        // GET: Admin/Roles/Create
        [PermissionChecker(7)]
        public IActionResult Create()
        {
            ViewBag.Permissions = _permissionService.GetPermissions();
            return View();
        }

        // POST: Admin/Roles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [PermissionChecker(7)]
        public IActionResult Create(Role role,List<int> selectedPermissions)
        {
            if (ModelState.IsValid)
            {
                if (_permissionService.CheckExistsRoleTitle(role.RoleTitle))
                {
                    ViewBag.Permissions = _permissionService.GetPermissions();
                    ViewBag.TitleExists = true;
                    return View();
                }

               int roleId= _permissionService.AddRole(role);
                _permissionService.AddRolePermissions(roleId, selectedPermissions);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.TitleExists = false;
            ViewBag.Permissions = _permissionService.GetPermissions();
            return View(role);
        }

        // GET: Admin/Roles/Edit/5
        [PermissionChecker(8)]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var role = _permissionService.GetRoleByID(id.Value);
            if (role == null)
            {
                return NotFound();
            }
            ViewBag.RolePermissions = _permissionService.GetRolePermissionsByRoleID(role.RoleID);
            ViewBag.Permissions = _permissionService.GetPermissions();
            return View(new EditRoleViewModel { LastRoleTitle=role.RoleTitle,RoleID=role.RoleID});
        }

        //// POST: Admin/Roles/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [PermissionChecker(8)]
        public IActionResult Edit(EditRoleViewModel edit,List<int> selectedPermissions)
        {
           

            if (ModelState.IsValid)
            {
                if (edit.LastRoleTitle!= edit.NewRoleTitle)
                {
                    if (_permissionService.CheckExistsRoleTitle(edit.NewRoleTitle))
                    {
                        ViewBag.RolePermissions = _permissionService.GetRolePermissionsByRoleID(edit.RoleID);
                        ViewBag.Permissions = _permissionService.GetPermissions();
                        ViewBag.TitleExists = true;
                        return View(edit);
                    }
                }
                var role = _permissionService.GetRoleByID(edit.RoleID);
                role.RoleTitle = edit.NewRoleTitle;
                _permissionService.EditRole(role);
                _permissionService.EditRolePermissions(role.RoleID,selectedPermissions);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.RolePermissions = _permissionService.GetRolePermissionsByRoleID(edit.RoleID);
            ViewBag.Permissions = _permissionService.GetPermissions();
            return View(edit);
        }

        //// GET: Admin/Roles/Delete/5
         [PermissionChecker(9)]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var role = _permissionService.GetRoleByID(id.Value);
            if (role == null)
            {
                return NotFound();
            }

            return View(role);
        }

        // POST: Admin/Roles/Delete/5
        
        [HttpPost]
        [PermissionChecker(9)]
        public IActionResult Delete(int id)
        {
            var role = _permissionService.GetRoleByID(id);
            _permissionService.DeleteRole(role);
            return RedirectToAction(nameof(Index));
        }

        //private bool RoleExists(int id)
        //{
        //    return _context.Roles.Any(e => e.RoleID == id);
        //}
    }
}
