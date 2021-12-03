using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BancaBasica.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(String RolUsuario)
        {
            ViewBag.Rol = RolUsuario;
            HttpContext.Session.SetString("logged_rol", RolUsuario);
            //return View();
            return Redirect("~/Home/");
        }
    }
}
