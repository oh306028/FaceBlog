using System.ComponentModel.DataAnnotations;

namespace App.ViewModels
{
    public class RegisterViewModel
    {

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Passwords have to be equal")]
        public string ConfirmPassword { get; set; }


        [Required]
        public DateTime DateOfbirth { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Country { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Street { get; set; }  

    }
}
