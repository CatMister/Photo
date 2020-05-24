using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using HuxingModel.User;
using HuxingService.Login;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HuxingMvc.Contorller
{

    [Authorize]
    public class LoginController : MainController
    {

        private ILoginService loginService { get; set; }

        public LoginController(ILoginService _loginService)
        {
            loginService = _loginService;
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }


        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult Login(UserModel input)
        {
            var userId = loginService.Login(input);
            var claims = new[] { new Claim("UserId", userId.ToString()) };
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            ClaimsPrincipal user = new ClaimsPrincipal(claimsIdentity);
            Task.Run(async () =>
            {
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, user, new AuthenticationProperties()
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(60),
                    AllowRefresh = true
                });
            }).Wait();

            return Redirect("/Community/Selfintroduce");
        }

        /// <summary>
        /// 注销
        /// </summary>
        /// <returns></returns>
        public ActionResult SignInAsync()
        {
            Task.Run(async () =>
            {
                await HttpContext.SignOutAsync();

            });
            return Redirect("/Login");
        }


        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult Registered(UserModel input)
        {
            loginService.AddUser(input);
            return View("Index");
        }


        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="input"></param>
        public IActionResult UpdateUser(UserModel input)
        {
            input.Id = UserId;
            loginService.UpdateUser(input);
            return Redirect("/Community/Selfintroduce");

        }

        public ActionResult GetUserDetail()
        {
            return Json(loginService.GetUser(UserId));
        }


    }

}