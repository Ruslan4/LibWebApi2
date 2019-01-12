using System.ComponentModel.DataAnnotations;

namespace BestLibrary.Models
{
    /// <summary>
    /// Models returned by actions AccountController.
    /// </summary>
    public class RegisterModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Name { get; set; }
    }
}