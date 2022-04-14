using MetiKala.Application.DTOs.User;
using MetiKala.Application.Interfaces;
using MetiKala.Common.Convertors;
using MetiKala.Common.Security;
using MetiKala.Common.Senders;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EndPoint.Site.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly IViewRenderService _viewRenderService;
        public AccountController(IUserService userService,IViewRenderService viewRenderService)
        {
            _viewRenderService = viewRenderService;
            _userService = userService;
        }
        [Route("Register")]
        #region Register
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult Register(RegisterViewModel register)
        {
            if (_userService.CheckExistsEmail(register.Email))
            {
                ViewBag.existsEmail = true;
                return View(register);
            }
            if (_userService.CheckExistsUserName(register.UserName))
            {
                ViewBag.existsUserName = true;
                return View(register);
            }

            MetiKala.Domain.Entities.User.User user = new MetiKala.Domain.Entities.User.User
            {
                ActivationCode = GeneratCode.GenerateUniqCode(),
                Email = FixText.FixEmail(register.Email),
                IsActive = false,
                IsRemoved = false,
                Password = MyPasswordHasher.EncodePasswordMd5(register.Password),
                RegisterDate = DateTime.Now,
                UserName = register.UserName,

            };

            _userService.AddUser(user);
            ViewBag.Seccess = true;

            string body = _viewRenderService.RenderToStringAsync("_ActivateEmail", user);
            EmailSender.Send(register.Email,"فعالسازی حساب کاربری",body);

            return View("SuccessRegister", model: register);
        }
        #endregion

        #region Login

        [Route("Login")]
        public IActionResult Login(bool resetPassword,bool SendEmail)
        {
            if (resetPassword==true)
            {
                ViewBag.resetPassword = true;
            }

            if (SendEmail == true)
            {
                ViewBag.SendEmail = true;
            }
            return View();
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(LoginViewModel login)
        {
            var user = _userService.LoginUser(login.Password,login.UserNameOrEmail);
            if (user==null)
            {
                ViewBag.UserNull = true;
                return View();
            }
            if (user.IsActive==false)
            {
                ViewBag.UserNull = true;
                return View();
            }


            var Claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier,user.UserID.ToString()),
                        new Claim(ClaimTypes.Name,user.UserName),
                        new Claim(ClaimTypes.Email,user.Email),

                    };
            var identity = new ClaimsIdentity(Claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var principal = new ClaimsPrincipal(identity);

            var properties = new AuthenticationProperties
            {
                IsPersistent = login.RememberMe,

            };
            HttpContext.SignInAsync(principal, properties);
            ViewBag.Seccess = true;
            return View();

            
        }
        #endregion

        #region ActiveUser
        public IActionResult ActiveUser(string id)
        {
            var user = _userService.GetUserByActiveCode(id);
            if (user==null||user.IsActive)
            {
                return NotFound();
            }
            _userService.ActiveUser(user);
            
            return View(user);
        }
        #endregion

        #region LogOut
        [Route("LogOut")]
        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
        #endregion

        #region ForgotPassword
        [Route("ForgotPassword")]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [Route("ForgotPassword")]
        [HttpPost]
        public IActionResult ForgotPassword(ForgotPasswordViewModel forgot)
        {
            if (!_userService.CheckExistsEmail(forgot.Email))
            {
                ViewBag.UserNull = true;
                return View();
            }
            string body = _viewRenderService.RenderToStringAsync("_ForgotPasswordEmail",_userService.GetActivateCodeByEmail(forgot.Email));
            EmailSender.Send(forgot.Email,"تغییر رمز عبور",body);
            return Redirect("/Login?SendEmail=true");
        }
        #endregion

        #region ResetPassword
        public IActionResult ResetPassword(string id)
        {
            var user = _userService.GetUserByActiveCode(id);
            if (user==null)
            {
                return BadRequest();
            }
            return View(new ResetPasswordViewModel {UserID=user.UserID });
        }
        [HttpPost]
        public IActionResult ResetPassword(ResetPasswordViewModel reset)
        {
            var user = _userService.GetUserByID(reset.UserID);
            if (user == null)
            {
                return BadRequest();
            }
            if (reset.Password!=reset.RePassword)
            {
                ViewBag.WrongRepassword = true;
                return View();
            }
            _userService.ResetPassword(reset.UserID,reset.Password);
            return Redirect("/Login?resetPassword=true");
        }
        #endregion
    }
}
