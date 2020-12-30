using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Kashaneh.Core.Convertors;
using Kashaneh.Core.DTOs;
using Kashaneh.Core.Generator;
using Kashaneh.Core.Security;
using Kashaneh.Core.Senders;
using Kashaneh.Core.Services.Interfaces;
using Kashaneh.DataLayer.Entities.User;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;


namespace Kashaneh.Web.Controllers
{
    public class AccountController : Controller
    {
        private IUserService _userService;
        private IViewRenderService viewRender;

        public AccountController(IUserService userService, IViewRenderService viewRender)
        {
            _userService = userService;
            this.viewRender = viewRender;
        }

        #region register
        [Route("Register")]
        public IActionResult Register()
        {
            return View();
        }
        [Route("Register")]
        [HttpPost]
        public IActionResult Register(RegisterViewModel register)
        {
            if (!ModelState.IsValid)
            {
                return View(register);
            }

            if (_userService.IsExistUserName(register.UserName))
            {
                ModelState.AddModelError("UserName", "نام کاربری معتبر نمیباشد");
                return View(register);
            }

            if (_userService.IsExistEmail(register.Email))
            {
                ModelState.AddModelError("Email", "ایمیل معتبر نمیباشد");
                return View(register);
            }
            DataLayer.Entities.User.User user = new User()
            {
                ActiveCode = NameGenerator.GenerateUniqCode(),
                Email = FixedText.FixEmail(register.Email),
                IsActive = false,
                Password = PasswordHelper.EncodePasswordMd5(register.Password),
                RegisterDate = DateTime.Now,
                UserName = register.UserName,
                IsDeleted = false,


            };
            _userService.AddUser(user);

            #region sendActivationemail

            string body = viewRender.RenderToStringAsync("_ActiveEmail", user);
            SendEmail.Send(user.Email, "فعالسازی", body);


            #endregion
            return View("SuccessRegister", user);
        }


        #endregion

        #region login
        [Route("Login")]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [Route("Login")]
        public IActionResult Login(LoginViewModel login, string ReturnUrl = "/")
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }

            var user = _userService.LoginUser(login);
            if (user != null)
            {
                if (user.IsActive)
                {
                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.NameIdentifier,user.UserId.ToString()),
                        new Claim(ClaimTypes.Name,user.UserName)
                    };
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);

                    var properties = new AuthenticationProperties
                    {
                        IsPersistent = login.RememberMe
                    };
                    HttpContext.SignInAsync(principal, properties);

                    ViewBag.IsSuccess = true;
                    if (ReturnUrl != "/")
                    {
                        return Redirect(ReturnUrl);
                    }

                    return RedirectToAction("Index", "Home");

                }
                else
                {
                    ModelState.AddModelError("Email", "حساب کاربری شما فعال نمی باشد");
                }
            }
            ModelState.AddModelError("Email", "کاربری با مشخصات وارد شده یافت نشد");
            return View(login);
        }


        #endregion

        #region Active Account

        public IActionResult ActiveAccount(string id)
        {
            ViewBag.IsActive = _userService.ActiveAccount(id);
            return View();
        }

        #endregion
        #region Logout
        [Route("Logout")]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/Login");
        }

        #endregion

        #region Forgot Password
        [Route("ForgotPassword")]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [Route("ForgotPassword")]
        public ActionResult ForgotPassword(ForgotPasswordViewModel forgot)
        {
            if (!ModelState.IsValid)
                return View(forgot);

            string fixedEmail = FixedText.FixEmail(forgot.Email);
            DataLayer.Entities.User.User user = _userService.GetUserByEmail(fixedEmail);

            if (user == null)
            {
                ModelState.AddModelError("Email", "کاربری یافت نشد");
                return View(forgot);
            }

            string bodyEmail = viewRender.RenderToStringAsync("_ForgotPassword", user);
            SendEmail.Send(user.Email, "بازیابی حساب کاربری", bodyEmail);
            ViewBag.IsSuccess = true;

            return View();
        }
        #endregion


        #region Reset Password

        public ActionResult ResetPassword(string id)
        {
            return View(new ResetPasswordViewModel()
            {
                ActiveCode = id
            });
        }


        [HttpPost]
        public ActionResult ResetPassword(ResetPasswordViewModel reset)
        {
            if (!ModelState.IsValid)
                return View(reset);

            DataLayer.Entities.User.User user = _userService.GetUserByActiveCode(reset.ActiveCode);

            if (user == null)
                return NotFound();

            string hashNewPassword = PasswordHelper.EncodePasswordMd5(reset.Password);
            user.Password = hashNewPassword;
            _userService.UpdateUser(user);

            return Redirect("/Login");

        }
        #endregion
    }
}
