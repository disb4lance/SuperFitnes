using System.ComponentModel.DataAnnotations;

namespace SuperFitnes.Features.DtoModels.User
{
    public class EditUser
    {
        public Guid IsnNode { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Password { get; set; }

    }
}
