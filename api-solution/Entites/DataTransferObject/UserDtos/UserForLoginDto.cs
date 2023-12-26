using System.ComponentModel.DataAnnotations;

namespace Entites.DataTransferObject.UserDtos
{
    public class UserForLoginDto
    {
        [Required(ErrorMessage = "Name is required!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Password is required!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
