using System.ComponentModel.DataAnnotations;
namespace Donate4Life.Models
{
    public class LoginUser
    {
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Имейлът не е валиден")]
        [Required(ErrorMessage = "Имейлът е задължително поле.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Паролата е задължително поле.")]
        public string Password { get; set; }
    }
}