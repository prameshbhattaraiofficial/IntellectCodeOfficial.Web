using System.ComponentModel.DataAnnotations;

namespace IntellectCodeofficial.API.Models.Sign_Up
{
    public class RegisterUser
    {
        [Required(ErrorMessage ="Username is Required")]
        public string? Username  { get; set; }

        [Required(ErrorMessage ="Email is Required")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Password is required")]
        public string  Password { get; set; }
    }
}
