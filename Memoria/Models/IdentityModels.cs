using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Memoria.Models
{
    // Para agregar datos de perfil del usuario, agregue más propiedades a su clase ApplicationUser. Visite https://go.microsoft.com/fwlink/?LinkID=317594 para obtener más información.
    public class ApplicationUser : IdentityUser
    {
        [Required(ErrorMessage = " Nombre es requerido.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Nombre debe tener 3 caracteres minimo")]
        [DataType(DataType.Text)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = " Apellido es requerido.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Nombre debe tener 3 caracteres minimo")]
        [DataType(DataType.Text)]
        public string ApellidoPaterno { get; set; }

        [Required(ErrorMessage = " Apellido es requerido.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Nombre debe tener 3 caracteres minimo")]
        [DataType(DataType.Text)]
        public string ApellidoMaterno { get; set; }

        [Required(ErrorMessage = " fecha de realizacion es requerido")]
        [DisplayName("Fecha de Nacimiento")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Tenga en cuenta que el valor de authenticationType debe coincidir con el definido en CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            userIdentity.AddClaim(new Claim("Nombre",this.Nombre));
            userIdentity.AddClaim(new Claim("ApellidoPaterno", this.ApellidoPaterno));
            userIdentity.AddClaim(new Claim("ApellidoMaterno", this.ApellidoMaterno));
            // Agregar aquí notificaciones personalizadas de usuario
            return userIdentity;
        }
      //  public ApplicationUser() : base() { }
       // public ApplicationUser(string UserName) : base(UserName) { }

    }
   
    //agregado para activar los roles
    public class ApplicationRole: IdentityRole
    {
        public ApplicationRole() : base() { }
        public ApplicationRole(string roleName) : base(roleName) { }
    }

    public class ApplicationUserRole: IdentityUserRole
    {
        public ApplicationUserRole() : base() { }

    }
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<Memoria.Models.GameImage> GameImages { get; set; }

        public System.Data.Entity.DbSet<Memoria.Models.Evaluation> Evaluacions { get; set; }

        // public System.Data.Entity.DbSet<MemoryViewModels.Models.Memoria> Memorias { get; set; }



        // public System.Data.Entity.DbSet<Memoria.Models.RoleViewModel> RoleViewModels { get; set; }

        // public System.Data.Entity.DbSet<Memoria.Models.UserViewModel> UserViewModels { get; set; }

        //  public System.Data.Entity.DbSet<Memoria.Models.RoleViewModel> RoleViewModels { get; set; }
    }
}