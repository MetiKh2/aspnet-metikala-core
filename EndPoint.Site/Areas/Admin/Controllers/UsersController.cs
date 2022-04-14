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
using MetiKala.Common.Security;
using MetiKala.Common.Convertors;
using MetiKala.Application.DTOs.User;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        private readonly IPermissionService _permissionService;

        public UsersController(IUserService userService,IPermissionService permissionService)
        {
            _permissionService = permissionService;
            _userService = userService;
        }

        // GET: Admin/Users
        public IActionResult Index(string filterName="",string filterEmail="")
        {
          
            return View( _userService.GetUsers(filterName,filterEmail));
        }

        // GET: Admin/Users/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user =  _userService.GetUserByID(id.Value);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Admin/Users/Create
        public IActionResult Create()
        {
            ViewBag.Roles = _permissionService.GetRoles();
            return View();
        }

        // POST: Admin/Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       
        public IActionResult Create(User user,List<int> selectedRoles)
        {
          
            if (ModelState.IsValid)
            {
                if (_userService.CheckExistsEmail(user.Email))
                {
                    ViewBag.Roles = _permissionService.GetRoles();
                    ViewBag.existEmail = true;
                    return View();
                }
                if (_userService.CheckExistsUserName(user.UserName))
                {
                    ViewBag.Roles = _permissionService.GetRoles();
                    ViewBag.existUserName = true;
                    return View();
                }
                user.Password = MyPasswordHasher.EncodePasswordMd5(user.Password);
                user.ActivationCode = GeneratCode.GenerateUniqCode();
               int userId= _userService.AddUser(user);
                _permissionService.AddUserRoles(userId,selectedRoles);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Roles = _permissionService.GetRoles();
            return View(user);
        }

        //// GET: Admin/Users/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _userService.GetUserByID(id.Value);
            if (user == null)
            {
                return NotFound();
            }
            ViewBag.Roles = _permissionService.GetRoles();
            ViewBag.UserRoles = _permissionService.GetUserRolesByUserID(user.UserID);
            return View(new EditUserViewModel {Email=user.Email,
            IsActive=user.IsActive,
            UserID=user.UserID,
            UserName=user.UserName
            });
        }

        //// POST: Admin/Users/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
      
        public IActionResult Edit(int id,EditUserViewModel user,List<int> selectedRoles)
        {
            if (id != user.UserID)
            {
                return NotFound();
            }

          

             
                _userService.EditUser(id,user);
            _permissionService.EditUserRoles(id,selectedRoles);
                return RedirectToAction(nameof(Index));
            
          
        }

        // GET: Admin/Users/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _userService.GetUserByID(id.Value);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Admin/Users/Delete/5
        [HttpPost]
   
        public IActionResult Delete(int id)
        {

            _userService.DeleteUser(id);
            return RedirectToAction(nameof(Index));
        }

        //private bool UserExists(int id)
        //{
        //    return _context.User.Any(e => e.UserID == id);
        //}
    }
}
