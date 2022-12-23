using System.ComponentModel.DataAnnotations;

namespace CRUD1.Models
{
    public class Register
    {
        [Required]
        [Display(Name = "Usuario")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        [Display(Name = "Confirmar Contraseña")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Nombre Completo")]
        public string FullName { get; set; }

        [Required]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime BirthDate { get; set; }

    }
}
