using System.ComponentModel.DataAnnotations;

namespace BestLibrary.Models
{
    /// <summary>
    /// Models returned by actions AccountController.
    /// </summary>
    public class LoginModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}