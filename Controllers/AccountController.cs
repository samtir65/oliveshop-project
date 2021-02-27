using OliveShop.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;

namespace Account.Controllers
{

    public class AccountController : Controller
    {
        private IUserRepositori _userRepositori;
        public AccountController(IUserRepositori userRepositori)
        {
            _userRepositori=userRepositori;
            
        }
    #region register
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        
        public IActionResult Register(RegistrerViewModel register)
        {
            if(!ModelState.IsValid)
            {
                return View(register);

            }
            if(_userRepositori.ISExistEmail(register.Email.ToLower()))
            {
                ModelState.AddModelError("Email","کاربری قبلا در سایت ثبت نام کرده است");
                return View(register);


            }
            User user=new User()
            {
                Email=register.Email.ToLower(),
                IsAdmin=false,
                Password=register.password,
                RegisterDate=DateTime.Now
                

            };
            _userRepositori.AddUser(user);

            return View("Success",register);
            
        

    }
    #endregion

        
    public IActionResult login()
    {
        return View();
    }
    [HttpPost]
    public IActionResult login(LoginviewModel login)
    {
        if(!ModelState.IsValid)
        {
            return View(login);
        }
            // var user=_userRepositori.loinforuser(login.Email,login.Password);
            var user = _userRepositori.loginforuser(login.Email.ToLower(), login.Password);
        if(user==null)
        {
            ModelState.AddModelError("Email","اطلاعات صحیح نیست");
            return View(login);

        }
         var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Userid.ToString()),
                new Claim(ClaimTypes.Name, user.Email),
               // new Claim("CodeMeli", user.Email),

            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var principal = new ClaimsPrincipal(identity);

            var properties = new AuthenticationProperties
            {
                IsPersistent = login.Remember
            };

             HttpContext.SignInAsync(principal, properties);

            return Redirect("/");
        }

     public IActionResult Logout()
    {
        HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/Account/Login");
    }
       

    }

   


}

