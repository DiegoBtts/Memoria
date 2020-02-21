
using System.Collections.Generic;
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
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Role
        [Authorize(Roles = "Administrador")]
        public ActionResult Index()
        {
            
            List<UserViewModel> list = new List<UserViewModel>();
            
            foreach (var user in UserManager.Users)
            {
                if (!User.IsInRole("Administrador")&& User.IsInRole("Maestro"))
                {
                    
                    list.Add(new UserViewModel(user));

                }


            }


            return View(list);
        }
        [Authorize(Roles = "Administrador")]
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
        [HttpPost]
        public async Task<ActionResult> Create(UserViewModel model)
        {
            var user = new ApplicationUser() { Nombre = model.Nombre, ApellidoPaterno = model.ApellidoPaterno, ApellidoMaterno = model.ApellidoMaterno, UserName = model.UserName, Email = model.Email, FechaNacimiento = model.FechaNacimiento };
            var result = await UserManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                
                result = await UserManager.AddToRoleAsync(user.Id, model.RoleName);
                return RedirectToAction("Index");
            }
            else
            {
                AddErrors(result);
                return View(model);
            }

        }
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult> Edit(string id)
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

            var user = await UserManager.FindByIdAsync(id);
            return View(new UserViewModel(user));
        }

        [HttpPost]
        public async Task<ActionResult> Edit(UserViewModel model)
        {
            var user = new ApplicationUser() { Nombre = model.Nombre, ApellidoPaterno = model.ApellidoPaterno, ApellidoMaterno = model.ApellidoMaterno, UserName = model.UserName, Email = model.Email, FechaNacimiento = model.FechaNacimiento };
            var result = await UserManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                await UserManager.AddToRoleAsync(user.Id, model.RoleName);
                return RedirectToAction("Index");

            }
            {
                AddErrors(result);
                return View(model);
            }

        }
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult> Details(string id)
        {
            var user = await UserManager.FindByIdAsync(id);
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
            var user = new ApplicationUser() { Id = model.Id, Nombre = model.Nombre, ApellidoPaterno = model.ApellidoPaterno, ApellidoMaterno = model.ApellidoMaterno };
            var users = await UserManager.FindByIdAsync(user.Id);
            await UserManager.DeleteAsync(users);
            return RedirectToAction("Index");
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

    }
}