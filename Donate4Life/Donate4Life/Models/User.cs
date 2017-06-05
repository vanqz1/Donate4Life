using System.ComponentModel.DataAnnotations;

namespace Donate4Life.Models
{
    public class User
    {
        [Required(ErrorMessage = "Потребителското име е задължително поле.")]
        public string Username { get; set; }

        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Имейлът не е валиден")]
        [Required(ErrorMessage = "Имейлът е задължително поле.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Паролата е задължително поле.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Потвърждаването на паролата е задължително поле.")]
        public string ConfirmPassword { get; set; }

        public int Id { get; set; }
    }
}