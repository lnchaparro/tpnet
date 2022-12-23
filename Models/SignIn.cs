using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CRUD1.Models
{
    public class SignIn
    {
        [Required]
        [Display(Name = "Usuario")]
        public string UserName { get; set; }
        [Required]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }
        [Required]
        [Display(Name = "Recordarme")]
        public bool RememberMe { get; set; }
    }
}
