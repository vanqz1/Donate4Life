namespace Donate4Life.Models
{
    public class EditProfile
    {
        public string Email { get; set; }
        public string NewEmail { get; set; }
        public string Password { get; set; }
        public string NewPassword { get; set; }
        public int UserId { get; set; }
    }
}