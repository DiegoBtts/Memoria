using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Memoria.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace Memoria.Controllers
{
    public class UserController : Controller
    {
        private ApplicationUserManager _userManager;
        private ApplicationRoleManager _roleManager;
        private ApplicationSignInManager _signInManager;

        public UserController()
        {
        }

        public UserController(ApplicationUserManager userManager, ApplicationSignInManager signInManager, ApplicationRoleManager roleManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            RoleManager = roleManager;
        }


        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        public ApplicationRoleManager RoleManager
        {
            get
            {
                return _roleManager ?? HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
            }
            private set
            {
                _roleManager = value;
            }
        }
        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }
        //private ApplicationDbContext db = new ApplicationDbContext();
        //[Authorize(Roles = "Administrador")]
        public ActionResult Index()
        {
            List<UserViewModel> list = new List<UserViewModel>();
            foreach (var user in UserManager.Users)
            {
                if(user.UserName != "YanitzaMungarro")
                {
                    list.Add(new UserViewModel(user));
                }
  

            }
            return View(list);
        }
        [AllowAnonymous]
        //  [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var role in RoleManager.Roles)
            {

                if (role.Name != "Administrador")
                {
                    list.Add(new SelectListItem() { Value = role.Name, Text = role.Name });
                }

            }

            ViewBag.Roles = list;
            return View();
        }

        //
        // POST: /User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { Nombre = model.Nombre, ApellidoPaterno = model.ApellidoPaterno, ApellidoMaterno = model.ApellidoMaterno, UserName = model.UserName, Email = model.Email };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    result = await UserManager.AddToRoleAsync(user.Id, model.RoleName);
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                    return RedirectToAction("User Admin", "Index");
                }
                AddErrors(result);
            }

            // Si llegamos a este punto, es que se ha producido un error y volvemos a mostrar el formulario
            return View(model);
        }

        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult> Edit(string id)
        {
            var user = await UserManager.FindByIdAsync(id);
            return View(new UserViewModel(user));
        }

        [HttpPost]
        public async Task<ActionResult> Edit(UserViewModel model)
        {
            var user = new ApplicationUser() { Id = model.Id, UserName=model.UserName, Nombre = model.Nombre, ApellidoPaterno = model.ApellidoPaterno, ApellidoMaterno=model.ApellidoMaterno, Email = model.Email, FechaNacimiento = model.FechaNacimiento };
            await UserManager.AddToRoleAsync(user.Id, model.RoleName);
            await UserManager.UpdateAsync(user);
            return RedirectToAction("Index");
        }
       [Authorize(Roles = "Administrador")]
        public async Task<ActionResult> Details(string id)
        {
            var user= await UserManager.FindByIdAsync(id);
            return View(new UserViewModel(user));
        }



       [Authorize(Roles = "Administrador")]
        public async Task<ActionResult> Delete(string id)
        {
            var user = await UserManager.FindByIdAsync(id);
            return View(new UserViewModel(user));
        }

        [HttpPost]
        public async Task<ActionResult> Delete(UserViewModel model)
        {
            var user = new ApplicationUser() { Id = model.Id, UserName = model.UserName, Nombre = model.Nombre, ApellidoPaterno = model.ApellidoPaterno, ApellidoMaterno = model.ApellidoMaterno, Email = model.Email, FechaNacimiento = model.FechaNacimiento };
            var users = await UserManager.FindByIdAsync(user.Id);
            await UserManager.DeleteAsync(users);
            return RedirectToAction("Index");

        }

        //asistente
        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
    }
}
