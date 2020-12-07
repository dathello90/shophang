using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using shophang.Models;

namespace shophang.Areas.AdminCP.Controllers
{
    [Area(nameof(AdminCP))]
    public class DashboardController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        public DashboardController(SignInManager<User> _signInManager,
           UserManager<User> _userManager) //Dependence Injection <-- Startup 
        {
            this._signInManager = _signInManager;
            this._userManager = _userManager;

        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
    }
}
