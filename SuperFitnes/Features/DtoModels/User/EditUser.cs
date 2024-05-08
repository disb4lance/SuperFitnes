using System.ComponentModel.DataAnnotations;

namespace SuperFitnes.Features.DtoModels.User
{
    public sealed record EditUser
    {
        [Key]
        public Guid IsnNode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
