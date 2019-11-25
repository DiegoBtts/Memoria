using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Memoria.Models
{
    public class UserViewModel
    {

        public UserViewModel() { }
        public UserViewModel(ApplicationUser user)
        {
            Id = user.Id;
            UserName = user.UserName;
            Nombre = user.Nombre;
            ApellidoPaterno = user.ApellidoPaterno;
            ApellidoMaterno = user.ApellidoMaterno;
            Email = user.Email;
            FechaNacimiento = user.FechaNacimiento;
            Edad = DateTime.Today.Year - user.FechaNacimiento.Year;
            RoleName = new RoleViewModel().Name;

            

        //    Role = new ApplicationUserManager(user.Roles);
    
            
        }
        public string Id { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre debe de contener minimo 3 caracteres.")]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Apellido Paterno")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El apellido paterno debe de contener minimo 3 caracteres.")]
        public string ApellidoPaterno { get; set; }

        [Required]
        [Display(Name = "Apellido Materno")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El apellido materno debe de contener minimo 3 caracteres.")]
        public string ApellidoMaterno { get; set; }

        [Required(ErrorMessage = " fecha de nacimiento es requerido")]
        [DisplayName("Fecha de Nacimiento")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }

        [Required]
        [Display(Name = "Nombre de Usuario")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre de usuario debe de contener minimo 3 caracteres.")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Correo electrónico")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar contraseña")]
        [Compare("Password", ErrorMessage = "La contraseña y la contraseña de confirmación no coinciden.")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Tipo de Usuario")]
        public string RoleName { get; set; }

        [NotMapped]
        [Range(0,99,ErrorMessage ="La edad esta entre 0 años a 99")]
        public int Edad { get; set; }
    }
}