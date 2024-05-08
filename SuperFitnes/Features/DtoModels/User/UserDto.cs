using Classes.models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SuperFitnes.Features.DtoModels.User
{
    public sealed record UserDto
    {
        [Key]
        public Guid IsnNode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
